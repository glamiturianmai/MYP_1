using MYP_MassageSalon.BLL.Models.OutputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClientSetTime : AbstractState
    {
        Appointment _app;
        private List<IntervalsOutputModel> _timeTG;

        public StateClientSetTime(Appointment app, List<IntervalsOutputModel> timeTG)
        {
            _app = app;
            _timeTG = timeTG;
        }

        public override AbstractState ReceiveMessage(Update update)
        {

            if (update.Type == UpdateType.CallbackQuery)
            {
                string m = update.CallbackQuery.Data;
                if (m == "/back")
                {
                    return new StateClientSetData(_app);
                }
                else
                {
                    _app.IntervalId = Int32.Parse(m);
                    return new StateClientApproveApp(_app);
                }
            }
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
                new InlineKeyboardButton("Вернуться к выбору даты ->") { CallbackData = "/back"}
            });

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Выберите время", replyMarkup: markup);
        }
    }
}
