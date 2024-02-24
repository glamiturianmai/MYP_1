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
    public class AdminServiceDeleteState : AbstractState
    {
        private int _servId;
        private ServiceClient _servClient;
        private DeleteServiceInputModel _servTG;


        public AdminServiceDeleteState(int servId)
        {
            _servId = servId;
            _servClient = new ServiceClient();
            _servTG = new DeleteServiceInputModel();
            _servTG.Id = servId;
        }



        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                return new AdminServiceSeeState();
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {

            _servClient.DeleteServiceMap(_servTG);


            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                   new InlineKeyboardButton[][]
                   {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Спасибо!") {CallbackData="SeeApps"}

                        }
                   }
                   );

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Эта заявка удалена!", replyMarkup: markup);
        }
    }
}
