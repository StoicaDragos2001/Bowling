﻿using Bowling.UtilityComponents;



namespace Game
{
    public class Player : IPlayer
    {
        private IStrategy Strategy = new NormalStrategy();
        private Score Score = new Score();
        public String StrategyName { get; set; }
        public String Name { get; set; }
        public int NumberOfFrames { get; set; }

        public Player(String name)
        {
            Name = name;
        }

        public void Roll(int pins)
        {
            Score.InsertValue(pins);
        }

        public void DisplayScore()
        {
            Score.Display();
        }

        public void CalculateScore()
        {
            Score.Calculate();
        }

        public int GetTotalScore()
        {
            return Score.GetTotalScore();
        }

        public void SetStrategy(IStrategy strategy)
        {
            Strategy = strategy;
            StrategyName = Strategy.Name;
        }

        public void SimulateRolls()
        {
            var generatedRolls = Strategy.GenerateRolls();
            var firstRoll = generatedRolls.Item1;
            var secondRoll = generatedRolls.Item2;

            if (Score.IsFinished)
            {
                Roll(firstRoll);
            }
            else
            {
                Roll(firstRoll);
                Roll(secondRoll);
            }
        }
    }
}