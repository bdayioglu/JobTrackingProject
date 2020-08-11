using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Concrete.EntityFrameworkCore.Contexts;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfBildirimRepository : EfGenericRepository<Bildirim>, IBildirimDal
    {
        public List<Bildirim> GetirOkunmayanlar(int AppUserId)
        {
            using var context = new JobTrackingContext();
            return context.Bildirimler.Where(I => I.AppUserId == AppUserId && !I.Durum).ToList();
        }

        public int GetirOkunmayanSayisiileAppUserId(int AppUserId)
        {
            using var context = new JobTrackingContext();
            return context.Bildirimler.Count(I => I.AppUserId == AppUserId && !I.Durum);
        }
    }
}
