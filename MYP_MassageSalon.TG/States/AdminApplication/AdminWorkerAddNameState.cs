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
    public class AdminWorkerAddNameState : AbstractState //вводим имя мастера
    {

        

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.Message)
            {
                var name = update.Message.Text.ToString();
                return new AdminWorkerAddQualState(name);
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Введите имя мастера:");
        }

    }

}
