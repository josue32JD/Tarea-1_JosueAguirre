using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Serialization;

namespace Tarea_1_JosueAguirre.Vistas.Productos
{
    /// <summary>
    /// Descripción breve de ProductosHandler
    /// </summary>
    public class ProductosHandler : IHttpHandler, System.Web.SessionState.IRequiresSessionState
    {

        // Método principal que se ejecuta cuando llega una petición HTTP
        public void ProcessRequest(HttpContext context)
        {
            try
            {
                // Indicar que la respuesta será en formato JSON
                context.Response.ContentType = "application/json";

                // Validación de seguridad para verificar que haya sesión activa
                if (context.Session["usuario"] == null)
                {
                    context.Response.StatusCode = 401;
                    context.Response.Write(new JavaScriptSerializer().Serialize(new { status = "ERROR", mensaje = "Sesión expirada. Vuelve a iniciar sesión." }));
                    return;
                }

                // Recuperar el texto de búsqueda enviado desde AJAX
                string txt = context.Request["txt"];

                // Lista de productos disponibles
                List<string> listaProductos = new List<string>
                 {
                "IPhone 15 Pro Max", "Samsung Galaxy S24", "IPad Air M2", "MacBook Pro 16\"",
                "Dell XPS 13", "Laptop Dell", "Sony WH-1000XM5", "AirPods Pro 2", "Audífonos",
                "Nintendo Switch OLED", "PlayStation 5", "Xbox Series X", "Canon EOS R5",
                "GoPro Hero 12", "Apple Watch Series 9", "Fitbit Versa 4", "Kindle Paperwhite",
                "Echo Dot 5ta Gen", "Google Pixel 8", "Surface Pro 9", "LG OLED TV 55\"",
                "Monitor LQ", "Bose QuietComfort", "Impresora Epson LP 3750", "Teclado mecánico",
                "Proyector de astronauta", "Mouse Gamer RGB", "Memoria RAM 16GB",
                "Tarjeta Gráfica RTX 4080", "Procesador Intel i7", "Fuente de Poder 750W",
                "Cooler CPU Líquido"
                 };

                // Lista para guardar coincidencias
                List<string> resultados = new List<string>();

                // Validar que el texto no esté vacío y tenga al menos 2 caracteres
                if (!string.IsNullOrWhiteSpace(txt) && txt.Trim().Length >= 2)
                {
                    string busqueda = txt.Trim().ToLower();
                    // Recorrer la lista de productos y buscar coincidencias
                    foreach (string p in listaProductos)
                    {
                        // Si el nombre del producto contiene el texto buscado, agregarlo a resultados
                        if (p.ToLower().Contains(busqueda))
                        {
                            resultados.Add(p);
                        }
                    }
                }

                // Serializar la lista de resultados en JSON y enviarla al cliente
                var serializer = new JavaScriptSerializer();
                context.Response.Write(serializer.Serialize(resultados));
            }
            catch(Exception ex)
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
    }
}