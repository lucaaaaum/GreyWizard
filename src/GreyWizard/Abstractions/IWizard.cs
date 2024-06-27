namespace GreyWizard.Abstractions;

public interface IWizard
{
    public void YouShallNotPass(bool conditionToPass, string? message);
    public void ThrowHimIntoTheAbyss(bool conditionToNotThrowMyselfIntoTheAbyss, string? message);
    public bool HasStoriesToTell();
    public IReadOnlyCollection<IStory> TellStories();
    public void ForgetMyStories();
}
