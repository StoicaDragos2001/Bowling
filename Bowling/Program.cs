namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game();
            game.Roll(1);
            game.Roll(2);
            game.Roll(3);
            game.Roll(4);
        }
    }
}