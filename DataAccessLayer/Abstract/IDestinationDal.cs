using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Abstract
{
    public interface IDestinationDal : IGenericDal<Destination>
    {
       
        public Destination GetDestinationWithGuide(int id);
        public List<Destination> GetLast4Destinations();
    }

    //void Insert(Destination destination);
    //void Delete(Destination destination);      // BU METHODLARI HER SEFERİNDE KULLANMAK YERİNE IGenericDal'dan
    // referans alıyoruz ve oradaki yazılan methodların hepsine erişmiş oluyoruz
    //void Update(Destination destination);
    // List<Destination> GetList();

}
