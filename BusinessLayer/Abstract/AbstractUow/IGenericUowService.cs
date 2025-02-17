using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Abstract.AbstractUow
{
    public interface IGenericUowService<T>
    {
        void TInsert(T t); //T türünde t parametresi almasını istiyoruz
        void TUpgrade(T t);

        void TMultiUpdate(List<T> t);

        T TGetByID(int id);
    }
}
