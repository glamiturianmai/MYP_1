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
    public class AdminWorkerAddState : AbstractState //добавляем сотрудника
    {
        private string _workName;
        private int _qualId;

        private WorkersAddInputModel _workTG;
        private WorkerClient _workClient;
        public AdminWorkerAddState(string name, int qualid)
        {
            _workName = name;
            _qualId = qualid;
            _workTG = new WorkersAddInputModel();
            _workTG.Name = _workName;
            _workTG.QualificationId = _qualId;
            _workClient = new WorkerClient();
        }

        public override AbstractState ReceiveMessage(Update update)
        {
            if (update.Type == UpdateType.CallbackQuery)
            {
                return new AdminWorkerDoState();
            }
            return this;
        }

        public override void SendMessage(long chatId)
        {
            _workClient.AddNewWorkerMap(_workTG);

            InlineKeyboardMarkup markup = new InlineKeyboardMarkup(
                new InlineKeyboardButton[][]
                {
                        new InlineKeyboardButton[]
                        {
                            new InlineKeyboardButton("Хорошо!") {CallbackData="see"}

                        }
                }
                );
            SingletoneStorage.GetStorage().Client.SendTextMessageAsync(chatId, $"Мастер добавлен!", replyMarkup: markup);
        }
    }
}
