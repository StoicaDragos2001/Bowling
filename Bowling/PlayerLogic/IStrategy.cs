namespace Bowling.PlayerLogic
{
    public interface IStrategy
    {
        public Tuple<int, int> GenerateRolls();
        public string Name { get; }
    }
}