using mascota.entidades;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace mascota.servicios
{
    public interface IMascotaServicio
    {
        Task<Mascota> CrearMascota(Mascota mascota);
        Task<Mascota> EditarMascota(int Id, Mascota mascota);
        Task<bool> EliminarMascota(int Id);
        Task<List<Mascota>> ObtenerMascotas();
        Task<Mascota> ObtenerMascota(int Id);
    }
}