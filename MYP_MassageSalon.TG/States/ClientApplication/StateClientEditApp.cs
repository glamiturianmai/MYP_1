using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.BLL;
using MYP_MassageSalon.BLL.Models.InputModels;

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClientEditApp : AbstractState
    {
        private int _appId;
        private AppointmentClient _appClient;
        private DeleteAppIntputModel _appTG;
        private int _clientId;

        
        public StateClientEditApp(int appId, int clientId)
        {
            _appId = appId;
            _appClient = new AppointmentClient();
            _appTG = new DeleteAppIntputModel();
            _appTG.Id = appId;
            _clientId = clientId;
        }



        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                return new StateClientSetService(_clientId);
            }
            return this; 
        }

        public override void SendMessage(long chatId)
        {

            _appClient.DeleteAppointmentMap(_appTG); // не работает 


            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                   new InlineKeyboardButton[][]
                   {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Давайте") {CallbackData="SeeApps"}

                        }
                   }
                   );
            
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Давате изменим вашу заявку!", replyMarkup: markup);
        }
    }
}
