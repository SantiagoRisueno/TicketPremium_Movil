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
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "FacturaServicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione FacturaServicio.svc o FacturaServicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class FacturaServicio : IFacturaServicio
    {
        private readonly federacion_futbolEntities _context;

        public FacturaServicio()
        {
            _context = new federacion_futbolEntities();
        }

        public async Task<string> CrearFactura(FacturaDTO datosFactura)
        {
            factura _factura = new factura();
            _factura.FAC_ID = 1;
            _factura.FAC_CODIGO = Guid.NewGuid().ToString();
            _factura.FAC_FECHA_EMISION = DateTime.Parse(datosFactura.FechaEmision);
            _factura.CLI_ID = datosFactura.ClienteId;
            _factura.FAC_TOTAL = (decimal)datosFactura.Total;
            _factura.FAC_SUBTOTAL = (decimal)datosFactura.SubTotal;
            _factura.FAC_VALOR_IVA = (decimal)datosFactura.ValorIVA;
            _context.factura.Add(_factura);
            await _context.SaveChangesAsync();
            return _factura.FAC_CODIGO;
        }

        public async Task<ValoresFacturaDTO> CalcularValores(List<int> cantidades, List<int> localidadIds)
        {
            // Lógica para calcular los valores de la factura.
            double subtotal = 0;
            for (int i = 0; i < localidadIds.Count; i++)
            {
                var localidad = await _context.localidad_partido.FindAsync(localidadIds[i]);
                if (localidad != null)
                {
                    subtotal += float.Parse(localidad.LOC_PRECIO.ToString()) * cantidades[i];
                }
            }

            var valores = new ValoresFacturaDTO
            {
                Subtotal = subtotal,
                ValorIVA = subtotal * 0.12,
                Total = subtotal + subtotal * 0.12
            };
            return valores;
        }

        public async Task<bool> AgregarDetallesFactura(DetalleFacturaDTO datosDetalle)
        {
            detalle_factura detalle_Factura = new detalle_factura();
            detalle_Factura.DETF_ID = 1;
            detalle_Factura.DETF_TOTAL = (decimal)datosDetalle.Total;
            detalle_Factura.DETF_CANTIDAD = datosDetalle.Cantidad;
            detalle_Factura.LOC_ID = datosDetalle.LocalidadId;
            detalle_Factura.FAC_CODIGO = datosDetalle.FacturaCodigo;
            _context.detalle_factura.Add(detalle_Factura);
            int rowsAffected = await _context.SaveChangesAsync();
            return rowsAffected > 0;
        }

        public async Task<double> CalcularSubtotalPorDetalle(int cantidad, int localidadId)
        {
            var localidad = await _context.localidad_partido.FindAsync(localidadId);
            return (double)(localidad?.LOC_PRECIO * cantidad ?? 0);
        }

        public async Task<DatosFacturaFinalDTO> ObtenerFacturaDetallada(string codigoFactura)
        {
            var factura = await _context.factura
                .Where(f => f.FAC_CODIGO == codigoFactura)
                .Select(f => new DatosFacturaFinalDTO
                {
                    FacturaID = f.FAC_CODIGO,
                    FechaFactura = f.FAC_FECHA_EMISION.ToString(),
                    NombresCliente = f.cliente.CLI_NOMBRES,
                    ApellidosCliente = f.cliente.CLI_APELLIDOS,
                    EmailCliente = f.cliente.CLI_EMAIL,
                    TelefonoCliente = f.cliente.CLI_TELEFONO,
                    Subtotal = (double)f.FAC_SUBTOTAL,
                    IVA = (double)f.FAC_VALOR_IVA,
                    Total = (double)f.FAC_TOTAL,
                    Detalles = f.detalle_factura.Select(d => new DetalleFacturaDTO
                    {
                        LocalidadId = d.LOC_ID,
                        Cantidad = d.DETF_CANTIDAD,
                        Total = (double)d.DETF_TOTAL,
                        NombreLocalidad = d.localidad_partido.tipo_localidad.TIP_DESCRIPCION
                    }).ToList()
                }).FirstOrDefaultAsync();
            return factura;
        }

        public async Task<List<LocalidadPartidoDTO>> ObtenerResumenVentasLocalidad(int codigoPartido)
        {
            var resumen = await _context.localidad_partido
                .Where(lp => lp.PAR_ID == codigoPartido)
                .Select(lp => new LocalidadPartidoDTO
                {
                    Id = lp.LOC_ID,
                    NombreLocalidad = lp.tipo_localidad.TIP_DESCRIPCION,
                    Disponibilidad = lp.detalle_factura.Sum(df => df.DETF_CANTIDAD),
                    Precio = lp.detalle_factura.Sum(df => df.DETF_CANTIDAD)
                }).ToListAsync();

            return resumen;
        }
    }
}
