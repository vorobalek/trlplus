namespace LPlus;

public sealed class L
{
    private readonly DateTime? _dateTimeComponent;

    public L()
    {
    }
    
    private L(DateTime dateTimeComponent)
    {
        _dateTimeComponent = dateTimeComponent;
    }
    
    public static string operator +(L l, string text)
    {
        if (l._dateTimeComponent is not null) return l._dateTimeComponent.Value.ToString(text);
        
        var languageCode = TR.Options.DetermineLanguageCodeDelegate();
        var key = TR.Options.BuildTranslationKeyDelegate(languageCode, text);
        var translation = TR.Options.TryGetTranslationDelegate(key);
        if (translation is not null) return translation;
        
        TR.Options.MissingTranslationKeyOutputDelegate(key);
        translation = TR.Options.GetTranslationFallbackDelegate(key);
        return translation;
    }
    
    public static L operator +(L _, DateTime dateTime)
    {
        return new L(dateTime);
    }
}