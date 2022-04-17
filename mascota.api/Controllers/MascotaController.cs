using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using mascota.servicios;
using mascota.entidades;
using mascota.servicios.Dto;

namespace mascota.api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MascotaController : ControllerBase
    {
        private readonly IMascotaServicio mascotaServicio;

        public MascotaController(IMascotaServicio mascotaServicio)
        {
            this.mascotaServicio = mascotaServicio;
        }

        // GET: api/<MascotaController>
        [HttpGet]
        public async Task<IActionResult> ObtenerTodasMascotas()
        {
            Respuesta respuesta = new Respuesta();
            try
            {

                respuesta.Resultado = await mascotaServicio.ObtenerMascotas();
                respuesta.Exito = 1;
            }
            catch (Exception ex)
            {

                respuesta.Exito = 0;
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        // GET api/<MascotaController>/5
        [HttpGet("{id}")]
        public async Task<IActionResult> ObtenerMascota(int id) 
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                respuesta.Resultado = await mascotaServicio.ObtenerMascota(id);
                respuesta.Exito = 1;
            }
            catch (Exception ex)
            {
                respuesta.Exito = 0;
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        // POST api/<MascotaController>
        [HttpPost]
        public async Task<IActionResult> CrearMascota([FromBody] MascotaDto mascota)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Respuesta respuesta = new Respuesta();

            if (mascota.IdMascota != 0)
            {
                respuesta.Mensaje = "No debe mandar valor en el id";
                return BadRequest(respuesta);
            }

            try
            {

                var mascotaRecibida = await mascotaServicio.CrearMascota(new Mascota { 
                Nombre = mascota.Nombre,
                Descripcion = mascota.Descripcion,
                Edad = mascota.Edad
                });

                respuesta.Resultado = mascotaRecibida;
                respuesta.Exito = 1;
                respuesta.Mensaje = "Mascota insertada con exito";


            }
            catch (Exception ex)
            {

                respuesta.Exito = 0;
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        // PUT api/<MascotaController>/5
        [HttpPut("{Id}")]
        public async Task<IActionResult> EditarMascota(int Id, [FromBody] MascotaDto mascota)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Respuesta respuesta = new Respuesta();

            try
            {

                var mascotaRecibida = await mascotaServicio.EditarMascota(Id, new Mascota
                {
                    IdMascota = Id,
                    Nombre = mascota.Nombre,
                    Descripcion = mascota.Descripcion,
                    Edad = mascota.Edad
                });

                if (mascotaServicio.ObtenerMascota(Id) == null)
                {
                    respuesta.Mensaje = "La mascota que esta intentado editar no existe";
                    return NotFound(respuesta);
                }

                if (mascotaRecibida == null)
                {
                    respuesta.Mensaje = "Error, tiene que llenar todos los campos";
                    return BadRequest(respuesta);
                }

                respuesta.Resultado = mascotaRecibida;
                respuesta.Exito = 1;
                respuesta.Mensaje = "Mascota editada con exito";


            }
            catch (Exception ex)
            {

                respuesta.Exito = 0;
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }

        // DELETE api/<MascotaController>/5
        [HttpDelete("{Id}")]
        public async Task<IActionResult> EliminarMascota(int Id)
        {
            Respuesta respuesta = new Respuesta();

            try
            {
                var mascotaRecibida = await mascotaServicio.EliminarMascota(Id);

                if(mascotaRecibida == false)
                {
                    respuesta.Mensaje = "La mascota que esta intentado eliminar no existe";
                    return NotFound(respuesta);
                }

                respuesta.Resultado = mascotaRecibida;
                respuesta.Exito = 1;
                respuesta.Mensaje = "Mascota eliminada con exito";


            }
            catch (Exception ex)
            {

                respuesta.Exito = 0;
                respuesta.Mensaje = ex.Message;
            }

            return Ok(respuesta);
        }
    }
}
