using mascota.datos;
using mascota.entidades;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Linq;

namespace mascota.servicios
{
    public class MascotaServicio : IMascotaServicio
    {
        private readonly IMascotaRepositorio repositorio;

        public MascotaServicio(IMascotaRepositorio repositorio)
        {
            this.repositorio = repositorio;
        }

        public async Task<List<Mascota>> ObtenerMascotas()
        {
            return await repositorio.ObtenerMascotas();
        }

        public async Task<Mascota> ObtenerMascota(int Id)
        {
            return await repositorio.ObtenerMascota(Id);
        }

        public async Task<Mascota> CrearMascota(Mascota mascota)
        {
            if (mascota.Nombre == null && mascota.Edad == 0 && mascota.Descripcion == null)
            {
                return null;
            }

            return await repositorio.CrearMascota(mascota);
        }

        public async Task<Mascota> EditarMascota(int Id, Mascota mascota)
        {

            if (mascota.Nombre == null && mascota.Edad == 0 && mascota.Descripcion == null)
            {
                return null;
            }


            return await this.repositorio.EditarMascota(mascota);
        }

        public async Task<bool> EliminarMascota(int Id)
        {
            return await repositorio.EliminarMascota(Id);
        }
    }
}
