using Common;
using MyCustomerModule.Poco;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyCustomerModule
{
    [Export]
    public class CustomerRepository : MyGenericRepo<Customer>
    {
        public override void Save(Customer entity)
        {
            Console.WriteLine("Saving a customer");
        }
    }
}
