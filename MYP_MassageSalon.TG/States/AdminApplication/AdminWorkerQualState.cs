using MYP_MassageSalon.BLL.Models.OutputModels;
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
using MYP_MassageSalon.BLL.Models.InputModels;

namespace MYP_MassageSalon.TG.States.AdminApplication
{
    public class AdminWorkerQualState : AbstractState //меняем квалификацию 
    {
        private int _workId;
        private int _qualId;
        private QualifWorkerInputModels _qualTG;
        private WorkerClient _workerClient;
        public AdminWorkerQualState(int workid, int qualid)
        {
            _workId = workid;
            _qualId = qualid;
            _qualTG = new QualifWorkerInputModels();
            _qualTG.Id= _workId;
            _qualTG.QualificationId = _qualId;
            _workerClient =  new WorkerClient();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                //int qualId = Int32.Parse(update.CallbackQuery.Data);
                return new AdminWorkerSeeState();
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            _workerClient.SetWorkerQualificationMap(_qualTG);
            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                new InlineKeyboardButton[][]
                {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Хорошо!") {CallbackData="ok"}

                        }
                }
                );

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Квалификация изменена!", replyMarkup: markup);
        }
    }
}
