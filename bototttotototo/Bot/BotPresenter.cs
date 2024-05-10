using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;

namespace bototttotototo.Bot
{
    public class BotPresenter
    {
        private BotView gameView;

        private BotModel gameModel;

        public BotPresenter() 
        {
            gameView = new BotView();
            gameModel = new BotModel();
            var botclient = new TelegramBotClient("6435067834:AAHD-49wIKSo6ooiN82c0FdMH5_JWogwpwA");
            botclient.StartReceiving(HandleUpdateAsync, HandlePollingErrorAsync);
            gameView.commandRecieved += gameModel.HandleCommand;
            gameModel.OnGameResponse += (s, a) => gameView.SendMessage(botclient, a);
            Console.WriteLine("Бот был запущен!");

            string SQLConnection = "server=localhost;user=SuperKAD;database=bototttotototo;password=1234;";
            MySqlConnection SQLConn = new MySqlConnection(SQLConnection);

            Console.ReadLine();
        }
        private async Task HandlePollingErrorAsync(ITelegramBotClient client, Exception exception, CancellationToken token)
        {
            Console.WriteLine($"ошибка: {exception}");
        }

        private async Task HandleUpdateAsync(ITelegramBotClient client, Update update, CancellationToken token)
        {
            switch (update.Type)
            {
                case UpdateType.Message:
                case UpdateType.EditedMessage:
                    gameView.HandleMessage(update.Message);
                    break;
                case UpdateType.CallbackQuery:
                    gameView.HandleCallbackQuery(update.CallbackQuery);
                    break;
                //остальные возможные виды сообщений
                #region other cases
                case UpdateType.Unknown:
                case UpdateType.InlineQuery:
                case UpdateType.ChosenInlineResult:
                case UpdateType.ChannelPost:
                case UpdateType.EditedChannelPost:
                case UpdateType.ShippingQuery:
                case UpdateType.PreCheckoutQuery:
                case UpdateType.Poll:
                case UpdateType.PollAnswer:
                case UpdateType.MyChatMember:
                case UpdateType.ChatMember:
                case UpdateType.ChatJoinRequest:
                default:
                    break;
                    #endregion
            }
            gameView.ChatId = update.Message.Chat.Id;
        }
    }
}
