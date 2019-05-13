$(function () {



    var render = {
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
        }
        
    }


    var faIcon = {
        valid: 'fa fa-check-circle fa-lg text-success',
        invalid: 'fa fa-times-circle fa-lg',
        validating: 'fa fa-refresh'
    }
    var trutAfiliado = $('#rut-afi').val();
    var tperiodo = $('#periodo').val();
    var tipoCamp = $('#tipo').val();

    console.log(tipoCamp)

    $('.volvere').on('click', function (event) {
        location.href = BASE_URL + '/Motor/App/Gestion';
    });

    $.SecGetJSON(BASE_URL + "/motor/api/Gestion/obtener-seguimiento", { periodo: tperiodo, afiRut: trutAfiliado, tipoCampagna: tipoCamp }, function (datos) {

        if (datos.Estado === "OK")
        {
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

                    if (e.Tipo == "ACUERPAG")
                    {
                        sx = true;
                    }
                    else
                    {
                        $.niftyNoty({
                            type: 'success',
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
            else
            {
                $(".charlyNTF").hide();
            }

            var info_xxx = "";

            if (Asignacion.FiltrosRSG.length > 0) {
                info_xxx = ("Filtros Riesgo " + Asignacion.FiltrosRSG).toEtiquetaSuperior('x');
            }


            $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-rechazos-rsg", { Periodo: tperiodo, RutEmpresa: afiData.Empresa_Rut, RutAfiliado: afiData.Afiliado_Rut }, function (datos) {
                $("#letable").html("");
                $.each(datos, function (i, e) {
                    $("#letable").append($("<tr>").append("<td>").html(e.MotivoRechazo))
                });
            });

            
            if (tipoCamp === '1' || tipoCamp === '5')
            {
                render.HistorialGestion(gesList);
                $("#myLargeModalLabel").html(afiData.Prioridad.toString().toEtiquetaPrioridad() + " " + info_xxx);
                $("#titulo_gestion").text("Gestión Comercial");
            }

            if (tipoCamp === '2')
            {
                render.HistorialGestionRecuperaciones(gesList);
                $("#morfeable_monto").text("Monto Adeudado");
                $("#titulo_gestion").text("Gestión de Normalización, Folio Crédito: " + afiData.RiesgoPerfil);
            }

            if (tipoCamp === '4')
            {
                render.HistorialGestion(gesList);
                $("#myLargeModalLabel").html(afiData.Prioridad.toString().toEtiquetaPrioridad() + " Folios:" + afiData.RiesgoPerfil);// + afiData.Prioridad.toString().toEtiquetaPrioridad() + " " + info_xxx);
                $('#titulo_gestion').text('Gestión Seg Cesantía');
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
        else
        {
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

    //Carga de selects Filtros de Pre Aprobados
    $.SecGetJSON(BASE_URL + "/motor/api/Gestion/listar-oficinas", function (datos) {

        $("#afi_oficina_preferencia").html("");
        $("#afi_oficina_preferencia").append($("<option>").attr("value", "").html("Seleccione"));
        $.each(datos, function (i, e) {
            $("#afi_oficina_preferencia").append($("<option>").attr("value", e.Id).html(e.Nombre))
        });
    });

    //COMERCIAL
    if (tipoCamp === '1' || tipoCamp === '5')
    {
        $('#datos-gestion').show();
        
        //Datepicker de Pre Aprobados
        $('#demo-dp-component .input-group.date').datepicker(
            { autoclose: true, format: 'dd-mm-yyyy', startDate: "0d", language: "es", daysOfWeekDisabled: [6, 0], todayHighlight: true }
        ).on('changeDate', function (e) {
            $('#datos-gestion').bootstrapValidator('updateStatus', 'ges_prox_gestion', 'NOT_VALIDATED').bootstrapValidator('validateField', 'ges_prox_gestion');
        });


        //Carga de selects
        $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: tipoCamp, padre: 0 }, function (datos) {
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
                        container: 'floating',
                        html: '<strong>OK</strong> Gestion guardada exitosamente.',
                        focus: false,
                        timer: 3000
                    });


                    render.HistorialGestion(respuesta.Objeto);

                    /*const idAsig = parseInt($('#ges_id_asignacion').val());
                    var segimientos = JSON.parse(sessionStorage.getItem('lista_seguimientos_preaprobados'));
                    var min = 0, max = segimientos.data.length, mitad = 0;

                    while (min <= max) {
                        mitad = Math.floor((min + max) / 2);

                        if (segimientos.data[mitad].Seguimiento.id_Asign === idAsig) {
                            segimientos.data[mitad].UltimaGestion = respuesta.Objeto[0];
                            console.log("Pillado", segimientos.data[mitad].UltimaGestion)
                            return false;
                        }

                        if (segimientos.data[mitad].Seguimiento.id_Asign > idAsig) {
                            max = mitad;
                            mitad = Math.floor((min + max) / 2);
                        }

                        if (segimientos.data[mitad].Seguimiento.id_Asign < idAsig) {
                            min = mitad;
                            mitad = Math.floor((min + max) / 2);
                        }
                    }

                    sessionStorage.setItem('lista_seguimientos_preaprobados', JSON.stringify(segimientos));*/


                    /*if (respuesta.Objeto != null && respuesta.Objeto.length > 0 && respuesta.Objeto[0].EstadoGestion.ejes_terminal === "CERRADOS") {
                        $(".esconder").hide();
                    }*/

                    //$("#datos-gestion").bootstrapValidator('resetForm', true);


                    
                } else {
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

    //RECUPERACIONES
    if (tipoCamp === '2')
    {
        $('#datos-gestion_normalizacion').show();

        $('#demo-dp-component_normalizacion .input-group.date').datepicker({ autoclose: true, format: 'dd-mm-yyyy', startDate: "0d", language: "es", daysOfWeekDisabled: [6, 0], todayHighlight: true });
        
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

                if (respuesta.Estado === 'OK')
                {
                    render.HistorialGestionRecuperaciones(respuesta.Objeto);

                    /*const idAsig = parseInt($('#ges_id_asignacion').val());
                    var segimientos = JSON.parse(sessionStorage.getItem('lista_seguimientos_recuperaciones'));
                    var min = 0, max = segimientos.data.length, mitad = 0;

                    while (min <= max) {
                        mitad = Math.floor((min + max) / 2);

                        if (segimientos.data[mitad].Seguimiento.id_Asign === idAsig) {
                            segimientos.data[mitad].UltimaGestion = respuesta.Objeto[0];
                            console.log("Pillado", segimientos.data[mitad].UltimaGestion)
                            return false;
                        }

                        if (segimientos.data[mitad].Seguimiento.id_Asign > idAsig) {
                            max = mitad;
                            mitad = Math.floor((min + max) / 2);
                        }

                        if (segimientos.data[mitad].Seguimiento.id_Asign < idAsig) {
                            min = mitad;
                            mitad = Math.floor((min + max) / 2);
                        }
                    }

                    sessionStorage.setItem('lista_seguimientos_recuperaciones', JSON.stringify(segimientos));*/
                    

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
                else
                {
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
    if (tipoCamp === '4')
    {
        $('#datos-gestion-sc').show();


        $('#demo-dp-componentSC .input-group.date').datepicker({
            autoclose: true, format: 'dd-mm-yyyy', startDate: "0d", language: "es", daysOfWeekDisabled: [6, 0], todayHighlight: true
        }).on('changeDate', function (e) {
            $('#datos-gestion-sc').bootstrapValidator('updateStatus', 'ges_prox_gestionSC', 'NOT_VALIDATED').bootstrapValidator('validateField', 'ges_prox_gestionSC');
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

                if (respuesta.Estado === 'OK')
                {
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
                else
                {
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
    

    //CONTACTABILIDAD
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

                $.each(Variables.Afiliado_Current.data("afiliado").Telefonos, function (i, el) {
                    if (el.Valor_contacto == respuesta.Objeto.Valor_contacto) {
                        Variables.Afiliado_Current.data("afiliado").Telefonos.splice(i, 1);
                        return false;
                    }
                });
                Variables.Afiliado_Current.data("afiliado").Telefonos.push(respuesta.Objeto);

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

                                                console.log(Variables.Afiliado_Current.data("afiliado"))


                                                Variables.Afiliado_Current.data("afiliado").Telefonos.push(respuesta.Objeto)
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

                $.each(Variables.Afiliado_Current.data("afiliado").Celulares, function (i, el) {
                    if (el.Valor_contacto == respuesta.Objeto.Valor_contacto) {
                        Variables.Afiliado_Current.data("afiliado").Celulares.splice(i, 1);
                        return false;
                    }
                });
                Variables.Afiliado_Current.data("afiliado").Celulares.push(respuesta.Objeto);


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
                                                Variables.Afiliado_Current.data("afiliado").Celulares.push(respuesta.Objeto)
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

                $.each(Variables.Afiliado_Current.data("afiliado").Correos, function (i, el) {
                    if (el.Valor_contacto == respuesta.Objeto.Valor_contacto) {
                        Variables.Afiliado_Current.data("afiliado").Correos.splice(i, 1);
                        return false;
                    }
                });
                Variables.Afiliado_Current.data("afiliado").Correos.push(respuesta.Objeto);
                console.log(Variables.Afiliado_Current.data("afiliado"))

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
                                                console.log(Variables.Afiliado_Current.data("afiliado"))
                                                Variables.Afiliado_Current.data("afiliado").Correos.push(respuesta.Objeto)
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


    $("#afi_oficina_preferencia").on("change", function () {

        if ($(this).val() != "") {
            var WebPreferencia = {
                afiliado_Rut: $("#afi_rut").val().replace('.', '').replace('.', ''),
                tipo_preferencia: "OFICINA",
                valor_preferencia: $(this).val(),
                valido: true
            }
            WebPreferencia.afiliado_Rut = WebPreferencia.afiliado_Rut.substring(0, WebPreferencia.afiliado_Rut.length - 2);

            $.SecPostJSON(BASE_URL + "/motor/api/Gestion/guardar-preferencia-afiliado", WebPreferencia, function (respuesta) {
                if (respuesta.Estado === "OK") {
                    Variables.Afiliado_Current.data("afiliado").OficinaPreferencia = respuesta.Objeto;
                    console.log(Variables.Afiliado_Current.data("afiliado"))
                }
            });
        }
    });
    $("#afi_horario_preferencia").on("change", function () {

        if ($(this).val() != "") {

            var WebPreferencia = {
                afiliado_Rut: $("#afi_rut").val().replace('.', '').replace('.', ''),
                tipo_preferencia: "HORARIO",
                valor_preferencia: $(this).val(),
                valido: true
            }

            WebPreferencia.afiliado_Rut = WebPreferencia.afiliado_Rut.substring(0, WebPreferencia.afiliado_Rut.length - 2);

            $.SecPostJSON(BASE_URL + "/motor/api/Gestion/guardar-preferencia-afiliado", WebPreferencia, function (respuesta) {
                if (respuesta.Estado === "OK") {
                    Variables.Afiliado_Current.data("afiliado").HorarioPreferencia = respuesta.Objeto;
                    console.log(Variables.Afiliado_Current.data("afiliado"))
                }
            });
        }


    });


});