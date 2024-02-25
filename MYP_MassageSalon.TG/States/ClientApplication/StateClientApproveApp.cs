using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClientApproveApp : AbstractState
    {
        private int _serviceId;
        private int _worker_id;
        private int _intervalId;
        private int _price;

        public StateClientApproveApp(int serviceId, int workerId, int intervalId, int price)
        {
            _intervalId = intervalId;
            _serviceId = serviceId;
            _worker_id = workerId;
            _price = price;
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            throw new NotImplementedException();
        }

        public override void SendMessage(long chatId)
        {
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new InlineKeyboardButton("Подтвердить") {CallbackData="ApproveApp"}

                    },
                    new InlineKeyboardButton[]
                    {
                        new InlineKeyboardButton("Отмена") {CallbackData="Discard"}
                    }
                }
                );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                chatId, 
                $"Подвтердите запись \n Мастер: \n Услуга: \n Дата и время: \n Стоимость: ", 
                replyMarkup: markup);
        }
    }
}
