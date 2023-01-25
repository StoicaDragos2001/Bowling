using Bowling.Exceptions;
using Bowling.PlayerLogic;
using Bowling.UtilityComponents;

namespace Game
{
    public sealed class Game
    {
        public int NumberOfFrames { get; set; }
        public int TotalScore { get; set; }
        private static Game GameInstance;
        private List<IPlayer> Players = new List<IPlayer>();
        private int NoPlayers;

        public int NumberOfPlayers
        {
            get
            {
                return NoPlayers;
            }
            private set
            {
                NoPlayers = value;
            }
        }

        public static Game GetInstance(int numberOfPlayers)
        {
            if (GameInstance == null)
            {
                GameInstance = new Game(numberOfPlayers);
            }
            return GameInstance;
        }

        public void Play()
        {
            for (var frameIndex = 0; frameIndex <= NumberOfFrames; frameIndex++)
            {
                foreach (var player in Players)
                {
                    player.Play();
                }
            }
        }

        public void DisplayScoreBoard()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(MessageConstants.BowlingBanner);
            Console.ResetColor();
            foreach (var player in Players)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(String.Format(MessageConstants.PlayerDisplayFormat, player.Name, player.StrategyName));
                Console.ResetColor();
                player.DisplayScore();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(String.Format(MessageConstants.WinnerDisplayFormat, GetWinnerName(), GetMaxScore()));
            Console.ResetColor();
        }

        private Game(int numberOfPlayers)
        {
            if (numberOfPlayers < 1)
            {
                throw new NotEnoughPlayersException(MessageConstants.NumberOfPlayersMessage);
            }
            NumberOfPlayers = numberOfPlayers;
            GeneratePlayers(NumberOfPlayers);
            NumberOfFrames = ValueConstants.NumberOfFrames;
        }

        private void GeneratePlayers(int numberOfPlayers)
        {
            for (var playerIndex = 0; playerIndex < numberOfPlayers; playerIndex++)
            {
                AddPlayer(CreateRandomPlayer());
            }
        }

        private IPlayer CreateRandomPlayer()
        {
            var random = new Random();
            var playerType = random.Next(ValueConstants.NumberOfStrategies);
            switch (playerType)
            {
                case 0:
                    var normalStrategy = new NormalStrategy();
                    var normalPlayer = new Player(NameGenerator.Get());
                    normalPlayer.SetStrategy(normalStrategy);
                    return normalPlayer;
                default:
                    var proStrategy = new ProStrategy();
                    var proPlayer = new Player(NameGenerator.Get());
                    proPlayer.SetStrategy(proStrategy);
                    return proPlayer;
            }
        }

        private void AddPlayer(IPlayer player)
        {
            if (NumberOfPlayers == Players.Count)
            {
                throw new AddedMorePlayersThanDeclaredException(MessageConstants.DeclaredAnotherNumberOfPlayers);
            }
            Players.Add(player);
        }

        private int GetMaxScore()
        {
            return Players.OrderByDescending(x => x.GetTotalScore()).First().GetTotalScore();
        }

        private string GetWinnerName()
        {
            return Players.Where(x => x.GetTotalScore() == GetMaxScore()).First().Name;
        }
    }
}