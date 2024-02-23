using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MYP_MassageSalon.TG.States;
using MYP_MassageSalon.TG.States.ClientApplication;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot;

namespace MYP_MassageSalon.TG.States.AdminApplication
{
    public class AdminStartState : AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                //var message = update.CallbackQuery.Data;
                ////int clientId = Int32.Parse(update.CallbackQuery.Data); ; КОСТЫЛЬ ААААААААААААААААААА
                //int clientId = 2;
                //if (message == "SeeApps")
                //{
                //    return new StateClientSeeApp(clientId);
                //}
                //else if (message == "SetApp")
                //{
                //    return new StateClientSetService();
                //}
                return this;
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
                            new InlineKeyboardButton("Мастера") {CallbackData="workers"}

                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Услуги") {CallbackData="services"}
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Записи") {CallbackData="appointments"}
                        }
                }
                );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Здравствуйте администратор!", replyMarkup: markup);
        }

    }
}
