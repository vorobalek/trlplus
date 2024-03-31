namespace LPlus;

public sealed class TROptions
{
    public DetermineLanguageCodeDelegate DetermineLanguageCodeDelegate { get; set; } = () => "L";
    public BuildTranslationKeyDelegate BuildTranslationKeyDelegate { get; set; } = (languageCode, text) => $"{languageCode}:{text}";
    public TryGetTranslationDelegate TryGetTranslationDelegate { get; set; } = _ => null;
    public GetTranslationFallbackDelegate GetTranslationFallbackDelegate { get; set; } = translationKey => translationKey;
    public MissingTranslationKeyOutputDelegate MissingTranslationKeyOutputDelegate { get; set; } = _ => { };
}