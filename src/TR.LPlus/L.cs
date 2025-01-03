namespace LPlus;

public sealed class L
{
    private readonly DateTime? _dateTimeComponent;
    private readonly DateTimeOffset? _dateTimeOffsetComponent;

    public L()
    {
    }
    
    private L(DateTime dateTimeComponent)
    {
        _dateTimeComponent = dateTimeComponent;
    }
    
    private L(DateTimeOffset dateTimeOffsetComponent)
    {
        _dateTimeOffsetComponent = dateTimeOffsetComponent;
    }
    
    public static string operator +(L l, string text)
    {
        if (l._dateTimeComponent is not null) return l._dateTimeComponent.Value.ToString(text);
        if (l._dateTimeOffsetComponent is not null) return l._dateTimeOffsetComponent.Value.ToString(text);
        
        var translation = GetTranslation(text, out var key);
        if (translation is not null) return translation;
        
        TR.Options.MissingTranslationKeyOutputDelegate(key);
        translation = TR.Options.GetTranslationFallbackDelegate(key);
        return translation;
    }
    
    public static L operator +(L _, DateTime dateTime)
    {
        return new L(dateTime);
    }
    
    public static L operator +(L _, DateTimeOffset dateTimeOffset)
    {
        return new L(dateTimeOffset);
    }
    
    public static bool operator &(L l, string text)
    {
        var translation = GetTranslation(text, out _);
        return translation is not null;
    }

    // ReSharper disable once InconsistentNaming
    private static string? GetTranslation(string text, out string key)
    {
        var languageCode = TR.Options.DetermineLanguageCodeDelegate();
        key = TR.Options.BuildTranslationKeyDelegate(languageCode, text);
        var translation = TR.Options.TryGetTranslationDelegate(key);
        return translation;
    }
}