using Castle.Core.Resource;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Refactoring_Examples.Applying_SOLID_DependencyInversion.Dependency_Injection_Patterns_and_UML_Equivalents
{
    // COMPLETE EXAMPLE: All DI patterns mapped to UML
    public interface ILogger
    {
        void Log(string message);
    }

    //public class DatabaseLogger : ILogger { /* implements */ }

    //public class FileLogger : ILogger { /* implements */ }

    // --- PATTERN 1: Constructor Injection (ASSOCIATION) ---
    public class OrderService
    {
        // UML: Association (strong, persistent)
        private readonly ILogger _logger;

        public OrderService(ILogger logger) // Dependency Injection
        {
            _logger = logger; // Association established
        }

        public void PlaceOrder(Order order)
        {
            _logger.Log("Placing order"); // Uses association
        }
    }

    // --- PATTERN 2: Property Injection (ASSOCIATION with optional multiplicity) ---
    public class CustomerService
    {
        // UML: Association (optional, can be null)
        public ILogger Logger { get; set; } // Property Injection

        public void UpdateCustomer(Customer customer)
        {
            Logger?.Log("Updating customer"); // Optional association
        }
    }

    // --- PATTERN 3: Method Injection (DEPENDENCY) ---
    public class ReportGenerator
    {
        // UML: Dependency (temporary, parameter-based)
        public string GenerateReport(ILogger logger) // Method Injection
        {
            logger.Log("Generating report"); // Temporary dependency
            return "Report content";
        }
    }

    // --- PATTERN 4: Service Locator (Association + Dependency) ---
    public class PaymentProcessor
    {
        // UML: Association to IServiceProvider (persistent relationship)
        private readonly IServiceProvider _serviceProvider;

        public PaymentProcessor(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider; // ⭐ ASSOCIATION established here
                                                // PaymentProcessor "has-a" reference to IServiceProvider
                                                // This is a persistent structural relationship
        }

        public void ProcessPayment(Payment payment)
        {
            //// UML: Dependency on ILogger (transient relationship)
            //var logger = _serviceProvider.GetService<ILogger>();
            //// ⭐ DEPENDENCY created here (temporary, local variable)
            //// PaymentProcessor "uses" ILogger temporarily

            //logger.Log("Processing payment");

            //// After this method ends, the 'logger' variable is gone
            //// but _serviceProvider remains (association persists)
        }
    }

    // Supporting classes
    public class Order { /* Order properties */ }
    public class Customer { }
    public class Report { }
    public class Payment { }

}
