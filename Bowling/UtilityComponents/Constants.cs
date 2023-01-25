using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.UtilityComponents
{
    internal static class Constants
    {
        public static readonly string PlayerDisplayFormat = "------> {0} ({1}) <------";
        public static readonly string WinnerDisplayFormat = "==========> The winner is {0}, with a score of {1} <==========";
        public static readonly string NumberOfPlayersMessage = "The number of players should be at least 1";
        public static readonly string NumberOfFramesMessage = "The number of frames must be between 1 and 10";
        public static readonly string DeclaredAnotherNumberOfPlayers = "You have a different number of players than those declared";
        public static readonly string UnfairBonusMessage = "Can't have anoter shot because the last frame isn't a spare or a strike";
        public static readonly string ScoreDisplayFormat = "({0}, {1}) -> {2}";
        public static readonly string BowlingBanner = "██████╗  ██████╗ ██╗    ██╗██╗     ██╗███╗   ██╗ ██████╗ \r\n██╔══██╗██╔═══██╗██║    ██║██║     ██║████╗  ██║██╔════╝ \r\n██████╔╝██║   ██║██║ █╗ ██║██║     ██║██╔██╗ ██║██║  ███╗\r\n██╔══██╗██║   ██║██║███╗██║██║     ██║██║╚██╗██║██║   ██║\r\n██████╔╝╚██████╔╝╚███╔███╔╝███████╗██║██║ ╚████║╚██████╔╝\r\n╚═════╝  ╚═════╝  ╚══╝╚══╝ ╚══════╝╚═╝╚═╝  ╚═══╝ ╚═════╝ \r\n";
        public static readonly int NumberOfFrames = 10;
        public static readonly int RandomUpperBound = 11;
        public static readonly int ProCheatValue = 2;
        public static readonly int NumberOfStrategies = 2;
        public static readonly int MaxShotScore = 10;

    }
}
