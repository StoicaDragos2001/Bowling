namespace Bowling.Exceptions
{
    internal class TriedToRollMoreTimesThanAllowedException : Exception
    {
        public TriedToRollMoreTimesThanAllowedException(string message) : base(message)
        {

        }
    }
}
