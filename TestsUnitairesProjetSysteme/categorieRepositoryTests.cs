using Microsoft.VisualStudio.TestTools.UnitTesting;
using Restaurant;

namespace Test_TDD
{
    [TestClass]
    public class categorieRepositoryTests
    {
        [TestMethod]
        public void GetAll_StateUnderTest_ExpectedBehavior()
        {
            // Arrange
            var categorieRepository = new categorieRepository();

            // Act
            var result = categorieRepository.GetAll();

            // Assert
            Assert.Fail();
        }
    }
}
