using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    public interface IServiceLocator
    {
        IGenericRepository<T> GetServiceFor<T>();
    }

    [Export(typeof(IServiceLocator))]
    public class ServiceLocator : IServiceLocator
    {
        [ImportMany(AllowRecomposition = true)]
        public IServiceLocatorHint[] Hints { get; set; }

        public IGenericRepository<T> GetServiceFor<T>()
        {
            var serviceHint = (from hint in Hints
                               where hint.ServicesType<T>()
                               select hint).FirstOrDefault();

            if (serviceHint == null)
            {
                throw new NotSupportedException();
            }

            return serviceHint.GetServiceFor<T>();
        }
    }
}
