namespace Game
{
    public interface IPlayer
    {
        public void Roll(int pins);
        public void SetStrategy(IStrategy strategy);
        public void SimulateRolls();
        public void DisplayScore();
        public void CalculateScore();
        public int GetTotalScore();
        public String Name { get; set; }
        public String StrategyName { get; set; }
    }
}