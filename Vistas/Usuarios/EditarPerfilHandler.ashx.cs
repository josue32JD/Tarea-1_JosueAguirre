using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Tarea_1_JosueAguirre.Vistas.Usuarios
{
    /// <summary>
    /// Descripción breve de EditarPerfilHandler
    /// </summary>
    public class EditarPerfilHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        public void ProcessRequest(HttpContext context)
        {
            // Se establece las respuestas  en formato JSON
            context.Response.ContentType = "application/json";
            try
            {
                // Condicional verifica si la sesión del usuario existe
                if (context.Session["usuario"] == null)
                {
                    // Si la sesión expiró, devuelve un error 401 con mensaje JSON
                    context.Response.StatusCode = 401;
                    context.Response.Write(new JavaScriptSerializer().Serialize(new { status = "ERROR", mensaje = "Sesión expirada. Vuelve a iniciar sesión." }));
                    return; 
                }

                // Lee el cuerpo de la petición HTTP (JSON enviado desde el cliente)
                string jsonString;
                using (var reader = new System.IO.StreamReader(context.Request.InputStream))
                {
                    jsonString = reader.ReadToEnd();
                }

                // Deserializa el JSON a un objeto PerfilDTO
                var serializer = new JavaScriptSerializer();
                var datos = serializer.Deserialize<Perfil>(jsonString);

                // Validación: todos los campos son obligatorios
                if (string.IsNullOrWhiteSpace(datos.nombre) ||
                    string.IsNullOrWhiteSpace(datos.correo) ||
                    string.IsNullOrWhiteSpace(datos.telefono) ||
                    string.IsNullOrWhiteSpace(datos.contrasena))
                {
                    context.Response.Write(serializer.Serialize(new { status = "ERROR", mensaje = "Todos los campos son obligatorios." }));
                    return;
                }

                // Actualiza los datos del usuario en la sesión
                clsUsuario usuario = (clsUsuario)context.Session["usuario"];
                usuario.NombreCompleto = datos.nombre;
                usuario.Correo = datos.correo;
                usuario.Telefono = datos.telefono;
                usuario.Contrasena = datos.contrasena;
                // Guarda los cambios en la sesión
                context.Session["usuario"] = usuario;

                // Devuelve respuesta JSON indicando éxito
                context.Response.Write(serializer.Serialize(new { status = "OK", mensaje = "¡Tus datos han sido actualizados correctamente!" }));
            }
            catch (Exception ex)
            {
               
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        // Clase interna para los datos recibidos del cliente
        public class Perfil
        {
            public string nombre { get; set; }
            public string correo { get; set; }
            public string telefono { get; set; }
            public string contrasena { get; set; }
        }
    }
}