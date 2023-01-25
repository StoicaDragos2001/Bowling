using Bowling.UtilityComponents;

namespace Bowling.PlayerLogic
{
    public class ProStrategy : IStrategy
    {
        Random Random = new Random();
        private int FirstRollScore;
        private int SecondRollScore;

        public string Name
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
            FirstRollScore = Random.Next(ValueConstants.ProCheatValue, ValueConstants.RandomUpperBound);
        }

        private void GenerateSecondRoll()
        {
            if (FirstRollScore < 10)
            {
                SecondRollScore = Random.Next(ValueConstants.RandomUpperBound - FirstRollScore);
            }
            else
            {
                SecondRollScore = Random.Next(ValueConstants.ProCheatValue, ValueConstants.RandomUpperBound);
            }
        }
    }
}