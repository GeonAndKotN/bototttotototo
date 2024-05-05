using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types;

namespace bototttotototo.Bot
{
    public class BotModel : IGameModel
    {
        public BotModel() { }

        public event EventHandler<GameResponseEventArgs> OnGameResponse;

        public void HandleCommand(object sender, BotCommand command)
        {
            switch (command)
            {


                case BotCommand.Start:
                    OnGameResponse.Invoke(
                this,
                new GameResponseEventArgs()
                    {
                        TextMessage = "Так... вот и начало... ну что-ж, начнём. \n\n\nПриветствую тебя путник!\nДанный бот является мини рпг проектом для курсовой работы, идеи взяты из настольной ролевой игры DND(Dungeons & Dragons).\nДля начала выберите имя и класс, а дальше веселитесь!",
                        ImageUrl = "https://i0.wp.com/www.dicegeeks.com/wp-content/uploads/2022/10/DnDLogo.jpg?w=1200&ssl=1"
                    }
                );
                    break;

                case BotCommand.Unknown:
                    break;

                case BotCommand.Shop:
                    OnGameResponse.Invoke(
                this,
                new GameResponseEventArgs()
                    {
                        TextMessage = "Приветствую тебя Путник! Выбирай товары на свой вкус и цвет!",
                        ImageUrl = ""//тут я фотку вставлю торговца, уже сделал при помощи ИИ
                }
                );
                    break;

                case BotCommand.GoDung:
                    OnGameResponse.Invoke(
                this,
                new GameResponseEventArgs()
                    {
                        TextMessage = $"Выберите в какое именно подземелье вы бы хотели спуститься",
                        ImageUrl = "https://sun9-3.userapi.com/impg/c858324/v858324088/1a15f9/d_xygXE_Gh8.jpg?size=807x473&quality=96&sign=bad6e70eb09da92154f8c41bb9f8eadc&c_uniq_tag=IG5xWmb3RF5VYK5GvZrY7YqO_t6HzFwZWlo46cTWrHc&type=album"
                }
                );
                    break;

                case BotCommand.WarSel:
                    OnGameResponse.Invoke(
                this,
                new GameResponseEventArgs()
                    {
                        TextMessage = "Вы выбрали класс воина!!!",
                        ImageUrl = "https://raw.githubusercontent.com/GeonAndKotN/TgBotWithMySqlKAD1125/master/TgBotWithMySqlKAD1125/Image/WarriorImageMale.jpg"
                }
                );
                    break;
            }
        }
    }

    public class GameResponseEventArgs
    {
        public string TextMessage { get; set; }
        public string ImageUrl { get; set; }
    }

    public interface IGameModel 
    {
        public void HandleCommand(object sender, BotCommand command);

        event EventHandler<GameResponseEventArgs> OnGameResponse;
    }
}
