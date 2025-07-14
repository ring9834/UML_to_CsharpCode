namespace UML_to_CsharpCode
{
    public interface IVehicle
    {
        void Drive();
    }

    public class Truck : IVehicle // Realization
    {
        public void Drive()
        {
            Console.WriteLine("Truck is driving");
        }
    }
}
