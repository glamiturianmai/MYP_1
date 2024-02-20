using Telegram.Bot;
using Telegram.Bot.Polling;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using Telegram.Bot.Types.ReplyMarkups;
namespace MYP_MassageSalon.UITG
{
    public class Program
    {
        static List<long> chats = new List<long>(); //храним мы все храним....

        static void Main(string[] args)
        {
            ITelegramBotClient client = new TelegramBotClient("6520227174:AAHFPUiup_abIm1-vXMqxkXoRaJ2XKNsksM"); //связь между тг и системой
                                                                                                                 //+ должен быть в единственном экземпляре 

            var cts = new CancellationTokenSource();   //это библиотека 
            //подключайся 
            var cancellationToken = cts.Token; //телеграм это мы мы это телеграм 

            var receiverOptions = new ReceiverOptions()
            {
                AllowedUpdates = [UpdateType.Message, UpdateType.CallbackQuery],  //что мы готовы получить на вход (текст и нажатия на кнопки) 
                ThrowPendingUpdates = true //мы ВИДИМ отредактированные сообщения (чудо человеческое)
            };

            client.StartReceiving
                (
                HandleUpdate, //метод раз - апдейты 
                HandleError,  // метод два - ошибки 
                receiverOptions, // настройки 
                cancellationToken //токен для тг
                );


            string end = ""; //не выключайся сам 
            do
                end = Console.ReadLine();
            while (end != "end");
            //364888013
        }

        public static void HandleUpdate(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
        {
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup( //клавиатура под письмо 
                                                                    // на вход коллекцию коллекция кнопок 
                    new InlineKeyboardButton[][] //массив кнопок - элемент тоже массив 
                    {
                        new InlineKeyboardButton[] //строка кнопок
                        {
                            new InlineKeyboardButton("aa") { CallbackData="aa"}, //информация ТЕКСТ которая вернется 
                            new InlineKeyboardButton("не кнопка") { CallbackData="не туда"},
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("совсем не та кнопка") { CallbackData="ВООБЩЕ НЕ ТУДА"},
                        }
                    }
                    );

            
            InlineKeyboardMarkup markupnew = new InlineKeyboardMarkup(
                   new InlineKeyboardButton[][] //массив кнопок - элемент тоже массив 
                   {
                        new InlineKeyboardButton[] //строка кнопок
                        {
                            new InlineKeyboardButton("мяу") { CallbackData="мяу"}, //информация ТЕКСТ которая вернется 
                            new InlineKeyboardButton("гав") { CallbackData="гав"},
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("помогите") { CallbackData="помощь"},
                        }
                   }
                   );
            if (update.Type == UpdateType.Message) //если тебе пришел апдейт письмо 
            {
                if (update.Message.Text == "/start") //добавляем новых людей в список 
                {
                    chats.Add(update.Message.Chat.Id); //вот список 
                }


                

                Console.WriteLine($"{update.Message.Chat.Id} {update.Message.Chat.FirstName} {update.Message.Text}");
                if ((update.Message.Text != "1"))
                {
                    botClient.SendTextMessageAsync(update.Message.Chat.Id, $" {update.Message.Chat.FirstName}! привет!!!");
                    botClient.SendTextMessageAsync(update.Message.Chat.Id, $" напишите например 1");
                }
                
            

                if (update.Message.Text == "1")
                {
                    
                    botClient.SendTextMessageAsync(update.Message.Chat.Id, "молодец");
                    botClient.SendTextMessageAsync(update.Message.Chat.Id, "выберете кнопку", replyMarkup: markup);
                    
                       
                }


                //if (update.CallbackQuery.Data == "aa")
                //{
                //    Console.WriteLine("aaaaaaaa");
                //    botClient.SendTextMessageAsync(update.Message.Chat.Id, "работай пожалуйста", replyMarkup: markupnew);
                //}






                //пошлем письмо - лежит клавиатура 
            }
            else if (update.Type == UpdateType.CallbackQuery) //обрабатываем кнопки 
            {
                Console.WriteLine($"{update.CallbackQuery.Message.Chat.Id} {update.CallbackQuery.Message.Chat.FirstName} {update.CallbackQuery.Message.Text}");

                if ( update.CallbackQuery.Data == "aa")
                {
                    Console.WriteLine("aaaaaaaa");
                    botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "вы нажали на первую кнопку");
                    botClient.SendTextMessageAsync(update.CallbackQuery.Message.Chat.Id, "новые кнопки", replyMarkup: markupnew);
                }
            }

        }
        public static void HandleError(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
        {

        }
    }
}
