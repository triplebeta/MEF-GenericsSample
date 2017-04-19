using Common;
using MyPersonModule;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyPersonModule
{
    //
    // http://csharperimage.jeremylikness.com/2010/07/using-hints-for-generic-mef-exports.html
    //


    [Export(typeof(IServiceLocatorHint))]
    public class PersonModuleHints : IServiceLocatorHint
    {
        [Import]
        public PersonRepository MyServiceInstance { get; set; }


        /// <summary>
        /// Checks if this hint is capable of creating an instance of the given type
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public bool ServicesType<T>()
        {
            //return true;
            // TODO Check if we can use this type. 
            return typeof(T).Equals(typeof(Poco.Person));
        }

        public IGenericRepository<T> GetServiceFor<T>()
        {
            if (ServicesType<T>())
            {
                return (IGenericRepository<T>)MyServiceInstance;
            }

            throw new NotSupportedException();
        }
    }
}
