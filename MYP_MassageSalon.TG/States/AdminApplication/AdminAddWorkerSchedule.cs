using MYP_MassageSalon.BLL;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG.States.AdminApplication
{
    public class AdminAddWorkerSchedule : AbstractState
    {
        private int _workerId;
        private WorkerClient _wc;

        public AdminAddWorkerSchedule(int workerId)
        {
            _workerId = workerId;
            _wc = new WorkerClient();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.Message)
            {
                string message = update.Message.Text;
                _wc.SetSchedule(message, _workerId);
                return new AdminAddWorkerScheduleEnd(_workerId);
            }
            else if (update.Type == UpdateType.CallbackQuery)
            {
                string message = update.CallbackQuery.Data;
                if (message == "/admin")
                {
                    return new AdminStartState();
                }
                else if (message == "serWorker")
                {
                    return new AdminSetWorkerSchedule(_workerId);
                }
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                new InlineKeyboardButton[][]
                {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Вернуться к расписанию сотрудника") {CallbackData="serWorker"}

                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Вернуться в меню админа") {CallbackData="/admin"}
                        }
                }
                );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId,
                    "Введите дату в формате гггг-мм-дд:", replyMarkup: markup);
        }
    }
}
