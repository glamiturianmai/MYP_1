using MYP_MassageSalon.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClientAppDone : AbstractState
    {
        Appointment _app;
        AppointmentClient ac;

        public StateClientAppDone(Appointment app) 
        {
            _app = app;
            ac = new AppointmentClient();

            SetApp();
        }

        private void SetApp()
        {
            ac.SetAppointment(_app.ClientId, _app.ServiceId, _app.WorkerId, _app.ServiceDuration,
                _app.IntervalId, _app.Price);
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var message = update.CallbackQuery.Data;
                if (message == "SeeApps")
                {
                    return new StateClientSeeApp(_app.ClientId);
                }
                else if (message == "SetApp")
                {
                    return new StateClientSetService(_app.ClientId);
                }
            }
            return new StartState();
        }

        public override void SendMessage(long chatId)
        {
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                new InlineKeyboardButton[][]
                {
                    new InlineKeyboardButton[]
                    {
                        new InlineKeyboardButton("Посмотреть свои записи") {CallbackData="SeeApps"}

                    },
                    new InlineKeyboardButton[]
                    {
                        new InlineKeyboardButton("Записаться") {CallbackData="SetApp"}
                    }
                    }
                );

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(
                chatId,
                $"Ваша запись оформлена!",
                replyMarkup: markup);
        }
    }
}
