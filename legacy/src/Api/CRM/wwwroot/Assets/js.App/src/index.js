function cargaDatosDeContacto(rutAf) {
    
    $("#bdy_datos_contactos > tr").remove();
    $("#bdy_datos_contactos").html("");

    $.SecGetJSON(BASE_URL + "/motor/api/Contactos/lista-contactos-afi", { RutAfiliado: rutAf }, function (contac) {
        $.each(contac, function (i, e) {
            var colorPorc = '';
            var alertFecha = '';

            if (e.PorcIndice > 70) {
                var colorPorc = 'pull-left badge badge-success'
            }
            if (e.PorcIndice > 40 && e.PorcIndice < 69) {
                var colorPorc = 'pull-left badge badge-warning'
            }
            if (e.PorcIndice < 39) {
                var colorPorc = 'pull-left badge badge-danger'
            }
            if (e.FechaContacto.toFecha() === "01-01-1900") {
                alertFecha = e.FechaContacto.toFecha() + '<i class="badge badge-danger badge-stat badge-icon pull-right add-tooltip" style="position: static; data-toggle="tooltip" data-container="body" data-placement="top" data-original-title="Se debe Actualizar Contacto">!</i>'
                $("#afiContac").css({ 'display': 'block' })
            }
            else { alertFecha = e.FechaContacto.toFecha() }


            $("#bdy_datos_contactos")
                .append(
                    $("<tr>")
                        .append($("<td>").append(
                            $("<select>").addClass('dropdown-caret').css('width', '88px').css('border-radius', '6px').append(
                                $('<option data-icon="fa fa-paint-brush">').val('Seleccione').text("Seleccione..."),
                                $('<option>').val(1).text("Valido Presencial"),
                                $('<option>').val(2).text("Contacto Valido"),
                                $('<option>').val(3).text("Tercero Valido"),
                                $('<option>').val(4).text("No Contesta"),
                                $('<option>').val(5).text("Buzon de voz"),
                                $('<option>').val(6).text("Apagado"),
                                $('<option>').val(7).text("Equivocado"),
                                $('<option>').val(8).text("No Existe")
                            ).on('change', function () {

                                var indice = $(this).val();
                                var valorD = e.ValorDato;
                                var ofici = getCookie("Oficina");
                                $.SecGetJSON(BASE_URL + "/motor/api/Contactos/actualiza-indice-contacto", { Indice: indice, RutAfi: rutAf, ValorDato: valorD, Oficina: ofici }, function (datos) {

                                    cargaDatosDeContacto(rutAf);

                                    $.niftyNoty({
                                        type: 'success',
                                        icon: 'pli-like-2 icon-2x',
                                        message: 'Gestión Guardada correctamente.',
                                        container: '#tab-gestion-3',
                                        timer: 5000
                                    });
                                });
                            })
                        ))
                        .append($("<td>").append(e.ValorDato))
                        .append($("<td>").append(e.TipoDato))
                        .append($("<td>").append(e.PorcIndice))
                        .append($("<td>").append(alertFecha))
                );
        });
    });

}

