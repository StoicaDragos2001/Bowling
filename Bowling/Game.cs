namespace Game
{
    public class Game
    {
        private int _frames;
        private List<Tuple<int, int>> _scoreboard = new List<Tuple<int, int>>();
        private int _buffer = -1;   // -1 for first opportunity in frame


        public Game(int frames = 2)
        {
            if (frames < 1 && frames > 10)
                throw new ArgumentOutOfRangeException("The number of frames must be between 1 and 10");
            _frames = frames;
        }

        public void Roll(int pins)
        {
            if (_buffer == -1)
            {
                _buffer = pins;

            }
            else
            {
                _scoreboard.Add(Tuple.Create(_buffer, pins));
                _buffer = -1;
                _frames -= 1;
            }
            if (_frames == 0)
                Score();
        }

        private void Score()
        {
            for (int i = 1; i <= _scoreboard.Count; i++)
            {
                Console.WriteLine(String.Format("Round {0}:", i));
                Console.WriteLine(String.Format("{0} -> {1}", _scoreboard[i - 1], (_scoreboard[i - 1].Item1 + _scoreboard[i - 1].Item2)));
            }
        }
    }
}