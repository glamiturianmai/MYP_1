using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using MYP_MassageSalon.TG.States.ClientApplication;

namespace MYP_MassageSalon.TG.States.AdminApplication
{
    public class AdminAppSeeState : AbstractState //вывод всех услуг
    {
        private List<ClientAppPrOutputModel> _appTG;
        public AdminAppSeeState()
        {
            _appTG = new List<ClientAppPrOutputModel>();
            _appTG = new AppointmentClient().GetPleaseApp();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                string m = update.CallbackQuery.Data;
                if (m == "/back")
                {
                    return new AdminStartState();
                }
                else
                {
                    int appId = Int32.Parse(update.CallbackQuery.Data);
                    return new AdminAppChooseState(appId);
                }
            }
            return this;
            
        }

        public override void SendMessage(long chatId)
        {
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();

            for (var i = 0; i < _appTG.Count; i++)
            {
                keys.Add(new List<InlineKeyboardButton>());
                if (i % 2 == 0)
                {
                    keys[keys.Count - 1].Add(new InlineKeyboardButton($"{_appTG[i].WorkerName}, {_appTG[i].ServiceName}, {_appTG[i].Date.DayOfYear}, {_appTG[i].Date.TimeOfDay}-{_appTG[i + 1].Date.AddMinutes(15).TimeOfDay}, {_appTG[i].Price} руб.")
                    { CallbackData = _appTG[i].AppId.ToString() });
                }
            }
            keys.Add(new List<InlineKeyboardButton>()
            {
                new InlineKeyboardButton("Вернуться в главное меню ->") { CallbackData = "/back"}
            });
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Выберите запись (Название, время):", replyMarkup: markup);
        }
    }
}
