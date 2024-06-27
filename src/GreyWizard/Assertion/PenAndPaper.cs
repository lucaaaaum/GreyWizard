using GreyWizard.Abstractions;

namespace GreyWizard.Assertion;

public class PenAndPaper : IPenAndPaper
{
    public IStory WriteNewStory(string? message) => new Story(message);
}
