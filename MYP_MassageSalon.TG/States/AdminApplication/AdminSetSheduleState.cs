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

namespace MYP_MassageSalon.TG.States.AdminApplication
{
    public class AdminSetSheduleState : AbstractState
    {
        
        public AdminSetSheduleState()
        {
            
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                
                return this;
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
                            new InlineKeyboardButton("КНОПКА") {CallbackData="knopka"}

                        }
                        
                 }
                 );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Здравствуйте, Настя!", replyMarkup: markup);
        }
    }
}
