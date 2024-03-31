namespace LPlus;

public delegate string DetermineLanguageCodeDelegate();
public delegate string BuildTranslationKeyDelegate(string languageCode, string text);
public delegate string? TryGetTranslationDelegate(string translationKey);
public delegate string GetTranslationFallbackDelegate(string translationKey);
public delegate void MissingTranslationKeyOutputDelegate(string translationKey);