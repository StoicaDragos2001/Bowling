using Bowling.Exceptions;
using Bowling.UtilityComponents;



namespace Game
{
    public sealed class Game
    {
        private static Game GameInstance;
        private String WinnerName;
        private List<IPlayer> Players = new List<IPlayer>();
        private int MaxScore;
        private int NoPlayers;
        public int NumberOfFrames { get; set; }
        public int TotalScore { get; set; }
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
        
        private Game(int numberOfPlayers)
        {
            if (numberOfPlayers < 1)
            {
                throw new NotEnoughPlayersException(Constants.NumberOfPlayersMessage);
            }
            else
            {
                NumberOfPlayers = numberOfPlayers;
                GeneratePlayers(NumberOfPlayers);
            }
            NumberOfFrames = Constants.NumberOfFrames;
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
            Random random = new Random();
            for (var frameIndex = 0; frameIndex < NumberOfFrames; frameIndex++)
            {
                foreach (var player in Players)
                {
                    player.SimulateRolls();
                }
            }
            foreach (var player in Players)
                player.SimulateRolls();
            Calculate();
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
            var playerType = random.Next(Constants.NumberOfStrategies);
            switch (playerType)
            {
                case 0:
                    var NormalStrat = new NormalStrategy();
                    var NormalPlayer = new Player(NameGenerator.Get());
                    NormalPlayer.SetStrategy(NormalStrat);
                    return NormalPlayer;
                default:
                    var ProStrat = new ProStrategy();
                    var ProPlayer = new Player(NameGenerator.Get());
                    ProPlayer.SetStrategy(ProStrat);
                    return ProPlayer;
            }
        }

        private void AddPlayer(IPlayer player)
        {
            if (NumberOfPlayers == Players.Count)
            {
                throw new AddedMorePlayersThanDeclaredException(Constants.DeclaredAnotherNumberOfPlayers);
            }
            else
            {
                Players.Add(player);
            }
        }

        public void ShowPlayers()
        {
            foreach (Player player in Players)
            {
                Console.WriteLine(player.Name);
            }
        }

        public void DisplayScoreBoard()
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(Constants.BowlingBanner);
            Console.ResetColor();
            foreach (var player in Players)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine(String.Format(Constants.PlayerDisplayFormat, player.Name, player.StrategyName));
                Console.ResetColor();
                player.DisplayScore();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine(String.Format(Constants.WinnerDisplayFormat, WinnerName, MaxScore));
            Console.ResetColor();
        }

        private void Calculate()
        {
            foreach (var player in Players)
            {
                player.CalculateScore();
                if (player.GetTotalScore() > MaxScore)
                {
                    MaxScore = player.GetTotalScore();
                    WinnerName = player.Name;
                }
            }
        }
    }
}