using System;
using System.Collections.Generic;

namespace mascota.entidades
{
    public partial class Mascota
    {
        public int IdMascota { get; set; }
        public string Nombre { get; set; }
        public int Edad { get; set; }
        public string Descripcion { get; set; }
    }
}
