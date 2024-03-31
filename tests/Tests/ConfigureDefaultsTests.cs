using LPlus;

namespace Tests;

[TestClass]
public class ConfigureDefaultsTests
{
    [TestInitialize]
    public void ConfigureTest()
    {
        TR.Configure(_ => { });
    }
    
    [TestMethod]
    public void ConfigureDefaults_StaticClassInvocation_FromVariable()
    {
        const string inputText = "Static Class Invocation";
        
        
        var translation = TR.L+inputText;
        
        
        Assert.AreEqual("L:Static Class Invocation", translation);
    }

    [TestMethod]
    public void ConfigureDefaults_NewInstanceInvocation_FromVariable()
    {
        const string inputText = "New Instance Invocation";
        var l = new L();
        
        
        var translation = l+inputText;
        
        
        Assert.AreEqual("L:New Instance Invocation", translation);
    }
    [TestMethod]
    public void ConfigureDefaults_StaticClassInvocation_WithConst()
    {
        var translation = TR.L+"Static Class Invocation";
        
        
        Assert.AreEqual("L:Static Class Invocation", translation);
    }

    [TestMethod]
    public void ConfigureDefaults_NewInstanceInvocation_WithConst()
    {
        var l = new L();
        
        
        var translation = l+"New Instance Invocation";
        
        
        Assert.AreEqual("L:New Instance Invocation", translation);
    }
}