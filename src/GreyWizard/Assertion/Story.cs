using GreyWizard.Abstractions;

namespace GreyWizard.Assertion;

public class Story : IStory
{
    public string Narration { get; private set; }

    public Story(string narration) => Narration = narration;
}
