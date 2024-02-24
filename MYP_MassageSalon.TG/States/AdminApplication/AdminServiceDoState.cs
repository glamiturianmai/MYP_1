using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace MYP_MassageSalon.TG.States.AdminApplication
{
    public class AdminServiceDoState: AbstractState
    {
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var message = update.CallbackQuery.Data;

                if (message == "see")
                {
                    return this;

                    //return new AdminWorkerSeeState();
                }
                else if (message == "add")
                {
                    return new AdminServiceAddNameState();
                }
                else if (message == "back")
                {
                    return new AdminStartState();
                }
                else if (message == "home")
                {
                    return new StartState();
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
                            new InlineKeyboardButton("Наши услуги") {CallbackData="see"}

                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Добавить") {CallbackData="add"}
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("назад!") {CallbackData="back"}
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("домой") {CallbackData="home"}
                        }
                }
                );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Что будем делать?", replyMarkup: markup);
        }
    }
}
