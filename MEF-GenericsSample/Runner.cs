using Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MEF_OpenGenericTester
{
    /// <summary>
    /// Wrapper so that we can use MEF to compose an instance of it so that it will
    /// solve the Import properties and inject an instance of a Locator.
    /// </summary>
    [Export]
    public class Runner
    {
        [Import]
        public IServiceLocator Locator { get; set; }

        public void ProcessClass<T>(T item)
        {
            var service = Locator.GetServiceFor<T>();
            service.Save(item);
        }
    }
}
