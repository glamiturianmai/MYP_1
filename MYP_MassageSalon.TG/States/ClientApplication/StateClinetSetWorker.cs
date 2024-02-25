using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.BLL;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;
using Telegram.Bot.Types.Enums;

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClinetSetWorker : AbstractState
    {
        private List<WorkersOutputModel> _workersTG;
        Appointment _app;

        public StateClinetSetWorker(Appointment app)
        {
            _app = app;

            _workersTG = new WorkerClient().GetWorkersByServiceIdMap(_app.ServiceId);
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            
            if (update.Type == UpdateType.CallbackQuery)
            {
                if (update.CallbackQuery.Data == "/back")
                {
                    return new StateClientSetService(_app.ClientId);
                }
                else
                {
                    int m = Int32.Parse(update.CallbackQuery.Data);
                    _app.WorkerId = _workersTG[m].Id;
                    _app.Price = _workersTG[m].WorkServ[0].Price;
                    return new StateClientSetData(_app);
                }
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();

            int count = 0;
            for (int i = 0; i < _workersTG.Count; i++)
            {
                var w = _workersTG[i];
                keys.Add(new List<InlineKeyboardButton>());
                keys[keys.Count - 1].Add(new InlineKeyboardButton(
                    $"{w.Name}, {w.WorkServ[0].QualificationName}, {w.WorkServ[0].Price} рублей"
                    ) 
                    { CallbackData = i.ToString() }
                ); 
                count++;
            }
            keys.Add(new List<InlineKeyboardButton>()
            {
                new InlineKeyboardButton("Вернуться к выбору услуги ->") { CallbackData = "/back"}
            });

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Выберите мастера", replyMarkup: markup);
        }
    }
}
