using MYP_MassageSalon.BLL;
using MYP_MassageSalon.BLL.Models.InputModels;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClientApproveApp : AbstractState
    {
        Appointment _app;

        private string _workerName;
        private string _serviceName;
        private string _intervalDate;

        public StateClientApproveApp(Appointment app)
        {
            _app = app;

            InitNames();
        }

        private void InitNames()
        {
            AppointmentClient ap = new AppointmentClient();
            IntervalIdInputModel im = new IntervalIdInputModel { Id = _app.IntervalId };
            _intervalDate = ap.GetIntervalDateByIdMap(im)[0].Date.ToString("g");

            ServiceClient sc = new ServiceClient();
            ServiceIdInputModel sm = new ServiceIdInputModel { Id = _app.ServiceId };
            _serviceName = sc.GetServiceNameByIdMap(sm)[0].Name;

            WorkerClient wc = new WorkerClient();
            WorkerIdInputModel wm = new WorkerIdInputModel { Id = _app.WorkerId };
            _workerName = wc.GetWorkerNameByIdMap(wm)[0].Name;
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                string m = update.CallbackQuery.Data;
                if (m == "Discard")
                {
                    return new StartState();
                }
                else if (m == "ApproveApp")
                {
                    return new StateClientAppDone(_app);
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
                $"Подвтердите запись \n Мастер: {_workerName}\n Услуга: {_serviceName} \n Дата и время: {_intervalDate}\n Стоимость: {_app.Price}", 
                replyMarkup: markup);
        }
    }
}
