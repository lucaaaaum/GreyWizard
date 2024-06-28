using GreyWizard.Abstractions;
using GreyWizard.Assertion;
using GreyWizard.Exceptions;

namespace GreyWizard.Test.Assertion;

[TestFixture]
public class WizardTest
{
    private IWizard _wizard;

    [SetUp]
    public void SetUp()
    {
        var penAndPaper = new PenAndPaper();
        _wizard = new Wizard(penAndPaper);
    }

    [Test]
    public void WriteOneStory()
    {
        var narration = "Two plus two must be five (we live in a society)";
        _wizard.YouShallNotPass(2 + 2 == 5, narration);
        Assert.That(_wizard.HasStoriesToTell());
        Assert.That(_wizard.TellStories().Count == 1);
        Assert.That(_wizard.TellStories().All(x => x.Narration == narration));
    }

    [Test]
    public void WriteMultipleStories()
    {
        var narration = "Dumb assertion lol";
        for (var i = 0; i < 10; i++)
            _wizard.YouShallNotPass(i == -1, narration);
        Assert.That(_wizard.HasStoriesToTell());
        Assert.That(_wizard.TellStories().Count == 10);
        Assert.That(_wizard.TellStories().All(x => x.Narration == narration));
    }

    [Test]
    public void WriteNoStory()
    {
        var narration = "This narration won't be used";
        _wizard.YouShallNotPass(1 == 1, narration);
        Assert.That(!_wizard.HasStoriesToTell());
        Assert.That(_wizard.TellStories().Count == 0);
    }

    [Test]
    public void WriteOneStoryAndPassTheOtherAssertion()
    {
        var narration = "I'm getting tired of writing these";
        _wizard.YouShallNotPass(1 == 2, narration);
        _wizard.YouShallNotPass(1 == 1, narration);
        Assert.That(_wizard.HasStoriesToTell());
        Assert.That(_wizard.TellStories().Count == 1);  
        Assert.That(_wizard.TellStories().All(x => x.Narration == narration));
    }

    [Test]
    public void WriteStoryWithoutMessage()
    {
        _wizard.YouShallNotPass(false);
        Assert.That(_wizard.HasStoriesToTell());
        Assert.That(_wizard.TellStories().Count == 1);
        Assert.That(_wizard.TellStories().All(x => x.Narration == "Something went wrong..."));
    }

    [Test]
    public void ThrowException() => Assert.Throws<WizardThrownIntoTheAbyssException>(() => _wizard.ThrowHimIntoTheAbyss(false));

    [Test]
    public void ForgetStories()
    {
        var narration = "I swear it's the last one";
        _wizard.YouShallNotPass(false, narration);
        Assert.That(_wizard.HasStoriesToTell());
        Assert.That(_wizard.TellStories().Count == 1);
        Assert.That(_wizard.TellStories().All(x => x.Narration == narration));
        _wizard.ForgetMyStories();
        Assert.That(!_wizard.HasStoriesToTell());
        Assert.That(_wizard.TellStories().Count == 0);
    }
}
