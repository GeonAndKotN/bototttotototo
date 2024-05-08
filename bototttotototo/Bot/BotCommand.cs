namespace bototttotototo.Bot
{
    //enum это перечисленые возможных вариантов, он обязательно закрепляется за интом и
    //лучше это обозначать явно, чтобы не путаться
    public enum BotCommand
    {
        Start = 0,
        Unknown = 1,
        Shop = 2,
        GoDung = 3,
        ExitDung = 4,
        Stats = 5,
        PowPoint = 6,
        ResPoint = 7,
        YesDung = 8,
        NoDung = 9,
        BuyItem = 10,
        GoLobby = 11,
        OpenInventory = 12,
        UsePotion = 13,
        Escape = 14,
    }
}
