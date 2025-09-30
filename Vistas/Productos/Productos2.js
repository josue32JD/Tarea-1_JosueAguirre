// Espera a que el documento (DOM) esté completamente cargado
$(document).ready(function ()
{
     // Detecta cuando se presiona una tecla dentro del input #txtBuscar
    $("#txtBuscar").keypress(function (e)
    {
        if (e.which == 13)
        {
             // Evita que el formulario se envíe
            e.preventDefault();
            // Dispara manualmente el evento keyup para ejecutar la búsqueda
            $(this).trigger("keyup");
        }
    });

    // Detecta cuando el usuario levanta una tecla dentro del input #txtBuscar
    $("#txtBuscar").keyup(function ()
    {
        // Obtiene el valor escrito en el input, quitando espacios al inicio y final
        let query = $(this).val().trim();

        // Solo hace la búsqueda si hay al menos 2 caracteres
        if (query.length >= 2)
        {
            // Petición AJAX al servidor
            $.ajax({
                type: "GET",
                // Handler en el servidor que procesará la búsqueda
                url: "/Vistas/Productos/ProductosHandler.ashx",
                // Parámetro se envía al servidor con el texto a buscar
                data: { txt: query },
                // Se espera una respuesta en formato JSON
                dataType: "json",
                // Enviar también cookies de sesión.
                xhrFields: { withCredentials: true },

                // Si la petición es exitosa
                success: function (resultados)
                {
                    // Obtiene la lista de sugerencias, la limpia y la oculta inicialmente
                    let $lista = $("#sugerencias").empty().hide();
                    $lista.empty();

                    // Si el servidor devolvió resultados
                    if (resultados.length > 0)
                    {
                        // Recorre cada resultado y lo agrega como un <li> en la lista
                        resultados.forEach(item =>
                        {
                            $lista.append(`<li class="list-group-item sugerencia">${item}</li>`);
                        });
                        // Muestra la lista
                        $lista.show();
                    } else
                    {
                        // Muestra el mensaje
                        $lista.append(`<li class="list-group-item text-muted">No se encontraron productos</li>`);
                        $lista.show();
                    }
                },

                // Si ocurre un error en la petición AJAX
                error: function (xhr, status, error)
                {
                    alert("Error al buscar productos: " + error);
                }
            });
        } else
        {  
             // Si hay menos de 2 caracteres, se limpian las sugerencias
            $("#sugerencias").empty();
        }
    });

    // Detecta cuando se hace clic en una sugerencia de la lista
    $(document).on("click", ".sugerencia", function ()
    {
        let texto = $(this).text();
        $("#txtBuscar").val(texto);
        $("#sugerencias").empty();
    });
});
