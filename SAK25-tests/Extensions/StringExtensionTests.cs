namespace SAK25_tests;
using SAK25;
using SAK25.Extensions;

public class StringExtensionTests
{
    [SetUp]
    public void Setup()
    {
        SAK25.Init(42069);
    }

    [Test]
    public void IsANumber_WithNumberCharacter_ReturnsTrue()
    {
        char number = '5';
        Assert.That(number.IsANumber(), Is.True); // Use Assert.That with Is.True
    }

    [Test]
    public void IsANumber_WithNonNumberCharacter_ReturnsFalse()
    {
        char nonNumber = 'A';
        Assert.That(nonNumber.IsANumber(), Is.False); // Use Assert.That with Is.False
    }

    [Test]
    public void IsEmailAddress_WithValidEmail_ReturnsTrue()
    {
        string email = "test@example.com";
        Assert.That(email.IsEmailAddress(), Is.True); // Use Assert.That with Is.True
    }

    [Test]
    public void IsEmailAddress_WithInvalidEmail_ReturnsFalse()
    {
        string email = "not-an-email";
        Assert.That(email.IsEmailAddress(), Is.False); // Use Assert.That with Is.False
    }

    [Test]
    public void Minified_WithSpacesAndNewlines_RemovesWhitespace()
    {
        string text = "Hello \n World \t!";
        string result = text.Minified();
        Assert.That(result, Is.EqualTo("HelloWorld!")); // Use Assert.That with Is.EqualTo
    }

    [Test]
    public void Fill_WithStringAndSize_FillsCorrectly()
    {
        string text = "Test";
        string result = text.Fill(6, "*");
        Assert.That(result, Is.EqualTo("Test**")); // Use Assert.That with Is.EqualTo
    }

    [Test]
    public void AsStream_WithString_ReturnsMemoryStream()
    {
        string text = "Hello";
        using var stream = text.AsStream();
        Assert.That(stream.Length, Is.EqualTo(text.Length)); // Use Assert.That with Is.EqualTo
    }
}