$(function () {

    var faIcon = {
        valid: 'fa fa-check-circle fa-lg text-success',
        invalid: 'fa fa-times-circle fa-lg',
        validating: 'fa fa-refresh'
    }

    var entorno = {
        Periodo: function () {
            var hoy = new Date();
            return hoy.getFullYear().toString() + (hoy.getMonth() + 1).toString().paddingLeft("00");
        }
    }

    var render = {
        PreaProbadosTableBody: (data, elm) => {
            $.each(data, function (i, e) {

                e.Seguimiento.Empresa = e.Seguimiento.Empresa.addSlashes();
                e.Seguimiento.Nombre = e.Seguimiento.Nombre.addSlashes();
                e.Seguimiento.Apellido = e.Seguimiento.Apellido.addSlashes();
                e.Seguimiento.Holding = e.Seguimiento.Holding.addSlashes();

                //data-target="#mdl_data" data-toggle="modal" data-periodo="' + row.Seguimiento.Periodo + '" data-rut="' + value + '-' + row.Seguimiento.Afiliado_Dv + '" data-tipo="' + row.Seguimiento.TipoAsignacion + '"
                ///motor/App/Gestion/Oferta/' + e.Seguimiento.Periodo + '/' + e.Seguimiento.Afiliado_Rut + '-' + e.Seguimiento.Afiliado_Dv + '/' + e.Seguimiento.TipoAsignacion + '
                elm.append(
                    $("<tr>")
                        .append($("<td>").append('<a href="#" data-target="#mdl_data" data-toggle="modal" data-periodo="' + e.Seguimiento.Periodo + '" data-rut="' + e.Seguimiento.Afiliado_Rut + '-' + e.Seguimiento.Afiliado_Dv + '" data-tipo="' + e.Seguimiento.TipoAsignacion + '" class="btn-link" >' + e.Seguimiento.Afiliado_Rut.toMoney(0) + '-' + e.Seguimiento.Afiliado_Dv + '</a>'))
                        .append($("<td>").append(e.Seguimiento.Nombre + ' ' + e.Seguimiento.Apellido))
                        .append($("<td>").append(e.Seguimiento.Empresa))
                        .append($("<td>").append(e.Seguimiento.Segmento))
                        .append($("<td>").append((e.UltimaGestion.GestionBase.IdBaseCampagna > 0 && e.UltimaGestion.GestionBase.FechaCompromete.toFecha() != '01-01-1753') ? e.UltimaGestion.GestionBase.FechaCompromete.toFecha() : 'N/A'))
                        .append($("<td>").append('$' + e.Seguimiento.PreAprobadoFinal.toMoney(0)))
                        .append($("<td>").append(e.Seguimiento.Prioridad.toString().toEtiquetaPrioridad() + (e.Notificaciones.length > 0 ? '    <span class="badge badge-info">!</span>' : '')))
                        .append($("<td>").append(e.Seguimiento.TipoCampania))
                        .append($("<td>").append((e.UltimaGestion.GestionBase.IdBaseCampagna > 0) ? e.UltimaGestion.EstadoGestion.eges_nombre : 'Sin Gestión'))
                        .append($("<td>").append((e.UltimaGestion.GestionBase.IdBaseCampagna > 0) ? e.UltimaGestion.SubEstadoGestion.eges_nombre : 'Sin Gestión'))
                );
            });
        },
        RecuperacionesTableBody: (data) => {
            $.each(data, function (i, e) {

                e.Seguimiento.Empresa = e.Seguimiento.Empresa.addSlashes();
                e.Seguimiento.Nombre = e.Seguimiento.Nombre.addSlashes();
                e.Seguimiento.Apellido = e.Seguimiento.Apellido.addSlashes();
                e.Seguimiento.Holding = e.Seguimiento.Holding.addSlashes();

                $("#bdy_datos_recu")
                    .append(
                    $("<tr>")
                        .append($("<td>").append('<a href="#" data-target="#mdl_data" data-toggle="modal" data-periodo="' + e.Seguimiento.Periodo + '" data-rut="' + e.Seguimiento.Afiliado_Rut + '-' + e.Seguimiento.Afiliado_Dv + '" data-tipo="' + e.Seguimiento.TipoAsignacion + '" class="btn-link" >' + e.Seguimiento.Afiliado_Rut.toMoney(0) + '-' + e.Seguimiento.Afiliado_Dv + '</a>'))
                        .append($("<td>").append(e.Seguimiento.Nombre + ' ' + e.Seguimiento.Apellido))
                        .append($("<td>").append(e.Seguimiento.Empresa))
                        .append($("<td>").append(e.Seguimiento.Segmento))
                        .append($("<td>").append((e.UltimaGestion.GestionBase.IdBaseCampagna > 0 && e.UltimaGestion.GestionBase.FechaCompromete.toFecha() != '01-01-1753') ? e.UltimaGestion.GestionBase.FechaCompromete.toFecha() : 'N/A'))
                        .append($("<td>").append('$' + e.Seguimiento.PreAprobadoFinal.toMoney(0)))
                        .append($("<td>").append(e.Seguimiento.Prioridad.toString().toEtiquetaPloma() + (e.Notificaciones.length > 0 ? '    <span class="badge badge-info">!</span>' : '')))
                        .append($("<td>").append((e.UltimaGestion.GestionBase.IdBaseCampagna > 0) ? e.UltimaGestion.CausaBasalGestion.eges_nombre : 'Sin Causa'))
                        .append($("<td>").append((e.UltimaGestion.GestionBase.IdBaseCampagna > 0) ? e.UltimaGestion.ConsecuenciaGestion.eges_nombre : 'Sin Consecuencia'))
                        .append($("<td>").append((e.UltimaGestion.GestionBase.IdBaseCampagna > 0) ? e.UltimaGestion.EstadoGestion.eges_nombre : 'Sin Gestión'))
                    );

            });
        },
        SegCesantiaTableBody: (data, elm) => {
            $.each(data, function (i, e) {

                e.Seguimiento.Empresa = e.Seguimiento.Empresa.addSlashes();
                e.Seguimiento.Nombre = e.Seguimiento.Nombre.addSlashes();
                e.Seguimiento.Apellido = e.Seguimiento.Apellido.addSlashes();
                e.Seguimiento.Holding = e.Seguimiento.Holding.addSlashes();


                elm.append(
                    $("<tr>")
                        .append($("<td>").append('<a href="#" data-target="#mdl_data" data-toggle="modal" data-periodo="' + e.Seguimiento.Periodo + '" data-rut="' + e.Seguimiento.Afiliado_Rut + '-' + e.Seguimiento.Afiliado_Dv + '" data-tipo="' + e.Seguimiento.TipoAsignacion + '" class="btn-link" >' + e.Seguimiento.Afiliado_Rut.toMoney(0) + '-' + e.Seguimiento.Afiliado_Dv + '</a>'))
                        .append($("<td>").append(e.Seguimiento.Nombre + ' ' + e.Seguimiento.Apellido))
                        .append($("<td>").append(e.Seguimiento.PensionadoFFAA))
                        .append($("<td>").append(e.Seguimiento.Prioridad))
                        .append($("<td>").append((e.UltimaGestion.GestionBase.IdBaseCampagna > 0 && e.UltimaGestion.GestionBase.FechaCompromete.toFecha() != '01-01-1753') ? e.UltimaGestion.GestionBase.FechaCompromete.toFecha() : 'N/A'))
                        .append($("<td>").append((e.UltimaGestion.GestionBase.IdBaseCampagna > 0) ? e.UltimaGestion.EstadoGestion.eges_nombre : 'Sin Gestión'))
                        .append($("<td>").append((e.UltimaGestion.GestionBase.IdBaseCampagna > 0) ? e.UltimaGestion.SubEstadoGestion.eges_nombre : 'Sin Gestión'))
                );
            });
        },
        HistorialGestion: function (gesList) {
            //Gestiones Realizadas
            $("#gestiones_realizadas").html("");
            $.each(gesList, function (i, e) {
                $("#gestiones_realizadas").append($("<a>").attr("href", '#')
                    .append($("<h4>").addClass("list-group-item-heading").html("<strong>Gestor:</strong> " + e.Gestor.EjecutivoData.Nombres))
                    .append($("<p>").addClass("list-group-item-text").html("<strong>Fecha Gestión:</strong>" + e.GestionBase.FechaAccion.toFechaHora() + ", <strong>Fecha Prox. Gestión:</strong> " + e.GestionBase.FechaCompromete.toFecha()))
                    .append($("<p>").addClass("list-group-item-text").html("<strong>Estado:</strong> " + e.EstadoGestion.eges_nombre + ",  <strong>Sub Estado:</strong> " + e.SubEstadoGestion.eges_nombre))
                    .append($("<p>").addClass("list-group-item-text").html("<strong>Comentario:</strong> " + e.GestionBase.Descripcion))
                );
            });

            if (gesList.length > 0 && gesList[0].EstadoGestion.ejes_terminal === "CERRADOS") {
                $(".esconder").hide();
            } else {
                $(".esconder").show();
            }

            $("#morfeable_monto").text("Monto Pre Aprobado");

        },
        HistorialGestionRecuperaciones: function (gesList) {
            $("#gestiones_realizadas").html("");
            $.each(gesList, function (i, e) {
                var consecuencia = (e.ConsecuenciaGestion !== null) ? ", <strong>Consecuencia:</strong> " + e.ConsecuenciaGestion.eges_nombre : "";
                var estatus = (e.EstadoGestion !== null) ? ", <strong>Estado:</strong> " + e.EstadoGestion.eges_nombre : "";
                $("#gestiones_realizadas").append($("<a>").attr("href", '#')
                    .append($("<h4>").addClass("list-group-item-heading").html("<strong>Gestor:</strong> " + e.Gestor.EjecutivoData.Nombres))
                    .append($("<p>").addClass("list-group-item-text").html("<strong>Fecha Gestión:</strong>" + e.GestionBase.FechaAccion.toFechaHora() + ", <strong>Fecha Prox. Gestión:</strong> " + e.GestionBase.FechaCompromete.toFecha()))
                    .append($("<p>").addClass("list-group-item-text").html("<strong>Causa basal:</strong> " + e.CausaBasalGestion.eges_nombre + consecuencia + estatus))
                    .append($("<p>").addClass("list-group-item-text").html("<strong>Comentario:</strong> " + e.GestionBase.Descripcion))
                );
            });

            if (gesList.length > 0 && gesList[0].EstadoGestion.ejes_terminal === "CERRADOS") {
                $(".esconder").hide();
            } else {
                $(".esconder").show();
            }
        }
    }

    // Estados de Gestion
    $('#demo-foo-filter-status').change(function (e) {
        e.preventDefault();

        if ($(this).val() != '') {
            $("#demo-foo-filter-statusSub").attr("disabled", false);
            $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: 1, padre: $(this).val() }, function (datos) {
                $("#demo-foo-filter-statusSub").html("");
                $("#demo-foo-filter-statusSub").append($("<option>").attr("value", "").html("Seleccione"));
                $("#demo-foo-filter-statusSub").append($("<option>").attr("value", "-1").html("Sin Gestión"));
                $.each(datos, function (i, e) {
                    $("#demo-foo-filter-statusSub").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre))
                });
            });
        }
        else {
            $("#demo-foo-filter-statusSub").html("");
            $("#demo-foo-filter-statusSub").attr("disabled", true);
        }
    });


    // Filter status
    $('#demo-foo-filter-statusDR').change(function (e) {
        e.preventDefault();

        if ($(this).val() != '') {
            $("#demo-foo-filter-statusSubDR").attr("disabled", false);
            $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: 5, padre: $(this).val() }, function (datos) {
                $("#demo-foo-filter-statusSubDR").html("");
                $("#demo-foo-filter-statusSubDR").append($("<option>").attr("value", "").html("Seleccione"));

                $.each(datos, function (i, e) {
                    $("#demo-foo-filter-statusSubDR").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre))
                });
            });
        }
        else {
            $("#demo-foo-filter-statusSubDR").html("");
            $("#demo-foo-filter-statusSubDR").attr("disabled", true);
        }
    });

    $('#flt_estado_sc').change(function (e) {
        e.preventDefault();

        if ($(this).val() != '') {
            $("#flt_sub_estado_sc").attr("disabled", false);
            $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: 4, padre: $(this).val() }, function (datos) {
                $("#flt_sub_estado_sc").html("");
                $("#flt_sub_estado_sc").append($("<option>").attr("value", "").html("Seleccione"));
                $("#flt_sub_estado_sc").append($("<option>").attr("value", "-1").html("Sin Gestión"));

                $.each(datos, function (i, e) {
                    $("#flt_sub_estado_sc").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre))
                });
            });
        }
        else {
            $("#flt_sub_estado_sc").html("");
            $("#flt_sub_estado_sc").attr("disabled", true);
        }
    });


    //Evento de busqueda de cualquier gestión    
    $("#btn_buscar_otr").on("click", function () {

        var rutAfilado = $("#afi_rut_busc").val().replace(/\./g, '')
        var tpcmp = $("#PrincipalTabActivo").val();
        $.SecGetJSON(BASE_URL + "/motor/api/Gestion/obtener-seguimiento", { periodo: entorno.Periodo, afiRut: rutAfilado.trim(), tipoCampagna: tpcmp }, function (datos) {

            if (datos.Estado === "OK") {
                location.href = BASE_URL + '/motor/App/Gestion/Oferta/' + datos.Objeto.Seguimiento.Periodo.toString() + '/' + rutAfilado + '/' + tpcmp
            } else {
                $.niftyNoty({
                    type: 'primary',
                    container: '#bdy_busqueda',
                    html: '<strong>!</strong> No se encontro Rut para el periodo actual.',
                    focus: false,
                    timer: 3000
                });
            }
        });


    });

    //Evento de Estado maestro Pre Aprobados
    $("#ges_estado").on("change", function () {

        if ($(this).val() != '') {
            $("#ges_subestado").attr("disabled", false);
            $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: $(this).data("TipoAsignacion"), padre: $(this).val() }, function (datos) {
                $("#ges_subestado").html("");
                $("#ges_subestado").append($("<option>").attr("value", "").html("Seleccione"));
                $('#datos-gestion').bootstrapValidator('updateStatus', 'ges_subestado', 'NOT_VALIDATED').bootstrapValidator('validateField', 'ges_subestado');
                $.each(datos, function (i, e) {
                    $("#ges_subestado").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre))
                });
            });


            if ($(this).find("option:selected").data("terminal") == "CERRADOS" || $(this).find("option:selected").data("terminal") == "PENDIENTESNOCAL") {
                $("#fpg").hide();
            }
            else {
                $("#fpg").show();
            }

        }
        else {
            $("#ges_subestado").html("");
            $("#ges_subestado").attr("disabled", true);
        }
    });


    //Evento de Estado maestro Pre Aprobados Derivados
    $("#ges_estadoDR").on("change", function () {

        if ($(this).val() != '') {
            $("#ges_subestadoDR").attr("disabled", false);
            $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: $(this).data("TipoAsignacion"), padre: $(this).val() }, function (datos) {
                $("#ges_subestadoDR").html("");
                $("#ges_subestadoDR").append($("<option>").attr("value", "").html("Seleccione"));
                $('#datos-gestionDR').bootstrapValidator('updateStatus', 'ges_subestado', 'NOT_VALIDATED').bootstrapValidator('validateField', 'ges_subestado');
                $.each(datos, function (i, e) {
                    $("#ges_subestadoDR").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre))
                });
            });


            if ($(this).find("option:selected").data("terminal") == "CERRADOS" || $(this).find("option:selected").data("terminal") == "PENDIENTESNOCAL") {
                $("#fpg").hide();
            }
            else {
                $("#fpg").show();
            }

        }
        else {
            $("#ges_subestadoDR").html("");
            $("#ges_subestadoDR").attr("disabled", true);
        }
    });

    //Evento de estado maestro tmc
    $("#ges_estadoSC").on("change", function () {

        if ($(this).val() != '') {
            $("#ges_subestadoSC").attr("disabled", false);
            $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: $(this).data("TipoAsignacion"), padre: $(this).val() }, function (datos) {
                $("#ges_subestadoSC").html("");
                $("#ges_subestadoSC").append($("<option>").attr("value", "").html("Seleccione"));
                $('#datos-ges_subestadoSC').bootstrapValidator('updateStatus', 'ges_subestadoSC', 'NOT_VALIDATED').bootstrapValidator('validateField', 'ges_subestadoSC');
                $.each(datos, function (i, e) {
                    if (e.ejes_terminal != "SISTEMA") {
                        $("#ges_subestadoSC").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre))
                    }

                });
            });


            if ($(this).find("option:selected").data("terminal") == "CERRADOS" || $(this).find("option:selected").data("terminal") == "PENDIENTESNOCAL") {
                $("#fpgSC").hide();
            }
            else {
                $("#fpgSC").show();
            }

        }
        else {
            $("#ges_subestadoTMC").html("");
            $("#ges_subestadoTMC").attr("disabled", true);
        }
    });


    //EVENTOS TABS
    $("#tab_recuperaciones").on("shown.bs.tab", function () {
        sessionStorage.setItem('GST_PESTANA_ACTIVA', '2');
        $("#PrincipalTabActivo").val("2");

        //Carga de selects Filtros de Normalizaciones
        $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: 2, padre: 0 }, function (datos) {

            $("#flt_causa_normalizacion").html("");
            $("#flt_causa_normalizacion").append($("<option>").attr("value", "").html("Todos"));

            $.each(datos, function (i, e) {
                $("#flt_causa_normalizacion").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre).data("terminal", e.ejes_terminal))
            });
        });
        //Carga de selects Filtros de Normalizaciones
        $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: 2, padre: 10 }, function (datos) {

            $("#flt_consecuencia_normalizacion").html("");
            $("#flt_consecuencia_normalizacion").append($("<option>").attr("value", "").html("Todos"));

            $.each(datos, function (i, e) {
                $("#flt_consecuencia_normalizacion").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre).data("terminal", e.ejes_terminal))
            });
        });
        //Carga de selects Filtros de Normalizaciones
        $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: 2, padre: 20 }, function (datos) {

            $("#flt_estado_normalizacion").html("");
            $("#flt_estado_normalizacion").append($("<option>").attr("value", "").html("Todos"));

            $.each(datos, function (i, e) {
                $("#flt_estado_normalizacion").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre).data("terminal", e.ejes_terminal))
            });
        });
    })

    $("#tab_preaprobados").on("shown.bs.tab", function () {
        sessionStorage.setItem('GST_PESTANA_ACTIVA', '1');
        $("#PrincipalTabActivo").val("1")

        $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: 1, padre: 0 }, function (datos) {

            $("#demo-foo-filter-status").html("");
            $("#demo-foo-filter-status").append($("<option>").attr("value", "").html("Seleccione"));
            $("#demo-foo-filter-status").append($("<option>").attr("value", "-1").html("Sin Gestion"));
            $.each(datos, function (i, e) {
                $("#demo-foo-filter-status").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre).data("terminal", e.ejes_terminal))
            });


            $("#demo-foo-filter-statusDR").html("");
            $("#demo-foo-filter-statusDR").append($("<option>").attr("value", "").html("Seleccione"));
            $.each(datos, function (i, e) {
                $("#demo-foo-filter-statusDR").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre).data("terminal", e.ejes_terminal))
            });

        });

    })

    $("#tab_segcesantia").on("shown.bs.tab", function () {
        sessionStorage.setItem('GST_PESTANA_ACTIVA', '4');
        $("#PrincipalTabActivo").val("4")

        //Carga de selects Filtros de Normalizaciones
        $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: 4, padre: 0 }, function (datos) {

            $("#flt_estado_sc").html("");
            $("#flt_estado_sc").append($("<option>").attr("value", "").html("Todos"));
            $("#flt_estado_sc").append($("<option>").attr("value", "-1").html("Sin Gestión"));

            $.each(datos, function (i, e) {
                $("#flt_estado_sc").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre).data("terminal", e.ejes_terminal))
            });
        });
    })

    $("#tab_derivaciones").on("shown.bs.tab", function () {
        sessionStorage.setItem('GST_PESTANA_ACTIVA', '5');
        $("#PrincipalTabActivo").val("5");

        //Carga de selects Filtros de Pre Aprobados
        $("#demo-foo-filter-statusDR").html("");

        $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: 5, padre: 0 }, function (datos) {

            $("#demo-foo-filter-statusDR").append($("<option>").attr("value", "").html("Seleccione"));
            $("#demo-foo-filter-statusDR").append($("<option>").attr("value", "-1").html("Sin Gestión"));
            $.each(datos, function (i, e) {
                $("#demo-foo-filter-statusDR").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre).data("terminal", e.ejes_terminal))
            });

        });
    })


    //DERIVACIONES
    $('#btn_derivaciones').click(function () {
        $("#tabla_derivaciones").bootstrapTable('refresh', {
            url: BASE_URL + "/motor/api/Gestion/v3/lista-seguimientos",
            query: {
                tipoCampagna: 5,
                periodo: entorno.Periodo,
                estado: $('#demo-foo-filter-statusDR').val(),
                subestado: $('#demo-foo-filter-statusSubDR').val(),
                prioridad: $('#slPrioridadDR').val(),
                segmento: $('#slSegmentoDR').val(),
                tipo: $('#slTipoDR').val(),
                rut: $('#demo-foo-searchDR').val(),
                vencimiento: $('#flt_vencidos_dr').val()
            }
        });

    });

    $("#tabla_derivaciones").bootstrapTable({
        //url: BASE_URL + "/motor/api/Gestion/v3/lista-seguimientos",
        pagination: true,
        sidePagination: 'server',
        ajaxOptions: {
            headers: {
                "Token": getCookie("Token"),
                "TokenExpiry": "900",
                "Access-Control-Expose-Headers": "Token,TokenExpiry"
            }
        },
        queryParams: function (params) {

            params.periodo = entorno.Periodo;
            params.tipoCampagna = 5;
            params.estado = $('#demo-foo-filter-statusDR').val();
            params.subestado = $('#demo-foo-filter-statusSubDR').val();
            params.prioridad = $('#slPrioridadDR').val();
            params.segmento = $('#slSegmentoDR').val();
            params.tipo = $('#slTipoDR').val();
            params.vencimiento = $('#flt_vencidos_dr').val()
            return params;
        },
        locale: 'es-ES',
        striped: true,
        pagination: true,
        pageSize: 30,
        pageList: [],
        search: false,
        showColumns: false,
        showRefresh: false,
        sortName: 'Seguimiento.Afiliado_Rut',
        columns: [
            {
                field: 'Seguimiento.Afiliado_Rut',
                title: 'Rut',
                sortable: true,
                formatter: function (value, row, index) {
                    return '<a href="#" class="btn-link" data-target="#mdl_data" data-toggle="modal" data-periodo="' + row.Seguimiento.Periodo + '" data-rut="' + value + '-' + row.Seguimiento.Afiliado_Dv + '" data-tipo="' + row.Seguimiento.TipoAsignacion + '">' + value.toMoney(0).toString() + '-' + row.Seguimiento.Afiliado_Dv + '</a>';
                }
            },
            {
                field: 'Seguimiento.Nombre',
                title: 'Nombre',
                sortable: false,
                formatter: function (value, row, index) {
                    return value + ' ' + row.Seguimiento.Apellido
                }
            },
            {
                field: 'Seguimiento.Empresa',
                title: 'Empresa',
                sortable: true
            },
            {
                field: 'Seguimiento.Segmento',
                title: 'Segmento',
                sortable: false
            },
            {
                field: 'UltimaGestion.GestionBase.IdBaseCampagna',
                title: 'Prox. Gestión',
                sortable: true,
                formatter: function (value, row, index) {
                    return value > 0 ? row.UltimaGestion.GestionBase.FechaCompromete.toFecha() === '01-01-1753' ? '-' : row.UltimaGestion.GestionBase.FechaCompromete.toFecha() : 'N/A';
                }
            },
            {
                field: 'Seguimiento.PreAprobadoFinal',
                title: 'Pre Aprobado',
                sortable: true,
                align: 'right',
                formatter: function (value, row, index) {
                    return value.toMoney(0);
                }
            },
            {
                field: 'Seguimiento.Prioridad',
                title: 'Prioridad',
                sortable: false,
                formatter: function (value, row, index) {
                    return value.toString().toEtiquetaPrioridad() + (row.Notificaciones.length > 0 ? '    <span class="badge badge-info">!</span>' : '')
                }
            },

            {
                field: 'Seguimiento.TipoCampania',
                title: 'Tipo',
                sortable: false
            },

            {
                field: 'UltimaGestion.EstadoGestion.eges_id',
                title: 'Estado',
                sortable: false,
                formatter: function (value, row, index) {
                    return value > 0 ? row.UltimaGestion.EstadoGestion.eges_nombre : 'Sin Gestión';
                }
            },

            {
                field: 'UltimaGestion.SubEstadoGestion.eges_id',
                title: 'Sub Estado',
                sortable: false,
                formatter: function (value, row, index) {
                    var mostrar = ''
                    switch (row.UltimaGestion.SubEstadoGestion.eges_id) {
                        case 202:
                            mostrar = '<div class="label label-table label-success">' + row.UltimaGestion.SubEstadoGestion.eges_nombre + '</div>';
                            break;
                        case 201:
                        case 203:
                        case 204:
                        case 205:
                        case 206:
                            mostrar = '<div class="label label-table label-danger">' + row.UltimaGestion.SubEstadoGestion.eges_nombre + '</div>';
                            break;
                        default:
                            mostrar = '<div class="label label-table label-warning">' + row.UltimaGestion.SubEstadoGestion.eges_nombre + '</div>';

                    }

                    return value > 0 ? mostrar : '<div class="label label-table label-default">Sin Gestión</div>';
                }
            },


        ]
    });


    //COMERCIAL 

    $('#button').click(function () {
        $("#tabla_comercial").bootstrapTable('refresh', {
            url: BASE_URL + "/motor/api/Gestion/v3/lista-seguimientos",
            query: {
                tipoCampagna: 1,
                periodo: entorno.Periodo,
                estado: $('#demo-foo-filter-status').val(),
                subestado: $('#demo-foo-filter-statusSub').val(),
                marca: $('#demo-foo-filter-statusMarca').val(),
                prioridad: $('#slPrioridad').val(),
                segmento: $('#slSegmento').val(),
                tipo: $('#slTipo').val(),
                busEmpresa: $('#demo-chosen-select').val(),
                rut: $('#demo-foo-search').val(),
                vencimiento: $('#flt_vencidos').val()
            }
        });
        $("#tabla_comercial > tbody").addClass("buscar")
    });

    $("#tabla_comercial").bootstrapTable({
        //url: BASE_URL + "/motor/api/Gestion/v3/lista-seguimientos",
        pagination: true,
        sidePagination: 'server',
        ajaxOptions: {
            headers: {
                "Token": getCookie("Token"),
                "TokenExpiry": "900",
                "Access-Control-Expose-Headers": "Token,TokenExpiry"
            }
        },
        queryParams: function (params) {
            params.periodo = entorno.Periodo;
            params.tipoCampagna = 1;
            params.estado = $('#demo-foo-filter-status').val();
            params.subestado = $('#demo-foo-filter-statusSub').val();
            params.prioridad = $('#slPrioridad').val();
            params.segmento = $('#slSegmento').val();
            params.tipo = $('#slTipo').val();
            params.vencimiento = $('#flt_vencidos').val();
            return params;
        },
        locale: 'es-ES',
        striped: true,
        pagination: true,
        pageSize: 30,
        pageList: [],
        search: false,
        showColumns: false,
        showRefresh: false,
        sortName: 'Seguimiento.Afiliado_Rut',
        columns: [
            {
                field: 'Seguimiento.Afiliado_Rut',
                title: 'Rut',
                sortable: true,
                formatter: function (value, row, index) {
                    return '<a href="#" class="btn-link" data-target="#mdl_data" data-toggle="modal" data-periodo="' + row.Seguimiento.Periodo + '" data-rut="' + value + '-' + row.Seguimiento.Afiliado_Dv + '" data-tipo="' + row.Seguimiento.TipoAsignacion + '">' + value.toMoney(0).toString() + '-' + row.Seguimiento.Afiliado_Dv + '</a>';
                }
            },
            {
                field: 'Seguimiento.Nombre',
                title: 'Nombre',
                sortable: false,
                formatter: function (value, row, index) {
                    return value + ' ' + row.Seguimiento.Apellido
                }
            },
            {
                field: 'Seguimiento.Empresa',
                title: 'Empresa',
                sortable: true
            },
            {
                field: 'Seguimiento.Segmento',
                title: 'Segmento',
                sortable: false
            },
            {
                field: 'UltimaGestion.GestionBase.IdBaseCampagna',
                title: 'Prox. Gestión',
                sortable: true,
                formatter: function (value, row, index) {
                    return value > 0 ? row.UltimaGestion.GestionBase.FechaCompromete.toFecha() === '01-01-1753' ? '-' : row.UltimaGestion.GestionBase.FechaCompromete.toFecha() : 'N/A';
                }
            },
            {
                field: 'Seguimiento.PreAprobadoFinal',
                title: 'Pre Aprobado',
                sortable: true,
                align: 'right',
                formatter: function (value, row, index) {
                    return value.toMoney(0);
                }
            },
            {
                field: 'Seguimiento.Prioridad',
                title: 'Prioridad',
                sortable: false,
                formatter: function (value, row, index) {
                    return value.toString().toEtiquetaPrioridad() + (row.Notificaciones.length > 0 ? '    <span class="badge badge-info">!</span>' : '')
                }
            },

            {
                field: 'Seguimiento.TipoCampania',
                title: 'Tipo',
                sortable: false
            },

            {
                field: 'UltimaGestion.EstadoGestion.eges_id',
                title: 'Estado',
                sortable: false,
                formatter: function (value, row, index) {
                    return value > 0 ? row.UltimaGestion.EstadoGestion.eges_nombre : 'Sin Gestión';
                }
            },

            {
                field: 'UltimaGestion.SubEstadoGestion.eges_id',
                title: 'Sub Estado',
                sortable: false,
                formatter: function (value, row, index) {
                    var mostrar = ''
                    switch (row.UltimaGestion.SubEstadoGestion.eges_id) {
                        case 202:
                            mostrar = '<div class="label label-table label-success">' + row.UltimaGestion.SubEstadoGestion.eges_nombre + '</div>';
                            break;
                        case 201:
                        case 203:
                        case 204:
                        case 205:
                        case 206:
                            mostrar = '<div class="label label-table label-danger">' + row.UltimaGestion.SubEstadoGestion.eges_nombre + '</div>';
                            break;
                        default:
                            mostrar = '<div class="label label-table label-warning">' + row.UltimaGestion.SubEstadoGestion.eges_nombre + '</div>';

                    }

                    return value > 0 ? mostrar : '<div class="label label-table label-default">Sin Gestión</div>';
                }
            },
        ]
    });


    //RECUPERACIONES 

    $('#btn_recuperaciones').click(function () {
        $("#tabla_recuperaciones").bootstrapTable('refresh', {
            url: BASE_URL + "/motor/api/Gestion/v3/lista-seguimientos",
            query: {
                tipoCampagna: 2,
                periodo: entorno.Periodo,
                estado: $('#flt_estado_normalizacion').val(),
                causaBasal: $('#flt_causa_normalizacion').val(),
                consecuencia: $('#flt_consecuencia_normalizacion').val(),
                prioridad: $('#slPrioridad_normalizacion').val(),
                rut: $('flt_rut_normalizacion').val(),
                vencimiento: $('#flt_vencidos_normalizacion').val()
            }
        });

    });


    $("#tabla_recuperaciones").bootstrapTable({
        pagination: true,
        sidePagination: 'server',
        ajaxOptions: {
            headers: {
                "Token": getCookie("Token"),
                "TokenExpiry": "900",
                "Access-Control-Expose-Headers": "Token,TokenExpiry"
            }
        },
        queryParams: function (params) {

            params.periodo = entorno.Periodo;
            params.tipoCampagna = 2;
            params.causaBasal = $('#flt_causa_normalizacion').val();
            params.consecuencia = $('#flt_consecuencia_normalizacion').val();
            params.estado = $('#flt_estado_normalizacion').val();
            params.prioridad = $('#slPrioridad_normalizacion').val();
            params.rut = $('flt_rut_normalizacion').val();
            params.vencimiento = $('#flt_vencidos_normalizacion').val()
            return params;
        },
        locale: 'es-ES',
        striped: true,
        pagination: true,
        pageSize: 30,
        pageList: [],
        search: false,
        showColumns: false,
        showRefresh: false,
        sortName: 'Seguimiento.Afiliado_Rut',
        columns: [
            {
                field: 'Seguimiento.Afiliado_Rut',
                title: 'Rut',
                sortable: true,
                formatter: function (value, row, index) {
                    return '<a href="#" class="btn-link" data-target="#mdl_data" data-toggle="modal" data-periodo="' + row.Seguimiento.Periodo + '" data-rut="' + value + '-' + row.Seguimiento.Afiliado_Dv + '" data-tipo="' + row.Seguimiento.TipoAsignacion + '">' + value.toMoney(0).toString() + '-' + row.Seguimiento.Afiliado_Dv + '</a>';
                }
            },
            {
                field: 'Seguimiento.Nombre',
                title: 'Nombre',
                sortable: false,
                formatter: function (value, row, index) {
                    return value + ' ' + row.Seguimiento.Apellido
                }
            },
            {
                field: 'Seguimiento.Empresa',
                title: 'Empresa',
                sortable: true
            },
            {
                field: 'Seguimiento.Segmento',
                title: 'Segmento',
                sortable: false
            },
            {
                field: 'UltimaGestion.GestionBase.IdBaseCampagna',
                title: 'Prox. Gestión',
                sortable: true,
                formatter: function (value, row, index) {
                    return value > 0 ? row.UltimaGestion.GestionBase.FechaCompromete.toFecha() === '01-01-1753' ? '-' : row.UltimaGestion.GestionBase.FechaCompromete.toFecha() : 'N/A';
                }
            },
            {
                field: 'Seguimiento.PreAprobadoFinal',
                title: 'Monto Adeudado',
                sortable: true,
                align: 'right',
                formatter: function (value, row, index) {
                    return value.toMoney(0);
                }
            },
            {
                field: 'Seguimiento.Prioridad',
                title: 'Prioridad',
                sortable: false,
                formatter: function (value, row, index) {
                    return value.toString().toEtiquetaPloma() + (row.Notificaciones.length > 0 ? '    <span class="badge badge-info">!</span>' : '')
                }
            },
            {
                field: 'UltimaGestion.CausaBasalGestion.eges_id',
                title: 'Causa Basal',
                sortable: false,
                formatter: function (value, row, index) {
                    return value > 0 ? row.UltimaGestion.CausaBasalGestion.eges_nombre : 'Sin Causa';
                }
            },
            {
                field: 'UltimaGestion.ConsecuenciaGestion.eges_id',
                title: 'Concecuencia',
                sortable: false,
                formatter: function (value, row, index) {
                    return value > 0 ? row.UltimaGestion.ConsecuenciaGestion.eges_nombre : 'Sin Consecuencia';
                }
            },
            {
                field: 'UltimaGestion.EstadoGestion.eges_id',
                title: 'Estado',
                sortable: false,
                formatter: function (value, row, index) {
                    return value > 0 ? row.UltimaGestion.EstadoGestion.eges_nombre : 'Sin Gestión';

                }
            },
        ]
    });


    //SEGURO CESANTIA
    $('#btn_seguro_cesantia').click(function () {
        $("#tabla_seguro_cesantia").bootstrapTable('refresh', {
            url: BASE_URL + "/motor/api/Gestion/v3/lista-seguimientos",
            query: {
                tipoCampagna: 4,
                periodo: entorno.Periodo,
                estado: $('#flt_estado_sc').val(),
                subestado: $('#flt_sub_estado_sc').val(),
                rut: $('#flt_rut_sc').val(),
                vencimiento: $('#flt_vencidos_sc').val()
            }
        });
    });


    $("#tabla_seguro_cesantia").bootstrapTable({
        pagination: true,
        sidePagination: 'server',
        ajaxOptions: {
            headers: {
                "Token": getCookie("Token"),
                "TokenExpiry": "900",
                "Access-Control-Expose-Headers": "Token,TokenExpiry"
            }
        },
        queryParams: function (params) {
            params.tipoCampagna = 4;
            params.periodo = entorno.Periodo;
            params.estado = $('#flt_estado_sc').val();
            params.subestado = $('#flt_sub_estado_sc').val();
            params.rut = $('#flt_rut_sc').val();
            params.vencimiento = $('#flt_vencidos_sc').val();

            return params;
        },
        locale: 'es-ES',
        striped: true,
        pagination: true,
        pageSize: 30,
        pageList: [],
        search: false,
        showColumns: false,
        showRefresh: false,
        sortName: 'Seguimiento.Afiliado_Rut',
        columns: [
            {
                field: 'Seguimiento.Afiliado_Rut',
                title: 'Rut',
                sortable: true,
                formatter: function (value, row, index) {
                    return '<a href="#" class="btn-link" data-target="#mdl_data" data-toggle="modal" data-periodo="' + row.Seguimiento.Periodo + '" data-rut="' + value + '-' + row.Seguimiento.Afiliado_Dv + '" data-tipo="' + row.Seguimiento.TipoAsignacion + '">' + value.toMoney(0).toString() + '-' + row.Seguimiento.Afiliado_Dv + '</a>';
                }
            },
            {
                field: 'Seguimiento.Nombre',
                title: 'Nombre',
                sortable: false,
                formatter: function (value, row, index) {
                    return value + ' ' + row.Seguimiento.Apellido
                }
            },
            {
                field: 'Seguimiento.PensionadoFFAA',
                title: 'Número de Créditos',
                sortable: true
            },
            {
                field: 'Seguimiento.Prioridad',
                title: 'Prioridad',
                sortable: true,
                formatter: function (value, row, index) {
                    return value.toString().toEtiquetaPloma() + (row.Notificaciones.length > 0 ? '    <span class="badge badge-info">!</span>' : '')
                }
            },
            {
                field: 'UltimaGestion.GestionBase.IdBaseCampagna',
                title: 'Prox. Gestión',
                sortable: true,
                formatter: function (value, row, index) {
                    return value > 0 ? row.UltimaGestion.GestionBase.FechaCompromete.toFecha() === '01-01-1753' ? '-' : row.UltimaGestion.GestionBase.FechaCompromete.toFecha() : 'N/A';
                }
            },
            {
                field: 'UltimaGestion.EstadoGestion.eges_id',
                title: 'Estado',
                sortable: false,
                formatter: function (value, row, index) {
                    return value > 0 ? row.UltimaGestion.EstadoGestion.eges_nombre : 'Sin Gestión';
                }
            },
            {
                field: 'UltimaGestion.SubEstadoGestion.eges_id',
                title: 'Sub Estado',
                sortable: false,
                formatter: function (value, row, index) {
                    return value > 0 ? row.UltimaGestion.SubEstadoGestion.eges_nombre : 'Sin Gestión';
                }
            },
        ]
    });

    //GENERALES
    $.SecGetJSON(BASE_URL + "/motor/api/Gestion/listar-oficinas", function (datos) {

        $("#afi_oficina_preferencia").html("");
        $("#afi_oficina_preferencia").append($("<option>").attr("value", "").html("Seleccione"));
        $.each(datos, function (i, e) {
            $("#afi_oficina_preferencia").append($("<option>").attr("value", e.Id).html(e.Nombre))
        });
    });


    $('#mdl_data').on('show.bs.modal', function (e) {


        var trutAfiliado = $(e.relatedTarget).data("rut")
        var tperiodo = $(e.relatedTarget).data("periodo")
        var tipoCamp = $(e.relatedTarget).data("tipo")

        $.SecGetJSON(BASE_URL + "/motor/api/Gestion/obtener-seguimiento", { periodo: tperiodo, afiRut: trutAfiliado, tipoCampagna: tipoCamp }, function (datos) {

            if (datos.Estado === "OK") {
                const Asignacion = datos.Objeto;
                const afiData = Asignacion.Seguimiento;
                const gesList = Asignacion.HistorialGestion;

                //DATOS AFILIADO
                $('#afi_rut').val(afiData.Afiliado_Rut.toMoney(0) + '-' + afiData.Afiliado_Dv);
                $('#afi_nombres').val(afiData.Nombre + ' ' + afiData.Apellido);
                $('#afi_segmento').val(afiData.Segmento);
                $('#afi_empresa_nombre').val(afiData.Empresa);
                $('#afi_empresa_rut').val(parseInt(afiData.Empresa_Rut).toMoney(0) + '-' + afiData.Empresa_Dv);
                $('#afi_preaprobado').val(afiData.OfertaTexto.length === 0 ? '$' + afiData.PreAprobadoFinal.toMoney(0) : afiData.OfertaTexto);
                $('#ges_id_asignacion').val(afiData.id_Asign);
                $('#ges_id_asignacion_normalizacion').val(afiData.id_Asign);
                $('#ges_id_asignacionTMC').val(afiData.id_Asign);
                $('#ges_id_asignacionSC').val(afiData.id_Asign);
                $('#afi_oficina_preferencia').val(Asignacion.OficinaPreferencia.Valor_preferencia);
                $('#afi_horario_preferencia').val(Asignacion.HorarioPreferencia.Valor_preferencia);
                $("#OficinaAsig").val(Asignacion.NombreOficina)


                //CONTACTO
                ///////////////////////////////////////////////////////
                $("#afi_telefonos").html("");
                $.each(Asignacion.Telefonos, function (i, telefono) {

                    var n = '+' + telefono.Valor_contacto + ((telefono.Valido === 0) ? ' (malo)' : '');
                    var c = (telefono.Valido === 0) ? $("<option>").html(n).data("malo", "true") : $("<option>").html(n);
                    $("#afi_telefonos").append(c)

                });

                if (Asignacion.Telefonos.length == 0) {
                    $(".desaparecible, .forma-uno").hide();
                }

                ///////////////////////////////////////////////////////
                $("#afi_celulares").html("");
                $.each(Asignacion.Celulares, function (i, celular) {

                    var n = '+' + celular.Valor_contacto + ((celular.Valido === 0) ? ' (malo)' : '');
                    var c = (celular.Valido === 0) ? $("<option>").html(n).data("malo", "true") : $("<option>").html(n);
                    $("#afi_celulares").append(c)

                });

                if (Asignacion.Celulares.length == 0) {
                    $(".desaparecible-cel, .forma-uno-cel").hide();
                }

                ///////////////////////////////////////////////////////
                $("#afi_correos").html("");
                $.each(Asignacion.Correos, function (i, correo) {

                    var n = correo.Valor_contacto + ((correo.Valido === 0) ? ' (malo)' : '');
                    var c = (correo.Valido === 0) ? $("<option>").html(n).data("malo", "true") : $("<option>").html(n);
                    $("#afi_correos").append(c)

                });

                if (Asignacion.Correos.length == 0) {
                    $(".desaparecible-mail, .forma-uno-mail").hide();
                }

                //NOTIFICACIONES
                var sx = false;

                if (typeof Asignacion.Notificaciones != "undefined" && Asignacion.Notificaciones != null && Asignacion.Notificaciones.length > 0) {
                    var text = "";
                    var type = "success";
                    $(".charlyNTFContainer").html("");
                    $.each(Asignacion.Notificaciones, function (i, e) {

                        if (e.Tipo == "LICENCIA") {
                            text += "<strong>Licencias: </strong> Tiene " + e.Cantidad + " <strong>Licencia(s)</strong> pendiente(s) de pago por $" + Number(e.Valor).toMoney()
                        }

                        if (e.Tipo == "PAGEXCESO") {
                            text += "<strong>PEX: </strong> Tiene " + e.Cantidad + " <strong>Pagos en Exceso</strong> pendiente(s) de pago por $" + Number(e.Valor).toMoney()
                        }

                        if (e.Tipo == "SEGCESAN") {
                            text += "<strong>Seguros: </strong> Afiliado cuenta con <strong>Seguro de Cesantía</strong>"
                        }

                        if (e.Tipo == "MUNICIP") {
                            text += "<strong>Afiliado Municipal, </strong> debe ser evaluado por comité de créditos.</strong>"
                            type = "warning";
                        }

                        if (e.Tipo == "ACUERPAG") {
                            sx = true;
                        }
                        else {
                            $.niftyNoty({
                                type: type,
                                container: '.charlyNTFContainer',
                                html: text,
                                focus: false,
                                closeBtn: false
                            });
                        }
                    });


                    /*TO DO: Revisar la logica*/
                    if (!sx) {
                        $(".charlyNTF").show();
                    }
                }
                else {
                    $(".charlyNTF").hide();
                }

                var info_xxx = "";

                if (Asignacion.FiltrosRSG.length > 0) {
                    info_xxx = ("Filtros Riesgo " + Asignacion.FiltrosRSG).toEtiquetaSuperior('x');
                }



                if (tipoCamp === 1 || tipoCamp === 5) {
                    render.HistorialGestion(gesList);
                    $("#myLargeModalLabel").html("Gestión Comercial " + afiData.Prioridad.toString().toEtiquetaPrioridad() + " " + info_xxx);

                    $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-rechazos-rsg", { Periodo: tperiodo, RutEmpresa: afiData.Empresa_Rut, RutAfiliado: afiData.Afiliado_Rut }, function (datos) {
                        $("#letable").html("");
                        $.each(datos, function (i, e) {
                            $("#letable").append($("<tr>").append("<td>").html(e.MotivoRechazo))
                        });
                    });
                }

                if (tipoCamp === 2) {
                    render.HistorialGestionRecuperaciones(gesList);
                    $("#morfeable_monto").text("Monto Adeudado");
                    $("#myLargeModalLabel").text("Gestión de Normalización, Folio Crédito: " + afiData.RiesgoPerfil);
                }

                if (tipoCamp === 4) {
                    render.HistorialGestion(gesList);
                    $("#myLargeModalLabel").html('Gestión Seg Cesantía ' + afiData.Prioridad.toString().toEtiquetaPrioridad() + " Folios:" + afiData.RiesgoPerfil);// + afiData.Prioridad.toString().toEtiquetaPrioridad() + " " + info_xxx);
                    $("#morfeable_monto").text("Monto Adeudado");
                    $("#afi_preaprobado").val('$' + afiData.PreAprobadoFinal.toMoney(0))
                    $("#morf_cnvs").removeClass("col-sm-6").addClass("col-sm-3")

                    $(".segmento_texto").text("Fecha Colocación");
                    $("#afi_segmento").val(afiData.TipoCampania);

                    $("#labelempresa").text("N° Cuotas morosas");
                    $("#afi_empresa_nombre").val(afiData.EmpresaEsPensionado)

                    $("#labelrutempresa").text("Monto Cuota");
                    $("#afi_empresa_rut").val(afiData.Cuadrante.toMoney(0))

                    $(".charlyNTF").show();
                    $.niftyNoty({
                        type: 'warning',
                        container: '.charlyNTFContainer',
                        html: "<strong>Nota: </strong> Ver detalle de los creditos en sistema</strong>",
                        focus: false,
                        closeBtn: false
                    });

                }
            }
            else {
                $.niftyNoty({
                    type: 'primary',
                    container: '#bdy_busqueda',
                    html: '<strong>!</strong> No se encontro Rut para el periodo actual.',
                    focus: false,
                    timer: 3000
                });
            }
        });


        //Evento de Estado maestro Pre Aprobados
        $("#ges_estado").on("change", function () {

            if ($(this).val() != '') {
                $("#ges_subestado").attr("disabled", false);
                $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: tipoCamp, padre: $(this).val() }, function (datos) {
                    $("#ges_subestado").html("");
                    $("#ges_subestado").append($("<option>").attr("value", "").html("Seleccione"));
                    $('#datos-gestion').bootstrapValidator('updateStatus', 'ges_subestado', 'NOT_VALIDATED').bootstrapValidator('validateField', 'ges_subestado');
                    $.each(datos, function (i, e) {
                        $("#ges_subestado").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre))
                    });
                });


                if ($(this).find("option:selected").data("terminal") == "CERRADOS" || $(this).find("option:selected").data("terminal") == "PENDIENTESNOCAL") {
                    $("#fpg").hide();
                }
                else {
                    $("#fpg").show();
                }

            }
            else {
                $("#ges_subestado").html("");
                $("#ges_subestado").attr("disabled", true);
            }
        });

        //Evento de Estado maestro Pre Aprobados Derivados
        $("#ges_estadoDR").on("change", function () {

            if ($(this).val() != '') {
                $("#ges_subestadoDR").attr("disabled", false);
                $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: $(this).data("TipoAsignacion"), padre: $(this).val() }, function (datos) {
                    $("#ges_subestadoDR").html("");
                    $("#ges_subestadoDR").append($("<option>").attr("value", "").html("Seleccione"));
                    $('#datos-gestionDR').bootstrapValidator('updateStatus', 'ges_subestado', 'NOT_VALIDATED').bootstrapValidator('validateField', 'ges_subestado');
                    $.each(datos, function (i, e) {
                        $("#ges_subestadoDR").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre))
                    });
                });


                if ($(this).find("option:selected").data("terminal") == "CERRADOS" || $(this).find("option:selected").data("terminal") == "PENDIENTESNOCAL") {
                    $("#fpg").hide();
                }
                else {
                    $("#fpg").show();
                }

            }
            else {
                $("#ges_subestadoDR").html("");
                $("#ges_subestadoDR").attr("disabled", true);
            }
        });

        //Evento de estado maestro tmc
        $("#ges_estadoSC").on("change", function () {

            if ($(this).val() != '') {
                $("#ges_subestadoSC").attr("disabled", false);
                $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: tipoCamp, padre: $(this).val() }, function (datos) {
                    $("#ges_subestadoSC").html("");
                    $("#ges_subestadoSC").append($("<option>").attr("value", "").html("Seleccione"));
                    $('#datos-ges_subestadoSC').bootstrapValidator('updateStatus', 'ges_subestadoSC', 'NOT_VALIDATED').bootstrapValidator('validateField', 'ges_subestadoSC');
                    $.each(datos, function (i, e) {
                        if (e.ejes_terminal != "SISTEMA") {
                            $("#ges_subestadoSC").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre))
                        }

                    });
                });


                if ($(this).find("option:selected").data("terminal") == "CERRADOS" || $(this).find("option:selected").data("terminal") == "PENDIENTESNOCAL") {
                    $("#fpgSC").hide();
                }
                else {
                    $("#fpgSC").show();
                }

            }
            else {
                $("#ges_subestadoTMC").html("");
                $("#ges_subestadoTMC").attr("disabled", true);
            }
        });

        //COMERCIAL
        if (tipoCamp === 1 || tipoCamp === 5) {
            $('#datos-gestion').show();

            //Datepicker de Pre Aprobados
            $('#demo-dp-component .input-group.date').datepicker(
                { autoclose: true, format: 'dd-mm-yyyy', startDate: "0d", language: "es", daysOfWeekDisabled: [6, 0], todayHighlight: true }
            ).on('changeDate', function (e) {
                e.stopPropagation();
                $('#datos-gestion').bootstrapValidator('updateStatus', 'ges_prox_gestion', 'NOT_VALIDATED').bootstrapValidator('validateField', 'ges_prox_gestion');
            }).on('show.bs.modal hide.bs.modal', function (event) {
                // prevent datepicker from firing bootstrap modal "show.bs.modal"
                event.stopPropagation();
            });


            //Carga de selects
            $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: 1, padre: 0 }, function (datos) {
                $("#ges_estado").data("TipoAsignacion", tipoCamp);
                $("#ges_estado").html("");
                $("#ges_estado").append($("<option>").attr("value", "").html("Seleccione"));

                $.each(datos, function (i, e) {
                    $("#ges_estado").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre).data("terminal", e.ejes_terminal))
                });
            });


            // Validacion de formulario de Pre Aprobados
            // =================================================================
            $('#datos-gestion').bootstrapValidator({
                excluded: [':disabled', ':not(:visible)'],
                feedbackIcons: faIcon,
                fields: {
                    ges_estado: {
                        validators: {
                            notEmpty: {
                                message: 'Debe seleccionar un estado'
                            }
                        }
                    },
                    ges_subestado: {
                        validators: {
                            notEmpty: {
                                message: 'Debe seleccionar un sub estado'
                            }
                        }
                    },
                    ges_prox_gestion: {
                        validators: {
                            notEmpty: {
                                message: 'La fecha de próxima gestión no puede ser vacía'
                            },
                            date: {
                                format: 'DD-MM-YYYY',
                                message: 'Formato de fecha incorrecto'
                            }
                        }
                    },
                    ges_comentarios: {
                        validators: {
                            notEmpty: {
                                message: 'Debe agregar algún comentario'
                            },
                            stringLength: {
                                message: 'No pueden ser mas de 150 caracteres',
                                max: function (value, validator, $field) {
                                    return 150 - (value.match(/\r/g) || []).length;
                                }
                            }
                        }
                    },



                }
            }).on('success.form.bv', function (e) {
                // Prevén que se mande el formulario
                e.preventDefault();
                var $form = $(e.target);

                $.SecPostJSON(BASE_URL + "/motor/api/Gestion/guardar-gestion", $form.serialize(), function (respuesta) {

                    if (respuesta.Estado === 'OK') {

                        $.niftyNoty({
                            type: 'success',
                            container: '#mensahes-must',
                            html: '<strong>OK</strong> Gestion guardada exitosamente.',
                            focus: false,
                            timer: 3000
                        });


                        render.HistorialGestion(respuesta.Objeto);

                        if (respuesta.Objeto != null && respuesta.Objeto.length > 0 && respuesta.Objeto[0].EstadoGestion.ejes_terminal === "CERRADOS") {
                            $(".esconder").hide();
                        }

                        $("#datos-gestion").bootstrapValidator('resetForm', true);


                    } else {
                        $.niftyNoty({
                            type: 'danger',
                            container: '#mensahes-must',
                            html: '<strong>Error</strong> ' + respuesta.Mensaje,
                            focus: false,
                            timer: 3000
                        });
                    }

                });

            });

        }

        //RECUPERACIONES
        if (tipoCamp === 2) {

            $('#datos-gestion_normalizacion').show();

            $('#demo-dp-component_normalizacion .input-group.date').datepicker({ autoclose: true, format: 'dd-mm-yyyy', startDate: "0d", language: "es", daysOfWeekDisabled: [6, 0], todayHighlight: true }).on('show.bs.modal hide.bs.modal', function (event) {
                // prevent datepicker from firing bootstrap modal "show.bs.modal"
                event.stopPropagation();
            });

            //Carga de selects
            $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: tipoCamp, padre: 0 }, function (datos) {
                $("#ges_causa_basal_normalizacion").data("TipoAsignacion", tipoCamp);
                $("#ges_causa_basal_normalizacion").html("");
                $("#ges_causa_basal_normalizacion").append($("<option>").attr("value", "").html("Seleccione"));

                $.each(datos, function (i, e) {
                    $("#ges_causa_basal_normalizacion").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre).data("terminal", e.ejes_terminal))
                });
            });

            $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: tipoCamp, padre: 10 }, function (datos) {
                $("#ges_consecuencia_normalizacion").data("TipoAsignacion", tipoCamp);
                $("#ges_consecuencia_normalizacion").html("");
                $("#ges_consecuencia_normalizacion").append($("<option>").attr("value", "").html("Seleccione"));

                $.each(datos, function (i, e) {
                    $("#ges_consecuencia_normalizacion").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre).data("terminal", e.ejes_terminal))
                });
            });

            $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: tipoCamp, padre: 20 }, function (datos) {
                $("#ges_estado_normalizacion").data("TipoAsignacion", tipoCamp);
                $("#ges_estado_normalizacion").html("");
                $("#ges_estado_normalizacion").append($("<option>").attr("value", "").html("Seleccione"));

                $.each(datos, function (i, e) {
                    $("#ges_estado_normalizacion").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre).data("terminal", e.ejes_terminal))
                });
            });

            $('#datos-gestion_normalizacion').bootstrapValidator({
                excluded: [':disabled', ':not(:visible)'],
                feedbackIcons: faIcon,
                fields: {
                    ges_causa_basal_normalizacion: {
                        validators: {
                            notEmpty: {
                                message: 'Debe seleccionar una causa'
                            }
                        }
                    },
                    ges_consecuencia_normalizacion: {
                        validators: {
                            notEmpty: {
                                message: 'Debe seleccionar una consecuencia'
                            }
                        }
                    },
                    ges_estado_normalizacion: {
                        validators: {
                            notEmpty: {
                                message: 'Debe seleccionar un estado'
                            }
                        }
                    },
                    /*ges_prox_gestion_normalizacion: {
                        validators: {
                            notEmpty: {
                                message: 'La fecha de próxima gestión no puede ser vacía'
                            },
                            date: {
                                format: 'DD-MM-YYYY',
                                message: 'Formato de fecha incorrecto'
                            }
                        }
                    },*/
                    ges_comentarios_normalizacion: {
                        validators: {
                            notEmpty: {
                                message: 'Debe agregar algún comentario'
                            },
                            stringLength: {
                                message: 'No pueden ser mas de 150 caracteres',
                                max: function (value, validator, $field) {
                                    return 150 - (value.match(/\r/g) || []).length;
                                }
                            }
                        }
                    },



                }
            }).on('success.form.bv', function (e) {
                // Prevén que se mande el formulario
                e.preventDefault();
                var $form = $(e.target);

                $.SecPostJSON(BASE_URL + "/motor/api/Gestion/guardar-gestion-normalizacion", $form.serialize(), function (respuesta) {

                    if (respuesta.Estado === 'OK') {
                        render.HistorialGestionRecuperaciones(respuesta.Objeto);

                        if (respuesta.Objeto.length > 0 && respuesta.Objeto[0].EstadoGestion.ejes_terminal === "CERRADOS") {
                            $(".esconder").hide();
                        }

                        $("#datos-gestion_normalizacion").bootstrapValidator('resetForm', true);


                        $.niftyNoty({
                            type: 'success',
                            container: 'floating',
                            html: '<strong>OK</strong> Gestion guardada exitosamente.',
                            focus: false,
                            timer: 3000
                        });
                    }
                    else {
                        $.niftyNoty({
                            type: 'danger',
                            container: 'floating',
                            html: '<strong>Error</strong> ' + respuesta.Mensaje,
                            focus: false,
                            timer: 3000
                        });
                    }
                });
            });


        }

        //SEGURO CESANTIA
        if (tipoCamp === 4) {
            $('#datos-gestion-sc').show();


            $('#demo-dp-componentSC .input-group.date').datepicker({
                autoclose: true, format: 'dd-mm-yyyy', startDate: "0d", language: "es", daysOfWeekDisabled: [6, 0], todayHighlight: true
            }).on('changeDate', function (e) {
                $('#datos-gestion-sc').bootstrapValidator('updateStatus', 'ges_prox_gestionSC', 'NOT_VALIDATED').bootstrapValidator('validateField', 'ges_prox_gestionSC');
            }).on('show.bs.modal hide.bs.modal', function (event) {
                // prevent datepicker from firing bootstrap modal "show.bs.modal"
                event.stopPropagation();
            });

            //Carga de selects
            $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: tipoCamp, padre: 0 }, function (datos) {
                $("#ges_estadoSC").data("TipoAsignacion", tipoCamp);
                $("#ges_estadoSC").html("");
                $("#ges_estadoSC").append($("<option>").attr("value", "").html("Seleccione"));

                $.each(datos, function (i, e) {
                    $("#ges_estadoSC").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre).data("terminal", e.ejes_terminal))
                });
            });


            $('#datos-gestion-sc').bootstrapValidator({
                excluded: [':disabled', ':not(:visible)'],
                feedbackIcons: faIcon,
                fields: {
                    ges_estadoSC: {
                        validators: {
                            notEmpty: {
                                message: 'Debe seleccionar un estado'
                            }
                        }
                    },
                    ges_subestadoSC: {
                        validators: {
                            notEmpty: {
                                message: 'Debe seleccionar un sub estado'
                            }
                        }
                    },
                    ges_prox_gestionSC: {
                        validators: {
                            notEmpty: {
                                message: 'La fecha de próxima gestión no puede ser vacía'
                            },
                            date: {
                                format: 'DD-MM-YYYY',
                                message: 'Formato de fecha incorrecto'
                            }
                        }
                    },
                    ges_comentariosSC: {
                        validators: {
                            notEmpty: {
                                message: 'Debe agregar algún comentario'
                            },
                            stringLength: {
                                message: 'No pueden ser mas de 150 caracteres',
                                max: function (value, validator, $field) {
                                    return 150 - (value.match(/\r/g) || []).length;
                                }
                            }
                        }
                    },



                }
            }).on('success.form.bv', function (e) {
                // Prevén que se mande el formulario
                e.preventDefault();
                var $form = $(e.target);
                $.SecPostJSON(BASE_URL + "/motor/api/Gestion/guardar-gestion-normalizacionSC", $form.serialize(), function (respuesta) {

                    if (respuesta.Estado === 'OK') {
                        render.HistorialGestion(respuesta.Objeto);

                        $("#datos-gestion-sc").bootstrapValidator('resetForm', true);
                        //$("#mensaje_guardar").fadeIn();

                        $.niftyNoty({
                            type: 'success',
                            container: 'floating',
                            html: '<strong>OK</strong> Gestion guardada exitosamente.',
                            focus: false,
                            timer: 3000
                        });
                    }
                    else {
                        $.niftyNoty({
                            type: 'danger',
                            container: 'floating',
                            html: '<strong>Error</strong> ' + respuesta.Mensaje,
                            focus: false,
                            timer: 3000
                        });
                    }

                });
            });

        }


        //Contactabilidad
        var rutAf = trutAfiliado.replace(/\./g, '');
        rutAf = rutAf.substring(0, rutAf.indexOf('-'));

        cargaDatosDeContacto(rutAf);

        $('#form-registro-contacto').bootstrapValidator({
            excluded: [':disabled', ':not(:visible)'],
            feedbackIcons: [],
            fields: {
                cbtippContac: {
                    validators: {
                        notEmpty: {
                            message: 'Debe seleccionar un tipo de Contacto'
                        }
                    }
                },
                cbClasificacionConctac: {
                    validators: {
                        notEmpty: {
                            message: 'Debe seleccionar una clasificación de contacto'
                        }
                    }
                },
                afi_NewContacto: {
                    validators: {
                        notEmpty: {
                            message: 'Debe ingresar un contacto'
                        },
                        stringLength: {
                            message: 'No pueden ser mas de 100 caracteres',
                            max: function (value, validator, $field) {
                                return 150 - (value.match(/\r/g) || []).length;
                            }
                        }
                    }
                }
            }
        }).on('success.form.bv', function (e) {
            // Prevén que se mande el formulario
            e.preventDefault();
            var $form = $(e.target);

            var objeto_envio_contacto = {
                RutAfiliado: rutAf,
                IdTipoContac: $('#cbtippContac').val(),
                GlosaTipoContac: $('select[name="cbtippContac"] option:selected').text(),
                IdClasifContac: $('#cbClasificacionConctac').val(),
                GlosaClasifContac: $('select[name="cbClasificacionConctac"] option:selected').text(),
                DatosContac: $('#afi_NewContacto').val()
            }
            $.SecGetJSON(BASE_URL + "/motor/api/Contactos/ingresa-nuevo-contacto", objeto_envio_contacto, function (datos) {
                $("#form-registro-contacto").bootstrapValidator('resetForm', true);
                $('#demo-lg-modal-new').modal('hide');
                cargaDatosDeContacto(rutAf);
                $("#btn-add-contac").trigger("click");
                $.niftyNoty({
                    type: 'success',
                    icon: 'pli-like-2 icon-2x',
                    message: 'Contacto Guardado correctamente.',
                    container: '#tab-gestion-3',
                    timer: 5000
                });
            });

        });

    });


    $('#mdl_data').on('hide.bs.modal', function (e) {

        $('#tab_contacti').tab('show');

        $(".desaparecible, .forma-uno").show();
        $(".desaparecible-cel, .forma-uno-cel").show();
        $(".desaparecible-mail, .forma-uno-mail").show();
        $(".charlyNTFContainer").html("");

        const pestana = sessionStorage.getItem('GST_PESTANA_ACTIVA');
        switch (pestana) {
            case '1':
            case '5':
                $("#datos-gestion").bootstrapValidator('resetForm', true);
                $('#datos-gestion').bootstrapValidator('destroy')
                $('#datos-gestion').hide();
                break;
            case '2':
                $("#datos-gestion_normalizacion").bootstrapValidator('resetForm', true);
                $('#datos-gestion_normalizacion').bootstrapValidator('destroy')
                $('#datos-gestion_normalizacion').hide();
                break;
            case '4':
                $("#datos-gestion-sc").bootstrapValidator('resetForm', true);
                $('#datos-gestion-sc').bootstrapValidator('destroy')
                $('#datos-gestion-sc').hide();

                $("#morf_cnvs").removeClass("col-sm-3").addClass("col-sm-6")
                $("#labelempresa").text("Empresa");
                $("#labelrutempresa").text("Rut Empresa");


                break;


        }


    });

    //PREFERENCIAS AFILIADO
    $("#afi_oficina_preferencia").on("change", function () {

        if ($(this).val() != "") {
            var WebPreferencia = {
                afiliado_Rut: $("#afi_rut").val().replace(/\./g, ''),
                tipo_preferencia: "OFICINA",
                valor_preferencia: $(this).val(),
                valido: true
            }
            WebPreferencia.afiliado_Rut = WebPreferencia.afiliado_Rut.substring(0, WebPreferencia.afiliado_Rut.length - 2);

            $.SecPostJSON(BASE_URL + "/motor/api/Gestion/guardar-preferencia-afiliado", WebPreferencia, function (respuesta) {
                if (respuesta.Estado === "OK") {
                    $.niftyNoty({
                        type: 'success',
                        container: 'floating',
                        html: '<strong>OK</strong> Oficina asignada con éxito!',
                        focus: false,
                        timer: 3000
                    });
                }
            });
        }
    });
    $("#afi_horario_preferencia").on("change", function () {

        if ($(this).val() != "") {

            var WebPreferencia = {
                afiliado_Rut: $("#afi_rut").val().replace(/\./g, ''),
                tipo_preferencia: "HORARIO",
                valor_preferencia: $(this).val(),
                valido: true
            }

            WebPreferencia.afiliado_Rut = WebPreferencia.afiliado_Rut.substring(0, WebPreferencia.afiliado_Rut.length - 2);

            $.SecPostJSON(BASE_URL + "/motor/api/Gestion/guardar-preferencia-afiliado", WebPreferencia, function (respuesta) {
                if (respuesta.Estado === "OK") {
                    ///Variables.Afiliado_Current.data("afiliado").HorarioPreferencia = respuesta.Objeto;
                    ///console.log(Variables.Afiliado_Current.data("afiliado"))
                }
            });
        }


    });


    //CONTACTABILIDAD AFILIADOS
    $("#afi_telefonos").on("change", function (e) {

        $(".desaparecible, .forma-uno").show();
        if ($("#afi_telefonos :selected").data("malo") !== "undefined" && $("#afi_telefonos :selected").data("malo") === "true") {
            $(".desaparecible, .forma-uno").hide();
        }
    })
    $("#telefonos_Malo").on("click", function (e) {


        var WebDatoContacto = {
            afiliado_Rut: $("#afi_rut").val().replace('.', '').replace('.', ''),
            tipo: "telefonos",
            valor_contacto: $("#afi_telefonos :selected").html().replace("+", ""),
            valido: 0
        }
        WebDatoContacto.afiliado_Rut = WebDatoContacto.afiliado_Rut.substring(0, WebDatoContacto.afiliado_Rut.length - 2);

        $.SecPostJSON(BASE_URL + "/motor/api/Gestion/guardar-nuevo-contacto", WebDatoContacto, function (respuesta) {

            if (respuesta.Estado === "OK") {

                /*$.each(Variables.Afiliado_Current.data("afiliado").Telefonos, function (i, el) {
                    if (el.Valor_contacto == respuesta.Objeto.Valor_contacto) {
                        Variables.Afiliado_Current.data("afiliado").Telefonos.splice(i, 1);
                        return false;
                    }
                });
                Variables.Afiliado_Current.data("afiliado").Telefonos.push(respuesta.Objeto);*/

                $("#afi_telefonos :selected").html($("#afi_telefonos :selected").html() + ' (malo)').data("malo", "true");
                $(".desaparecible, .forma-uno").hide();
            }

        });


    });
    $("#telefonos_Nuevo").on("click", function (e) {

        var that = $(this);
        $("#afi_telefonos, .desaparecible, .forma-dos").hide();



        $(".multicontrol").append(
            $("<form>").attr({ "id": "miForm", "name": "miForm", "method": "post" }).append($("<input>").attr({ "type": "hidden", "id": "afiliado_Rut", "name": "afiliado_Rut", "value": $("#afi_rut").val() })).append($("<input>").attr({ "type": "hidden", "id": "tipo", "name": "tipo", "value": "telefonos" })).append(
                $("<input>").attr({ "type": "text", "id": "tmp_telefono", "name": "tmp_telefono", "maxlength": "12" }).val("+56").addClass("form-control").on({
                    "keypress blur": function (e) {


                        if (e.type === "blur" || (e.type === "keypress" && e.which === 13)) {
                            e.preventDefault();

                            if (typeof $("#miForm").data("bootstrapValidator") === "undefined") {
                                $("#miForm").bootstrapValidator({
                                    fields: {
                                        tmp_telefono: {
                                            validators: {
                                                notEmpty: {
                                                    message: 'no puede guardar numero vacio',
                                                },
                                                stringLength: {
                                                    min: 12,
                                                    max: 12,
                                                    message: 'formato de numero incorrecto'
                                                },
                                            }
                                        },
                                    }
                                }).on('success.form.bv', function (e) {
                                    e.preventDefault();
                                    var $form = $(e.target);
                                    var funcion = {
                                        existeValorEnSelect: function (arrayOptions, valorBuscado) {
                                            $.each(arrayOptions, function (i, e) {

                                                if ($(e).val() === valorBuscado) {
                                                    return true;
                                                }
                                            });
                                            return false;
                                        }
                                    }
                                    if (!funcion.existeValorEnSelect($("#afi_telefonos option"), $form.find("#tmp_telefono").val())) {

                                        var WebDatoContacto = {
                                            afiliado_Rut: $form.find("#afiliado_Rut").val().replace('.', '').replace('.', ''),
                                            tipo: $form.find("#tipo").val(),
                                            valor_contacto: $form.find("#tmp_telefono").val().replace("+", ""),
                                            valido: 1
                                        }
                                        WebDatoContacto.afiliado_Rut = WebDatoContacto.afiliado_Rut.substring(0, WebDatoContacto.afiliado_Rut.length - 2);

                                        $.SecPostJSON(BASE_URL + "/motor/api/Gestion/guardar-nuevo-contacto", WebDatoContacto, function (respuesta) {
                                            if (respuesta.Estado === "OK") {

                                                $("#afi_telefonos").prepend($("<option>").html($form.find("#tmp_telefono").val()));
                                                $("#afi_telefonos option:eq(0)").prop('selected', true)
                                                $("#afi_telefonos, .desaparecible, .forma-dos, .forma-uno").show();
                                                $("#miForm").remove();
                                            }
                                        });

                                    }
                                });
                            }


                            $("#miForm").submit();
                        }

                    },

                })

            ));

    });

    $("#afi_celulares").on("change", function (e) {

        $(".desaparecible-cel, .forma-uno-cel").show();
        if ($("#afi_celulares :selected").data("malo") !== "undefined" && $("#afi_celulares :selected").data("malo") === "true") {
            $(".desaparecible-cel, .forma-uno-cel").hide();
        }
    })
    $("#celulares_Malo").on("click", function (e) {


        var WebDatoContacto = {
            afiliado_Rut: $("#afi_rut").val().replace('.', '').replace('.', ''),
            tipo: "celulares",
            valor_contacto: $("#afi_celulares :selected").html().replace("+", ""),
            valido: 0
        }
        WebDatoContacto.afiliado_Rut = WebDatoContacto.afiliado_Rut.substring(0, WebDatoContacto.afiliado_Rut.length - 2);

        $.SecPostJSON(BASE_URL + "/motor/api/Gestion/guardar-nuevo-contacto", WebDatoContacto, function (respuesta) {

            if (respuesta.Estado === "OK") {

                /*$.each(Variables.Afiliado_Current.data("afiliado").Celulares, function (i, el) {
                    if (el.Valor_contacto == respuesta.Objeto.Valor_contacto) {
                        Variables.Afiliado_Current.data("afiliado").Celulares.splice(i, 1);
                        return false;
                    }
                });
                Variables.Afiliado_Current.data("afiliado").Celulares.push(respuesta.Objeto);
                */

                $("#afi_celulares :selected").html($("#afi_celulares :selected").html() + ' (malo)').data("malo", "true");
                $(".desaparecible-cel, .forma-uno-cel").hide();
            }

        });


    });
    $("#celulares_Nuevo").on("click", function (e) {

        var that = $(this);
        $("#afi_celulares, .desaparecible-cel, .forma-dos-cel").hide();



        $(".multicontrol-cel").append(
            $("<form>").attr({ "id": "miFormCel", "name": "miFormCel", "method": "post" }).append($("<input>").attr({ "type": "hidden", "id": "afiliado_Rut", "name": "afiliado_Rut", "value": $("#afi_rut").val() })).append($("<input>").attr({ "type": "hidden", "id": "tipo", "name": "tipo", "value": "celulares" })).append(
                $("<input>").attr({ "type": "text", "id": "tmp_celular", "name": "tmp_celular", "maxlength": "12" }).val("+56").addClass("form-control").on({
                    "keypress blur": function (e) {


                        if (e.type === "blur" || (e.type === "keypress" && e.which === 13)) {
                            e.preventDefault();

                            if (typeof $("#miFormCel").data("bootstrapValidator") === "undefined") {
                                $("#miFormCel").bootstrapValidator({
                                    fields: {
                                        tmp_celular: {
                                            validators: {
                                                notEmpty: {
                                                    message: 'no puede guardar numero vacio',
                                                },
                                                stringLength: {
                                                    min: 12,
                                                    max: 12,
                                                    message: 'formato de numero incorrecto'
                                                },
                                            }
                                        },
                                    }
                                }).on('success.form.bv', function (e) {
                                    e.preventDefault();
                                    var $form = $(e.target);
                                    var funcion = {
                                        existeValorEnSelect: function (arrayOptions, valorBuscado) {
                                            $.each(arrayOptions, function (i, e) {

                                                if ($(e).val() === valorBuscado) {
                                                    return true;
                                                }
                                            });
                                            return false;
                                        }
                                    }
                                    if (!funcion.existeValorEnSelect($("#afi_celulares option"), $form.find("#tmp_celular").val())) {

                                        var WebDatoContacto = {
                                            afiliado_Rut: $form.find("#afiliado_Rut").val().replace('.', '').replace('.', ''),
                                            tipo: $form.find("#tipo").val(),
                                            valor_contacto: $form.find("#tmp_celular").val().replace("+", ""),
                                            valido: 1
                                        }
                                        WebDatoContacto.afiliado_Rut = WebDatoContacto.afiliado_Rut.substring(0, WebDatoContacto.afiliado_Rut.length - 2);

                                        $.SecPostJSON(BASE_URL + "/motor/api/Gestion/guardar-nuevo-contacto", WebDatoContacto, function (respuesta) {
                                            if (respuesta.Estado === "OK") {
                                                //Variables.Afiliado_Current.data("afiliado").Celulares.push(respuesta.Objeto)
                                                $("#afi_celulares").prepend($("<option>").html($form.find("#tmp_celular").val()));
                                                $("#afi_celulares option:eq(0)").prop('selected', true)
                                                $("#afi_celulares, .desaparecible-cel, .forma-dos-cel, .forma-uno-cel").show();
                                                $("#miFormCel").remove();
                                            }

                                        });

                                    }
                                });
                            }


                            $("#miFormCel").submit();
                        }

                    },

                })

            ));

    });

    $("#afi_correos").on("change", function (e) {

        $(".desaparecible-mail, .forma-uno-mail").show();
        if ($("#afi_correos :selected").data("malo") !== "undefined" && $("#afi_correos :selected").data("malo") === "true") {
            $(".desaparecible-mail, .forma-uno-mail").hide();
        }
    })
    $("#correos_Malo").on("click", function (e) {


        var WebDatoContacto = {
            afiliado_Rut: $("#afi_rut").val().replace('.', '').replace('.', ''),
            tipo: "correos",
            valor_contacto: $("#afi_correos :selected").html(),
            valido: 0
        }
        WebDatoContacto.afiliado_Rut = WebDatoContacto.afiliado_Rut.substring(0, WebDatoContacto.afiliado_Rut.length - 2);

        $.SecPostJSON(BASE_URL + "/motor/api/Gestion/guardar-nuevo-contacto", WebDatoContacto, function (respuesta) {

            if (respuesta.Estado === "OK") {

                /*$.each(Variables.Afiliado_Current.data("afiliado").Correos, function (i, el) {
                    if (el.Valor_contacto == respuesta.Objeto.Valor_contacto) {
                        Variables.Afiliado_Current.data("afiliado").Correos.splice(i, 1);
                        return false;
                    }
                });
                Variables.Afiliado_Current.data("afiliado").Correos.push(respuesta.Objeto);
                console.log(Variables.Afiliado_Current.data("afiliado"))*/

                $("#afi_correos :selected").html($("#afi_correos :selected").html() + ' (malo)').data("malo", "true");
                $(".desaparecible-mail, .forma-uno-mail").hide();
            }

        });


    });
    $("#correos_Nuevo").on("click", function (e) {

        var that = $(this);
        $("#afi_correos, .desaparecible-mail, .forma-dos-mail").hide();



        $(".multicontrol-mail").append(
            $("<form>").attr({ "id": "miFormMail", "name": "miFormMail", "method": "post" }).append($("<input>").attr({ "type": "hidden", "id": "afiliado_Rut", "name": "afiliado_Rut", "value": $("#afi_rut").val() })).append($("<input>").attr({ "type": "hidden", "id": "tipo", "name": "tipo", "value": "correos" })).append(
                $("<input>").attr({ "type": "text", "id": "tmp_correo", "name": "tmp_correo" }).addClass("form-control").on({
                    "keypress blur": function (e) {


                        if (e.type === "blur" || (e.type === "keypress" && e.which === 13)) {
                            e.preventDefault();

                            if (typeof $("#miFormMail").data("bootstrapValidator") === "undefined") {
                                $("#miFormMail").bootstrapValidator({
                                    fields: {
                                        tmp_correo: {
                                            validators: {
                                                notEmpty: {
                                                    message: 'No puede guardar correo vacio',
                                                },
                                                stringLength: {
                                                    max: 512,
                                                    message: 'No puede Exceder los 512 caracteres'
                                                },
                                                emailAddress: {
                                                    message: 'No es un formato de correo válido'
                                                },
                                            }
                                        },
                                    }
                                }).on('success.form.bv', function (e) {
                                    e.preventDefault();
                                    var $form = $(e.target);
                                    var funcion = {
                                        existeValorEnSelect: function (arrayOptions, valorBuscado) {
                                            $.each(arrayOptions, function (i, e) {

                                                if ($(e).val() === valorBuscado) {
                                                    return true;
                                                }
                                            });
                                            return false;
                                        }
                                    }
                                    if (!funcion.existeValorEnSelect($("#afi_correos option"), $form.find("#tmp_correo").val())) {

                                        var WebDatoContacto = {
                                            afiliado_Rut: $form.find("#afiliado_Rut").val().replace('.', '').replace('.', ''),
                                            tipo: $form.find("#tipo").val(),
                                            valor_contacto: $form.find("#tmp_correo").val(),
                                            valido: 1
                                        }
                                        WebDatoContacto.afiliado_Rut = WebDatoContacto.afiliado_Rut.substring(0, WebDatoContacto.afiliado_Rut.length - 2);

                                        $.SecPostJSON(BASE_URL + "/motor/api/Gestion/guardar-nuevo-contacto", WebDatoContacto, function (respuesta) {
                                            if (respuesta.Estado === "OK") {
                                                //console.log(Variables.Afiliado_Current.data("afiliado"))
                                                //Variables.Afiliado_Current.data("afiliado").Correos.push(respuesta.Objeto)
                                                $("#afi_correos").prepend($("<option>").html($form.find("#tmp_correo").val()));
                                                $("#afi_correos option:eq(0)").prop('selected', true)
                                                $("#afi_correos, .desaparecible-mail, .forma-dos-mail, .forma-uno-mail").show();
                                                $("#miFormMail").remove();
                                            }

                                        });

                                    }
                                });
                            }


                            $("#miFormMail").submit();
                        }

                    },

                })

            ));

    });



    const pestana = sessionStorage.getItem('GST_PESTANA_ACTIVA');
    if (pestana != null) {
        switch (pestana) {
            case '1':
                $('#tab_preaprobados').tab('show');
                $("#tab_preaprobados").trigger("shown.bs.tab");
                break;
            case '2':
                $('#tab_recuperaciones').tab('show');
                //$("#tab_recuperaciones").trigger("shown.bs.tab");
                break;
            case '3':
                $('#tab_normalizacionTMC').tab('show');
                //$("#tab_normalizacionTMC").trigger("shown.bs.tab");
                break;
            case '4':
                $('#tab_segcesantia').tab('show');
                //$("#tab_segcesantia").trigger("shown.bs.tab");
                break;
            case '5':
                $('#tab_derivaciones').tab('show');
                //$("#tab_derivaciones").trigger("shown.bs.tab");
                break;
        }
    } else {
        $("#tab_preaprobados").trigger("shown.bs.tab");
    }

    $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-empresas", function (datos) {
        $("#demo-chosen-select").html("");
        $("#demo-chosen-select").append($("<option>").text("Seleccione").val(""));
        $.each(datos, function (i, e) {
            $("#demo-chosen-select").append($("<option>").val(e.NonEmpresa).html(e.NonEmpresa));
        });
        $('#demo-chosen-select').chosen();
    });

    $('#btn-add-contac').on('click', function () {

        console.log('Visibiliadad', $('#formulario-contac').is(':visible'));
        if ($('#formulario-contac').is(':visible'))
        {
            $('#formulario-contac').hide('slow');
        }
        else
        {
            $('#formulario-contac').show('slow');
        }

    });

});
