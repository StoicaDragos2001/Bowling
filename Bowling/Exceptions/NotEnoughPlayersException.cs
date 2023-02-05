namespace Bowling.Exceptions
{
    internal class NotEnoughPlayersException : Exception
    {
        public NotEnoughPlayersException(string message) : base(message)
        {

        }
    }
}
