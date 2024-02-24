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
    public class AdminServiceSeeState : AbstractState //вывод всех услуг
    {
        private List<ServiceAdminOutputModel> _servTG;
        public AdminServiceSeeState()
        {
            _servTG = new ServiceClient().GetAllServicesMap();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                int workId = Int32.Parse(update.CallbackQuery.Data);
                return new AdminServiceChooseState(workId);
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();

            for (var i = 0; i < _servTG.Count; i++)
            {
                keys.Add(new List<InlineKeyboardButton>());
                {
                    keys[keys.Count - 1].Add(new InlineKeyboardButton($" Мастер {_servTG[i].Name}, {_servTG[i].Price} руб., {_servTG[i].Time} минут")
                    { CallbackData = _servTG[i].Id.ToString() });
                }

            }

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Выберите услугу (Название, цена, продолжительность):", replyMarkup: markup);
        }
    }
}
