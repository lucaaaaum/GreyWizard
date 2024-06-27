using System.Collections.ObjectModel;
using GreyWizard.Abstractions;
using GreyWizard.Exceptions;

namespace GreyWizard.Assertion;

public class Wizard : IWizard
{
    private readonly IPenAndPaper penAndPaper;
    private readonly List<IStory> _stories = [];

    public Wizard(IPenAndPaper penAndPaper) => this.penAndPaper = penAndPaper;
    
    public void YouShallNotPass(bool conditionToPass, string? message)
    {
        if (conditionToPass)
            return;
        _stories.Add(penAndPaper.WriteNewStory(message));
    }
    
    public void ThrowHimIntoTheAbyss(bool conditionToNotThrowMyselfIntoTheAbyss, string? message)
    {
        if (conditionToNotThrowMyselfIntoTheAbyss)
            return;
        if (message is null)
            throw new WizardThrownIntoTheAbyssException();
        else
            throw new WizardThrownIntoTheAbyssException(message);
    }

    public bool HasStoriesToTell() => _stories.Any();

    public IReadOnlyCollection<IStory> TellStories() => new ReadOnlyCollection<IStory>(_stories);
    
    public void ForgetMyStories() => _stories.Clear();
}
