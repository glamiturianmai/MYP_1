using MYP_MassageSalon.TG.States.ClientApplication;
using MYP_MassageSalon.TG.TypaBLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG.States
{
    public class StartState : AbstractState
    {
        private TypaData _clients;

        public StartState() { 
            _clients = new TypaData();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.Message)
            { 
                //TODO: добавить проверку на наличие клиента в базе
                _clients.AddClient(update.Message.Chat.Id, update.Message.Text);
                return this;
            }
            else if (update.Type == UpdateType.CallbackQuery)
            {
                var message = update.CallbackQuery.Data;
                //int clientId = Int32.Parse(update.CallbackQuery.Data); ; КОСТЫЛЬ ААААААААААААААААААА
                int clientId = 2;
                if (message == "SeeApps")
                {
                    return new StateClientSeeApp(clientId);
                } else if (message == "SetApp")
                {
                    return new StateClientSetService();
                }
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            Dictionary<long, string> clients = _clients.GetAllClients(); //костыль

            if (clients.ContainsKey(chatId))
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
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Здравствуйте, {clients[chatId]}!", replyMarkup: markup);
            }
            else SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, "Здравствуйте! Как я могу к вам обращаться?");
        }
    }
}
