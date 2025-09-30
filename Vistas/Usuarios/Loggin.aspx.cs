using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tarea_1_JosueAguirre.Vistas.Usuarios
{
    public partial class Loggin : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
             // Si ya existe un usuario en la sesión, se redirige directamente al perfil
            if (Session["usuario"] != null)
            {
                Response.Redirect("~/Vistas/Usuarios/PerfilUsuario.aspx");
            }

            // Se ejecuta solo en la primera carga
            if (!IsPostBack)
            {
                // Mostrar mensaje de sesión expirada si existe
                if (Session["mensajeExpiracion"] != null)
                {
                    // Si hay un mensaje de expiración de sesión, se muestra en pantalla
                    lblMensaje.Text = Session["mensajeExpiracion"].ToString();
                    Session.Remove("mensajeExpiracion"); 
                }
            }
        }

        //Este método se ejecuta cuando el usuario hace clic en "Iniciar sesión"
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            // Obtiene los valores de los campos de texto y elimina espacios extras
            string usuario = txtUsuario.Text.Trim();
            string contra = txtContrasena.Text.Trim();

            clsUsuario usuarioEncontrado= null;

            // Busca en la lista de usuarios ya registrados
            foreach (clsUsuario dato in Registros.listaUsuarios)
            {
                // Se busca al usuario y se comparan de contraseñas
                if (dato.NombreUsuario.Equals(usuario, StringComparison.OrdinalIgnoreCase) && 
                    dato.Contrasena == contra)
                {
                    // Usuario encontrado
                    usuarioEncontrado = dato;
                    break;
                }
            }

            // Si no lo encontró, busca en la lista de pre-registro
            if (usuarioEncontrado == null)
            {
                foreach (clsUsuario dato in Registros.PreResgistro)
                {
                    if (dato.NombreUsuario.Equals(usuario, StringComparison.OrdinalIgnoreCase) &&
                        dato.Contrasena == contra)
                    {
                        usuarioEncontrado = dato;
                        break;
                    }
                }
            }

            //Validar si se encontró el usuario
            if (usuarioEncontrado != null)
            {
                // Guardar en sesión
                Session["usuario"] = usuarioEncontrado;
                Response.Redirect("~/Vistas/Usuarios/PerfilUsuario.aspx");
            }
            else
            {
                lblError.Text = "Usuario o contraseña incorrectos.";
            }
        }

        protected void btnRegistro_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Vistas/Usuarios/Registros.aspx");
        }
    }
}  
