using mascota.entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mascota.datos
{
    public interface IMascotaRepositorio
    {
        Task<Mascota> CrearMascota(Mascota mascota);
        Task<Mascota> EditarMascota(Mascota mascota);
        Task<bool> EliminarMascota(int Id);
        Task<Mascota> ObtenerMascota(int Id);
        Task<List<Mascota>> ObtenerMascotas();
    }
}