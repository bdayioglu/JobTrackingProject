using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Concrete.EntityFrameworkCore.Contexts;
using DataAccess.Interfaces;
using Entities.Interfaces;

namespace DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfGenericRepository<Tablo> : IGenericDal<Tablo>
        where Tablo : class, ITablo, new()
    {
        public List<Tablo> GetirHepsi()
        {
          
            using var context = new JobTrackingContext();
            return context.Set<Tablo>().ToList();
        }

        public Tablo GetirIdile(int id)
        {
            using var context = new JobTrackingContext();
            return context.Set<Tablo>().Find(id);
        }

        public void Guncelle(Tablo tablo)
        {
            using var context = new JobTrackingContext();
            context.Set<Tablo>().Update(tablo);
            context.SaveChanges();
        }

        public void Kaydet(Tablo tablo)
        {
            using var context = new JobTrackingContext();
            context.Set<Tablo>().Add(tablo);
            context.SaveChanges();
        }

        public void Sil(Tablo tablo)
        {
            using var context = new JobTrackingContext();
            context.Set<Tablo>().Remove(tablo);
            context.SaveChanges();
        }
    }
}
