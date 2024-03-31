using LPlus;

namespace Tests;

[TestClass]
public class ConfigureTranslationKeyTests
{
    [TestMethod]
    [DataRow("!234")]
    [DataRow("$$$$")]
    public void ConfigureTranslationKey_FromVariable_StaticClassInvocation(string delimiter)
    {
        TR.Configure(options =>
        {
            options.BuildTranslationKeyDelegate = (languageCode, text) => $"{languageCode}{delimiter}{text}";
        });
        const string inputText = "Static Class Invocation";
        
        
        var translation = TR.L+inputText;
        
        
        Assert.AreEqual($"L{delimiter}Static Class Invocation", translation);
    }

    [TestMethod]
    [DataRow("!234")]
    [DataRow("$$$$")]
    public void ConfigureTranslationKey_FromVariable_NewInstanceInvocation(string delimiter)
    {
        TR.Configure(options =>
        {
            options.BuildTranslationKeyDelegate = (languageCode, text) => $"{languageCode}{delimiter}{text}";
        });
        const string inputText = "New Instance Invocation";
        var l = new L();

        
        var translation = l+inputText;
        
        
        Assert.AreEqual($"L{delimiter}New Instance Invocation", translation);
    }

    [TestMethod]
    [DataRow("!234")]
    [DataRow("$$$$")]
    public void ConfigureTranslationKey_WithConst_StaticClassInvocation(string delimiter)
    {
        TR.Configure(options =>
        {
            options.BuildTranslationKeyDelegate = (languageCode, text) => $"{languageCode}{delimiter}{text}";
        });
        
        
        var translation = TR.L+"Static Class Invocation";
        
        
        Assert.AreEqual($"L{delimiter}Static Class Invocation", translation);
    }

    [TestMethod]
    [DataRow("!234")]
    [DataRow("$$$$")]
    public void ConfigureTranslationKey_WithConst_NewInstanceInvocation(string delimiter)
    {
        TR.Configure(options =>
        {
            options.BuildTranslationKeyDelegate = (languageCode, text) => $"{languageCode}{delimiter}{text}";
        });
        var l = new L();

        
        var translation = l+"New Instance Invocation";
        
        
        Assert.AreEqual($"L{delimiter}New Instance Invocation", translation);
    }
}