using LPlus;

namespace Tests;

[TestClass]
public class ConfigureTryGetTranslationTests
{
    private static readonly Dictionary<string, string?> Translations = new()
    {
        ["L:Static Class Invocation"] = "Static Class Invocation",
        ["L:Hola"] = "Hello",
        ["L:Hello"] = "Привет"
    };

    [TestInitialize]
    public void ConfigureTest()
    {
        TR.Configure(options =>
        {
            options.TryGetTranslationDelegate = key => Translations.GetValueOrDefault(key, null);
        });
    }

    [TestMethod]
    [DataRow("Static Class Invocation", "Static Class Invocation")]
    [DataRow("Hola", "Hello")]
    [DataRow("Hello", "Привет")]
    public void ConfigureTryGetTranslation_FromVariable_StaticClassInvocation(
        string inputText, 
        string expectedTranslation)
    {
        var translation = TR.L+inputText;
        
        
        Assert.AreEqual(expectedTranslation, translation);
    }

    [TestMethod]
    [DataRow("Static Class Invocation", "Static Class Invocation")]
    [DataRow("Hola", "Hello")]
    [DataRow("Hello", "Привет")]
    public void ConfigureTryGetTranslation_FromVariable_NewInstanceInvocation(
        string inputText, 
        string expectedTranslation)
    {
        var l = new L();
        var translation = l+inputText;
        
        
        Assert.AreEqual(expectedTranslation, translation);
    }
}