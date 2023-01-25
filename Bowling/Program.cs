namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bowling = Game.GetInstance(3);

            bowling.Play();

            bowling.DisplayScoreBoard();
        }
    }
}