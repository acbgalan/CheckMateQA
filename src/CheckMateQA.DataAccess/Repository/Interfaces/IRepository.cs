using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CheckMateQA.DataAccess.Repository.Interfaces
{
    public interface IRepository<T> where T : class
    {
        void Add(T entity);
        T Get(T entity);
        List<T> GetAll();
        void Update(T entity);
        void Delete(int id);
        void Delete(T entity);
        bool Exits(int id);
        int Save();
    }
}
