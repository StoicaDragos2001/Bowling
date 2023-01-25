using Bowling.UtilityComponents;

namespace Game
{
    public class Frame
    {
        private int FirstRollScore;
        private int SecondRollScore;
        private bool IsFirstRollUsed = false;
        private bool IsSecondRollUsed = false;

        public int FirstShot
        {
            get
            {
                return FirstRollScore;
            }
            set
            {
                FirstRollScore = value;
            }
        }

        public int SecondShot
        {
            get
            {
                return SecondRollScore;
            }
            set
            {
                SecondRollScore = value;
            }
        }

        public Frame(int firstShotScore = 0, int secondShotScore = 0)
        {
            FirstRollScore = firstShotScore;
            SecondRollScore = secondShotScore;
        }

        public bool CanInsert()
        {
            return IsFirstRollUsed == false || IsSecondRollUsed == false;
        }

        public void AddScore(int score)
        {
            if (IsFirstRollUsed == false)
            {
                IsFirstRollUsed = true;
                FirstShot = score;
            }
            else
            {
                IsSecondRollUsed = true;
                SecondShot = score;
            }
        }

        public bool IsStrike()
        {
            return FirstRollScore == Constants.MaxShotScore;
        }

        public bool IsSpare()
        {
            return FirstRollScore + SecondRollScore == Constants.MaxShotScore;
        }
    }
}