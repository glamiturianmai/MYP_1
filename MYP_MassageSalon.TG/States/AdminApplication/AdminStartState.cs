﻿using System;
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
                var message = update.CallbackQuery.Data;

                if (message == "workers")
                {

                    return new AdminWorkerDoState();
                }
                else if (message == "services")
                {
                    return new AdminServiceDoState();
                }
                else if (message == "appointments")
                {
                    return new AdminAppDoState();
                }
                else if (message == "sheduleinterval")
                {
                    return new AdminSetSheduleState();
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
                            new InlineKeyboardButton("Мастера") {CallbackData="workers"}

                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Услуги") {CallbackData="services"}
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Записи") {CallbackData="appointments"}
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Редактировать расписание") {CallbackData="sheduleinterval"}
                        }
                }
                );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Здравствуйте, администратор!", replyMarkup: markup);
        }

    }
}
