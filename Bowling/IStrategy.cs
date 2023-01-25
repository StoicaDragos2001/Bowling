namespace Game
{
    public interface IStrategy
    {
        public Tuple<int, int> GenerateRolls();
        public String Name { get; }
    }
}