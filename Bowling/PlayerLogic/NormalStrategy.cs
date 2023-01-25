using Bowling.UtilityComponents;

namespace Bowling.PlayerLogic
{
    public class NormalStrategy : IStrategy
    {
        Random Random = new Random();
        private int FirstRollScore;
        private int SecondRollScore;

        public string Name
        {
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
            FirstRollScore = Random.Next(ValueConstants.RandomUpperBound);
        }

        private void GenerateSecondRoll()
        {
            if (FirstRollScore < ValueConstants.MaxShotScore)
            {
                SecondRollScore = Random.Next(ValueConstants.RandomUpperBound - FirstRollScore);
            }
            else
            {
                SecondRollScore = Random.Next(ValueConstants.RandomUpperBound);
            }
        }
    }
}