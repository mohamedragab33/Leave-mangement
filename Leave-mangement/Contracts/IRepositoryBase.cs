using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Leave_mangement.Contracts
{
   public interface IRepositoryBase <T> where T: class
    {
        ICollection<T> FindAll();
        T FindById(int ID);
        bool create(T entity);
        bool delete(T entity);

        bool update(T entity);
        bool save();
    }
}
