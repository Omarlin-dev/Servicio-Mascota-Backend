using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mascota.servicios.Dto
{
    public class MascotaDto
    {
        public MascotaDto()
        {
            this.IdMascota = 0;
        }

        public int IdMascota { get; set; }

        [Required]
        public string Nombre { get; set; }

        [Required]
        public int Edad { get; set; }

        [Required]
        public string Descripcion { get; set; }
    }
}
