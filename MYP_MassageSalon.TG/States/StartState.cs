using MYP_MassageSalon.BLL;
using MYP_MassageSalon.BLL.Models.InputModels;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.TG.States.AdminApplication;
using MYP_MassageSalon.TG.States.ClientApplication;
using MYP_MassageSalon.TG.States.MasterApplication;
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
        private ClientClient _clients;
        private List<IpInfOutputModel> _clientId;
        private ClientInputModel _curClient;

        public StartState() { 
            _clients = new ClientClient();
            _curClient = new ClientInputModel();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.Message)
            {
                var message = update.Message.Text.ToString();
                if (message == "/admin")
                {
                    return new AdminStartState();
                }
                else if (message == "/master")
                {
                    return new MasterStartState();
                }
                else
                {
                    if(_clientId.Count == 0)
                    {
                        _curClient.Username = message;
                        _clients.AddClientMap(_curClient);
                    }
                    
                    return this;
                }
                
            }
            else if (update.Type == UpdateType.CallbackQuery)
            {
                var message = update.CallbackQuery.Data;
                if (message == "SeeApps")
                {
                    return new StateClientSeeApp(_clientId[0].Id);
                } else if (message == "SetApp")
                {
                    return new StateClientSetService();
                }
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            _clientId = _clients.GetClientIdByIpInfMap((int)chatId);

            if (_clientId.Count != 0)
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
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, 
                    $"Здравствуйте, {_clientId[0].Username}!", replyMarkup: markup);
            }
            else
            {
                _curClient.IpInf = (int)chatId;
                SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId,
                    "Здравствуйте! Как я могу к вам обращаться?");
            }
        }
    }
}
