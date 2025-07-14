namespace UML_to_CsharpCode
{
    public class Person
    {
        // Association: Person has a reference to Car
        // The Person class has a property OwnedCar that references a Car object, indicating an association.
        public Car OwnedCar { get; set; }

        // Association: One-to-many association
        // Multiplicity such as one-to-many can be implemented using collections
        public List<Car> OwnedCars { get; set; } = new List<Car>();
    }

    public class Car
    {
        public string Model { get; set; }
    }
}
