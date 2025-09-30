using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace Tarea_1_JosueAguirre.Vistas.Usuarios
{
    public partial class Registros : System.Web.UI.Page
    {
        // Lista para almacenar los usuarios registrados.
        public static List<clsUsuario> listaUsuarios = new List<clsUsuario>();

        // Lista con pre-registro con un usuario administrador predeterminado
        public static List<clsUsuario> PreResgistro = new List<clsUsuario>
        {
           new clsUsuario
           {
                NombreCompleto = "Admin Usuario",
                Correo = "admin@hotmail.com",
                Telefono = "88888888",
                NombreUsuario = "admin",
                Contrasena = "hola",
                FechaNacimiento = new DateTime(1990, 1, 1),
                TerminosAceptados = true
           }
        };

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void txtNombre_TextChanged(object sender, EventArgs e)
        {

        }

        protected void btnRegistrar_Click(object sender, EventArgs e)
        {
            // Valida que todos los campos obligatorios estén completos
            if (!validarCampos())
            {
                lblError.Text = "Debe de completar todos los campos";
            }

            // Valida que no existan usuarios con el mismo nombre de usuario o correo
            string mensaje;
            if(ValidarDuplicados(txtUsuario.Text.Trim(), txtCorreo.Text.Trim(), out mensaje))
            {
                lblError.Text = mensaje;
                return;
            }

            // Se crea un nuevo objeto de tipo clsUsuario con los datos del formulario
            clsUsuario usuario = new clsUsuario();
            usuario.NombreCompleto = txtNombre.Text.Trim();
            usuario.Correo = txtCorreo.Text.Trim();
            usuario.Telefono = txtTelefono.Text.Trim();
            usuario.NombreUsuario = txtUsuario.Text.Trim();
            usuario.Contrasena = txtContraseña.Text.Trim();
            usuario.FechaNacimiento = DateTime.Parse(txtFecha.Text.Trim());
            usuario.TerminosAceptados = checkTerminos.Checked;
            // Agrega el usuario a la lista de usuarios registrados
            listaUsuarios.Add(usuario);
            lblExito.Text = "Registro con exito";
            lblError.Text = "";
            // Redirige a la página de login después del registro
            Response.Redirect("~/Vistas/Usuarios/Loggin.aspx");
        }

        // Metodo que valida si ya existe un usuario o correo registrado
        public bool ValidarDuplicados(string nombre, string correo, out string mensajeError)
        {
            foreach (clsUsuario datos in listaUsuarios)
            {
                // Condicional si el nombre de usuario ya existe.
                if (datos.NombreUsuario.Equals(nombre, StringComparison.OrdinalIgnoreCase))
                {
                    mensajeError = "El nombre ya esta registrado";
                    return true;
                }

                // Condicional si el correo ya existe.
                if (datos.Correo.Equals(correo, StringComparison.OrdinalIgnoreCase))
                {
                    mensajeError = "El correo ya esta registrado, use otro correo";
                    // Devuelve true indicando que hay duplicado
                    return true;
                }
            }
            mensajeError = string.Empty;
            return false;
        }

        // Metodo que valida que todos los campos estén llenos
        public bool validarCampos ()
        {
            // Condicional que revisa si alguno de los campos está vacío o los términos no están aceptados
            if (string.IsNullOrWhiteSpace(txtNombre.Text) || string.IsNullOrWhiteSpace(txtCorreo.Text) ||
                string.IsNullOrWhiteSpace(txtTelefono.Text) || string.IsNullOrWhiteSpace(txtUsuario.Text) ||
                string.IsNullOrWhiteSpace(txtContraseña.Text) || string.IsNullOrWhiteSpace(txtFecha.Text) ||
                !checkTerminos.Checked)
            {
                // Retorna false si falta algún dato
                return false;
            }
            // Todos los campos están completos
            return true;
        }

        //Metodo para limpiar pantalla
        public void limpiar()
        {
            txtNombre.Text = "";
            txtCorreo.Text = "";
            txtTelefono.Text = "";
            txtUsuario.Text = "";
            txtContraseña.Text = "";
            txtFecha.Text = "";
            checkTerminos.Checked = false;
        }
    }
}