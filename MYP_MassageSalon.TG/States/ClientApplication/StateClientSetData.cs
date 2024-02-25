using MYP_MassageSalon.BLL;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.DAL.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClientSetData : AbstractState
    {
        private int _serviceId;
        private int _workerId;
        private int _serviceDuration;

        private Dictionary<string, List<IntervalsOutputModel>> _datesTG;

        public StateClientSetData(int serviceID, int workerId, int serviceDuration)
        {
            _serviceId = serviceID;
            _workerId = workerId;
            _serviceDuration = serviceDuration;

            _datesTG = new WorkerClient().CheckOutIntervals(serviceDuration, _workerId);
        }


        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                if (update.CallbackQuery.Data == "/back")
                {
                    return new StateClinetSetWorker(_serviceId, _serviceDuration);
                }
                else
                {
                    return this;
                }
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();

            int count = 0;
            foreach (var d in _datesTG)
            {
                if (count % 3 == 0) keys.Add(new List<InlineKeyboardButton>());
                keys[keys.Count - 1].Add(new InlineKeyboardButton($"{d.Key}")
                    { CallbackData = d.Key }
                );
                count++;
            }
            keys.Add(new List<InlineKeyboardButton>()
            {
                new InlineKeyboardButton("Вернуться к выбору мастера ->") { CallbackData = "/back"}
            });

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Выберите дату", replyMarkup: markup);
        }
    }
}
