using System;
using System.Collections.Generic;
using System.Text;
using Entities.Interfaces;

namespace Entities.Concrete
{
    public class Aciliyet: ITablo
    {
        public int Id { get; set; }
        public string Tanim { get; set; }

        public List<Gorev> Gorevler { get; set; }
    }
}
