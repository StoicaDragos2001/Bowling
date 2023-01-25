using Game;

namespace UnitTests
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
    }
}