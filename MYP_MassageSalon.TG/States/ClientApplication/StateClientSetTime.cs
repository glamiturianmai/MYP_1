using MYP_MassageSalon.BLL.Models.OutputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClientSetTime : AbstractState
    {
        private int _serviceId;
        private int _workerId;
        private int _serviceDuration;

        private List<IntervalsOutputModel> _timeTG;

        public StateClientSetTime(int serviceId, int workerId, int serviceDuration, List<IntervalsOutputModel> timeTG)
        {
            _serviceId = serviceId;
            _workerId = workerId;
            _serviceDuration = serviceDuration;
            _timeTG = timeTG;
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            return this;
        }

        public override void SendMessage(long chatId)
        {
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();

            int count = 0;
            foreach (var t in _timeTG)
            {
                if (count % 4 == 0) keys.Add(new List<InlineKeyboardButton>());
                keys[keys.Count - 1].Add(new InlineKeyboardButton(t.Date.ToString("t"))
                { CallbackData = t.Id.ToString() }
                );
                count++;
            }
            keys.Add(new List<InlineKeyboardButton>()
            {
                new InlineKeyboardButton("Вернуться к выбору услуги ->") { CallbackData = "/back"}
            });

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Выберите время", replyMarkup: markup);
        }
    }
}
