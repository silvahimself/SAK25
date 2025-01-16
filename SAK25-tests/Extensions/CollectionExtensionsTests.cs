using NUnit.Framework.Legacy;
using SAK25.Extensions;
using S = SAK25.Extensions.CollectionExtensions;
namespace SAK25.Tests
{
    [TestFixture]
    public class CollectionExtensionsTests
    {
        [Test]
        public void RandomElement_WithEnumerable_ReturnsElement()
        {
            var list = new List<int> { 1, 2, 3, 4 };
            var randomElement = list.RandomElement();
            Assert.That(list, Does.Contain(randomElement));
        }

        [Test]
        public void RandomElement_WithArray_ReturnsElement()
        {
            int[] array = { 1, 2, 3, 4 };
            var randomElement = array.RandomElement();
            Assert.That(Array.Exists(array, x => x == randomElement), Is.True);
        }

        [Test]
        public void Fill_WithCharacterArray_FillsArray()
        {
            char[] array = new char[5];
            array.Fill('X');
            Assert.That(Array.TrueForAll(array, x => x == 'X'), Is.True);
        }

        [Test]
        public void Fill_With2DCharacterArray_FillsArray()
        {
            char[][] array = [new char[3], new char[3]];
            array.Fill(2, 3, 'Y');

            foreach (var row in array)
            {
                Assert.That(Array.TrueForAll(row, x => x == 'Y'), Is.True);
            }
        }

        [Test]
        public void ParseArray_WithStrings_ParsesToIntArray()
        {
            var data = new List<string> { "1", "2", "3" };
            var result = data.ParseArray();
            Assert.That(result, Is.EqualTo(new[] { 1, 2, 3 }).AsCollection);
        }

        [Test]
        public void GroupedInDictionary_WithIntegers_GroupsCorrectly()
        {
            int[] numbers = { 1, 2, 2, 3 };

            var result = S.GroupedInDictionary(numbers);

            Assert.Multiple(() =>
            {
                Assert.That(result[1], Is.EqualTo(1));
                Assert.That(result[2], Is.EqualTo(2));
                Assert.That(result[3], Is.EqualTo(1));
            });
        }
    }
}
