using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Script.Services;
using System.Web.Services;
using System.Web.UI;
using System.Web.UI.WebControls;
using Tarea_1_JosueAguirre.Vistas.Usuarios;

namespace Tarea_1_JosueAguirre.Vistas.Usuarios
{
    public partial class EditarPerfil : System.Web.UI.Page
    {
        // Lista estática de usuarios en memoria
        public static List<clsUsuario> listaUsuarios = new List<clsUsuario>();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                // Si no hay usuario en sesión, redirige al login
                if (Session["usuario"] == null)
                {
                    Response.Redirect("~/Vistas/Usuarios/Loggin.aspx");
                }

                // Si existe el usuario en la sesión, carga los datos en los TextBox
                if (Session["usuario"] != null)
                {
                    clsUsuario usuario = (clsUsuario)Session["usuario"];

                    // Asigna valores a los controles de la página
                    txtNombre.Text = usuario.NombreCompleto;
                    txtCorreo.Text = usuario.Correo;
                    txtTelefono.Text = usuario.Telefono;
                    txtContrasena.Text = usuario.Contrasena;
                }
            }
        }
    }
}