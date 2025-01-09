using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IGenericDal<T> //Bu T parametresi bizim entitymize karşılık gelecek
    {
        void Insert(T t); //T türünde t parametresi almasını istiyoruz
        void Delete(T t);
        void Upgrade(T t);
        List<T> GetList();

        T GetByID(int id); // ID'ye göre veri getirme işlemi için 
        List<T> GetListByFilter(Expression<Func<T, bool>> filter);
    }
}
