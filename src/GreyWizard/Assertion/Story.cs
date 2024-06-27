using GreyWizard.Abstractions;

namespace GreyWizard.Assertion;

public class Story : IStory
{
    private readonly string Narration;

    public Story(string? narration) => Narration = narration ?? "Something went wrong...";

    public string WriteDownTheWords() => Narration;
}
