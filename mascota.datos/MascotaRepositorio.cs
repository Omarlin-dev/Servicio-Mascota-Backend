using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using mascota.entidades;
using Microsoft.EntityFrameworkCore;

namespace mascota.datos
{
    public class MascotaRepositorio : IMascotaRepositorio
    {
        private readonly DbMascotaContext contexto;

        public MascotaRepositorio(DbMascotaContext contexto)
        {
            this.contexto = contexto;
        }

        public async Task<List<Mascota>> ObtenerMascotas()
        {
            return await contexto.Mascota.ToListAsync();
        }

        public async Task<Mascota> ObtenerMascota(int Id)
        {
            return await contexto.Mascota.FirstOrDefaultAsync(d => d.IdMascota == Id);
        }

        public async Task<Mascota> CrearMascota(Mascota mascota)
        {
            await contexto.Mascota.AddAsync(mascota);
            await contexto.SaveChangesAsync();
            return mascota;
        }

        public async Task<Mascota> EditarMascota(Mascota mascota)
        {
            contexto.Mascota.Update(mascota);
            await contexto.SaveChangesAsync();
            return mascota;
        }

        public async Task<bool> EliminarMascota(int Id)
        {
            var mascota = await ObtenerMascota(Id);

            if(mascota == null)
            {
                return false;
            }

            contexto.Entry(mascota).State = EntityState.Deleted;
            int filaAfectada = await contexto.SaveChangesAsync();

            return filaAfectada > 0 ? true : false;
        }
    }
}
