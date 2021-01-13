using System;
using System.Collections.Generic;

namespace WebApiTest.Models
{
    public partial class Cursos
    {
        public Cursos()
        {
            Notas = new HashSet<Notas>();
        }

        public string Codcurso { get; set; }
        public string Nomcurso { get; set; }
        public int? Nhoras { get; set; }
        public string Tipo { get; set; }
        public string Eliminado { get; set; }

        public ICollection<Notas> Notas { get; set; }
    }
}
