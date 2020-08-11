using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using Entities.Interfaces;

namespace Entities.Concrete
{
    public class AppUser : IdentityUser<int>, ITablo
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Picture { get; set; }


        public List<Bildirim> Bildirimler { get; set; }
        public List<Gorev> Gorevler { get; set; }
    }
}
