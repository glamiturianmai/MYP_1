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

namespace MYP_MassageSalon.TG.States.AdminApplication // выводим все квадификации + передаем id
{
    public class AdminWorkerQualChooseState : AbstractState
    {
        private int _workId;
        private List<QualificationsOutputModel> _qualTG;
        public AdminWorkerQualChooseState(int workId)
        {
            _workId = workId;
            _qualTG = new WorkerClient().GetQualifWorker();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                int qualId = Int32.Parse(update.CallbackQuery.Data);
                int workId = _workId;
                return new AdminWorkerQualState(workId, qualId);
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            List<List<InlineKeyboardButton>> keys = new List<List<InlineKeyboardButton>>();

            for (var i = 0; i < _qualTG.Count; i++)
            {
                keys.Add(new List<InlineKeyboardButton>());
                {
                    keys[keys.Count - 1].Add(new InlineKeyboardButton($"{_qualTG[i].Qualification}")
                    { CallbackData = _qualTG[i].Id.ToString() });
                }

            }

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(keys);

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Выберите квалификацию:", replyMarkup: markup);
        }
    }
}
