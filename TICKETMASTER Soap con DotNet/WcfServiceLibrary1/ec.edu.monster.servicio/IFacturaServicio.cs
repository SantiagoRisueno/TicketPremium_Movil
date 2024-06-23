using _01.SERVIDOR.ec.edu.monster.modelo;
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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IFacturaServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IFacturaServicio
    {
        [OperationContract]
        Task<string> CrearFactura(factura datosFactura);

        [OperationContract]
        Task<ValoresFacturaDTO> CalcularValores(List<int> cantidades, List<int> localidadIds);

        [OperationContract]
        Task<bool> AgregarDetallesFactura(detalle_factura datosDetalle);

        [OperationContract]
        Task<double> CalcularSubtotalPorDetalle(int cantidad, int localidadId);

        [OperationContract]
        Task<DatosFacturaFinalDTO> ObtenerFacturaDetallada(string codigoFactura);

        [OperationContract]
        Task<List<LocalidadPartidoDTO>> ObtenerResumenVentasLocalidad(int codigoPartido);
    }
}
