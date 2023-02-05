namespace Bowling.UtilityComponents
{
    internal static class MessageConstants
    {
        public static readonly string PlayerDisplayFormat = "------> {0} ({1}) <------";
        public static readonly string WinnerDisplayFormat = "==========> The winner is {0}, with a score of {1} <==========";
        public static readonly string NumberOfPlayersMessage = "The number of players should be at least 1";
        public static readonly string ShotIndexMessage = "Shot index should be 0 or 1";
        public static readonly string NumberOfFramesMessage = "The number of frames must be between 1 and 10";
        public static readonly string NumberOfRollsMessage = "You can't roll this many times";
        public static readonly string DeclaredAnotherNumberOfPlayers = "You have a different number of players than those declared";
        public static readonly string UnfairBonusMessage = "Can't have anoter shot because the last frame isn't a spare or a strike";
        public static readonly string ScoreDisplayFormat = "({0}, {1}) -> {2}";
        public static readonly string BowlingBanner = "██████╗  ██████╗ ██╗    ██╗██╗     ██╗███╗   ██╗ ██████╗ \r\n██╔══██╗██╔═══██╗██║    ██║██║     ██║████╗  ██║██╔════╝ \r\n██████╔╝██║   ██║██║ █╗ ██║██║     ██║██╔██╗ ██║██║  ███╗\r\n██╔══██╗██║   ██║██║███╗██║██║     ██║██║╚██╗██║██║   ██║\r\n██████╔╝╚██████╔╝╚███╔███╔╝███████╗██║██║ ╚████║╚██████╔╝\r\n╚═════╝  ╚═════╝  ╚══╝╚══╝ ╚══════╝╚═╝╚═╝  ╚═══╝ ╚═════╝ \r\n";

    }
}
