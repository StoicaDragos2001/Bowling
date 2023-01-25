using Bowling.UtilityComponents;

namespace Game
{
    public class NormalStrategy : IStrategy
    {
        Random Random = new Random();
        private int FirstRollScore;
        private int SecondRollScore;

        public String Name {
            get
            {
                return "normal";
            }
        }

        public Tuple<int, int> GenerateRolls()
        {
            GenerateFirstRoll();
            GenerateSecondRoll();
            return Tuple.Create(FirstRollScore, SecondRollScore);
        }

        private void GenerateFirstRoll()
        {
            FirstRollScore = Random.Next(Constants.RandomUpperBound);
        }

        private void GenerateSecondRoll()
        {
            if (FirstRollScore < Constants.MaxShotScore)
            {
                SecondRollScore = Random.Next(Constants.RandomUpperBound - FirstRollScore);
            }
            else
            {
                SecondRollScore = Random.Next(Constants.RandomUpperBound);
            }
        }
    }
}