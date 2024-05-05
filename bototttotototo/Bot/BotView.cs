using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;
using Telegram.Bot.Types.Enums;
using System.Text.RegularExpressions;



namespace bototttotototo.Bot
{
    public class BotView : IGameView
    {
        public long ChatId { get; set; }
        public BotView() { }

        public event EventHandler<BotCommand> commandRecieved;

        public void HandleCallbackQuery(CallbackQuery callbackQuery)
        {
            if (TryParseCommand(callbackQuery.Data, out var command))
            {
                Console.WriteLine($"Кнопка была отработана {command}");
                commandRecieved.Invoke(this, command);
            } 
        }

        public void SendMessage(ITelegramBotClient client, GameResponseEventArgs args)
        {
            if (!string.IsNullOrEmpty(args.TextMessage))
            {
                client.SendTextMessageAsync(ChatId, args.TextMessage);
            }
            if (!string.IsNullOrEmpty(args.ImageUrl))
            {
                client.SendPhotoAsync(ChatId, InputFile.FromUri(args.ImageUrl));
            }
        }

        public void HandleMessage(Message message)
        {
            switch (message.Type)
            {
                case MessageType.Text:
                    if (TryParseCommand(message.Text, out var command))
                    {
                        Console.WriteLine($"Команда была отработана {command}");
                        commandRecieved.Invoke(this, command); 
                    }
                    break;
                #region other message types
                case MessageType.Unknown:
                    break;
                case MessageType.Photo:
                    break;
                case MessageType.Audio:
                    break;
                case MessageType.Video:
                    break;
                case MessageType.Voice:
                    break;
                case MessageType.Document:
                    break;
                case MessageType.Sticker:
                    break;
                case MessageType.Location:
                    break;
                case MessageType.Contact:
                    break;
                case MessageType.Venue:
                    break;
                case MessageType.Game:
                    break;
                case MessageType.VideoNote:
                    break;
                case MessageType.Invoice:
                    break;
                case MessageType.SuccessfulPayment:
                    break;
                case MessageType.WebsiteConnected:
                    break;
                case MessageType.ChatMembersAdded:
                    break;
                case MessageType.ChatMemberLeft:
                    break;
                case MessageType.ChatTitleChanged:
                    break;
                case MessageType.ChatPhotoChanged:
                    break;
                case MessageType.MessagePinned:
                    break;
                case MessageType.ChatPhotoDeleted:
                    break;
                case MessageType.GroupCreated:
                    break;
                case MessageType.SupergroupCreated:
                    break;
                case MessageType.ChannelCreated:
                    break;
                case MessageType.MigratedToSupergroup:
                    break;
                case MessageType.MigratedFromGroup:
                    break;
                case MessageType.Poll:
                    break;
                case MessageType.Dice:
                    break;
                case MessageType.MessageAutoDeleteTimerChanged:
                    break;
                case MessageType.ProximityAlertTriggered:
                    break;
                case MessageType.WebAppData:
                    break;
                case MessageType.VideoChatScheduled:
                    break;
                case MessageType.VideoChatStarted:
                    break;
                case MessageType.VideoChatEnded:
                    break;
                case MessageType.VideoChatParticipantsInvited:
                    break;
                case MessageType.Animation:
                    break;
                case MessageType.ForumTopicCreated:
                    break;
                case MessageType.ForumTopicClosed:
                    break;
                case MessageType.ForumTopicReopened:
                    break;
                case MessageType.ForumTopicEdited:
                    break;
                case MessageType.GeneralForumTopicHidden:
                    break;
                case MessageType.GeneralForumTopicUnhidden:
                    break;
                case MessageType.WriteAccessAllowed:
                    break;
                case MessageType.UserShared:
                    break;
                case MessageType.ChatShared:
                    break;
                default:
                    break;
                    #endregion
            }
        }
        
        private bool TryParseCommand(string text, out BotCommand command)
        {
            command = BotCommand.Unknown;
            if (text.StartsWith('/'))
            {
                var editedText = text.Replace("/", string.Empty).ToLower();
                command = ParseGameCommand(editedText);
                return true;
            }
            return false;
        }
        private BotCommand ParseGameCommand(string text)
        {
            foreach (var gameCommand in Enum.GetValues<BotCommand>())
            {
                var gameCommandName = gameCommand.ToString().ToLower();

                if (gameCommandName.Equals(text))
                {
                    return gameCommand;
                }
            }
            return BotCommand.Unknown;
        }
    }


    public interface IGameView
    {
        event EventHandler<BotCommand> commandRecieved;
    }
}
