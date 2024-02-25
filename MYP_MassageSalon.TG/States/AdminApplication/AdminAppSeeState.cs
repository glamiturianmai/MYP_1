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

namespace MYP_MassageSalon.TG.States.AdminApplication
{
    public class AdminAppSeeState : AbstractState //вывод всех услуг
    {
        private List<WorkersAppOutputModel> _appTG;
        public AdminAppSeeState()
        {
            _appTG = new List<WorkersAppOutputModel>();
            _appTG = new AppointmentClient().GetAllAppointmentsAdminMap();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                int appId = Int32.Parse(update.CallbackQuery.Data);
                return new AdminAppChooseState(appId);
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();

            for (var i = 0; i < _appTG.Count; i++)
            {
                keys.Add(new List<InlineKeyboardButton>());
                {
                    keys[keys.Count - 1].Add(new InlineKeyboardButton($" Клиент {_appTG[i].WorksApp[0].ServiceName}, {_appTG[i].WorksApp[0].Date}")
                    { CallbackData = _appTG[i].WorksApp[0].AppId.ToString() });
                }

            }

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Выберите запись (Название, время):", replyMarkup: markup);
        }
    }
}
