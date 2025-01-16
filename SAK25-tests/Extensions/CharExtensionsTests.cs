using SAK25.Extensions;

namespace SAK25.Tests
{
    [TestFixture]
    public class CharExtensionsTests
    {
        [Test]
        public void IsSpecialCharacter_WithSpecialCharacter_ReturnsTrue()
        {
            char specialChar = '@';
            Assert.That(specialChar.IsSpecialCharacter(), Is.True);
        }

        [Test]
        public void IsSpecialCharacter_WithAlphanumericCharacter_ReturnsFalse()
        {
            char alphanumeric = 'A';
            Assert.That(alphanumeric.IsSpecialCharacter(), Is.False);
        }
    }
}
