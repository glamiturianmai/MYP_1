using MYP_MassageSalon.BLL.Models.InputModels;
using MYP_MassageSalon.BLL;
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
    public class AdminAppDeleteState : AbstractState
    {
        private int _appId;
        private AppointmentClient _appClient;
        private DeleteAppIntputModel _appTG;


        public AdminAppDeleteState(int appId)
        {
            _appId = appId;
            _appClient = new AppointmentClient();
            _appTG = new DeleteAppIntputModel();
            _appTG.AppId = appId;
        }



        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                return new AdminAppDoState();
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {

            _appClient.DeleteAppointmentMap(_appTG);


            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                   new InlineKeyboardButton[][]
                   {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Спасибо!") {CallbackData="SeeApps"}

                        }
                   }
                   );

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Эта запись удалена!", replyMarkup: markup);
        }
    }
}
