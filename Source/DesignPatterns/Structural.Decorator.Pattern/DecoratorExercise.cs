namespace Udemy_Learnings.Source.DesignPatterns.Structural.Decorator.Pattern;


public static class DecoratorExercise
{
    public static void DragonMain(string[] args)
    {
        var dragon = new Dragon();
        dragon.Age = 3;
        Console.WriteLine(dragon.Fly());
        Console.WriteLine(dragon.Crawl());
    }
}


public interface IFlyingAnimal
{
    public string Fly();
}
public interface ICrawlingAnimal
{
    public string Crawl();
}

public class Bird
{
    public int Age { get; set; }

    public string Fly()
    {
        return (Age < 10) ? "flying" : "too old";
    }
}

public class Lizard
{
    public int Age { get; set; }

    public string Crawl()
    {
        return (Age > 1) ? "crawling" : "too young";
    }
}

//either this is a bad example or decorator is really bad.
//storing 2 class instances inside a class??? Yes use all my memory please.
//This reminds me of a super class that has 100 instances of classes to do different things.
//But I see the point of decorator, sometimes I want to add a functionality to a class and I don't know the implementation of the other classes.
public class Dragon
{
    private Bird bird = new Bird();
    private Lizard lizard = new Lizard();
    private int _age;

    //When the dragon age is changed, then we have to propagate the change to the bird and lizard, because we call their methods
    public int Age
    {
        get { return _age; }
        set { _age = bird.Age = lizard.Age = value; }
    }

    public string Fly()
    {
        return bird.Fly();
    }

    public string Crawl()
    {
        return lizard.Crawl();
    }
}


//Doing this looks the same, but I had to implement the interfaces. Not always I can do that and even if I can, i would just be copy pasting stuff
public class DragonWithInterfaces : IFlyingAnimal, ICrawlingAnimal
{
    public int Age { get; set; }

    public string Fly()
    {
        return (Age < 10) ? "flying" : "too old";
    }

    public string Crawl()
    {
        return (Age > 1) ? "crawling" : "too young";
    }
}