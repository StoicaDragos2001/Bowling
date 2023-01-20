namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var game = new Game(10);
            game.Roll(2);
            game.Roll(4);

            game.Roll(4);
            game.Roll(6);

            game.Roll(3);
            game.Roll(2);

            game.Roll(10);
            game.Roll(2);

            game.Roll(3);
            game.Roll(1);

            game.Roll(10);
            game.Roll(10);

            game.Roll(10);
            game.Roll(4);

            game.Roll(5);
            game.Roll(3);

            game.Roll(10);
            game.Roll(6);

            game.Roll(5);
            game.Roll(5);

            game.Roll(8);

            game.Score();
        }
    }
}