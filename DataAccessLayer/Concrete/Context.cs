using EntityLayer.Concrete;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete
{                              
    public class Context : IdentityDbContext<AppUser,AppRole,int> //DBcontext sınıfından miras alıyoruz burada tanımlanmış olan komutları üzerinde çalıştığımız context sınıfında kullanabilmek için
    {                       //Dbcontext sınıfı yerine IdentityDbContext ve paremetreleri tanımlıyoruz
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) //Kod içinde bir değerin protected olarak tanımlanması; o değere, bulunduğu class  ve ondan türetilen diğer sınıflar içinden erişilebilir olduğunu göstermektedir.
        {
            optionsBuilder.UseSqlServer("server=DESKTOP-363RU31\\SQLEXPRESS;database=TraversalDB;integrated security=true;");
        }


        public DbSet<About> Abouts { get; set; }
        public DbSet<About2> About2s { get; set; }
        public DbSet<Contact> Contacts { get; set; }
        public DbSet<ContactUs> ContactUses { get; set; }
        public DbSet<Destination> Destinations { get; set; }
        public DbSet<Feature> Features { get; set; }
        public DbSet<Feature2> Feature2s { get; set; }
        public DbSet<Guide> Guides { get; set; }
        public DbSet<Newsletter> Newsletters { get; set; }
        public DbSet<SubAbout> SubAbouts { get; set; }
        public DbSet<Testimonial> Testimonials { get; set; }
        public DbSet<Comment> Comments { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<Announcement> Announcements { get; set; }
        public DbSet<Account> Accounts { get; set; }



    }
}
