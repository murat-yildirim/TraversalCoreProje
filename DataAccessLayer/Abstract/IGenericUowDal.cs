using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericUowDal <T> where T : class
    {
        void Insert(T t); //T türünde t parametresi almasını istiyoruz
        void Upgrade(T t);

        void MultiUpdate(List<T> t);

        T GetByID(int id);
       
    }
}
