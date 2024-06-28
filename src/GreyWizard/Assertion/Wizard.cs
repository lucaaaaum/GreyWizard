using System.Collections.ObjectModel;
using GreyWizard.Abstractions;
using GreyWizard.Exceptions;

namespace GreyWizard.Assertion;

public class Wizard : IWizard
{
    private readonly IPenAndPaper penAndPaper;
    private readonly List<IStory> _stories = [];

    public IReadOnlyCollection<IStory> Stories => new ReadOnlyCollection<IStory>(_stories);
    public bool HasStoriesToTell => _stories.Any(); 

    public Wizard(IPenAndPaper penAndPaper) => this.penAndPaper = penAndPaper;

    public void YouShallNotPass(bool conditionToPass, string? narration = default)
    {
        if (conditionToPass)
            return;
        _stories.Add(penAndPaper.WriteNewStory(narration ?? "Something went wrong..."));
    }

    public void ThrowHimIntoTheAbyss(bool conditionToNotThrowMyselfIntoTheAbyss, string? narration = default)
    {
        if (conditionToNotThrowMyselfIntoTheAbyss)
            return;
        if (narration is null)
            throw new WizardThrownIntoTheAbyssException();
        else
            throw new WizardThrownIntoTheAbyssException(narration);
    }

    public void ForgetMyStories() => _stories.Clear();
}
