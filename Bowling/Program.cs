namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bowling = Game.GetInstance(4);

            bowling.Play();

            bowling.DisplayScoreBoard();
        }
    }
}