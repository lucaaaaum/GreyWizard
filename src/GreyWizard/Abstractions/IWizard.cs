namespace GreyWizard.Abstractions;

public interface IWizard
{
    public void YouShallNotPass(bool conditionToPass, string? message = default);
    public void ThrowHimIntoTheAbyss(bool conditionToNotThrowMyselfIntoTheAbyss, string? message = default);
    public bool HasStoriesToTell();
    public IReadOnlyCollection<IStory> TellStories();
    public void ForgetMyStories();
}
