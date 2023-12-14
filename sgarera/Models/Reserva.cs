using System;
using System.Collections.Generic;

namespace sgarera.Models
{
    public partial class Reserva
    {
        public int Idreserva { get; set; }
        public DateTime? Fchreserva { get; set; }
        public long? Idvajres { get; set; }
    }
}
