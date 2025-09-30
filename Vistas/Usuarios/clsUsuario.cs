using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tarea_1_JosueAguirre.Vistas.Usuarios
{
    public class clsUsuario
    {
        public string NombreCompleto { get; set; }
        public string Correo { get; set; }
        public string Telefono { get; set; }
        public string NombreUsuario { get; set; }
        public string Contrasena { get; set; }
        public DateTime FechaNacimiento { get; set; }
        public bool TerminosAceptados { get; set; }
    }
}