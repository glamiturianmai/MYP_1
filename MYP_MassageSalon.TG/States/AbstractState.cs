using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types;

namespace MYP_MassageSalon.TG.States
{
    public abstract class AbstractState
    {
        public abstract void SendMessage(long chatId);

        public abstract AbstractState ReceiveMessage(Update update);

        public virtual AbstractState ReceiveMenue(Update update)
        {
            if (update.Type == UpdateType.Message)
            {
                var message = update.Message.Text.ToLower();
                if (message == "/start")
                {
                    return new StartState();
                }
            }
            return this;
        }
    }
}
