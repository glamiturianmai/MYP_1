using MYP_MassageSalon.BLL;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.TG.TypaBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClientSetService : AbstractState
    {
        private List<ServiceOutputModel> _servicesTG;
        
        public StateClientSetService()
        {
            _servicesTG = new ServiceClient().GetAllServicesNameMap();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                if (update.CallbackQuery.Data == "/back")
                {
                    return new StartState();
                } 
                else
                {
                    int serviceId = Int32.Parse(update.CallbackQuery.Data);
                    return new StateClinetSetWorker(_servicesTG[serviceId].Id, _servicesTG[serviceId].Time);
                }
                
            }
            return this;
        }
        
        public override void SendMessage(long chatId)
        {
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();

            int count = 0;
            for (int i = 0; i < _servicesTG.Count; i++)
            {
                var s = _servicesTG[i];
                keys.Add(new List<InlineKeyboardButton>());
                keys[keys.Count - 1].Add(new InlineKeyboardButton($"{s.Name}, {s.Time} минут") 
                    { CallbackData = i.ToString()}
                );
                count++;
            }
            keys.Add(new List<InlineKeyboardButton>()
            {
                new InlineKeyboardButton("Вернуться в главное меню ->") { CallbackData = "/back"}
            });

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                chatId, $"Выберите услугу", replyMarkup: markup
                );
        }
    }
}
