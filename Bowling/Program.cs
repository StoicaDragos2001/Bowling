namespace Game
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var bowling = new BowlingGame(10, 1);
            bowling.AddPlayer(new Player("John"));
            //bowling.AddPlayer(new Player("Rob"));

            
            Console.WriteLine("Number of players: " + bowling.NumberOfPlayers);
            bowling.ShowPlayers();

            /*var frame = new Frame(3);
            frame.AddSecondScore(4);
            Console.WriteLine(frame.FirstShot);
            Console.WriteLine(frame.SecondShot);*/

            bowling.Roll(2);
            bowling.Roll(3);

            bowling.Roll(5);
            bowling.Roll(5);

            bowling.Roll(3);
            bowling.Roll(1);

            bowling.Roll(10);
            bowling.Roll(5);

            bowling.Roll(3);
            bowling.Roll(4);

            bowling.Roll(5);
            bowling.Roll(1);

            bowling.Roll(4);
            bowling.Roll(6);

            bowling.Roll(8);
            bowling.Roll(2);

            bowling.Roll(4);
            bowling.Roll(6);

            bowling.Roll(5);
            bowling.Roll(5);

            bowling.Roll(4);

            bowling.DisplayScore();





            /*var game = new Game(10);
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

            game.Score();*/
        }
    }
}