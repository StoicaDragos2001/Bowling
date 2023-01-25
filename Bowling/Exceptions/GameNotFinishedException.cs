namespace Bowling.Exceptions
{
    internal class GameNotFinishedException : Exception
    {
        public GameNotFinishedException(string message) : base(message)
        {

        }
    }
}
