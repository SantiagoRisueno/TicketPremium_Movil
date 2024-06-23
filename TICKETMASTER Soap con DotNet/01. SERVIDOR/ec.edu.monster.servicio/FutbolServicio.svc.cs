using _01.SERVIDOR.ec.edu.monster.dto;
using _01.SERVIDOR.ec.edu.monster.modelo;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _01.SERVIDOR.ec.edu.monster.servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "FutbolServicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione FutbolServicio.svc o FutbolServicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class FutbolServicio : IFutbolServicio
    {
        private readonly federacion_futbolEntities _context;

        public FutbolServicio()
        {
            _context = new federacion_futbolEntities();
        }
        public async Task<List<PartidoFutbolDTO>> ObtenerPartidosDisponibles()
        {
            var hoy = DateTime.Today;
            var ahora = DateTime.Now;

            // Formato de hora actual como entero en HHmm
            int horaActualEntero = ahora.Hour * 100 + ahora.Minute;

            var partidos = await _context.partido_futbol
                .Where(p => p.PAR_FECHA >= hoy)
                .Select(p => new
                {
                    Partido = p,
                    p.PAR_FECHA,
                    p.PAR_HORA
                })
                .ToListAsync();

            // Convertir la hora a formato entero HHmm para comparación
            var partidosDisponibles = partidos
                .Where(p => p.PAR_FECHA > hoy ||
                           (p.PAR_FECHA == hoy && ConvertirHoraAEntero(p.PAR_HORA.ToString()) > horaActualEntero))
                .Select(p => new PartidoFutbolDTO
                {
                    Id = p.Partido.PAR_ID,
                    EstadioId = p.Partido.EST_ID,
                    NombreEstadio = p.Partido.estadio.EST_NOMBRE,
                    EquipoLocal = p.Partido.equipo.EQU_NOMBRE,
                    EquipoVisita = p.Partido.equipo1.EQU_NOMBRE,
                    LogoEquipoLocal = p.Partido.equipo.EQUI_IMG,
                    LogoEquipoVisita = p.Partido.equipo1.EQUI_IMG,
                    Fecha = p.PAR_FECHA,
                    Hora = p.PAR_HORA
                })
                .ToList();

            return partidosDisponibles;
        }

        // Método auxiliar para convertir hora en formato cadena a entero en formato HHmm
        private int ConvertirHoraAEntero(string hora)
        {
            var partesHora = hora.Split(':');
            int horas = int.Parse(partesHora[0]);
            int minutos = int.Parse(partesHora[1]);
            return horas * 100 + minutos;
        }




        public async Task<PartidoFutbolDTO> ObtenerPartidoPorId(int codigoPartido)
        {
            var partido = await _context.partido_futbol
                .Where(p => p.PAR_ID == codigoPartido)
                .Select(p => new PartidoFutbolDTO
                {
                    Id = p.PAR_ID,
                    EstadioId = p.EST_ID,
                    NombreEstadio = p.estadio.EST_NOMBRE,
                    EquipoLocal = p.equipo.EQU_NOMBRE,
                    EquipoVisita = p.equipo1.EQU_NOMBRE,
                    LogoEquipoLocal = p.equipo.EQUI_IMG,
                    LogoEquipoVisita = p.equipo1.EQUI_IMG,
                    Fecha = p.PAR_FECHA,
                    Hora = p.PAR_HORA
                })
                .FirstOrDefaultAsync();

            return partido;
        }

        public async Task<List<LocalidadPartidoDTO>> ObtenerLocalidadesDisponibles(int codigoPartido)
        {
            var localidades = await _context.localidad_partido
                .Where(lp => lp.PAR_ID == codigoPartido)
                .Select(lp => new LocalidadPartidoDTO
                {
                    Id = lp.LOC_ID,
                    PartidoId = lp.PAR_ID,
                    TipoLocalidad = lp.tipo_localidad.TIPL_ID,
                    NombreLocalidad = lp.tipo_localidad.TIP_DESCRIPCION,
                    Precio = (double)lp.LOC_PRECIO,
                    Disponibilidad = lp.LOC_DISPONIBILIDAD
                })
                .ToListAsync();

            return localidades;
        }

        public async Task<LocalidadPartidoDTO> ObtenerLocalidadPorId(int codigoLocalidad)
        {
            var localidad = await _context.localidad_partido
                .Where(lp => lp.PAR_ID == codigoLocalidad)
                .Select(lp => new LocalidadPartidoDTO
                {
                    Id = lp.LOC_ID,
                    PartidoId = lp.PAR_ID,
                    TipoLocalidad = lp.tipo_localidad.TIPL_ID,
                    NombreLocalidad = lp.tipo_localidad.TIP_DESCRIPCION,
                    Precio = (double)lp.LOC_PRECIO,
                    Disponibilidad = lp.LOC_DISPONIBILIDAD
                })
                .FirstOrDefaultAsync();

            return localidad;
        }

        public async Task<bool> DecrementarDisponibilidad(int codigoLocalidad, int cantidad)
        {
            var localidad = await _context.localidad_partido.FindAsync(codigoLocalidad);
            if (localidad != null && localidad.LOC_DISPONIBILIDAD >= cantidad)
            {
                localidad.LOC_DISPONIBILIDAD -= cantidad;
                await _context.SaveChangesAsync();
                return true;
            }

            return false;
        }
    }
}
