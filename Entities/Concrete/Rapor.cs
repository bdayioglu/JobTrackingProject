using System;
using System.Collections.Generic;
using System.Text;
using Entities.Interfaces;

namespace Entities.Concrete
{
    public class Rapor : ITablo
    {
        public int Id { get; set; }
        public string Tanim { get; set; }
        public string Detay { get; set; }

        public int GorevId { get; set; }
        public Gorev Gorev { get; set; }
    }
}
