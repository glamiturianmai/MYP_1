using MYP_MassageSalon.BLL.Models.InputModels;
using MYP_MassageSalon.BLL;
using MYP_MassageSalon.TG.States.AdminApplication;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;
using Telegram.Bot;
using MYP_MassageSalon.TG.States.MasterApplication;

namespace MYP_MassageSalon.TG.States
{
    public class AdminPasswordStartState : AbstractState //добавляем сотрудника
    {


        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.Message)
            {
                var message = update.Message.Text.ToString();
                if (message == "1234")
                {
                    return new AdminPasswordStartState();
                }
                else 
                {
                    return new StartState();
                }
            }

            return this;
        }

        public override void SendMessage(long chatId)
        {
           
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Введите пароль админа:");
        }
    }
}
