using MYP_MassageSalon.BLL.Models.OutputModels;
using MYP_MassageSalon.BLL;
using MYP_MassageSalon.TG.States.ClientApplication;
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
    public class AdminWorkerChooseState : AbstractState
    {
        
        private int _workId;
        
        public AdminWorkerChooseState(int workid)
        {
            _workId = workid;
            
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                
                int workId = _workId;
                var message = update.CallbackQuery.Data;

                if (message == "delete")
                {
                    
                    return new AdminWorkerDeleteAskState(workId);
                }
                else if (message == "editQual")
                {
                    return new AdminWorkerQualChooseState(workId);
                }
                else if (message == "back")
                {
                    return new AdminWorkerSeeState();
                }
                else if (message == "home")
                {
                    return new StartState();
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
                            new InlineKeyboardButton("Изменить квалификацию") {CallbackData="editQual"}
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
