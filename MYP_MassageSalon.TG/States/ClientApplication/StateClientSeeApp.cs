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

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClientSeeApp : AbstractState
    {
        private List<AppointmentsOutputModel> _appTG;
        private int _clientId;
        public StateClientSeeApp(int clientId)
        {
            _clientId = clientId;
            _appTG = new AppointmentClient().GetClientsAppointmentsMap(clientId);
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                int appId = Int32.Parse(update.CallbackQuery.Data);
                return new StateClientDoWithApp(appId);
                
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();

            int count = 0;
            foreach (var s in _appTG)
            {
                keys.Add(new List<InlineKeyboardButton>());
               keys[keys.Count - 1].Add(new InlineKeyboardButton($"{s.WorksApp[0].WorkerName}, {s.WorksApp[0].ServiceName}, {s.WorksApp[0].Date}, {s.WorksApp[0].Price}")
               { CallbackData = s.Id.ToString() });
                count++;
            }

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Выберите заявку", replyMarkup: markup);
        }
    }
}
