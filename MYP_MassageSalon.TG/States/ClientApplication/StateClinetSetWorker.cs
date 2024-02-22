using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.BLL;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClinetSetWorker : AbstractState
    {
        private List<WorkersOutputModel> _workersTG;
        private int _workerId;
        public StateClinetSetWorker(int serviceId)
        {
            _workerId = serviceId;
            _workersTG = new WorkerClient().GetWorkersByServiceIdMap(serviceId);
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            return this;
        }

        public override void SendMessage(long chatId)
        {
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();

            int count = 0;
            foreach (var s in _workersTG)
            {
                keys.Add(new List<InlineKeyboardButton>());
                keys[keys.Count - 1].Add(new InlineKeyboardButton($"{s.Name}, {s.QualificationName[0].QualificationName}") 
                    { CallbackData = s.Name.ToString() }); // колбек айди поменять
                count++;
            }

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Выберите мастера", replyMarkup: markup);
        }
    }
}
