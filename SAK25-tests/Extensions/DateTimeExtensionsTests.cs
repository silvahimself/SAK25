using SAK25.Extensions;

namespace SAK25.Tests
{
    [TestFixture]
    public class DateTimeExtensionsTests
    {
        [Test]
        public void YearsElapsed_WithPastDate_ReturnsCorrectYears()
        {
            DateTime pastDate = new DateTime(2000, 1, 1);
            int elapsedYears = pastDate.YearsElapsed();
            Assert.That(elapsedYears, Is.EqualTo(DateTime.Now.Year - 2000));
        }
    }
}
