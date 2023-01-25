using Bowling.UtilityComponents;

namespace Game
{
    public class ProStrategy : IStrategy
    {
        Random Random = new Random();
        private int FirstRollScore;
        private int SecondRollScore;

        public String Name
        {
            get
            {
                return "pro";
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
            FirstRollScore = Random.Next(Constants.ProCheatValue, Constants.RandomUpperBound);
        }

        private void GenerateSecondRoll()
        {
            if (FirstRollScore < 10)
            {
                SecondRollScore = Random.Next(Constants.RandomUpperBound - FirstRollScore);
            }
            else
            {
                SecondRollScore = Random.Next(Constants.ProCheatValue, Constants.RandomUpperBound);
            }
        }
    }
}