using MYP_MassageSalon.BLL.Models.InputModels;
using MYP_MassageSalon.BLL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;

namespace MYP_MassageSalon.TG.States.AdminApplication
{
    public class AdminSetWorkerSchedule : AbstractState
    {
        private int _workerId;
        private string _workerName;

        public AdminSetWorkerSchedule(int workerId) 
        {
            _workerId = workerId;

            WorkerClient wc = new WorkerClient();
            WorkerIdInputModel wm = new WorkerIdInputModel { Id = _workerId };
            _workerName = wc.GetWorkerNameByIdMap(wm)[0].Name;
        }
        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                var message = update.CallbackQuery.Data;

                if (message == "seeSchedule")
                {
                    return this;
                }
                else if (message == "addSchedule")
                {
                    return new AdminAddWorkerSchedule(_workerId);
                }
                else if (message == "/admin")
                {
                    return new AdminStartState();
                }
                else if (message == "setWorker")
                {
                    return new AdminSetSheduleState();
                }
                else return this;

            }
            else return this; new NotImplementedException();
        }

        public override void SendMessage(long chatId)
        {
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                new InlineKeyboardButton[][]
                {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Посмотреть расписание") {CallbackData="seeSchedule"}
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Добавить расписание") {CallbackData="addSchedule"}
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Вернуться к выбору сотрудника") {CallbackData="setWorker"}
                        },
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Вернуться в меню админа") {CallbackData="/admin"}
                        }
                }
                );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Расписание сотрудника: {_workerName}", replyMarkup: markup);
        }
    }
}
