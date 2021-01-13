using System;
using System.Collections.Generic;

namespace WebApiTest.Models
{
    public partial class Notas
    {
        public int Nroreg { get; set; }
        public string Codalumno { get; set; }
        public string Codcurso { get; set; }
        public string Semestre { get; set; }
        public int? Ntrabajo { get; set; }
        public int? Nparcial { get; set; }
        public int? Nfinal { get; set; }
        public string Eliminado { get; set; }

        public Alumnos CodalumnoNavigation { get; set; }
        public Cursos CodcursoNavigation { get; set; }
    }
}
