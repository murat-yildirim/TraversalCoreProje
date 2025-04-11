using DataAccessLayer.Abstract;
using DataAccessLayer.Concrete;
using DataAccessLayer.Repository;
using EntityLayer.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.EntityFramework
{
    public class EfReservationDal : GenericRepository<Reservation>, IReservationDal
    {
        public List<Reservation> GetListWithReservationByAccepted(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Onaylandı" && x.AppUserId == id).ToList();
            }
        }

        public List<Reservation> GetListWithReservationByPrevious(int id)
        {
            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Geçmiş Rezervasyon" && x.AppUserId == id).ToList();
            }
        }

        public List<Reservation> GetListWithReservationByWaitAprroval(int id)
        {

            using (var context = new Context())
            {
                return context.Reservations.Include(x => x.Destination).Where(x => x.Status == "Onay Bekliyor" && x.AppUserId == id).ToList();
            }
        }

        public void ChangeStatusApproved(int id)
        {
            using (var context = new Context())
            {
                var values = context.Reservations.Find(id);
                values.Status = "Onaylandı";
                context.Update(values);
                context.SaveChanges();
            }
        }

        public void ChangeStatusPassivation(int id)
        {
            using (var context = new Context())
            {
                var values = context.Reservations.Find(id);
                values.Status = "İptal Edildi";
                context.Update(values);
                context.SaveChanges();
            }
        }
    }
}
