using Common;
using MyPersonModule;
using MyPersonModule.Poco;
using MyCustomerModule;
using MyCustomerModule.Poco;
using System.ComponentModel.Composition.Hosting;
using System;

namespace MEF_OpenGenericTester
{
    class Program
    {
        // Using example from: http://csharperimage.jeremylikness.com/2010/07/using-hints-for-generic-mef-exports.html
        static void Main(string[] args)
        {
            Console.WriteLine("Example of how to load generic modules using MEF");
            Console.WriteLine("================================================");

            Console.WriteLine("Registering types from this assembly");
            // Register our own type
            var thisProgramCatalog = new TypeCatalog(typeof(Runner));
            var commonCatalog = new AssemblyCatalog(typeof(ServiceLocator).Assembly);

            // Register the new modules
            Console.WriteLine("Registering modules");
            var myPersonModuleCatalog = new AssemblyCatalog(typeof(PersonRepository).Assembly);
            var myCustomerModuleCatalog = new AssemblyCatalog(typeof(CustomerRepository).Assembly);

            // Aggregate all catalogs and create a container from them
            var aggrContainer = new AggregateCatalog(thisProgramCatalog, commonCatalog, myPersonModuleCatalog, myCustomerModuleCatalog);
            var container = new CompositionContainer(aggrContainer);

            // Have MEF create an instance of the runner and inject the dependencies.
            var runner = container.GetExportedValue<Runner>();

            Console.WriteLine("\nTesting Person repository");
            Person person = new MyPersonModule.Poco.Person();
            runner.ProcessClass(person);

            Console.WriteLine("Testing Customer repository");
            Customer customer = new MyCustomerModule.Poco.Customer();
            runner.ProcessClass(customer);

            Console.WriteLine("\nPress any key...");
            Console.ReadKey();
        }
    }
}
