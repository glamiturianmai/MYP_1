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
        private int _serviceId;
        private int _serviceDuration;

        public StateClinetSetWorker(int serviceId, int serviceDuration)
        {
            _serviceId = serviceId;
            _serviceDuration = serviceDuration;

            _workersTG = new WorkerClient().GetWorkersByServiceIdMap(serviceId);
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            
            if (update.Type == UpdateType.CallbackQuery)
            {
                if (update.CallbackQuery.Data == "/back")
                {
                    return new StateClientSetService();
                }
                else
                {
                    int workerId = Int32.Parse(update.CallbackQuery.Data);
                    return new StateClientSetData(_serviceId, workerId, _serviceDuration);
                }
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();

            int count = 0;
            foreach (var w in _workersTG)
            {
                keys.Add(new List<InlineKeyboardButton>());
                Console.WriteLine(keys.Count - 1);
                keys[keys.Count - 1].Add(new InlineKeyboardButton($"{w.Name}, {w.WorkServ[0].QualificationName}, {w.WorkServ[0].Price} рублей") 
                    { CallbackData = w.Id.ToString() }
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
