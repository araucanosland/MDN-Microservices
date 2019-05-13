function envio(rut) {
    localStorage.clear();
    sessionStorage.clear();
    location.href = "/Motor/Home/Acceso?RE=" + rut
}

$(function () {

    if (getCookie("Cargo") == 'Administrador Sistema' || getCookie("Cargo") == 'Usuario Avanzado') {



        

        $("#bdy_datos").html("");
        $.getJSON(BASE_URL + "/motor/api/busqueda-dotacion/listar-ejecutivos", function (ejecutivos) {



            $.each(ejecutivos, function (i, e) {


                $("#bdy_datos")
                    .append(
                        $("<tr>")
                            .append($("<td>").append('<a href="javascript:envio(\''+e.Rut+'\')" class="btn-link envio" >' + e.Rut + '</a>'))
                            .append($("<td>").html(e.Nombres))
                            .append($("<td>").html(e.IdSucursal))
                            .append($("<td>").html(e.Sucursal))
                            .append($("<td>").html(e.Cargo))


                    );
            });

            if (typeof $('#demo-foo-filtering').data('footable') !== "undefined") {
                $('#demo-foo-filtering').data('footable').redraw();
            }

        });

        



        var filtering = $('#demo-foo-filtering');

        filtering.footable().on('footable_filtering', function (e) {

            e.clear = !e.filter;

        });





        // Search input
        $('#demo-foo-search').on('input', function (e) {
            e.preventDefault();
            if ($(this).val().length >= 5 || $(this).val().length == 0) {
                filtering.trigger('footable_filter', { filter: $(this).val() });
            }
        });

    }

});