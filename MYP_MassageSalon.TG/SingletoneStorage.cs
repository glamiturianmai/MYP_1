using MYP_MassageSalon.TG.States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;

namespace MYP_MassageSalon.TG
{
    internal class SingletoneStorage
    {
        private static SingletoneStorage _object = null;
        public ITelegramBotClient Client { get; private set; }

        public Dictionary<long, AbstractState> Clients { get; private set; }

        private SingletoneStorage() {
            Client = new TelegramBotClient(Options.ConStr);

            Clients = new Dictionary<long, AbstractState>();   
        }

        public static SingletoneStorage GetStorage()
        {
            if (_object is null)
            {
                _object = new SingletoneStorage();
            }

            return _object;
        }
    }
}
