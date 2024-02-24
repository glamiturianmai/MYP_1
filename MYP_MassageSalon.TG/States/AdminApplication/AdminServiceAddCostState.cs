using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;
using Telegram.Bot;
using MYP_MassageSalon.BLL.Models.InputModels;
using MYP_MassageSalon.BLL;

namespace MYP_MassageSalon.TG.States.AdminApplication
{
    public class AdminServiceAddCostState : AbstractState //вводим wцену услуги
    {
        private string _servName;
        public AdminServiceAddCostState(string name)
        {
            _servName = name;
        }


        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.Message)
            {
                var cost = int.Parse(update.Message.Text);
                var name = _servName;
                return new AdminServiceAddTimeState(name, cost);
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Введите цену услуги:");
        }

    }
}
