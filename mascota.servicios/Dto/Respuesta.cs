using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mascota.servicios.Dto
{
    public class Respuesta
    {
        public Respuesta()
        {
            this.Exito = 0;
        }

        public int Exito { get; set; }
        public object Resultado { get; set; }
        public string Mensaje { get; set; } 
    }
}
