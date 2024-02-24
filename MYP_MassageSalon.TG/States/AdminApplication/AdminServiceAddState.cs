using MYP_MassageSalon.BLL.Models.InputModels;
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
    public class AdminServiceAddState : AbstractState //добавляем сотрудника
    {
        private string _servName;
        private int _servCost;
        private int _servTime;

        private ServiceIntputModel _servTG;
        private ServiceClient _servClient;
        public AdminServiceAddState(string name, int cost, int time)
        {
            _servName = name;
            _servCost = cost;
            _servTime = time;

            _servTG = new ServiceIntputModel();
            _servTG.Name = _servName;
            _servTG.Price = _servCost;
            _servTG.Time = _servTime;

            _servClient = new ServiceClient();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                return new AdminServiceDoState();
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            _servClient.SetServiceMap(_servTG);

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                new InlineKeyboardButton[][]
                {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Хорошо!") {CallbackData="see"}

                        }
                }
                );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Услуга добавлена!", replyMarkup: markup);
        }
    }
}
