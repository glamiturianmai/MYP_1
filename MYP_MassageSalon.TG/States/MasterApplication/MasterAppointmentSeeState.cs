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
      return this;
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

      InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

      SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Рады были помочь, всегда на связи", replyMarkup: markup);
    }
  }
}
