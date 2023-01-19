namespace Game
{
    public class Game
    {
        private int _frames;
        private List<Tuple<int, int>> _shots = new List<Tuple<int, int>>();
        private int _buffer = -1;   // -1 for first opportunity in frame
        private int _totalScore = 0;
        private bool _bonusRound = false;


        public Game(int frames = 10)
        {
            if (frames < 1 && frames > 10)
                throw new ArgumentOutOfRangeException("The number of frames must be between 1 and 10");
            _frames = frames;
        }

        public void Roll(int pins)
        {
            if(_frames == 0)
            {
                _shots.Add(Tuple.Create(pins, 0));
                _bonusRound = true;
            }
            else
            {
                if (_buffer == -1)
                {
                    _buffer = pins;
                }
                else
                {
                    _shots.Add(Tuple.Create(_buffer, pins));
                    _buffer = -1;
                    _frames -= 1;
                    Console.WriteLine(_frames);
                }
            }
        }

        public void Score()
        {
            int roundScore = 0;
            int numberOfRounds = _shots.Count;

            Console.WriteLine("Number of rounds: " + numberOfRounds);

            if (_bonusRound)
            {
                numberOfRounds -= 1;
            }

            for (int indexRound = 1; indexRound <= numberOfRounds; indexRound++)
            {
                Console.WriteLine(String.Format("Round {0}:", indexRound));
                if (_shots[indexRound - 1].Item1 == 10)
                    roundScore = _shots[indexRound - 1].Item1 + _shots[indexRound - 1].Item2 + _shots[indexRound].Item1;
                else if (_shots[indexRound - 1].Item1 + _shots[indexRound - 1].Item2 == 10)
                    roundScore = _shots[indexRound - 1].Item1 + _shots[indexRound - 1].Item2 + _shots[indexRound].Item1;
                else
                    roundScore = _shots[indexRound - 1].Item1 + _shots[indexRound - 1].Item2;
                Console.WriteLine(String.Format("{0} -> {1}", _shots[indexRound - 1], roundScore));
                _totalScore += roundScore;
                roundScore = 0;
            }
            Console.WriteLine(String.Format("------> Total score: {0} <------", _totalScore));
        }
    }
}