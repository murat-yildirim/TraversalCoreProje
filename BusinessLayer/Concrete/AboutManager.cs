using BusinessLayer.Abstract;
using DataAccessLayer.Abstract;
using EntityLayer.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.Concrete
{
    public class AboutManager : IAboutService
    {
        // BURADA BİR FİELD TANIMLANDI BURADA DEPENDENCY İNJECTİON KULLANILACAK
        // AMACI GELEN ENTİTYİ KARŞILAYACAK HANGİ ENTİTY GELDİYSE O ENTİTYE AİT REPOLARA ULAŞMAK İÇİN
        // CONSTRUCTİON BİR METHOD TANIMLIYORUZ BİR SINIFTA TANIMLANAN METHODUN SINIFIN AYNI İSMİYLE TANIMLANMASI

        // BU YAPININ İSMİ DEPENDENCY İNJECTİON OLARAK ADLANDIRILIYOR
        IAboutDal _aboutDal;
        public AboutManager(IAboutDal aboutDal)
        {
            _aboutDal = aboutDal;
        }
        //----------------------------------------------

        // BURADAKİ ÇALIŞMA MANTIĞI IAboutDal ERİŞİYOR ORADAN IGenericDal 'A ERİŞİYOR VE ORADAKİ EKLE SİL METHODLARINI KULLANIYOR
        public void TAdd(About t)
        {
           _aboutDal.Insert(t); //BURADA EKLEME İŞLEMİNE ULAŞTIĞIMIZ GİBİ
        }

        public void TDelete(About t)
        {
            _aboutDal.Delete(t);
        }

        public About TGetByID(int id)
        {
            throw new NotImplementedException();
        }

        public List<About> TGetList()
        {
            return _aboutDal.GetList();
        }

        public void TUpdate(About t)
        {
            _aboutDal.Upgrade(t);
        }
    }
}
