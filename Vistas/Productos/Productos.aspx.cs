using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tarea_1_JosueAguirre.Vistas.Usuarios;

namespace Tarea_1_JosueAguirre.Vistas.Productos
{
    public partial class Productos : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Verificar si existe un usuario en sesión
            if (Session["usuario"] != null)
            {
                // Si hay sesión, obtener el usuario actual desde la sesión
                clsUsuario usuarioActual = (clsUsuario)Session["usuario"];

                // Mostrar un mensaje de bienvenida con el nombre de usuario
                lblBienvenida.Text = $"Bienvenido, {usuarioActual.NombreUsuario}";
            }
            else
            {
                // Si no hay sesión activa, redirigir al login
                Response.Redirect("~/Vistas/Usuarios/Loggin.aspx");
            }
        }
    }
}
