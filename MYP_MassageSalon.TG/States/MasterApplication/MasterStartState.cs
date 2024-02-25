using MYP_MassageSalon.TG.States.AdminApplication;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG.States.MasterApplication;

public class MasterStartState : AbstractState
{
  public override AbstractState ReceiveMessage(Update update)
  {
    if (update.Type == UpdateType.CallbackQuery)
    {
      var message = update.CallbackQuery.Data;

      if (message == "services")
      {
        return new MasterServiceSeeState();
      }
      else if (message == "appointments")
      {
        return new MasterAppointmentSeeState();
      }
      else
      {
        return this;
      }
    }
    else return this;
  }

  public override void SendMessage(long chatId)
  {
    InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
        new InlineKeyboardButton[][]
        {
          new InlineKeyboardButton[]
          {
            new InlineKeyboardButton("Мои Услуги") {CallbackData="services"}
          },
          new InlineKeyboardButton[]
          {
            new InlineKeyboardButton("Мои записи") {CallbackData="appointments"}
          }
        }
        );
    SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Здравствуйте, мастер!", replyMarkup: markup);
  }
}
