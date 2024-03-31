using LPlus;

namespace Tests;

[TestClass]
public class ConfigureLanguageCodeTests
{
    [TestMethod]
    [DataRow("en")]
    [DataRow("ru")]
    public void ConfigureLanguageCode_FromVariable_StaticClassInvocation(string languageCode)
    {
        TR.Configure(options =>
        {
            options.DetermineLanguageCodeDelegate = () => languageCode;
        });
        const string inputText = "Static Class Invocation";
        
        
        var translation = TR.L+inputText;
        
        
        Assert.AreEqual($"{languageCode}:Static Class Invocation", translation);
    }

    [TestMethod]
    [DataRow("en")]
    [DataRow("ru")]
    public void ConfigureLanguageCode_FromVariable_NewInstanceInvocation(string languageCode)
    {
        TR.Configure(options =>
        {
            options.DetermineLanguageCodeDelegate = () => languageCode;
        });
        const string inputText = "New Instance Invocation";
        var l = new L();

        
        var translation = l+inputText;
        
        
        Assert.AreEqual($"{languageCode}:New Instance Invocation", translation);
    }

    [TestMethod]
    [DataRow("en")]
    [DataRow("ru")]
    public void ConfigureLanguageCode_WithConst_StaticClassInvocation(string languageCode)
    {
        TR.Configure(options =>
        {
            options.DetermineLanguageCodeDelegate = () => languageCode;
        });
        
        
        var translation = TR.L+"Static Class Invocation";
        
        
        Assert.AreEqual($"{languageCode}:Static Class Invocation", translation);
    }

    [TestMethod]
    [DataRow("en")]
    [DataRow("ru")]
    public void ConfigureLanguageCode_WithConst_NewInstanceInvocation(string languageCode)
    {
        TR.Configure(options =>
        {
            options.DetermineLanguageCodeDelegate = () => languageCode;
        });
        var l = new L();

        
        var translation = l+"New Instance Invocation";
        
        
        Assert.AreEqual($"{languageCode}:New Instance Invocation", translation);
    }
}