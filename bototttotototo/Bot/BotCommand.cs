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
        AgiPoint = 6,
        PowPoint = 7,
        ResPoint = 8,
        YesDung = 9,
        NoDung = 10,
        BuyItem = 11,
        GoLobby = 12,
        OpenInventory = 13,
        SelectItemInInv = 14,
        PickItem = 15,
    }
}
