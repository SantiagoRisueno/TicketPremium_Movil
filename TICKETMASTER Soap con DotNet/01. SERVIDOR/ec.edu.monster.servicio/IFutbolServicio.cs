using _01.SERVIDOR.ec.edu.monster.dto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace _01.SERVIDOR.ec.edu.monster.servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IFutbolServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IFutbolServicio
    {
        [OperationContract]
        Task<List<PartidoFutbolDTO>> ObtenerPartidosDisponibles();

        [OperationContract]
        Task<PartidoFutbolDTO> ObtenerPartidoPorId(int codigoPartido);

        [OperationContract]
        Task<List<LocalidadPartidoDTO>> ObtenerLocalidadesDisponibles(int codigoPartido);

        [OperationContract]
        Task<LocalidadPartidoDTO> ObtenerLocalidadPorId(int codigoLocalidad);

        [OperationContract]
        Task<bool> DecrementarDisponibilidad(int codigoLocalidad, int cantidad);
    }
}
