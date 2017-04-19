using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Common
{
    /// <summary>
    /// Interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T>
    {
        T Get();

        void Save(T entity);
    }

    /// <summary>
    /// Implementation of the interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class MyGenericRepo<T> : IGenericRepository<T>
    {
        public T Get()
        {
            throw new NotImplementedException();
        }

        public virtual void Save(T entity)
        {
            Console.WriteLine("Saving default");
        }
    }
}
