using MYP_MassageSalon.BLL;
using MYP_MassageSalon.BLL.Models.OutputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG.States.MasterApplication
{
  public class MasterAppointmentSeeState : AbstractState
  {
    private List<AppointmentsMasterOutputModel> _appointmentsTG;
    public MasterAppointmentSeeState()
    {
      _appointmentsTG = new AppointmentClient().GetAllAppointmentsMasterMap();
    }

    public override AbstractState ReceiveMessage(Update update)
    { 
      var message = update.CallbackQuery.Data;

      if (message == "back")
      {
        return new MasterStartState();
      }
      else if (message == "home")
      {
        return new StartState();
      }
      else
      {
        return this;
      }
    }

    public override void SendMessage(long chatId)
    {
      List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();

      for (var i = 0; i < _appointmentsTG.Count; i++)
      {
        keys.Add(new List<InlineKeyboardButton>());
        {
          keys[keys.Count - 1].Add(new InlineKeyboardButton($"{_appointmentsTG[i].WorksApp[0].ServiceName}," +
            $"{_appointmentsTG[i].WorksApp[0].Date}," +
            $"{_appointmentsTG[i].WorksApp[0].Username}")
          { CallbackData = _appointmentsTG[i].Id.ToString() });
        }
      }
      
      keys.Add(new List<InlineKeyboardButton>());
      {
        keys[keys.Count - 1].Add(new InlineKeyboardButton("назад") { CallbackData = "back" });
      }
      keys.Add(new List<InlineKeyboardButton>());
      {
        keys[keys.Count - 1].Add(new InlineKeyboardButton("домой") { CallbackData = "home" });
      }

      InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

      SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Записи", replyMarkup: markup);
    }
  }
}
