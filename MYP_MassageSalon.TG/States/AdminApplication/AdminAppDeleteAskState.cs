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
    public class AdminAppDeleteAskState : AbstractState
    {
        private int _appId;
        public AdminAppDeleteAskState(int id)
        {
            _appId = id;

        }



        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {

                int appId = _appId;
                var message = update.CallbackQuery.Data;

                if (message == "ok")
                {
                    return new AdminAppDeleteState(appId);
                }
                else if (message == "back")
                {
                    return new AdminAppChooseState(appId);
                }
                else if (message == "home")
                {
                    return new AdminStartState();
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
                            new InlineKeyboardButton("Да, хочу удадить") {CallbackData="ok"}

                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("назад!") {CallbackData="back"}
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("домой!") {CallbackData="home"}
                        }
                    }
                    );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"А вы уверены?", replyMarkup: markup);
        }
    }
}
