using _01.SERVIDOR.ec.edu.monster.modelo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using _01.SERVIDOR.ec.edu.monster.dto;

namespace _01.SERVIDOR.ec.edu.monster.servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de clase "AutenticacionServicio" en el código, en svc y en el archivo de configuración a la vez.
    // NOTA: para iniciar el Cliente de prueba WCF para probar este servicio, seleccione AutenticacionServicio.svc o AutenticacionServicio.svc.cs en el Explorador de soluciones e inicie la depuración.
    public class AutenticacionServicio : IAutenticacionServicio
    {
        private readonly federacion_futbolEntities _context;

        public AutenticacionServicio()
        {
            _context = new federacion_futbolEntities();
        }

        public ClienteDTO IniciarSesion(string email, string password)
        {
            try
            {
                var usuario = _context.cliente
                    .FirstOrDefault(u => u.CLI_EMAIL == email && u.CLI_PASSWORD_HASH == password);

                if (usuario == null)
                {
                    return new ClienteDTO
                    {
                        Message = "Usuario no encontrado o credenciales incorrectas."
                    };
                }
                else 
                {
                    ClienteDTO cliente = new ClienteDTO();
                    cliente.CLI_EMAIL = email;
                    cliente.CLI_APELLIDOS = usuario.CLI_APELLIDOS;
                    cliente.CLI_NOMBRES = usuario.CLI_NOMBRES;
                    cliente.CLI_TELEFONO = usuario.CLI_TELEFONO;
                    cliente.CLI_ID = usuario.CLI_ID;
                    cliente.Message = "Usuario encontrado con éxito.";

                    return cliente;
                }
            }
            catch (Exception ex)
            {
                throw new FaultException($"Error: {ex.Message}");
            }
        }



        public bool Registrar(String nombres,String apellidos, String email, String telefono,String password)
        {
            // Crear un nuevo usuario a partir de los datos proporcionados
            var usuario = new cliente
            {
                CLI_ID = Guid.NewGuid().ToString(),
                CLI_NOMBRES = nombres,
                CLI_APELLIDOS = apellidos,
                CLI_EMAIL = email,
                CLI_TELEFONO = telefono,
                CLI_PASSWORD_HASH = password 
            };

            _context.cliente.Add(usuario);
            var result = _context.SaveChanges();

            return result > 0;
        }
    }
}
