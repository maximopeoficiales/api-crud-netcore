using System;
using System.Collections.Generic;

namespace WebApiTest.Models
{
    public partial class Pagos
    {
        public int Codpago { get; set; }
        public string Codalumno { get; set; }
        public string Semestre { get; set; }
        public int Ncuota { get; set; }
        public int Monto { get; set; }
        public DateTime? Fecha { get; set; }
        public string Pagado { get; set; }
        public DateTime? FechaPago { get; set; }

        public Alumnos CodalumnoNavigation { get; set; }
    }
}
