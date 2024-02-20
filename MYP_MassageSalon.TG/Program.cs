using MYP_MassageSalon.TG.States;
using System.Threading;
using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;

namespace MYP_MassageSalon.TG
{
    internal class Program
    {
        static List<long> chats = new List<long>();

        static void Main(string[] args)
        {
            ITelegramBotClient client = SingletoneStorage.GetStorage().Client;

            var cts = new CancellationTokenSource();
            var cancellationToken = cts.Token;

            var receiverOptions = new ReceiverOptions
            {
                AllowedUpdates = [UpdateType.Message, UpdateType.CallbackQuery],
                ThrowPendingUpdates = true
            };

            client.StartReceiving(
               HandleUpdate,
               HandleError,
               receiverOptions,
               cancellationToken
            );

            string end = "";
            do
                end = Console.ReadLine();
            while (end != "end");
        }

        public static void HandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            var users = SingletoneStorage.GetStorage().Clients;
            long id = update.Message != null ? update.Message.Chat.Id : update.CallbackQuery.From.Id;

            if (!users.ContainsKey(id))
            {
                users.Add(id, new StartState());
            }
            else
            {
                var tmp = users[id].ReceiveMenue(update);

                if (tmp == users[id])
                {
                    users[id] = users[id].ReceiveMessage(update);
                }
                else
                {
                    users[id] = tmp;
                }

            }
            users[id].SendMessage(id);
        }

        public static void HandleError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {
        }
    }
}
