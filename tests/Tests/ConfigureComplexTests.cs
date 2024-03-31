using LPlus;

namespace Tests;

[TestClass]
public class ConfigureComplexTests
{
    private static Dictionary<string, string> _translations = new()
    {
        ["en:Static Class Invocation"] = "Static Class Invocation",
        ["en:Hola"] = "Hello",
        ["ru:Hello"] = "Привет"
    };

    [TestMethod]
    [DataRow("en", "Static Class Invocation", "Static Class Invocation")]
    [DataRow("en", "Hola", "Hello")]
    [DataRow("ru", "Hello", "Привет")]
    [DataRow("L", "unavailable", "DEFAULT")]
    public void ConfigureTranslationKey_FromVariable_StaticClassInvocation(
        string languageCode,
        string inputText, 
        string expectedTranslation)
    {
        TR.Configure(options =>
        {
            options.DetermineLanguageCodeDelegate = () => languageCode;
            options.TryGetTranslationDelegate = key => _translations.GetValueOrDefault(key, "DEFAULT");
        });
        
        
        var translation = TR.L+inputText;
        
        
        Assert.AreEqual(expectedTranslation, translation);
    }

    [TestMethod]
    [DataRow("en", "Static Class Invocation", "Static Class Invocation")]
    [DataRow("en", "Hola", "Hello")]
    [DataRow("ru", "Hello", "Привет")]
    [DataRow("L", "unavailable", "DEFAULT")]
    public void ConfigureTranslationKey_FromVariable_NewInstanceInvocation(
        string languageCode,
        string inputText, 
        string expectedTranslation)
    {
        TR.Configure(options =>
        {
            options.DetermineLanguageCodeDelegate = () => languageCode;
            options.TryGetTranslationDelegate = key => _translations.GetValueOrDefault(key, "DEFAULT");
        });
        var l = new L();
        
        
        var translation = l+inputText;
        
        
        Assert.AreEqual(expectedTranslation, translation);
    }
}