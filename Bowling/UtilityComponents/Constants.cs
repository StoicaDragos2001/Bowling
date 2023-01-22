using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bowling.UtilityComponents
{
    internal static class Constants
    {
        public static readonly string numberOfPlayersMessage = "The number of players should be at least 1";
        public static readonly string numberOfFramesMessage = "The number of frames must be between 1 and 10";
        public static readonly string declaredAnotherNumberOfPlayers = "You have a different number of players than those declared";
        public static readonly string unfairBonusMessage = "Can't have anoter shot because the last frame isn't a spare or a strike";
        public static readonly string scoreDisplayFormat = "({0}, {1}) -> {2}";
    }
}
