using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClientDeleteAskApp : AbstractState
    {
        private int _appId;
        public StateClientDeleteAskApp(int id)
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
                    return new StateClientCancelApp(appId);
                }
                else if (message == "back")
                {
                    return new StateClientDoWithApp(appId);
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
                            new InlineKeyboardButton("Да, хочу отменить") {CallbackData="ok"}

                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("назад!") {CallbackData="back"}
                        }
                    }
                    );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"А вы уверены?", replyMarkup: markup);
        }
    }
}
