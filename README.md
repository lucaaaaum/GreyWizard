# GreyWizard
> You shall not pass!

## Description
This is a simple project to implement assertions throughout your code. Similar to FluentValidation, but without many of it's features. It is meant this way.

The idea behind it was to create some assertions that could guarantee the code does not reach a specified state. That and to make a Lord of the Rings reference. I'm not even that into Tolkien, but I couldn't get the pun out of my head.

So, about it's usage.

Don't want the user Id to be null? Make the wizard shout "You shall not pass!" and write a story about it, so you can inspect it later. 

Sometimes you *really* don't want the user Id to be null. Sometimes, all you want is for the Wizard to go down and beat the current state to death. That's when you make the Wizard throw himself into the abyss.

## Usage

After installing the package, you have access to some really interesting classes. The most important are these two:

* Wizard
* PenAndPaper

The Wizard is the main guy here. He is the one battling the program's state and writing it down as Stories. He has gone through a lot. Please don't judge him.

Pen and paper is just pen and paper. The Wizard uses it to write down his stories.

### YouShallNotPass(bool conditionToPass, string? narration = default)

#### Example:
```csharp
var penAndPaper = new PenAndPaper();
var wizard = new Wizard(penAndPaper);
wizard.YouShallNotPass(1 == 1, "Some sort of narration on why the state must be this");
```

#### Description:
When this method is used, there is an assertion being made. If it passes the test, then the program may proceed with it's natural course. If not, then the Wizard will write down the story so it can be read later. In both cases the program just continues.

### ThrowHimIntoTheAbyss(bool conditionToNotThrowMyselfIntoTheAbyss, string? narration = default)

#### Example:
```csharp
var penAndPaper = new PenAndPaper();
var wizard = new Wizard(penAndPaper);
wizard.ThrowHimIntoTheAbyss(false, "Some sort of narration on why the state must be this")
```

#### Description:
This is where things get interesting. See, there is still an assertion being made and, if the condition reveals itself to be true, the program continues. But, instead of writing down the story, the Wizard takes the battle to a whole new level: he jumps into the abyss to fight the current state and brings down the whole application with it!

Now, you may be thinking: why the hell would I want to crash the code?

And to that I answer: because it's easier to build CLI tools that way. I'm not saying you should apply this concept everywhere, but it is a way of doing things.
