namespace GreyWizard.Abstractions;

public interface IWizard
{
    public void YouShallNotPass(bool conditionToPass, string? narration = default);
    public void ThrowHimIntoTheAbyss(bool conditionToNotThrowMyselfIntoTheAbyss, string? narration = default);
    public bool HasStoriesToTell();
    public IReadOnlyCollection<IStory> TellStories();
    public void ForgetMyStories();
}
