using GreyWizard.Abstractions;

namespace GreyWizard.Assertion;

public class PenAndPaper : IPenAndPaper
{
    public IStory WriteNewStory(string narration) => new Story(narration);
}
