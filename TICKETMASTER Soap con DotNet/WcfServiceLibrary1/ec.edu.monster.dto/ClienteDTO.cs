using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace _01.SERVIDOR.ec.edu.monster.dto
{
    public class ClienteDTO
    {
        public string CLI_ID { get; set; }
        public string CLI_NOMBRES { get; set; }
        public string CLI_APELLIDOS { get; set; }
        public string CLI_EMAIL { get; set; }
        public string CLI_TELEFONO { get; set; }
        public string Message { get; set; }
    }
}