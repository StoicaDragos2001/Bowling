using Bowling.Exceptions;
using Bowling.UtilityComponents;
using Microsoft.VisualBasic;
using System.Runtime.CompilerServices;

namespace Game
{
    public class Score
    {
        public int Bonus = -1;
        public bool IsFinished = false;
        private List<Frame> Frames = new List<Frame>();
        private List<int> ScorePerFrame = new List<int>();
        private int CurrentFrameIndex = 0;
        private bool IsCalculated = false;
        
        public int TotalScore { get; set; }

        public Score()
        {
            InitializeFrames(ValueConstants.NumberOfFrames);
        }

        public int GetPoints(int frameIndex, int shotIndex)
        {
            if(shotIndex == 0)
                return Frames[frameIndex].FirstShot;
            if(shotIndex == 1)
                return Frames[frameIndex].SecondShot;
            throw new ShotIndexOutOfBoundsException(MessageConstants.ShotIndexMessage);
        }

        public void InitializeFrames(int numberOfFrames)
        {
            for (var frameIndex = 0; frameIndex < numberOfFrames; frameIndex++)
                Frames.Add(new Frame());
        }

        public void InsertValue(int pins)
        {
            if (Frames[CurrentFrameIndex].CanInsert())
            {
                Frames[CurrentFrameIndex].AddScore(pins);
            }
            else
            {
                if (CurrentFrameIndex == ValueConstants.NumberOfFrames - 1)
                {
                    InsertForLastBonus(pins);
                    IsFinished = true;
                }
                else
                {
                    InsertForNextFrame(pins);
                }
            }
        }

        public bool CanInsertForLastBonus()
        {
            var lastFrame = Frames[ValueConstants.NumberOfFrames - 1];
            return Bonus == -1 && (lastFrame.IsSpare() || lastFrame.IsStrike());
        }

        public void Calculate()
        {
            if (IsFinished)
            {
                var numFramesExceptLast = ValueConstants.NumberOfFrames - 1;
                var points = 0;
                for (var frameIndex = 0; frameIndex < numFramesExceptLast; frameIndex++)
                {
                    points = CalculateFrameScore(frameIndex);
                    ScorePerFrame.Add(points);
                    TotalScore += points;
                }
                points = CalculateLastFrameScore(numFramesExceptLast);
                ScorePerFrame.Add(points);
                TotalScore += points;
                IsCalculated = true;
            }
            else
            {
                throw new GameNotFinishedException("Not all the players finished their rolls");
            }
        }

        public void Display()
        {
            if (!IsCalculated)
                Calculate();

            if (IsFinished)
            {

                var numFramesExceptLast = ValueConstants.NumberOfFrames - 1;
                for (var frameIndex = 0; frameIndex < numFramesExceptLast; frameIndex++)
                {
                    var frameShots = Frames[frameIndex];
                    Console.WriteLine(String.Format(MessageConstants.ScoreDisplayFormat, frameShots.FirstShot, frameShots.SecondShot, ScorePerFrame[frameIndex]));
                }
                var lastFrameShots = Frames[numFramesExceptLast];
                Console.WriteLine(String.Format(MessageConstants.ScoreDisplayFormat, lastFrameShots.FirstShot, lastFrameShots.SecondShot, ScorePerFrame[numFramesExceptLast]));
                if (Bonus != -1)
                {
                    Console.WriteLine("Last bonus: " + Bonus);
                }
                Console.WriteLine("Total score: " + TotalScore);
                Console.WriteLine();
            }
            else
            {
                throw new GameNotFinishedException("Not all the players finished their rolls");
            }
        }

        public int GetTotalScore()
        {
            if (IsFinished)
            {
                return TotalScore;
            }
            else
            {
                throw new ArgumentOutOfRangeException("The game isn't finished");
            }
        }

        private void InsertForLastBonus(int pins)
        {
            if (CanInsertForLastBonus() == true)
            {
                Bonus = pins;
            }
        }

        private void InsertForNextFrame(int pins)
        {
            CurrentFrameIndex += 1;
            Frames[CurrentFrameIndex].AddScore(pins);
        }

        private int CalculateFrameScore(int frameIndex)
        {
            var frameShots = Frames[frameIndex];
            var nextFrameShots = Frames[frameIndex + 1];
            if (frameShots.IsStrike())
            {
                return frameShots.FirstShot + frameShots.SecondShot + nextFrameShots.FirstShot;
            }
            else if (frameShots.IsSpare())
            {
                return frameShots.FirstShot + frameShots.SecondShot + nextFrameShots.FirstShot;
            }
            return frameShots.FirstShot + frameShots.SecondShot;
        }

        private int CalculateLastFrameScore(int frameIndex)
        {
            var frameShots = Frames[frameIndex];
            if (Bonus != -1)
            {
                return frameShots.FirstShot + frameShots.SecondShot + Bonus;
            }
            return frameShots.FirstShot + frameShots.SecondShot;
        }

    }
}   