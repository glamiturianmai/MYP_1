using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG.States.AdminApplication
{
    public class AdminAddWorkerScheduleEnd : AbstractState
    {
        private int _workerId;

        public AdminAddWorkerScheduleEnd(int workerId)
        {
            _workerId = workerId;
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var message = update.CallbackQuery.Data;

                if (message == "SetWorker")
                {
                    return new AdminSetSheduleState();
                }
                else if (message == "SetDate")
                {
                    return new AdminAddWorkerSchedule(_workerId);
                }
                else if (message == "/admin")
                {
                    return new AdminStartState();
                }
                else return this;
            }
            else return this;
        }

        public override void SendMessage(long chatId)
        {
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new InlineKeyboardButton("Выбрать другого сотрудника") {CallbackData="SetWorker"}
                    },
                    new InlineKeyboardButton[]
                    {
                        new InlineKeyboardButton("Добавить ещё дату") {CallbackData="SetDate"}
                    },
                    new InlineKeyboardButton[]
                    {
                        new InlineKeyboardButton("В меню админа") {CallbackData="/admin"}
                    }
                }
                );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId,
                $"Расписание добавлено!", replyMarkup: markup);
        }
    }
}
