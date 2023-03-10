using Game;
using System.Reflection;

namespace BowlingUnitTests
{
    [TestClass]
    public class ScoreTests
    {
        [TestMethod]
        public void CanInsertForLastBonus_BonusIsUsed_ReturnsFalse()
        {
            //Arrange
            var score = new Score();

            //Act
            var result = score.CanInsertForLastBonus();

            //Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void InsertValue_InsertValueIsCalled_InsertsInTheCorrectFrames()
        {
            var score = new Score();
            score.InsertValue(5);
            Assert.AreEqual(5, score.GetPoints(0, 0));
            score.InsertValue(3);
            Assert.AreEqual(3, score.GetPoints(0, 1));
            score.InsertValue(7);
            Assert.AreEqual(7, score.GetPoints(1, 0));
        }

        [TestMethod]
        public void Calculate_NoSpecials_GeneratedCorrectScore()
        {
            var score = new Score();
            score.InsertValue(5);
            score.InsertValue(3);
            score.InsertValue(7);
            score.InsertValue(2);
            score.IsFinished = true;
            score.Calculate();
            Assert.AreEqual(17, score.TotalScore);
        }

        [TestMethod]
        public void Calculate_Strike_GeneratedCorrectScore()
        {
            var score = new Score();
            score.InsertValue(10);
            score.InsertValue(3);
            score.InsertValue(7);
            score.InsertValue(2);
            score.IsFinished = true;
            score.Calculate();
            Assert.AreEqual(29, score.TotalScore);
        }

        [TestMethod]
        public void Calculate_Spare_GeneratedCorrectScore()
        {
            var score = new Score();
            score.InsertValue(7);
            score.InsertValue(3);
            score.InsertValue(7);
            score.InsertValue(2);
            score.IsFinished = true;
            score.Calculate();
            Assert.AreEqual(26, score.TotalScore);
        }

        [TestMethod]
        public void Bonus_LastFrameIsStrike_ValidBonus()
        {
            var score = new Score();
            for (var shot = 0; shot < 18; shot++)
            {
                score.InsertValue(0);
            }
            score.InsertValue(10);
            score.InsertValue(3);
            score.InsertValue(7);
            Assert.AreEqual(7, score.Bonus);
        }

        [TestMethod]
        public void Bonus_LastFrameIsSpare_ValidBonus()
        {
            var score = new Score();
            for (var shot = 0; shot < 18; shot++)
            {
                score.InsertValue(0);
            }
            score.InsertValue(7);
            score.InsertValue(3);
            score.InsertValue(7);
            Assert.AreEqual(7, score.Bonus);
        }

        [TestMethod]
        public void Bonus_LastFrameIsNormal_InvalidBonus()
        {
            var score = new Score();
            for (var shot = 0; shot < 18; shot++)
            {
                score.InsertValue(0);
            }
            score.InsertValue(3);
            score.InsertValue(3);
            score.InsertValue(7);
            Assert.AreEqual(-1, score.Bonus);
        }
    }
}