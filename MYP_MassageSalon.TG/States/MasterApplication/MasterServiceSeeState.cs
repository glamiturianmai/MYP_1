using MYP_MassageSalon.BLL;
using MYP_MassageSalon.BLL.Models.OutputModels;
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
    return this;
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

    InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

    SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Всё:", replyMarkup: markup);
  }
}
