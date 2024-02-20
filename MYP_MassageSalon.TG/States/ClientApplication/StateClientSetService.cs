using MYP_MassageSalon.TG.TypaBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClientSetService : AbstractState
    {
        private TypaData _services;
        
        public StateClientSetService()
        {
            _services = new TypaData();
        }

        public override AbstractState ReceiveMessage(Update update)
        {


            return this;
        }

        public override void SendMessage(long chatId)
        {
            Dictionary<int, string> services = _services.GetAllServices(); //костыль

            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();

            int count = 0;
            foreach (var s in services)
            {
                if (count % 3 == 0)
                {
                    keys.Add(new List<InlineKeyboardButton>());

                }
                keys[keys.Count - 1].Add(new InlineKeyboardButton(s.Value) { CallbackData = s.Key.ToString()});
                count++;
            }

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Выберите услугу", replyMarkup: markup);
        }
    }
}
