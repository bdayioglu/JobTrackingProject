using System;
using System.Collections.Generic;
using System.Text;
using Entities.Concrete;

namespace DataAccess.Interfaces
{
    public interface IBildirimDal : IGenericDal<Bildirim>
    {
        List<Bildirim> GetirOkunmayanlar(int AppUserId);
        int GetirOkunmayanSayisiileAppUserId(int AppUserId);
    }
}
