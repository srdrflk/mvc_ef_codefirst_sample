using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace mvc_ef_codefirst_sample.Models.Managers
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Kisiler> Kisiler { get; set; }
        public DbSet<Adresler> Adresler { get; set; }

        public DatabaseContext()
        {
            Database.SetInitializer(new VeriTabaniOlusturucu());
        }
    }

    public class VeriTabaniOlusturucu : CreateDatabaseIfNotExists<DatabaseContext>
    {
        protected override void Seed(DatabaseContext context)
        {  
            //Kişiler ekleniyor
            for (int i = 0; i < 10; i++)
            {
                Kisiler k = new Kisiler();
                k.Ad = FakeData.NameData.GetFemaleFirstName();
                k.Soyad = FakeData.NameData.GetSurname();
                k.Yas = FakeData.NumberData.GetNumber(18, 90);
                context.Kisiler.Add(k);
            }
            context.SaveChanges();

            List<Kisiler> tumKisiler = context.Kisiler.ToList();

            //Adresler ekleniyor
            foreach (Kisiler item in tumKisiler)
            {
                for (int i = 0; i < FakeData.NumberData.GetNumber(1,4); i++)
                {
                    Adresler a = new Adresler();
                    a.AdresTanim = FakeData.PlaceData.GetAddress();
                    a.Kisi = item;
                    context.Adresler.Add(a);
                }
            }
            context.SaveChanges();
        }
    }
}