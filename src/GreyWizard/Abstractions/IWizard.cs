namespace GreyWizard.Abstractions;

public interface IWizard
{
    public IReadOnlyCollection<IStory> Stories { get; }
    public bool HasStoriesToTell { get; }

    public void YouShallNotPass(bool conditionToPass, string? narration = default);
    public void ThrowHimIntoTheAbyss(bool conditionToNotThrowMyselfIntoTheAbyss, string? narration = default);
    public void ForgetMyStories();
}
