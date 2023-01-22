using Bowling.Exceptions;
using Bowling.UtilityComponents;

namespace Game
{
    public class BowlingGame
    {
        private List<Player> players = new List<Player>();
        private List<Frame> framesScoreBoard = new List<Frame>();
        private int CurrentFrameIndex = 0;
        private int bonus = -1;
        public int NumberOfPlayers { get; set; }
        public int NumberOfFrames { get; set; }
        public BowlingGame(int numberOfFrames, int numberOfPlayers)
        {
            if (numberOfPlayers < 1)
            {
                throw new NotEnoughPlayersException(Constants.numberOfPlayersMessage);
            }
            else
            {
                NumberOfPlayers = numberOfPlayers;
            }

            if (numberOfFrames < 1 || numberOfFrames > 10)
            {
                throw new NumberOfFramesOutOfRangeException(Constants.numberOfFramesMessage);
            }
            else
            {
                NumberOfFrames = numberOfFrames;
                InitializeFrames(NumberOfFrames);
            }
        }

        private void InitializeFrames(int numberOfFrames)
        {
            for (var frameIndex = 0; frameIndex < numberOfFrames; frameIndex++)
                framesScoreBoard.Add(new Frame());
        }

        public void AddPlayer(Player player)
        {
            if (NumberOfPlayers == players.Count)
            {
                throw new AddedMorePlayersThanDeclaredException(Constants.declaredAnotherNumberOfPlayers);
            }
            else
            {
                players.Add(player);
            }
        }

        public void ShowPlayers()
        {
            foreach (Player player in players)
            {
                Console.WriteLine(player.Name);
            }
        }

        public void Roll(int pins)
        {
            if (framesScoreBoard[CurrentFrameIndex].CanInsert())
            {
                framesScoreBoard[CurrentFrameIndex].Insert(pins);
            }
            else
            {
                if (CurrentFrameIndex == NumberOfFrames - 1)
                {
                    RollForLastBonus(pins);
                }
                else
                {
                    RollForNextFrame(pins);
                }
            }
        }

        private void RollForLastBonus(int pins)
        {
            if (CanRollForLastBonus() == true)
            {
                bonus = pins;
            }
            else
            {
                throw new UnfairBonusRollException(Constants.unfairBonusMessage);
            }
        }

        private void RollForNextFrame(int pins)
        {
            CurrentFrameIndex += 1;
            framesScoreBoard[CurrentFrameIndex].Insert(pins);
        }

        public void DisplayScore()
        {
            var numFramesExceptLast = NumberOfFrames - 1;
            for (var frameIndex = 0; frameIndex < numFramesExceptLast; frameIndex++)
            {
                var frameShots = framesScoreBoard[frameIndex];
                Console.WriteLine(String.Format(Constants.scoreDisplayFormat, frameShots.FirstShot, frameShots.SecondShot, CalculateFrameScore(frameIndex)));
            }

            var lastFrameShots = framesScoreBoard[numFramesExceptLast];
            Console.WriteLine(String.Format(Constants.scoreDisplayFormat, lastFrameShots.FirstShot, lastFrameShots.SecondShot, CalculateLastFrameScore(numFramesExceptLast)));
            if(bonus != -1)
                Console.WriteLine("Last bonus: " + bonus);
        }

        private int CalculateFrameScore(int frameIndex)
        {
            var frameShots = framesScoreBoard[frameIndex];
            var nextFrameShots = framesScoreBoard[frameIndex + 1];
            if (frameShots.IsStrike())
            {
                return frameShots.FirstShot + frameShots.SecondShot + nextFrameShots.FirstShot;
            }
            else if (frameShots.IsSpare())
            {
                return frameShots.FirstShot + frameShots.SecondShot + nextFrameShots.FirstShot;
            }
            return frameShots.FirstShot + frameShots.SecondShot;
        }

        private int CalculateLastFrameScore(int frameIndex)
        {
            var frameShots = framesScoreBoard[frameIndex];
            if (bonus != -1)
            {
                return frameShots.FirstShot + frameShots.SecondShot + bonus;
            }
            return frameShots.FirstShot + frameShots.SecondShot;
        }

        private bool CanRollForLastBonus()
        {
            var lastFrame = framesScoreBoard[CurrentFrameIndex];
            if (bonus == -1 && (lastFrame.IsSpare() || lastFrame.IsStrike()))
            {
                return true;
            }
            return false;
        }

    }
}