using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using _01.SERVIDOR.ec.edu.monster.modelo;
using _01.SERVIDOR.ec.edu.monster.dto;

namespace _01.SERVIDOR.ec.edu.monster.servicio
{
    // NOTA: puede usar el comando "Rename" del menú "Refactorizar" para cambiar el nombre de interfaz "IAutenticacionServicio" en el código y en el archivo de configuración a la vez.
    [ServiceContract]
    public interface IAutenticacionServicio
    {
        [OperationContract]
        ClienteDTO IniciarSesion(string email, string password);

        [OperationContract]
        bool Registrar(String nombres, String apellidos, String email, String telefono, String password);
    }
}
