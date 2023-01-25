namespace Bowling.PlayerLogic
{
    public interface IPlayer
    {
        public void Roll(int pins);
        public void SetStrategy(IStrategy strategy);
        public void Play();
        public void DisplayScore();
        public void CalculateScore();
        public int GetTotalScore();
        public string Name { get; set; }
        public string StrategyName { get; set; }
    }
}