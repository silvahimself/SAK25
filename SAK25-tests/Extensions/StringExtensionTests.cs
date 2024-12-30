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
    public void RandomString_IsCorrect_Length()
    {
        string filled = "".FillRandom(new RandomStringParams { Size = 100 });
        Assert.That(filled.Length, Is.EqualTo(100));
    }
    
    [Test]
    public void Fill_IsCorrect_Length()
    {
        string filled = "".Fill(100, "ABC");
        Assert.That(filled.Length, Is.EqualTo(100));
    }
}

