namespace Bowling.Exceptions
{
    internal class AddedMorePlayersThanDeclaredException : Exception
    {
        public AddedMorePlayersThanDeclaredException(string message) : base(message)
        {

        }
    }
}
