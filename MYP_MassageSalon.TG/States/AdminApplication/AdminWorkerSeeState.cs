using MYP_MassageSalon.BLL;
using MYP_MassageSalon.BLL.Models.OutputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG.States.AdminApplication
{
    public class AdminWorkerSeeState : AbstractState
    {
        private List<WorkersAllOutputModel> _workTG;
        public AdminWorkerSeeState()
        {
            _workTG = new WorkerClient().GetAllWorkerMap();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                int workId = Int32.Parse(update.CallbackQuery.Data);
                return new AdminWorkerChooseState(workId);
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();

            for (var i = 0; i < _workTG.Count; i++)
            {
                keys.Add(new List<InlineKeyboardButton>());
                {
                    keys[keys.Count - 1].Add(new InlineKeyboardButton($" Мастер {_workTG[i].Name}, {_workTG[i].QualificationName[0].Qualification}, {_workTG[i].QualificationName[0].ProcentToPrice}%")
                    { CallbackData = _workTG[i].Id.ToString() });
                }

            }

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Выберите мастера (Имя мастера, квалификация, процент):", replyMarkup: markup);
        }
    }
}
