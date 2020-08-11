using System;
using System.Collections.Generic;
using System.Text;
using DataAccess.Interfaces;
using Entities.Concrete;

namespace DataAccess.Concrete.EntityFrameworkCore.Repositories
{
    public class EfAciliyetRepository : EfGenericRepository<Aciliyet>, IAciliyetDal
    {
    }
}
