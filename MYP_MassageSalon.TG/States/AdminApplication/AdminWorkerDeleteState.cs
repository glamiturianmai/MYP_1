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
    public class AdminWorkerDeleteState : AbstractState
    {
        private int _workId;
        private WorkerClient _workClient;
        private DeleteWorkerInputModel _workTG;


        public AdminWorkerDeleteState(int workId)
        {
            _workId = workId;
            _workClient = new WorkerClient();
            _workTG = new DeleteWorkerInputModel();
            _workTG.Id = workId;
        }



        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                return new AdminWorkerSeeState();
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {

            _workClient.DeleteWorkerMap(_workTG); 


            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                   new InlineKeyboardButton[][]
                   {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Спасибо!") {CallbackData="SeeApps"}

                        }
                   }
                   );

            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Мы удалили этого мастера!", replyMarkup: markup);
        }
    }
}
