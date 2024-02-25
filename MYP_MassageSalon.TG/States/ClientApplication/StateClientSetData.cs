using MYP_MassageSalon.BLL;
using MYP_MassageSalon.BLL.Models.OutputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClientSetData : AbstractState
    {
        Appointment _app;

        private Dictionary<string, List<IntervalsOutputModel>> _datesTG;

        public StateClientSetData(Appointment app)
        {
            _app = app;

            _datesTG = new WorkerClient().CheckOutIntervals(_app.ServiceDuration, _app.WorkerId);            
        }


        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                string m = update.CallbackQuery.Data;
                if (m == "/back")
                {
                    return new StateClinetSetWorker(_app);
                }
                else
                {
                    return new StateClientSetTime(_app, _datesTG[m]);
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
