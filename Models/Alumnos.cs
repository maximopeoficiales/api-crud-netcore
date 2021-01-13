using System;
using System.Collections.Generic;

namespace WebApiTest.Models
{
    public partial class Alumnos
    {
        public Alumnos()
        {
            Notas = new HashSet<Notas>();
            Pagos = new HashSet<Pagos>();
        }

        public string Codalumno { get; set; }
        public string Apealumno { get; set; }
        public string Nomalumno { get; set; }
        public string Codesp { get; set; }
        public string Colegio { get; set; }
        public string Eliminado { get; set; }

        public Especialidad CodespNavigation { get; set; }
        public ICollection<Notas> Notas { get; set; }
        public ICollection<Pagos> Pagos { get; set; }
    }
}
