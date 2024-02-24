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
    public class AdminServiceChooseState : AbstractState
    {

        private int _servId;

        public AdminServiceChooseState(int servid)
        {
            _servId = servid;

        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {

                int workId = _servId;
                var message = update.CallbackQuery.Data;

                if (message == "delete")
                {

                    return new AdminServiceDeleteAskState(workId);
                }
                else if (message == "back")
                {
                    return new AdminServiceSeeState();
                }
                else if (message == "home")
                {
                    return new AdminStartState();
                }
                else
                {
                    return this;
                }

            }
            else
            {
                return this;
            }
        }

        public override void SendMessage(long chatId)
        {

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                    new InlineKeyboardButton[][]
                    {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Удалить") {CallbackData="delete"}

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
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Что же вы хотите сделать?", replyMarkup: markup);
        }
    }
}
