namespace UML_to_CsharpCode
{
    // Abstract class (cannot be instantiated)
    public abstract class Animall
    {
        public string Name { get; set; }

        // Abstract method (no body, must be implemented by derived class)
        public abstract void Speak();

        // Concrete method (optional override)
        public void Eat()
        {
            Console.WriteLine($"{Name} is eating.");
        }
    }

    // Concrete class that realizes the abstract class
    public class Dogg : Animall
    {
        // Implementing the abstract method
        public override void Speak()
        {
            Console.WriteLine($"{Name} says: Woof!");
        }
    }

    // Another concrete class
    public class Cat : Animall
    {
        public override void Speak()
        {
            Console.WriteLine($"{Name} says: Meow!");
        }
    }
}
