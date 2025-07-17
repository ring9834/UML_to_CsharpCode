# Relationships in UML Reflected on C# code
In Unified Modeling Language (UML), relationships between classes are used to model how objects interact or are structured in a system. These relationships are then reflected in C# code through specific programming constructs. Below is the explanation of the key UML relationships—Association, Aggregation, Composition, Generalization (Inheritance), Realization, and Dependency and how they are implemented in C# code.

## Association
It represents a general relationship between two classes where objects of one class can be related to objects of another class. It is often a "has-a" or "uses-a" relationship, depicted as a solid line between classes, sometimes with multiplicity such as 1..*, 0..1.

<div style="text-align: center; width:100%;">
  <img src="https://upload.wikimedia.org/wikipedia/commons/thumb/9/93/Uml_classes_en.svg/1920px-Uml_classes_en.svg.png" alt="UML" width="300">
</div>

### C# Implementation
Associations are typically implemented using fields, properties, or collections to reference objects of another class.

Code Example and Explanation
```sh
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
```

## Aggregation
A special type of association representing a "whole-part" relationship where the part can exist independently of the whole. It is depicted with a hollow diamond on the "whole" side.

Similar to association, aggregation is implemented using fields or properties, but ***the lifecycle of the "part" is not controlled by the "whole." The part can be shared among multiple wholes.***

### C# Implementation
The Department class has a list of Employee objects. The Employee objects can exist independently and may belong to multiple departments (if the model allows). The hollow diamond in UML emphasizes that the Employee is not destroyed when the Department is destroyed.

So, we can find an important point that there is a <span style="color:red">logic</span> in the relationships when comparing Agregation and Association even though the code form looks same in both.

Code Example and Explanation
```sh
    public class Department
    {
        // Aggregation: Department contains Employees, but Employees can exist independently
        // the lifecycle of the Employee is not controlled by the Department.
        // The Employee can be shared among multiple Departments.
        public List<Employee> Employees { get; set; } = new List<Employee>();
    }

    public class Employee
    {
        public string Name { get; set; }
    }
```

## Composition
It is a stronger form of aggregation where the part cannot exist without the whole, and depicted with a filled diamond on the "whole" side, indicating that the lifecycle of the part is tied to the whole. 

Composition is implemented similarly to aggregation but with tighter control over the part’s lifecycle. ***The part is typically created and destroyed along with the whole.***

### C# Implementation
The House class creates and manages Room objects. If the House is destroyed, the Room objects are also destroyed (as they are tightly coupled). The rooms list is <span style="color:red">private</span>, and a read-only view is exposed to prevent external modification, reinforcing the lifecycle dependency.

Code Example and Explanation
```sh
    public class House
    {
        // Composition: House contains Rooms, and Rooms cannot exist without the House
        // The part is typically created and destroyed along with the whole
        // The rooms list is private, and a read-only view is exposed to prevent external modification
        private List<Room> rooms = new List<Room>();

        public House()
        {
            rooms.Add(new Room("Living Room"));
            rooms.Add(new Room("Kitchen"));
        }

        public IReadOnlyList<Room> Rooms => rooms.AsReadOnly();
    }

    public class Room
    {
        public string Name { get; set; }

        public Room(string name)
        {
            Name = name;

        }
    }
```

## Generalization (Inheritance)
It represents an "is-a" relationship where a child class inherits from a parent class. It is depicted with a solid line and a hollow triangle pointing to the parent class. 

### C# Implementation
The Dog class inherits from the Animal class, indicating that a Dog is an Animal. The ***virtual*** and ***override*** keywords allow polymorphic behavior, a common feature in inheritance.

Code Example and Explanation
```sh
    public class Animal
    {
        public string Name { get; set; }
        public virtual void MakeSound() { Console.WriteLine("Some sound"); }
    }

    public class Dog : Animal // Generalization
    {
        public override void MakeSound() { Console.WriteLine("Woof"); }
    }
```


## Realization
It represents a relationship where a class implements an interface or realizes an abstract specification. It is depicted with a dashed line and a hollow triangle pointing to the interface. 

### C# Implementation
The Car class realizes the IVehicle interface by implementing its Drive method. This reflects the UML realization relationship, where the class commits to fulfilling the contract defined by the interface.

Code Example == Interface ==
```sh
    public class Animal
    {
        public string Name { get; set; }
        public virtual void MakeSound() { Console.WriteLine("Some sound"); }
    }

    public class Dog : Animal // Generalization
    {
        public override void MakeSound() { Console.WriteLine("Woof"); }
    }
```

Code Example == Abstract ==
Animal is an abstract class with one abstract method Speak() and one concrete method Eat().
Dog and Cat realize Animal by overriding the abstract Speak() method.
```sh
    // Abstract class (cannot be instantiated)
    public abstract class Animal
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
    public class Dog : Animal
    {
        // Implementing the abstract method
        public override void Speak()
        {
            Console.WriteLine($"{Name} says: Woof!");
        }
    }

    // Another concrete class
    public class Cat : Animal
    {
        public override void Speak()
        {
            Console.WriteLine($"{Name} says: Meow!");
        }
    }
```

## Dependency
Represents a weaker relationship where one class depends on another, typically because it uses it temporarily, for example, as a method parameter or local variable. It is depicted with a dashed line and an arrow.

### C# Implementation
The Order class depends on the Logger class because it uses it in the ProcessOrder method. However, Order does not maintain a reference to Logger, reflecting the ***temporary*** nature of the dependency.

Code Example and Explanation
```sh
    public class Order
    {
        // Dependency: Order uses Logger temporarily
        public void ProcessOrder(Logger logger)
        {
            logger.Log("Order processed");
        }
    }

    public class Logger
    {
        public void Log(string message)
        {
            Console.WriteLine(message);
        }
    }
```
