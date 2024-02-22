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

        
        public StateClientEditApp(int appId)
        {
            _appId = appId;
            _appClient = new AppointmentClient();
            _appTG = new DeleteAppIntputModel();
            _appTG.Id = appId;
        }



        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                return new StateClientSetService();
            }
            return this; 
        }

        public override void SendMessage(long chatId)
        {
            _appClient.DeleteAppointmentMap(_appTG);
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Давате изменим вашу заявку!");//ВОТ ТУТ НУЖНА КНОПКА
        }
    }
}
