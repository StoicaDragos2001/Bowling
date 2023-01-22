namespace Game
{
    public class Frame
    {
        private int firstShot;
        private int secondShot;
        private bool firstShotUsed = false;
        private bool secondShotUsed = false;

        public int FirstShot
        {
            get
            {
                return firstShot;
            }
            set
            {
                firstShot = value;
            }
        }
        public int SecondShot
        {
            get
            {
                return secondShot;
            }
            set
            {
                secondShot = value;
            }
        }

        public Frame(int firstShotScore = 0, int secondShotScore = 0)
        {
            firstShot = firstShotScore;
            secondShot = secondShotScore;
        }

        public bool CanInsert()
        {
            if (firstShotUsed == false || secondShotUsed == false)
                return true;
            return false;
        }

        public void Insert(int score)
        {
            if (firstShotUsed == false)
            {
                firstShotUsed = true;
                FirstShot = score;
            }
            else
            {
                secondShotUsed = true;
                SecondShot = score;
            }
        }

        public bool IsStrike()
        {
            if (firstShot == 10)
                return true;
            return false;
        }

        public bool IsSpare()
        {
            if (firstShot + secondShot == 10)
                return true;
            return false;
        }
        


    }
}