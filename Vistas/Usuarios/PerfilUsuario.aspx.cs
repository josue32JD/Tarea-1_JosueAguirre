using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tarea_1_JosueAguirre.Vistas.Usuarios
{
    public partial class PerfilUsuario : System.Web.UI.Page
    {

        protected void Page_Load(object sender, EventArgs e)
        {
            // Verifica si el tiene usuario tenga sesión activa
            if (Session["usuario"] == null)
            {
                Session["mensajeExpiracion"] = "Su sesión ha expirado. Por favor, inicie sesión nuevamente.";
                Response.Redirect("~/Vistas/Usuarios/Loggin.aspx");
                return;
            }

            // Se ejecuta solo la primera vez que carga la página
            if (!IsPostBack)
            {
                // Obtener los datos del usuario desde la sesión
                clsUsuario usuario = (clsUsuario)Session["usuario"];

                // Mostrar información del usuario en etiquetas de la página
                lblBienvenida.Text = $"Bienvenido, {usuario.NombreCompleto}";
                lblNombre.Text = $"Nombre completo: {usuario.NombreCompleto}";
                lblCorreo.Text = $"Correo: {usuario.Correo}";
                lblTelefono.Text = $"Teléfono: {usuario.Telefono}";
                lblUsuario.Text = $"Usuario: {usuario.NombreUsuario}";
                lblFecha.Text = $"Fecha de nacimiento: {usuario.FechaNacimiento.ToShortDateString()}";
            }
        }

        // Este método se ejecuta cuando el usuario hace clic en "Cerrar sesión"
        protected void btnCerrarSesion_Click(object sender, EventArgs e)
        {
            // Limpia todas las variables de sesión
            Session.Clear();

            // Termina la sesión actual
            Session.Abandon();

            // Condicional si existe la cookie "MiSesionSegura"
            if (Request.Cookies["MiSesionSegura"] != null)
            {
                // Crea una nueva cookie con el mismo nombre para sobrescribirla
                HttpCookie cookie = new HttpCookie("MiSesionSegura");
                // Borra el valor de la cookie
                cookie.Value = "";
                // Expira inmediatamente (elimina la cookie)
                cookie.Expires = DateTime.Now.AddDays(-1);
                // Se aplica a todo el sitio
                cookie.Path = "/";
                // Agrega la cookie al response para que el navegador la elimine
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("~/Vistas/Usuarios/Loggin.aspx", false);
        }

        protected void btnProductos_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas/Productos/Productos.aspx");
        }

        protected void btnActualizar_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas/Usuarios/EditarPerfil.aspx");
        }
    }
}