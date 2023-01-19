namespace Game
{
    public class Game
    {
        private int _framesLeft;
        private List<Tuple<int, int>> _shotsPerFrame = new List<Tuple<int, int>>();
        private int _firstShotBuffer = -1;   // -1 for first opportunity in frame
        private int _totalScore = 0;
        private bool _bonusRound = false;


        public Game(int frames = 10)
        {
            if (frames < 1 && frames > 10)
                throw new ArgumentOutOfRangeException("The number of frames must be between 1 and 10");
            _framesLeft = frames;
        }

        public void Roll(int pins)
        {
            if (_framesLeft == 0)
            {
                _shotsPerFrame.Add(Tuple.Create(pins, 0));
                _bonusRound = true;
            }
            else
            {
                if (_firstShotBuffer == -1)
                {
                    _firstShotBuffer = pins;
                }
                else
                {
                    _shotsPerFrame.Add(Tuple.Create(_firstShotBuffer, pins));
                    _firstShotBuffer = -1;
                    _framesLeft -= 1;
                }
            }
        }

        private int CalculateFrameScore(int roundIndex)
        {
            var currentFrame = _shotsPerFrame[roundIndex - 1];
            int currentFrameFirstShot = currentFrame.Item1;
            int currentFrameSecondShot = currentFrame.Item2;
            int nextFrameFirstShot = _shotsPerFrame[roundIndex].Item1;
            int roundScore = 0;
            if (currentFrameFirstShot == 10)
            {
                roundScore = currentFrameFirstShot + currentFrameSecondShot + nextFrameFirstShot;
            }
            else if (currentFrameFirstShot + currentFrameSecondShot == 10)
            {
                roundScore = currentFrameFirstShot + currentFrameSecondShot + nextFrameFirstShot;
            }
            else
            {
                roundScore = currentFrameFirstShot + currentFrameSecondShot;
            }
            Console.WriteLine(String.Format("{0} -> {1}", currentFrame, roundScore));
            return roundScore;
        }

        public void Score()
        {
            int numberOfRounds = _shotsPerFrame.Count;

            if (_bonusRound)
            {
                numberOfRounds -= 1;
            }

            for (int roundIndex = 1; roundIndex <= numberOfRounds; roundIndex++)
            {
                Console.WriteLine(String.Format("Round {0}:", roundIndex));
                _totalScore += CalculateFrameScore(roundIndex);
            }
            Console.WriteLine(String.Format("------> Total score: {0} <------", _totalScore));
        }
    }
}