﻿using MYP_MassageSalon.BLL.Models.OutputModels;
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

namespace MYP_MassageSalon.TG.States.ClientApplication
{
    public class StateClientSeeApp : AbstractState
    {
        private List<ClientAppPrOutputModel> _appTG;
        private int _clientId;
        public StateClientSeeApp(int clientId)
        {
            _clientId = clientId;
            _appTG = new AppointmentClient().GetPlease(clientId);
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                string m = update.CallbackQuery.Data;
                if (m == "/back")
                {
                    return new StartState();
                }
                else
                {
                    int appId = Int32.Parse(update.CallbackQuery.Data);
                    return new StateClientDoWithApp(appId, _clientId);
                }
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();
            string message;

            if (_appTG.Count != 0)
            {
                message = $"Выберите заявку";
                for (var i = 0; i < _appTG.Count; i++)
                {
                    keys.Add(new List<InlineKeyboardButton>());
                    if (i % 2 == 0)
                    {
                        keys[keys.Count - 1].Add(new InlineKeyboardButton($"{_appTG[i].WorkerName}, {_appTG[i].ServiceName}, {_appTG[i].Date.DayOfYear}, {_appTG[i].Date.TimeOfDay}-{_appTG[i + 1].Date.AddMinutes(15).TimeOfDay}, {_appTG[i].Price} руб.")
                        { CallbackData = _appTG[i].AppId.ToString() });
                    }
                }
            }
            else message = "У вас ещё нет записей";

            keys.Add(new List<InlineKeyboardButton>()
            {
                new InlineKeyboardButton("Вернуться в главное меню ->") { CallbackData = "/back"}
            });

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, message, replyMarkup: markup);
        }
    }
}
