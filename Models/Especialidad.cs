using System;
using System.Collections.Generic;

namespace WebApiTest.Models
{
    public partial class Especialidad
    {
        public Especialidad()
        {
            Alumnos = new HashSet<Alumnos>();
        }

        public string Coddesp { get; set; }
        public string Nomesp { get; set; }
        public int Costo { get; set; }

        public ICollection<Alumnos> Alumnos { get; set; }
    }
}
