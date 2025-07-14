namespace UML_to_CsharpCode
{
    public class Animal
    {
        public string Name { get; set; }
        public virtual void MakeSound() { Console.WriteLine("Some sound"); }
    }

    public class Dog : Animal // Generalization
    {
        public override void MakeSound() { Console.WriteLine("Woof"); }
    }
}
