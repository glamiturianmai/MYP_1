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
    public class AdminSeeClientState : AbstractState //вывод всех услуг
    {
        private List<ClientOutputModel> _clientTG;
        public AdminSeeClientState()
        {
            _clientTG = new ClientClient().GetAllClientsMap();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            f(update.Type == UpdateType.CallbackQuery)
            {
                string m = update.CallbackQuery.Data;
                if (m == "/back")
                {
                    return new StartState();
                }
                else
                {
                    int workId = Int32.Parse(update.CallbackQuery.Data);
                    return new AdminStartState();
                }
            }
            return this;
            
        }

        public override void SendMessage(long chatId)
        {
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();

            for (var i = 0; i < _clientTG.Count; i++)
            {
                keys.Add(new List<InlineKeyboardButton>());
                {
                    keys[keys.Count - 1].Add(new InlineKeyboardButton($" Клиент {_clientTG[i].Username}, {_clientTG[i].IPInf}")
                    { CallbackData = _clientTG[i].Id.ToString() });
                }

            }
            keys.Add(new List<InlineKeyboardButton>()
            {
                new InlineKeyboardButton("Вернуться в главное меню ->") { CallbackData = "/back"}
            });

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Это все клиенты нашего салона:", replyMarkup: markup);
        }
    }
}
