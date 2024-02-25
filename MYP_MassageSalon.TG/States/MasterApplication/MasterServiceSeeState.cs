using MYP_MassageSalon.BLL;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.TG.States.MasterApplication;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG.States.AdminApplication;

public class MasterServiceSeeState : AbstractState
{
  private List<ServiceOutputModel> _servicesTG;

  public MasterServiceSeeState()
  {
    _servicesTG = new ServiceClient().GetAllServicesNameMap();
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

    for (var i = 0; i < _servicesTG.Count; i++)
    {
      keys.Add(new List<InlineKeyboardButton>());
      {
        keys[keys.Count - 1].Add(new InlineKeyboardButton($"Делаю {_servicesTG[i].Name}, {_servicesTG[i].Time}")
        { CallbackData = _servicesTG[i].Id.ToString() });
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

    SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Услуги:", replyMarkup: markup);
  }
}
