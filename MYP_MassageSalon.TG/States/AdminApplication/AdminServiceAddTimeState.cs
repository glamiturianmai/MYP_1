using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;

namespace MYP_MassageSalon.TG.States.AdminApplication
{
    public class AdminServiceAddTimeState : AbstractState //вводим wцену услуги
    {
        private string _servName;
        private int _servCost;
        public AdminServiceAddTimeState(string name, int cost)
        {
            _servName = name;
            _servCost = cost;
        }


        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.Message)
            {
                var time = int.Parse(update.Message.Text);
                var cost = _servCost;
                var name = _servName;
                return new AdminServiceAddState(name, cost, time);
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Введите время для услуги (в минутах):");
        }

    }
}
