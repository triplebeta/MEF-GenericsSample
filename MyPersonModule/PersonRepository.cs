using Common;
using MyPersonModule.Poco;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonModule
{
    [Export]
    public class PersonRepository : MyGenericRepo<Person>
    {
        public override void Save(Person entity)
        {
            Console.WriteLine("Saving person");
        }
    }
}
