using System;
using System.Collections.Generic;

namespace sgarera.Models
{
    public partial class Vajilla
    {
        public Vajilla()
        {
            
        }

        public Vajilla(int idelemento, string? codigoelemento, string? descripcionelemento, string? nombreelemento, int cantidadelemento)
        {
            Idelemento = idelemento;
            Cantidadelemento = cantidadelemento;
            Codigoelemento = codigoelemento;
            Descripcionelemento = descripcionelemento;
            Nombreelemento = nombreelemento;
        }

        public int Idelemento { get; set; }
        public int? Cantidadelemento { get; set; }
        public string? Codigoelemento { get; set; }
        public string? Descripcionelemento { get; set; }
        public string? Nombreelemento { get; set; } 


    }
}
