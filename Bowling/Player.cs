namespace Game
{
    public class Player
    {
        private List<Frame> shotsPerFrame = new List<Frame>();
        public String Name { get; set; }

        public Player(String name)
        {
            Name = name;
        }


    }
}