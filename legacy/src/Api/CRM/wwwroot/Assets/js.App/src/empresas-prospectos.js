

$(function () {
    /*#Prospecciones
            Tabla de prospecciones donde se cargan todos los datos cargados para una oficina en partucular.
    */
    var codigo_oficina = getCookie("Oficina");
    var rut_ejecutivo = getCookie("Rut");
    var servidor_api = "http://localhost:15001";
    var objeto_localidad = [];
    var prospecto_data = {};
    prospecto_data.contactos = [];
    var moduloContactos = {
        renderizarListadoContactos: function () {
            $("#tbody-contactos").html("");
            $.each(prospecto_data.contactos, function (i, e) {
                $("#tbody-contactos").append(`
                    <tr>
                        <td class="text-center">${e.cargo}</td>
                        <td class="text-center">${e.nombre}</td>
                        <td class="text-center">${e.correo}</td>
                        <td class="text-center">${e.celular}</td>
                        <td class="text-center">${e.telefono}</td>
                    </tr>`);
            });
        },
        agregarNuevoContacto: function () {
            var modelo = $("#form-contacto").serializeFormJSON();
            modelo.rutEjecutivo = rut_ejecutivo;
            modelo.oficinaCodigo = parseInt(codigo_oficina);
            modelo.id = 0;
            prospecto_data.contactos.push(modelo);
        },
        limpiarFormularioContactos: function () {
            $("#form-contacto").find("input[type=text], select").val("");
        },
        limpiarFormularioProspecto: function () {
            $("#form-ingreso-prospecto").find("input[type=text], select").val("");
        },
        cerrarModalContactos: function () {
            $("#modal-contactos").modal("hide");
        },
        guardarCambios: function (metodo) {
            var modGeneral = $("#form-ingreso-prospecto").serializeFormJSON();
            var modelo = Object.assign(prospecto_data, modGeneral);
            modelo.oficinaCodigo = parseInt(codigo_oficina);
            modelo.rutEjecutivo = rut_ejecutivo;
            var url_envio = metodo === "post" ? `${servidor_api}/api/prospectos` : `${servidor_api}/api/prospectos/${modelo.rut}`;
            console.log({ modelo, url_envio, metodo });

            $.ajax({
                type: metodo === "post" ? "POST":"PUT",
                url: url_envio,
                data: JSON.stringify(modelo),
                contentType: "application/json; charset=utf-8"
            }).done(function (data) {

                $.niftyNoty({
                    type: "success",
                    container: "floating",
                    title: "Exito",
                    message: "Datos de prospeccion guardados.<br/><small></small>",
                    closeBtn: true,
                    timer: 5000
                });

                moduloContactos.limpiarFormularioProspecto();
                moduloContactos.cargarTablaProspectos();
                $(".listado-prospectos").toggle();
                $(".detalle-prospectos").toggle();
                
                console.log({ data });
            }).fail(function (error) {
                console.log({ error });
            });

            
        },
        cargarTablaProspectos: function (){
            var link = `${servidor_api}/api/prospectos/${codigo_oficina}`;
            $("#tbody_prospectos").html("");
            $.getJSON(link, function (prospectos) {
                console.log(prospectos);
                $.each(prospectos, function (i, e) {
                    $("#tbody_prospectos").append(`
                        <tr>
                            <td><a href="#" class="btn-link prospecto-accion" data-rut="${e.rut}">${e.rut}</a></td>
                            <td>${e.nombre}</td>
                            <td>${e.nombreHolding}</td>
                            <td>${e.cajaOrigen}</td>
                        </tr>
                    `);
                });
            });
        }, 
        cargaLocalidades: function () {
            $.getJSON(`${servidor_api}/api/localizacion`, function (regiones) {
                objeto_localidad = regiones;
                $.each(objeto_localidad, function (i, region) {
                    $("#region").append(`<option value="${region.Id}">${region.Nombre}</option>`);
                });

                console.log({ objeto_localidad });
            });
        },
        buscarProspectoPorRut: function (rut) {
            $.getJSON(`${servidor_api}/api/prospectos/busqueda/${rut}`, function (prospecto) {
                console.log({ prospecto });

                $("#form-ingreso-prospecto").find("input[type=text], select").each(function (i, e) {
                    var campo = $(e).prop("id");
                    eval(`$("#${campo}").val(prospecto.${campo}).trigger("change")`);
                });
                var rubros = ['Construccion', 'Educacion', 'Financiero', 'Mineria', 'Produccion', 'Salud', 'Servicios', 'Ventas', 'Retail'];

                if (rubros.indexOf(prospecto.rubro) === -1) {
                    $("#rubro").val("Otro").trigger("change");
                    $("#otroRubro").val(prospecto.rubro);
                }
                
                $(".listado-prospectos").toggle();
                $(".detalle-prospectos").toggle();
                prospecto_data.contactos = prospecto.contactos.map(function (o) {
                    return {
                        id: o.id,
                        cargo: o.tipoContacto,
                        nombre: o.nombreContacto,
                        correo: o.email,
                        celular: o.celular,
                        telefono: o.telefono
                    };
                });
                moduloContactos.renderizarListadoContactos();
            });
        },
        formateaRut: function(rut) {

            var actual = rut.replace(/^0+/, "");
            if (actual != '' && actual.length > 1) {
                var sinPuntos = actual.replace(/\./g, "");
                var actualLimpio = sinPuntos.replace(/-/g, "");
                var inicio = actualLimpio.substring(0, actualLimpio.length - 1);
                var rutPuntos = "";
                var i = 0;
                var j = 1;
                for (i = inicio.length - 1; i >= 0; i--) {
                    var letra = inicio.charAt(i);
                    rutPuntos = letra + rutPuntos;
                    j++;
                }
                var dv = actualLimpio.substring(actualLimpio.length - 1);
                rutPuntos = rutPuntos + "-" + dv;
            }
            return rutPuntos;
        }

    };



    //Carga de Documento
    moduloContactos.cargarTablaProspectos();
    moduloContactos.cargaLocalidades();


    //Eventos de Jquery
    $("#agregar-cerrar").on("click", function () {
        moduloContactos.agregarNuevoContacto();
        moduloContactos.limpiarFormularioContactos();
        moduloContactos.cerrarModalContactos();
        moduloContactos.renderizarListadoContactos();
    });

    $("#agregar-limpiar").on("click", function () {
        moduloContactos.agregarNuevoContacto();
        moduloContactos.limpiarFormularioContactos();
        moduloContactos.renderizarListadoContactos();
    });

    $("#nuevo-prospecto, #bt-cancelar").on("click", function () {
        moduloContactos.limpiarFormularioProspecto();
        $(".listado-prospectos").toggle();
        $(".detalle-prospectos").toggle();
        $("#form-ingreso-prospecto").data("method", "post");
        prospecto_data.contactos = [];
        moduloContactos.renderizarListadoContactos();

    });
    

    $("#segmento").on("change", function () {
        if ($(this).val() === "Publica") {
            $("#categoria").prop("disabled", false);
        } else {
            $("#categoria").prop("disabled", true);
        }
    });

    $("#rubro").on("change", function () {
        if ($(this).val() === "Otro") {
            $(".otro-rubro").show();
        } else {
            $(".otro-rubro").hide();
        }
    });

    $("#region").on("change", function () {
        var codigoreg = parseInt($(this).val());
        var seleccionada = objeto_localidad.find(function (region) {
            return region.Id === codigoreg;
        });
        $("#comuna").html("");
        $("#comuna").append("<option value=''>Selecciona</option>");
        if (typeof seleccionada !== 'undefined') {
            $.each(seleccionada.Comunas, function (index, element) {
                $("#comuna").append(`<option value="${element.Nombre}">${element.Nombre}</option>`);
            });
        }
        
        console.log({ codigoreg, seleccionada, objeto_localidad });
    });


   


    $("#form-ingreso-prospecto").on("submit", function () {

        var metodio = $(this).data("method");
        moduloContactos.guardarCambios(metodio);

        return false;
    });

    $(document.body).on('click', '.prospecto-accion', function (event) {
        var rut = $(event.currentTarget).data("rut");
        $("#form-ingreso-prospecto").data("method", "put");
        moduloContactos.buscarProspectoPorRut(rut);
    });

    $("#rut").on("blur", function () {
        
        $(this).val(moduloContactos.formateaRut($(this).val()));
    });

});