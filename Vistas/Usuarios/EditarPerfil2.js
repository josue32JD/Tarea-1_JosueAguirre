$(document).ready(function () {
    const $btnGuardar = $('#btnGuardar');
    const $lblMensaje = $('#lblMensaje');

    // Muestra un mensaje de error debajo del campo y marca el input como inválido
    function mostrarError(input, mensaje) {
        // Aplica la clase de Bootstrap para borde rojo
        $(input).addClass('is-invalid');
        if ($(input).next('.error-msg').length === 0) {
            // Si no existe un mensaje de error ya agregado, se crea uno
            $(input).after('<span class="error-msg text-danger small">' + mensaje + '</span>');
        } else {
            $(input).next('.error-msg').text(mensaje);
        }
    }

    //Limpiar datos
    function limpiarError(input) {
        $(input).removeClass('is-invalid');
        // Elimina el mensaje de error
        $(input).next('.error-msg').remove();
    }

     // Validar el nombre (solo letras y espacios, mínimo 3 caracteres)
    function validarNombre() {
        const nombre = $('#txtNombre').val().trim();
        if (!nombre || !/^[a-zA-Z\s]{3,}$/.test(nombre)) {
            mostrarError('#txtNombre', 'Nombre obligatorio, solo letras y mínimo 3 caracteres');
            return false;
        }
        limpiarError('#txtNombre');
        return true;
    }

     // Validar el correo electrónico
    function validarCorreo() {
        const correo = $('#txtCorreo').val().trim();
         // Regex para validar formato de email: letras/números + @ + dominio
        const regex = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;
        if (!correo || !regex.test(correo)) {
            mostrarError('#txtCorreo', 'Correo inválido (ej. usuario@dominio.com)');
            return false;
        }
        limpiarError('#txtCorreo');
        return true;
    }

     // Validar el teléfono (entre 8 y 15 dígitos, opcional prefijo con +)
    function validarTelefono() {
        const telefono = $('#txtTelefono').val().trim();
        const regex = /^\+?\d{8,15}$/;
        if (!telefono || !regex.test(telefono)) {
            mostrarError('#txtTelefono', 'Teléfono inválido (solo dígitos, opcional +, 8-15 caracteres)');
            return false;
        }
        limpiarError('#txtTelefono');
        return true;
    }

     // Validar la contraseña (mínimo 8 caracteres, al menos: 1 mayúscula, 1 minúscula, 1 número y 1 símbolo)
    function validarContrasena() {
        const contra = $('#txtContrasena').val();
        const regex = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$/;
        if (!contra || !regex.test(contra)) {
            mostrarError('#txtContrasena', 'Contraseña inválida (mín 8 caracteres, mayúscula, minúscula, número, símbolo)');
            return false;
        }
        limpiarError('#txtContrasena');
        return true;
    }

    // Validar la confirmación de contraseña (que sea igual al campo anterior)
    function validarConfirmar() {
        const contra = $('#txtContrasena').val();
        const confirmar = $('#txtConfirmar').val();
        if (!confirmar) {
            mostrarError('#txtConfirmar', 'Debe confirmar la contraseña');
            return false;
        }
        if (contra !== confirmar) {
            mostrarError('#txtConfirmar', 'Las contraseñas no coinciden');
            return false;
        }
        limpiarError('#txtConfirmar');
        return true;
    }

    // Validaciones en tiempo real
    $('#txtNombre').blur(validarNombre).keyup(validarNombre);
    $('#txtCorreo').blur(validarCorreo).keyup(validarCorreo);
    $('#txtTelefono').blur(validarTelefono).keyup(validarTelefono);
    $('#txtContrasena').blur(validarContrasena).keyup(validarContrasena);
    $('#txtConfirmar').blur(validarConfirmar).keyup(validarConfirmar);

    // Guardar datos con el click con AJAX
    $btnGuardar.click(function (e) {
        e.preventDefault();

         // Ejecuta todas las validaciones
        const valido = validarNombre() && validarCorreo() && validarTelefono() &&
            validarContrasena() && validarConfirmar();

        // Si alguna validación falla, muestra un mensaje general
        if (!valido) {
            $lblMensaje.removeClass('d-none alert-success alert-danger')
                .addClass('alert-danger')
                .text('Por favor corrige los errores antes de guardar.');
            return;
        }

        // Si todas las validaciones pasan, arma el objeto con los datos del formulario
        const datos = {
            nombre: $('#txtNombre').val(),
            correo: $('#txtCorreo').val(),
            telefono: $('#txtTelefono').val(),
            contrasena: $('#txtContrasena').val()
        };

        //Peticion AJAX para enviar los datos al servidor
        $.ajax({
            type: "POST",
            // Handler que recibe los datos
            url: "/Vistas/Usuarios/EditarPerfilHandler.ashx",
            //Envío como JSON los datos
            data: JSON.stringify(datos),
            // Se especifica que el formato
            contentType: "application/json; charset=utf-8",
            // Se espera una respuesta en JSON
            dataType: "json",
            // Si el servidor responde correctamente
            success: function (response) {
                if (response.status === "OK") {
                    // Mensaje de éxito
                    $lblMensaje.removeClass('d-none alert-success alert-danger')
                        .addClass('alert-success')
                        .text(response.mensaje);
                    setTimeout(() => $lblMensaje.addClass('d-none'), 3000);
                } else {
                    // Si hay un error muestra un mensaje
                    $lblMensaje.removeClass('d-none alert-success alert-danger')
                        .addClass('alert-danger')
                        .text(response.mensaje);
                }
            },
            error: function (xhr) {
                $lblMensaje.removeClass('d-none alert-success alert-danger')
                    .addClass('alert-danger')
                    .text(xhr.status === 401 ? 'Sesión expirada.' : 'Error al actualizar datos.');
            }
        });
    });
});
