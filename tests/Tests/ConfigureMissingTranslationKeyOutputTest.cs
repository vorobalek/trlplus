using LPlus;

namespace Tests;

[TestClass]
public class ConfigureMissingTranslationKeyOutputTest
{
    [TestCleanup]
    public void TestCleanup()
    {
        TR.Configure(_ => { });
    }

    [TestMethod]
    public void MissingTranslationKeyOutput_Callback_Called()
    {
        var missingKeys = new List<string>();
        var expectedMissingKeys = new[]
        {
            "en|ABCDEFG",
            "en|en|ABCDEFG",
            "en|en|en|ABCDEFG",
            "en|qwerty",
        };
        TR.Configure(options =>
        {
            options.DetermineLanguageCodeDelegate = () => "en";
            options.BuildTranslationKeyDelegate = (languageCode, text) => $"{languageCode}|{text}";
            options.MissingTranslationKeyOutputDelegate = translationKey => missingKeys.Add(translationKey);
        });
        
        
        var foo = TR.L+"ABCDEFG";
        foo = TR.L+foo;
        var l = new L();
        foo = l+foo;
        foo = l+"qwerty";


        CollectionAssert.AreEquivalent(expectedMissingKeys, missingKeys);
    }
}