using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace Tarea_1_JosueAguirre
{
    public partial class SiteMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ConfigurarMenu();
            }
        }

        private void ConfigurarMenu()
        {
            // Verificar si hay sesión activa
            bool usuarioLogueado = Session["usuario"] != null;

            if (usuarioLogueado)
            {
                // Mostra opciones de usuario autenticado
                menuLogin.Visible = false;
                menuRegistro.Visible = false;
                menuBuscar.Visible = true;
                menuPerfil.Visible = true;
                menuEditar.Visible = true;
                menuLogout.Visible = true;
            }
            else
            {
                //Mostrar opciones públicas de usuario no logueado
                menuLogin.Visible = true;
                menuRegistro.Visible = true;

                menuBuscar.Visible = false;
                menuPerfil.Visible = false;
                menuEditar.Visible = false;
                menuLogout.Visible = false;
            }
        }
        protected void CerrarSesion_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Session.Abandon();

            if (Request.Cookies["MiSesionSegura"] != null)
            {
                HttpCookie cookie = new HttpCookie("MiSesionSegura");
                cookie.Value = "";
                cookie.Expires = DateTime.Now.AddDays(-1);
                cookie.Path = "/";
                Response.Cookies.Add(cookie);
            }
            Response.Redirect("~/Vistas/Usuarios/Loggin.aspx", false);
        }

    }
}