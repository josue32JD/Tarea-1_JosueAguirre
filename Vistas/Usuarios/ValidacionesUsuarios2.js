$(document).ready(function ()
{
    // Función para mostrar errores en los inputs
    function mostrarError(input, mensaje)
    {
         // Agrega la clase 'is-invalid' al input para resaltar visualmente el error
        $(input).addClass('is-invalid');

         // Si el input es un checkbox
        if ($(input).attr('type') === 'checkbox')
        {
            var check = $(input).closest('.form-check');

             // Si no existe un mensaje de error, lo crea
            if (check.find('.error-msg').length === 0)
            {
                check.append('<div class="error-msg text-danger small mt-1">' + mensaje + '</div>');
            } else
            {
                // Si ya existe, actualiza el mensaje
                check.find('.error-msg').text(mensaje);
            }
            return;
        }

         //Si no existe un span de error, lo crea esto para otros Input
        if ($(input).next('.error-msg').length === 0)
        {
            $(input).after('<span class="error-msg text-danger">' + mensaje + '</span>');
        } else
        {
            $(input).next('.error-msg').text(mensaje);
        }
    }

    // Función para limpiar error de checkbox
    function limpiarError(input)
    {
         // Quita la clase que marca el input como inválido
        $(input).removeClass('is-invalid');

         // Condicional: si es checkbox, elimina su mensaje de error específico
        if ($(input).attr('type') === 'checkbox')
        {
            $(input).closest('.form-check').find('.error-msg').remove();
        } else
        {// Para otros inputs, elimina el span de error siguiente
            $(input).next('.error-msg').remove();
        }
    }

    // Validaciones

    //Función para validar nombre
    function validarNombre()
    {
        var nombre = $('#txtNombre').val().trim();

        if (!nombre || !/^[a-zA-Z\s]+$/.test(nombre) || nombre.length < 3)
        {
            mostrarError('#txtNombre', 'Nombre obligatorio, solo letras y mínimo 3 caracteres');
            return false;
        }

        limpiarError('#txtNombre');
        return true;
    }

    function validarCorreo()
    {
        var correo = $('#txtCorreo').val().trim();
        var expresion = /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/;

        if (!correo)
        {
            mostrarError('#txtCorreo', 'Correo electrónico es obligatorio');
            return false;
        }
        if (!expresion.test(correo))
        {
            mostrarError('#txtCorreo', 'Correo inválido (ej. usuario@dominio.com)');
            return false;
        }

        limpiarError('#txtCorreo');
        return true;
    }

    function validarTelefono()
    {
        var telefono = $('#txtTelefono').val().trim();
        var expresion = /^\+?\d{8,15}$/;

        if (!telefono)
        {
            mostrarError('#txtTelefono', 'Teléfono es obligatorio');
            return false;
        }
        if (!expresion.test(telefono)) {
            mostrarError('#txtTelefono', 'Teléfono inválido. Solo dígitos, opcional +, 8-15 caracteres');
            return false;
        }
        limpiarError('#txtTelefono');
        return true;
    }

    function validarUsuario()
    {
        var usuario = $('#txtUsuario').val().trim();

        if (!usuario || /\s/.test(usuario) || !/^[a-zA-Z0-9]+$/.test(usuario))
        {
            mostrarError('#txtUsuario', 'Usuario obligatorio, sin espacios y solo alfanumérico');
            return false;
        }
        limpiarError('#txtUsuario');
        return true;
    }

    function validarContrasena()
    {
        var contra = $('#txtContraseña').val();
  
        if (!contra)
        {
            mostrarError('#txtContraseña', 'La contraseña es obligatoria');
            return false;
        }

        var expresion = /^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&]).{8,}$/;

        if (!expresion.test(contra))
        {

            mostrarError('#txtContraseña', 'Contraseña inválida (mín 8 caracteres, mayúscula, minúscula, número, símbolo)');
            return false;
        }

        limpiarError('#txtContraseña');
        return true;
    }

    function validarConfirmar()
    {
        var contra = $('#txtContraseña').val();
        var confirmar = $('#txtConfirmar').val();
      
        if (!confirmar)
        {
            mostrarError('#txtConfirmar', 'Debe confirmar la contraseña');
            return false;
        }

        if (contra !== confirmar)
        {
            mostrarError('#txtConfirmar', 'Las contraseñas no coinciden');
            return false;
        }

        limpiarError('#txtConfirmar');
        return true;
    }

    // Validar fecha y edad
    function validarFecha()
    {
         // Obtiene el valor del input de fecha y elimina espacios al inicio y final
        var fecha = $('#txtFecha').val().trim();

        // Si la fecha está vacío, muestra un error y detiene la validación
        if (!fecha)
        {
            mostrarError('#txtFecha', 'Fecha de nacimiento es obligatoria');
            return false;
        }

        // Se convierte el valor dato a un objeto Date
        var fechaInput = new Date(fecha);

        // Se obtiene la fecha actual
        var hoy = new Date();

        //Se calcula la diferencia de años entre la fecha actual y la fecha de nacimiento
        var edad = hoy.getFullYear() - fechaInput.getFullYear();
        // Se calcula la diferencia de meses para ajustar la edad si aún no ha cumplido años
        var dato = hoy.getMonth() - fechaInput.getMonth();

        //Si el mes actual es menor que el mes de nacimiento, o es el mismo mes pero no ha llegado el día,
        // entonces la persona aún no ha cumplido años este año, así que se resta 1 a la edad
        if (dato < 0 || (dato === 0 && hoy.getDate() < fechaInput.getDate()))
        {
            edad--;
        }

        // Si la edad calculada es menor a 18, muestra un error
        if (edad < 18)
        {
            mostrarError('#txtFecha', 'Debes ser mayor de 18 años');
            return false;
        }

        limpiarError('#txtFecha');
        return true;
    }

    function validarTerminos()
    {
        if (!$('#checkTerminos').is(':checked'))
        {
            mostrarError('#checkTerminos', 'Debes aceptar los términos');
            return false;
        }

        limpiarError('#checkTerminos');
        return true;
    }

    // Eventos en tiempo real
    $('#txtNombre').blur(validarNombre).keyup(validarNombre);
    $('#txtCorreo').blur(validarCorreo).keyup(validarCorreo);
    $('#txtTelefono').blur(validarTelefono).keyup(validarTelefono);
    $('#txtUsuario').blur(validarUsuario).keyup(validarUsuario);
    $('#txtContraseña').blur(validarContrasena).keyup(validarContrasena);
    $('#txtConfirmar').blur(validarConfirmar).keyup(validarConfirmar);
    $('#txtFecha').blur(validarFecha).change(validarFecha);
    $('#checkTerminos').change(validarTerminos);

    // Validación final al enviar
    $('#btnRegistrar').click(function (e)
    {
        var valido = validarNombre() && validarCorreo() && validarTelefono() &&
            validarUsuario() && validarContrasena() && validarConfirmar() &&
            validarFecha() && validarTerminos();

        if (!valido) {
            e.preventDefault();
        }
    });

});