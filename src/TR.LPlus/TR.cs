namespace LPlus;

public static class TR
{
    public static readonly L L = new();
    internal static TROptions Options { get; private set; } = new();

    public static void Configure(Action<TROptions> configureAction)
    {
        Options = new TROptions();
        configureAction.Invoke(Options);
    }
}