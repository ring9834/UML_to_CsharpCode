namespace UML_to_CsharpCode
{
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
}
