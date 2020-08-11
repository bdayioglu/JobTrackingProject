using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DataAccess.Concrete.EntityFrameworkCore.Contexts;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfRaporRepository : EfGenericRepository<Rapor>, IRaporDal
    {
        public Rapor GetirGorevileId(int id)
        {
            using var context = new JobTrackingContext();
            return context.Raporlar.Include(I => I.Gorev).ThenInclude(I=>I.Aciliyet).Where(I => I.Id == id).FirstOrDefault();
        }

        public int GetirRaporSayisi()
        {
            using var context = new JobTrackingContext();
            return context.Raporlar.Count();
        }

        public int GetirRaporSayisiileAppUserId(int id)
        {
            using var context = new JobTrackingContext();
            var result= context.Gorevler.Include(I => I.Raporlar).Where(I => I.AppUserId == id);

            return result.SelectMany(I => I.Raporlar).Count();
        }
    }
}
