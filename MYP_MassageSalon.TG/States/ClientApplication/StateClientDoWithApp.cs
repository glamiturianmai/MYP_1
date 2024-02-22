using MYP_MassageSalon.BLL.Models.OutputModels;
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

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClientDoWithApp : AbstractState
    {
        private List<AppointmentsOutputModel> _appTG;
        private int _appId;
        public StateClientDoWithApp(int id)
        {
            _appId =id;
            _appTG = new AppointmentClient().GetClientsAppointmentsMap(_appId);
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                //int appId = 2;
                int appId = _appId;
                var message = update.CallbackQuery.Data;
                
                if (message == "Cansel")
                {
                    return this;
                    //return new StateClientDeleteAskApp(clientId);
                }
                else if (message == "Edit")
                {
                    return new StateClientEditAskApp(appId);
                }
                else if (message == "back")
                {
                    return new StateClientDoWithApp(appId);
                }
                //return new StateClientDoWithApp(id);
                
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
                            new InlineKeyboardButton("Отменить") {CallbackData="Cancel"}

                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Изменить") {CallbackData="Edit"}
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("назад") {CallbackData="back"}
                        }
                    }
                    );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Что же вы хотите сделать?", replyMarkup: markup);
        }
    }
}
