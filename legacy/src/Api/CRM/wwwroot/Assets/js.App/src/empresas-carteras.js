$('#dateTimepk').timepicker();
$('#dateTimeDiaria').timepicker();
$('#dateTimeSemanal').timepicker();
$('#dateTimeMensual').timepicker();
$('#demo-dp-component .input-group.date').datepicker({
    format: "dd-mm-yyyy",
    autoclose: true,
    language: "es"
}).datepicker("setDate", new Date());
$('#FechaResolucion').val('01-01-1900')
var fechaPop;
var idEnvta = 0;
var idCabManGest = 0;
var compromiso = 0;
var alerta = 0;
var alertaGestion = 0;

$(function () {

    $("#titulo").css('font-size', '27px').css('color', '#b3b3b3').css('margin-left', '20px')
    $('[data-toggle="popover"]').popover();
    cargador.CargaDatosCateraAgente();
});

var cargador = {
    CargaDatosCateraAgente: function () {
        $("#bdy_datos").html("");
        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/obtener-cartera-agente", function (menus) {
            var iterador = ""
            $.each(menus, function (i, e) {
                var NomHolding = ""
                var Asignados = "";
                var Anexo = "";
                var validador = 0;
                if (e.Holding == 0 || e.NombreHolding == "") {
                    NomHolding = $('<div>').addClass('label label-table label-warning').append('Sin Holding')
                }
                else {
                    NomHolding = $('<div>').addClass('label label-table label-success').append(e.NombreHolding)
                }

                if (e.CountEmp > 0) {
                    Asignados = $('<a>').attr('href', '#popover')
                        .addClass('demo-psi-male icon-lg add-popover').attr('data-original-title', 'Ejecutivos Asignados')
                        .attr('data-content', 'prueba de datos')
                        .attr('data-placement', 'top')
                        .attr('data-trigger', 'focus')
                        .attr('data-toggle', 'popover')
                    validador = 1
                }
                else { Anexo = "" }

                if (e.CountAnexo > 0) {
                    Anexo = '<a data-toggle="dropdown" class="dropdown-toggle" aria-expanded="true"><i class="ion-clipboard" style="font-size: 22px;"></i><span class="badge badge-header badge-danger" style="position: unset;">' + e.CountAnexo + '</span></a>'
                    validador = 2
                }
                else { Anexo = "" }
                $("#bdy_datos")
                    .append($("<tr>")
                        .append($("<td>").append(e.RutEmpresa))
                        .append($("<td>").append('<a href="' + BASE_URL + '/motor/Emp/FichaEmpresa?rutEmp=' + e.RutEmpresa + '&validador=' + validador + '&Id=' + e.Id + '&rutEmpA=0' + ' " class="btn-link text-semibold" style="font-weight: 400;">' + e.NombreEmpresa + '</a>'))
                        .append($("<td>").append(e.NTrabajador))
                        .append($("<td>").append(NomHolding))
                        .append($("<td>").append(Asignados))
                        .append($("<td>").append(Anexo))
                    )
            });

            $("#tabla").bootstrapTable({
                striped: true,
                pagination: true,
                pageSize: 10,
                pageList: [],
                search: true,
                showColumns: true,
                showRefresh: false,
                sortable: true,
            });
            $('.add-popover').popover();

            $("#slEmpresaAgendas").html("");
            $("#slEmpresaAgendas").append($("<option>").attr("value", "0").html("TODO...."));
            $("#slEmpresaAgendasIng").html("");
            $.each(menus, function (i, e) {
                $("#slEmpresaAgendas").append($("<option>").attr("value", e.RutEmpresa).html(e.NombreEmpresa))
            });
            $('#slEmpresaAgendas').chosen();


            $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/dotacion-oficina", function (menus) {
                $("#slEjecutivoAgenda").append($("<option>").attr("value", "0").html("TODO...."));
                $("#slEjecutivoAgendaIng").append($("<option>").attr("value", "0").html("Seleccione"));
                $.each(menus, function (i, e) {
                    $("#slEjecutivoAgenda").append($("<option>").attr("value", e.Rut).html(e.Nombre.OrdenaNombreCompleto()))
                    $("#slEjecutivoAgendaIng").append($("<option>").attr("value", e.Rut).html(e.Nombre.OrdenaNombreCompleto()))
                });
                $('#slEjecutivoAgenda').chosen();
            });
        });
    },
    CargaDatosAsignados: function () {
        $.SecGetJSON(BASE_URL + "/motor/api/Config/dotacion-oficina", function (menus) {

        });
    },
    CargaAgenda: function (rutEmp, rutEje) {
        $('#demo-calendar').fullCalendar('destroy');
        $('#demo-calendar').fullCalendar({
            lang: 'es',
            header: {
                left: 'prev,next today',
                center: 'title',
                right: 'month,agendaWeek,agendaDay'
            },
            defaultView: 'month',
            weekends: false,
            defaultDate: moment(),
            eventLimit: false,
            selectable: true,
            selectHelper: true,
            editable: false,
            eventClick: function (event) {

                $('#txtFechacita_update').val(event.start._i.toFecha())
                $('#slTipoVisita_update').val(event.TipoVisita)
                $('#txtObsCita_update').val(event.Glosa)
                $('#slFrecuencia_update').val(event.Frecuencia)
                $('#slSucedeDia_update').val(event.DiasSucede)
                $('#slDiasMensual_update').val(event.Dias)
                $('#slComienzaDia_update').val(event.HoraInicio)
                $('#txtHoraFin_update').val(event.HoraFin)
                $('#nomEmpCita').html(' Cita de Empresa:  ' + event.NombreEmpresa)

                $("#btCita_update").data("idagenda", event.IdAgenda).data("idregistro", event.IdRegistro).data("rutempresa", event.RutEmpresa)
                $("#btCita_elimina").data("idregistro", event.IdRegistro).data("idagenda", event.IdAgenda).data("rutempresa", event.RutEmpresa)

                if (event.Frecuencia == 'Diaria') {
                    $("#divMensual_update").css('display', 'none')
                    $("#divSemanal_update").css('display', 'none')
                    $("#divDiario_update").css('display', 'block')
                }
                else if (event.Frecuencia == 'Semanal') {
                    $("#divDiario_update").css('display', 'none')
                    $("#divMensual_update").css('display', 'none')
                    $("#divSemanal_update").css('display', 'block')
                }
                else if (event.Frecuencia == 'Quincenal') {
                    $("#divDiario_update").css('display', 'none')
                    $("#divMensual_update").css('display', 'none')
                    $("#divSemanal_update").css('display', 'block')
                }
                else if (event.Frecuencia == 'Mensual') {
                    $("#divDiario_update").css('display', 'none')
                    $("#divSemanal_update").css('display', 'none')
                    $("#divMensual_update").css('display', 'block')
                }

                cargador.CargaDatosEntrevista();
                cargador.CargaDatosGestionMan();
                cargador.AfiliadoOficina(event.RutEmpresa);

                $('#demo-lg-modal-agenda_update').modal('show');
                return false;
            },
            select: function (start, end) {
                var check = moment(start).format('YYYY-MM-DD');
                var today = moment(new Date()).format('YYYY-MM-DD');
                if (check >= today) {
                    $("#lbEmpresaAgenda").html('Empresa : ' + $("#NombreEmpresaPer").html())
                    $('#txtFechacita').val(moment(start).format('DD-MM-YYYY'))
                    fechaPop = (moment(start).format('YYYY-MM-DD'))
                    $('#slEjecutivoAgendaIng').chosen({ width: '100%' });
                    $('#slEjecutivoAgendaIng').val($("#slEjecutivoAgenda").val()).trigger('chosen:updated');
                    $('#slEmpresaAgendasIng').val($("#slEmpresaAgendas").val()).trigger('chosen:updated');
                    $('#demo-lg-modal-agenda').modal('show');
                }
                else {

                    $.niftyNoty({
                        type: 'danger',
                        container: 'floating',
                        title: 'Error',
                        message: 'NO SE PUEDE CREAR EVENTOS ANTES DE LA FECHA ACTUAL!...',
                        closeBtn: false,
                        timer: 2800,
                    });
                }
            },
            eventSources: [
                {
                    url: '/motor/api/perfil-empresas/lista-cita-agenda-cartera/' + rutEmp + '/' + rutEje + '/' + 0,
                    type: 'GET',
                    headers: {
                        'Token': getCookie('Token')
                    },
                    success: function (i, e) {
                        if (i.length != 0) {
                            $('#ncitas').html(i[0].Ncitas)
                        }
                        else {
                            $('#ncitas').html('0')
                        }
                    }
                }
            ]
        });
        $('#demo-calendar').fullCalendar("refetchEvents");
        $('#demo-calendar').fullCalendar('render');
    },
    CargaDatosEntrevista: function () {
        $("#tbdyentrevista").html("");
        var rutEmpresa = $("#btCita_update").data("rutempresa")
        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-entrevista", { RutEmpresa: rutEmpresa, Anexo: 0 }, function (menus) {
            $.each(menus, function (i, e) {
                $("#tbdyentrevista")
                    .append(
                        $("<tr>")
                            .append($("<td>").append(e.FechaEntrevista))
                            .append($("<td>").append("<span class='pull-center badge badge-success'>" + e.Tipo + "</span>"))
                            .append($("<td>").append(e.NombreContacto))
                            .append($("<td>").append(e.Cargo))
                            .append($("<td>").append(e.Estamento))
                            .append($("<td>").append('<a href="' + BASE_URL + '/motor/Emp/DetalleVisita?IdEntrevista=' + e.IdEntrevista + '" class="btn btn-primary btn-icon btn-circle"><i class="demo-psi-receipt-4 icon-xs"></i></a>'))
                    )
            });
        });
    },
    CargaDatosGestionMan: function () {
        var rutEmpresa = $("#btCita_update").data("rutempresa")
        $("#tbdyGestMan").html("");
        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-mantencion-gestion", { RutEmpresa: rutEmpresa, idAnexo: 0 }, function (menus) {
            $.each(menus, function (i, e) {
                $("#tbdyGestMan")
                    .append(
                        $("<tr>")
                            .append($("<td>").append(e.FechaIngreso.toFecha()))
                            .append($("<td>").append("<span class='pull-center badge badge-success' style='width: 62px;'>" + e.Tipo + "</span>"))
                            .append($("<td>").append(e.Comentarios))
                            .append($("<td>").append(e.NombreEjecutivo.OrdenaNombreCompleto()))
                            .append($("<td>").append('<a href="' + BASE_URL + '/motor/Emp/DetalleGestion?IdCabGestion=' + e.IdCabGesMantencion + '&RutEmp=' + e.RutEmpresa + '" class="btn btn-primary btn-icon btn-circle"><i class="demo-psi-receipt-4 icon-xs"></i></a>'))
                    )
            });
        });
    },
    AfiliadoOficina: function (RutEmpresa) {
        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-afiliado-oficina", { RutEmpresa: RutEmpresa }, function (menus) {
            $.each(menus, function (i, e) {
                $("#slAfiliadoSelect").append($("<option>").attr("value", e.RutAfiliado).html(e.NombreAfiliado))
            });
            $('#demo-chosen-select').chosen();
            $('#slAfiliadoSelect').chosen({ width: '100%' });
        });
    }
}

$('#tabla .page-number').on("click", function () {
    $('.add-popover').popover();
});

$('#tab_planificacion').on('click', function () {
    $('#demo-calendar').fullCalendar({});
});

jQuery.fn.bootstrapTable.defaults.icons = {
    paginationSwitchDown: 'demo-pli-arrow-down',
    paginationSwitchUp: 'demo-pli-arrow-up',
    refresh: 'demo-pli-repeat-2',
    toggle: 'demo-pli-layout-grid',
    columns: 'demo-pli-check',
    detailOpen: 'demo-psi-add',
    detailClose: 'demo-psi-remove'
}

cargador.CargaAgenda('0', '0');

$('#slFrecuencia').change(function (e) {
    e.preventDefault();
    if ($(this).val() == 'Diaria') {

        $("#divSemanal").css('display', 'none')
        $("#divMensual").css('display', 'none')
        $("#tituloFecuencia").html('Frecuencia Diaria')
        $("#divDiario").css('display', 'block')
    }
    else if ($(this).val() == 'Semanal') {

        $("#divDiario").css('display', 'none')
        $("#divMensual").css('display', 'none')
        $("#tituloFecuencia").html('Frecuencia Semanal')
        $("#divSemanal").css('display', 'block')
    }
    else if ($(this).val() == 'Quincenal') {

        $("#divDiario").css('display', 'none')
        $("#divMensual").css('display', 'none')
        $("#tituloFecuencia").html('Frecuencia Quicenal')
        $("#divSemanal").css('display', 'block')
    }
    else if ($(this).val() == 'Mensual') {
        $("#divSemanal").css('display', 'none')
        $("#divDiario").css('display', 'none')
        $("#tituloFecuencia").html('Frecuencia Mensual')
        $("#divMensual").css('display', 'block')
    }
});

$('#slFrecuencia_update').change(function (e) {
    e.preventDefault();
    if ($(this).val() == 'Diaria') {

        $("#divSemanal_update").css('display', 'none')
        $("#divMensual_update").css('display', 'none')
        $("#tituloFecuencia_update").html('Frecuencia Diaria')
        $("#divDiario_update").css('display', 'block')
    }
    else if ($(this).val() == 'Semanal') {

        $("#divDiario_update").css('display', 'none')
        $("#divMensual_update").css('display', 'none')
        $("#tituloFecuencia_update").html('Frecuencia Semanal')
        $("#divSemanal_update").css('display', 'block')
    }
    else if ($(this).val() == 'Quincenal') {

        $("#divDiario_update").css('display', 'none')
        $("#divMensual_update").css('display', 'none')
        $("#tituloFecuencia_update").html('Frecuencia Quicenal')
        $("#divSemanal_update").css('display', 'block')
    }
    else if ($(this).val() == 'Mensual') {
        $("#divSemanal_update").css('display', 'none')
        $("#divDiario_update").css('display', 'none')
        $("#tituloFecuencia_update").html('Frecuencia Mensual')
        $("#divMensual_update").css('display', 'block')
    }
});

$('#slEjecutivoAgendaIng').change(function (e) {
    e.preventDefault();
    if ($(this).val() != '') {
        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-empresa-ejecutivo", { RutEjecutivo: $(this).val() }, function (datos) {
            $("#slEmpresaAgendasIng").html("");
            $("#slEmpresaAgendasIng").append($("<option>").attr("value", "").html("Seleccione"));
            $.each(datos, function (i, e) {
                $("#slEmpresaAgendasIng").append($("<option>").attr("value", e.RutEmpresa).html(e.NombreEmpresa).data('idanexo', e.IdEmpresa)).trigger('chosen:updated')
            });
        });
        $('#slEmpresaAgendasIng').chosen({ width: '100%' });
    }
    else {
        $("#slEmpresaAgendasIng").html("");
        $("#slEmpresaAgendasIng").attr("disabled", true);
    }
});

$('#slDuracionDia').change(function (e) {
    e.preventDefault();
    if ($(this).val() != '') {

        var Hrini = $('#slComienzaDia').val()
        var Hrfin = $('#slDuracionDia').val()
        var HriniSpl = Hrini.split(':');
        var HrfinSpl = Hrfin.split(':');
        var hora
        var minutos;
        if ((parseInt(HriniSpl[1]) + parseInt(HrfinSpl[1])) < 59) {
            hora = parseInt(HriniSpl[0]) + parseInt(HrfinSpl[0]);
            minutos = parseInt(HriniSpl[1]) + parseInt(HrfinSpl[1])
            if (minutos == 0) {
                minutos = '00'
            }
        }
        else {
            hora = (parseInt(HriniSpl[0]) + parseInt(HrfinSpl[0])) + 1;
            minutos = '00'
        }
        var valor = hora + ':' + minutos
        $('#txtHoraFin').val(valor)
    }
});

$('#slComienzaDia').change(function (e) {
    e.preventDefault();
    if ($(this).val() != '') {

        var Hrini = $('#slComienzaDia').val()
        var Hrfin = $('#slDuracionDia').val()
        var HriniSpl = Hrini.split(':');
        var HrfinSpl = Hrfin.split(':');
        var hora
        var minutos;
        if ((parseInt(HriniSpl[1]) + parseInt(HrfinSpl[1])) < 59) {
            hora = parseInt(HriniSpl[0]) + parseInt(HrfinSpl[0]);
            minutos = parseInt(HriniSpl[1]) + parseInt(HrfinSpl[1])
            if (minutos == 0) {
                minutos = '00'
            }
        }
        else {
            hora = (parseInt(HriniSpl[0]) + parseInt(HrfinSpl[0])) + 1;
            minutos = '00'
        }
        var valor = hora + ':' + minutos
        $('#txtHoraFin').val(valor)
    }
});

$('#slDuracionDia_update').change(function (e) {
    e.preventDefault();
    if ($(this).val() != '') {

        var Hrini = $('#slComienzaDia_update').val()
        var Hrfin = $('#slDuracionDia_update').val()
        var HriniSpl = Hrini.split(':');
        var HrfinSpl = Hrfin.split(':');
        var hora
        var minutos;
        if ((parseInt(HriniSpl[1]) + parseInt(HrfinSpl[1])) < 59) {
            hora = parseInt(HriniSpl[0]) + parseInt(HrfinSpl[0]);
            minutos = parseInt(HriniSpl[1]) + parseInt(HrfinSpl[1])
            if (minutos == 0) {
                minutos = '00'
            }
        }
        else {
            hora = (parseInt(HriniSpl[0]) + parseInt(HrfinSpl[0])) + 1;
            minutos = '00'
        }
        var valor = hora + ':' + minutos
        $('#txtHoraFin_update').val(valor)
    }
});

$('#slComienzaDia_update').change(function (e) {
    e.preventDefault();
    if ($(this).val() != '') {

        var Hrini = $('#slComienzaDia_update').val()
        var Hrfin = $('#slDuracionDia_update').val()
        var HriniSpl = Hrini.split(':');
        var HrfinSpl = Hrfin.split(':');
        var hora
        var minutos;
        if ((parseInt(HriniSpl[1]) + parseInt(HrfinSpl[1])) < 59) {
            hora = parseInt(HriniSpl[0]) + parseInt(HrfinSpl[0]);
            minutos = parseInt(HriniSpl[1]) + parseInt(HrfinSpl[1])
            if (minutos == 0) {
                minutos = '00'
            }
        }
        else {
            hora = (parseInt(HriniSpl[0]) + parseInt(HrfinSpl[0])) + 1;
            minutos = '00'
        }
        var valor = hora + ':' + minutos
        $('#txtHoraFin_update').val(valor)
    }
});

$('#form_registro_agendaEmpresa').bootstrapValidator({
    excluded: [':disabled', ':not(:visible)'],
    feedbackIcons: [],
    fields: {
        slEmpresaAgendasIng: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar empresa'
                }
            }
        },
        slEjecutivoAgendaIng: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar ejecutivo'
                }
            }
        },
        slTipoVisita: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar un tipo de visita'
                }
            }
        },
        txtObsCita: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar glosa de la cita'
                }
            }
        },
        slFrecuencia: {
            validators: {
                notEmpty: {
                    message: 'Debe seleccionar una frecuencia'
                }
            }
        },
        slComienzaDia: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar una hora'
                }
            }
        }
    }
}).on('success.form.bv', function (e) {
    e.preventDefault();
    var $form = $(e.target);
    var results = new Array();
    results.length = 0;
    var i = 0;
    if ($('#slFrecuencia').val() == 'Semanal' || $('#slFrecuencia').val() == 'Quincenal') {
        $("input[name='groupCkeckDias[]']:checked").each(function () {
            results[i] = '"' + $(this).val() + '"'
            i++
        });
        results = '[' + results + ']'
    }
    else if ($('#slFrecuencia').val() == 'Mensual') {
        results = $('#slDiasMensual').val()
    }
    else if ($('#slFrecuencia').val() == 'Diaria') {
        results = "Null"
    }

    var objeto_envio_agenda_empresa = {
        RutEmpresa: $('#slEmpresaAgendasIng').val(),
        RutEjecutivo: $('#slEjecutivoAgendaIng').val(),
        NombreEmpresa: $('#slEmpresaAgendasIng option:selected').text(),
        Glosa: $('#txtObsCita').val(),
        FechaInico: fechaPop + ' ' + $('#slComienzaDia').val(),
        FechaFin: fechaPop + ' ' + $('#txtHoraFin').val(),
        HoraInicio: $('#slComienzaDia').val(),
        HoraFin: $('#txtHoraFin').val(),
        Frecuencia: $('#slFrecuencia').val(),
        Dias: results,
        TipoVisita: $('#slTipoVisita').val(),
        IdAnexo: $('#slEmpresaAgendasIng option:selected').data('idanexo'),
        DiasSucede: $('#slSucedeDia').val(),
    }

    $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/ingresa-cita-agenda-empresa-agente", objeto_envio_agenda_empresa, function (datos) {
        $("#form_registro_agendaEmpresa").bootstrapValidator('resetForm', true);
        $('#demo-lg-modal-agenda').modal('hide');
        $.niftyNoty({
            type: 'success',
            icon: 'pli-like-2 icon-2x',
            message: 'Se agendo la cita correctamente.',
            container: 'floating',
            timer: 5000
        });
        $('#demo-calendar').fullCalendar('refetchEvents');
    });
});

$("#slEjecutivoAgenda").on("change", function (event) {
    $('#slEmpresaAgendas').val('0').trigger('chosen:updated');
    cargador.CargaAgenda('0', $('#slEjecutivoAgenda').val());
    $('#slEjecutivoAgendaIng').val($("#slEjecutivoAgenda").val()).trigger('chosen:updated');
    $('#slEmpresaAgendasIng').val('0').trigger('chosen:updated');
})
$("#slEmpresaAgendas").on("change", function (event) {
    $('#slEjecutivoAgenda').val('0').trigger('chosen:updated');
    cargador.CargaAgenda($('#slEmpresaAgendas').val(), '0');
    $('#slEmpresaAgendasIng').val($("#slEmpresaAgendas").val()).trigger('chosen:updated');
    $('#slEjecutivoAgendaIng').val('0').trigger('chosen:updated');
});

$('#form_registro_agendaEmpresa_update').bootstrapValidator({
    excluded: [':disabled', ':not(:visible)'],
    feedbackIcons: [],
    fields: {
        slTipoVisita_update: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar un tipo de visita'
                }
            }
        },
        txtObsCita_update: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar glosa de la cita'
                }
            }
        },
        slFrecuencia_update: {
            validators: {
                notEmpty: {
                    message: 'Debe seleccionar una frecuencia'
                }
            }
        },
        slComienzaDia_update: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar una hora'
                }
            }
        }
    }
}).on('success.form.bv', function (e) {
    e.preventDefault();
    var $form = $(e.target);
    var results = new Array();
    results.length = 0;
    var i = 0;
    if ($('#slFrecuencia_update').val() == 'Semanal' || $('#slFrecuencia_update').val() == 'Quincenal') {
        $("input[name='groupCkeckDias_update[]']:checked").each(function () {
            results[i] = '"' + $(this).val() + '"'
            i++
        });
        results = '[' + results + ']'
    }
    else if ($('#slFrecuencia_update').val() == 'Mensual') {
        results = $('#slDiasMensual_update').val()
    }
    else if ($('#slFrecuencia_update').val() == 'Diaria') {
        results = "Null"
    }

    var objeto_envio_agenda_empresa_update = {
        IdAgenda: $("#btCita_update").data("idagenda"),
        RutEmpresa: $("#btCita_update").data("rutempresa"),
        Glosa: $('#txtObsCita_update').val(),
        FechaInico: $('#txtFechacita_update').val().toFecha() + ' ' + $('#slComienzaDia_update').val(),
        FechaFin: $('#txtFechacita_update').val().toFecha() + ' ' + $('#txtHoraFin_update').val(),
        HoraInicio: $('#slComienzaDia_update').val(),
        HoraFin: $('#txtHoraFin_update').val(),
        TipoVisita: $('#slTipoVisita_update').val(),
    }
    $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/actualiza-cita-agenda-empresa", objeto_envio_agenda_empresa_update, function (datos) {
        $("#form_registro_agendaEmpresa_update").bootstrapValidator('resetForm', true);
        $('#demo-lg-modal-agenda_update').modal('hide');
        $.niftyNoty({
            type: 'success',
            icon: 'pli-like-2 icon-2x',
            message: 'SE MODIFICO LA CITA DEL DIA CORRECTAMENTE !.',
            container: 'floating',
            timer: 5000
        });
        $('#demo-calendar').fullCalendar('refetchEvents');
    });
});

$('#btCita_elimina').on('click', function () {
    bootbox.dialog({
        message: "<h1 class='page-header text-overflow pad-btm'>Puede eliminar la cita del dia o la cita frecuente !</h1>",
        title: "ELIMINAR CITA",
        buttons: {
            success: {
                label: "Eliminar Cita del Dia",
                className: "btn-success",
                callback: function () {
                    var objeto_envio_agenda_empresa_eliminar = {
                        IdAgenda: $("#btCita_elimina").data("idagenda"),
                        IdRegistro: 0,
                        RutEmpresa: $("#btCita_elimina").data("rutempresa"), // $('#slEmpresaAgendas').val(),   //rutempresa
                    }
                    $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/elimina-cita-agenda-empresa", objeto_envio_agenda_empresa_eliminar, function (datos) {
                        $("#form_registro_agendaEmpresa_update").bootstrapValidator('resetForm', true);
                        $('#demo-lg-modal-agenda_update').modal('hide');
                        $.niftyNoty({
                            type: 'success',
                            icon: 'pli-like-2 icon-2x',
                            message: 'SE ELIMINO LA CITA DEL DIA CORRECTAMENTE.',
                            container: 'floating',
                            timer: 5000
                        });
                        $('#demo-calendar').fullCalendar('refetchEvents');
                    });
                }
            },

            danger: {
                label: "Eliminar Cita Frecuente",
                className: "btn-danger",
                callback: function () {
                    var objeto_envio_agenda_empresa_eliminar = {
                        IdAgenda: 0,
                        IdRegistro: $("#btCita_elimina").data("idregistro"),
                        RutEmpresa: $("#btCita_elimina").data("rutempresa"),
                    }
                    $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/elimina-cita-agenda-empresa", objeto_envio_agenda_empresa_eliminar, function (datos) {
                        $("#form_registro_agendaEmpresa_update").bootstrapValidator('resetForm', true);
                        $('#demo-lg-modal-agenda_update').modal('hide');
                        $.niftyNoty({
                            type: 'success',
                            icon: 'pli-like-2 icon-2x',
                            message: 'SE ELIMINO LA CITA FRECUENTE CORRECTAMENTE.',
                            container: 'floating',
                            timer: 5000
                        });
                        $('#demo-calendar').fullCalendar('refetchEvents');
                    });
                }
            },
            main: {
                label: "Cancelar",
                className: "btn-primary",
            }
        }
    })
});

$.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-tipologia-gestion", { tipoCampagna: 1, padre: 0 }, function (datos) {
    $("#slTemaGestion").html("");
    $("#slTemaGestion").append($("<option>").attr("value", "").html("Seleccione"));
    $("#slTema").html("");
    $("#slTema").append($("<option>").attr("value", "").html("Seleccione"));
    $.each(datos, function (i, e) {
        $("#slTemaGestion").append($("<option>").attr("value", e.IdTema).html(e.GlosaGestion))
        $("#slTema").append($("<option>").attr("value", e.IdTema).html(e.GlosaGestion))
    });
});

$.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", { tipoCampagna: 1, padre: 0 }, function (datos) {
    $("#selecEstado").html("");
    $("#selecEstado").append($("<option>").attr("value", "").html("Seleccione"));
    $("#selecEstado").append($("<option>").attr("value", "-1").html("Sin Gestion"));
    $.each(datos, function (i, e) {
        $("#selecEstado").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre).data("terminal", e.ejes_terminal))
    });
});

$.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-comunas-empresa", function (menus) {
    $("#slComuna_multiselect").html("");
    $("#slComuna_multiselectUp").html("");
    $("#slComuna_multiselect").append($("<option>").attr("value", "").html("Seleccione"));
    $("#slComuna_multiselectUp").append($("<option>").attr("value", "").html("Seleccione"));
    $.each(menus, function (i, e) {
        $("#slComuna_multiselect").append($("<option>").attr("value", e.IdComuna).html(e.NombreComuna))
        $("#slComuna_multiselectUp").append($("<option>").attr("value", e.IdComuna).html(e.NombreComuna))
    });
    $('#slComuna_multiselect').chosen({ width: '100%' });
    $('#slComuna_multiselectUp').chosen({ width: '100%' });
});

$.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/dotacion-oficina", function (menus) {
    $.each(menus, function (i, e) {
        $("#demo-cs-multiselectEje").append($("<option>").attr("value", e.Rut).html(e.Nombre + " - ( " + e.Cargo + " )"))
        $("#demo-cs-multiselectEjeEmpresa").append($("<option>").attr("value", e.Rut).html(e.Nombre + " - ( " + e.Cargo + " )"))
    });
    $('#demo-chosen-select').chosen();
    $('#demo-cs-multiselectEje').chosen({ width: '70%' });
    $('#demo-cs-multiselectEjeEmpresa').chosen({ width: '80%' });
});

$('#slTemaGestion').change(function (e) {
    e.preventDefault();
    if ($(this).val() != '') {
        $("#slSubTemavisita").attr("disabled", false);
        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-tipologia-Subgestion", { IdTema: $(this).val() }, function (datos) {
            $("#slSubTemavisita").html("");
            $("#slSubTemavisita").append($("<option>").attr("value", " ").html("Seleccione"));
            $.each(datos, function (i, e) {
                $("#slSubTemavisita").append($("<option>").attr("value", e.IdSubTema).html(e.GlosaSubTema))
            });
        });
    }
    else {
        $("#slSubTemavisita").html("");
        $("#slSubTemavisita").attr("disabled", true);
    }
});

$('#slTema').change(function (e) {
    e.preventDefault();
    if ($(this).val() != '') {
        $("#slSubTema").attr("disabled", false);
        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-tipologia-Subgestion", { IdTema: $(this).val() }, function (datos) {
            $("#slSubTema").html("");
            $("#slSubTema").append($("<option>").attr("value", " ").html("Seleccione"));
            $.each(datos, function (i, e) {
                $("#slSubTema").append($("<option>").attr("value", e.IdSubTema).html(e.GlosaSubTema))
            });
        });
    }
    else {
        $("#slSubTema").html("");
        $("#slSubTema").attr("disabled", true);
    }
});

$("input:radio[name=groupCkeckCompromiso]").click(function () {
    switch (this.value) {
        case "SI":
            compromiso = 1;
            $("#divFechaResul").css('display', 'block')
            $("#comentarioResultado").css('display', 'block')
            break;
        case "NO":
            compromiso = 0;
            $("#divFechaResul").css('display', 'none')
            $("#comentarioResultado").css('display', 'none')
            $('#FechaResolucion').val('01-01-1900')
            break;
    }
});

$("input:radio[name=groupCkeckAlerta_visitas]").click(function () {
    switch (this.value) {
        case "Mantenedor":
            $('.colap2').collapse('hide')
            $('.colap1').collapse('show')

            break;
        case "Visita":
            $('.colap1').collapse('hide')
            $('.colap2').collapse('show')
            break;
    }
});

$('#radioEntravista').on("click", function () {
    $('#divVisita').css('display', 'none')
    $('#divEntrevista').css('display', 'block')
});
$('#radioVisita').on("click", function () {
    $('#divEntrevista').css('display', 'none')
    $('#divVisita').css('display', 'block')
});

$('#demo-lg-modal-entrevista').on('hidden.bs.modal', function (event) {
    $('#btGuardaCabecera').css('display', 'block')
    $('#btGuardaGestionMan').css('display', 'block')
    $("#form_gestion_mantencion").bootstrapValidator('resetForm', true);
    $("#form_gestion_mantencion_detalle").bootstrapValidator('resetForm', true);
    $("#form-registro-entrevista").bootstrapValidator('resetForm', true);
    $("#form_entrevista_detalle").bootstrapValidator('resetForm', true);
    $("#slAfiliadoSelect").val('').trigger("chosen:updated");
    $("#ckAlertaNOGestion").prop("checked", true);
    $('#form_gestion_mantencion_detalle').css('display', 'none')
    $('#form_entrevista_detalle').css('display', 'none')
});

$('#form-registro-entrevista').bootstrapValidator({
    excluded: [':disabled', ':not(:visible)'],
    feedbackIcons: [],
    fields: {
        nombContacto: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar un contacto'
                }
            }
        },
        slEstamento: {
            validators: {
                notEmpty: {
                    message: 'Seleccionar un Estamento'
                }
            }
        },
        txtCargo: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar un cargo'
                }
            }
        },
        txtComentariosCab: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar un comentario'
                }
            }
        },
        tefContacto: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar un Telefono'
                }
            }
        },
        correoContacto: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar un Correo'
                }
            }
        }
    }
}).on('success.form.bv', function (e) {
    e.preventDefault();
    var $form = $(e.target);


    var objeto_envio_entrevista = {
        RutEmpresa: $("#btCita_update").data("rutempresa"),
        FechaEntrevista: $('#FechaGestges').val(),
        NombreContacto: $("#nombContacto").val(),
        Estamento: $('#slEstamento').val(),
        Cargo: $('#txtCargo').val(),
        Comentarios: $('#txtComentariosCab').val(),
        TelefonoContacto: $('#tefContacto').val(),
        CorreoContacto: $('#correoContacto').val(),

    }
    $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/ingresa-cabecera-entrevista", objeto_envio_entrevista, function (datos) {
        $('#btGuardaCabecera').css('display', 'none')
        $('#btGuardaDetalleEntrevista').attr('disabled', false);
        $('#form_entrevista_detalle').css('display', 'block')
        idEnvta = datos.IdEntrevista
        $.niftyNoty({
            type: 'success',
            icon: 'pli-like-2 icon-2x',
            message: 'Entrevista Creada Correctamente.',
            container: '#msjEntrevistaCab',
            timer: 5000
        });
        cargador.CargaDatosEntrevista();
    });
});

$('#form_entrevista_detalle').bootstrapValidator({
    excluded: [':disabled', ':not(:visible)'],
    feedbackIcons: [],
    fields: {
        slTema: {
            validators: {
                notEmpty: {
                    message: 'Seleccionar un Tema'
                }
            }
        },
        slSubTema: {
            validators: {
                notEmpty: {
                    message: 'Seleccionar un Sub-Tema'
                }
            }
        },
        slSemaforo: {
            validators: {
                notEmpty: {
                    message: 'Seleccionar un color de Semaforo'
                }
            }
        },
        comentarioDtEn: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar un comentario'
                }
            }
        }
    }
}).on('success.form.bv', function (e) {
    e.preventDefault();
    var $form = $(e.target);
    var objeto_detalle_entrevista = {
        IdEntrevista: idEnvta,
        Tema: $('#slTema option:selected').text(),
        SubTema: $('#slSubTema option:selected').text(),
        Semaforo: $('#slSemaforo').val(),
        Alerta: alerta,
        FechaResolucion: $('#FechaResolucion').val(),
        Comentarios: $('#comentarioDtEn').val(),
        Compromiso: compromiso,
    }




    $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/ingresa-detalle-entrevista", objeto_detalle_entrevista, function (datos) {
        $("#form-registro-entrevista-detalle").bootstrapValidator('resetForm', true);

        $("#slTema").val('')
        $("#slSubTema").val("")
        $("#slSemaforo").val("")
        $("#comentarioDtEn").val("")
        $("#ckCompromisoNO").prop("checked", true);
        $("#ckAlertaNO").prop("checked", true);
        compromiso = 0;
        $("#divFechaResul").css('display', 'none')
        $('#FechaResolucion').val('01-01-1900')



        $.niftyNoty({
            type: 'success',
            icon: 'pli-like-2 icon-2x',
            message: 'Detalle Entrevista Guardada Correctamente.',
            container: '#msjEntrevistaDet',
            timer: 5000
        });
    });
});

$('#form_gestion_mantencion').bootstrapValidator({
    excluded: [':disabled', ':not(:visible)'],
    feedbackIcons: [],
    fields: {
        FechaCabeceraGest: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar una Fecha'
                }
            }
        },
        slTipoGestion: {
            validators: {
                notEmpty: {
                    message: 'Seleccionar un Tipo'
                }
            }
        },
        comentarioCabeceraGestion: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar un comentario'
                }
            }
        }
    }
}).on('success.form.bv', function (e) {
    e.preventDefault();
    var $form = $(e.target);

    var objeto_envio_cab_gestion_man = {
        RutEmpresa: $("#btCita_update").data("rutempresa"),
        FechaIngreso: $('#FechaCabeceraGest').val(),
        Tipo: $("#slTipoGestion").val(),
        Comentarios: $('#comentarioCabeceraGestion').val(),
    }

    console.log(objeto_envio_cab_gestion_man)
    $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/ingresa-cabecera-mant-gestion", objeto_envio_cab_gestion_man, function (datos) {
        $('#btGuardaGestionMan').css('display', 'none')
        $('#btGuardaDetalleGestionMan').attr('disabled', false);
        $('#form_gestion_mantencion_detalle').css('display', 'block')
        idCabManGest = datos.IdCabGesMantencion
        $.niftyNoty({
            type: 'success',
            icon: 'pli-like-2 icon-2x',
            message: 'Mantencion Gestion Creada Correctamente.',
            container: '#msjMantGestCab',
            timer: 5000
        });
        cargador.CargaDatosGestionMan();
    });
});

$('#form_gestion_mantencion_detalle').bootstrapValidator({
    excluded: [':disabled', ':not(:visible)'],
    feedbackIcons: [],
    fields: {
        slTema: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar un Tema'
                }
            }
        },
        slSubTemavisita: {
            validators: {
                notEmpty: {
                    message: 'Debe seleccionar una Sub-Tema'
                }
            }
        },
        slAfiliadoSelect: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar Afiliados'
                }
            }
        },
        comentarioGestion: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar un comentario'
                }
            }
        }
    }
}).on('success.form.bv', function (e) {
    e.preventDefault();
    var $form = $(e.target);
    var idcomuna = 0;
    var afi = $('#slAfiliadoSelect').val()
    var afi2 = afi.join()

    var objeto_envio_gestion_mantencion = {
        IdCabGesMantencion: idCabManGest,
        RutEmpresa: $("#btCita_update").data("rutempresa"),
        Tema: $('#slTemaGestion option:selected').text(),
        SubTema: $('#slSubTemavisita option:selected').text(),
        RutAfiliado: afi2,
        Comentarios: $('#comentarioGestion').val(),
        Alerta: alertaGestion,
    }
    $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/ingresa-gestion-mantencion", objeto_envio_gestion_mantencion, function (datos) {
        $("#form_gestion_mantencion_detalle").bootstrapValidator('resetForm', true);

        $("#slTemaGestion").val('')
        $("#slSubTemavisita").val("")
        $("#ckAlertaNOGestion").prop("checked", true);
        alertaGestion = 0;
        $("#slAfiliadoSelect").val('').trigger("chosen:updated");
        $("#comentarioGestion").val("")

        $.niftyNoty({
            type: 'success',
            icon: 'pli-like-2 icon-2x',
            message: 'Nuevo detalle de gestion Creado Correctamente.',
            container: '#msjMantGestDet',
            timer: 5000
        });
    });
});


// BUBBLE NUMBERS
//CARLOS PRADENAS
// =================================================================
$('#demo-step-wz').bootstrapWizard({
    tabClass: 'wz-steps',
    nextSelector: '.next',
    previousSelector: '.previous',
    onTabClick: function (tab, navigation, index) {
        return false;
    },
    onInit: function () {
        $('#demo-step-wz').find('.finish').hide().prop('disabled', true);
    },
    onTabShow: function (tab, navigation, index) {
        var $total = navigation.find('li').length;
        var $current = index + 1;
        var $percent = (index / $total) * 100;
        var wdt = 100 / $total;
        var lft = wdt * index;
        var margin = (100 / $total) / 2;
        $('#demo-step-wz').find('.progress-bar').css({ width: $percent + '%', 'margin': 0 + 'px ' + margin + '%' });


        console.log({ tab, navigation, index });

        if (index == 1) {
            $(document).trigger("charlie.events.onAsignarAnexos");
        }

        if (index == 2) {
            $(document).trigger("charlie.events.onAsignacionyCargaDeAfiliados");
        }

        // If it's the last tab then hide the last button and show the finish instead
        if ($current >= $total) {
            $('#demo-step-wz').find('.next').hide();
            $('#demo-step-wz').find('.finish').show();
            $('#demo-step-wz').find('.finish').prop('disabled', false);
        } else {
            $('#demo-step-wz').find('.next').show();
            $('#demo-step-wz').find('.finish').hide().prop('disabled', true);
        }
    }
});


$("#btn-add-new-enterprise").on('click', function () {
    $("#add-enterprise").show();
    $("#enterprises-added").hide();
    $("#btn-add-new-enterprise").hide();
    $("#btn-back").show();
});

$("#btn-back").on('click', function () {
    $("#add-enterprise").hide();
    $("#enterprises-added").show();
    $("#btn-add-new-enterprise").show();
    $("#btn-back").hide();
    //resetear las etapas del wizard
});


$('#bt-search-company').on('click', function () {
    var query = $('#query-company').val();
    $("#lading-indicator").show();
    $('#search-results').html("");
    $.SecGetJSON(BASE_URL + "/motor/api/CarteraEmpresas/buscar-empresa", { query }, function (response) {

        $.each(response, function (i, e) {
            var rendhtml = `<tr class="result-item">
                                        <td>
                                            <span class="text-semibold elnombre">${e.NombreEmpresa}</span>
                                            <br>
                                            <small class="elrut">${e.RutEmpresa}</small>
                                        </td>
                                        <td class="text-center"><span class="text-semibold elholding">${e.Holding}</span></td>
                                    </tr>`;

            $('#search-results').append(rendhtml);

        });

        $("#lading-indicator").hide();
        $("#table-results").show();
        $('#tNombreEmpresa').html(response[0].NombreEmpresa)
        $('#tRutEmpresa').html(response[0].RutEmpresa)


    });
});

$(document).on("click", ".result-item", function () {

    $(".result-item").removeClass("seleccionado");
    $(this).addClass("seleccionado");
});

$('#es-sin-sucursal').on('click', function () {

    charlie_listado_anexos.cleanData();
    if ($(this).is(':checked')) {
        $('.bloqueable').hide();
    } else {
        $('.bloqueable').show();
    }
});

$('#bt-agregar-anexo').on('click', function () {

    var vacios = [];

    $('.no-vacio').each(function (i, e) {
        console.log({
            e, i
        })

        if ($(e).val() === '') {
            $(e).addClass('has-error');
            vacios.push($(e).prop('id'));
        }
    })

    if (vacios.length > 0) {

        var mensaje = 'Porfavor Rellena los Campos Vacíos \n -' + vacios.join('\n -')
        alert(mensaje);
        return false;
    }


    if (charlie_listado_anexos.state.editing !== null) {

        let fnd = charlie_listado_anexos.data.find(elm => elm.guid === charlie_listado_anexos.state.editing);
        let idx = charlie_listado_anexos.data.findIndex(elm => elm.guid === charlie_listado_anexos.state.editing);

        fnd.nombre = $('#nombre-anexo').val();
        fnd.direccion = $('#direccion-anexo-calle').val();
        fnd.numeroDireccion = $('#direccion-anexo-numeracion').val();
        fnd.local = $('#direccion-anexo-local').val();
        fnd.region = $('select[id="region-anexo"] option:selected').text();
        fnd.comuna = $('select[id="comuna-anexo"] option:selected').text();
        fnd.cantidadTrabajadores = parseInt($('#n-trabajadores-anexo').val());

        charlie_listado_anexos.data[idx] = fnd;
        $(this).text('Agregar Anexo');

    } else {

        charlie_listado_anexos.data.push({
            nombre: $('#nombre-anexo').val(),
            direccion: $('#direccion-anexo-calle').val(),
            numeroDireccion: $('#direccion-anexo-numeracion').val(),
            local: $('#direccion-anexo-local').val(),
            region: $('select[id="region-anexo"] option:selected').text(),
            comuna: $('select[id="comuna-anexo"] option:selected').text(),
            cantidadTrabajadores: parseInt($('#n-trabajadores-anexo').val()),
            guid: uuid4(),
            databaseId: 0
        });
    }

    $('#nombre-anexo').val("");
    $('#direccion-anexo-calle').val("");
    $('#direccion-anexo-numeracion').val("");
    $('#direccion-anexo-local').val("");
    $('#region-anexo option[value=""]').attr("selected", true);
    $('#comuna-anexo option[value=""]').attr("selected", true);
    $('#n-trabajadores-anexo').val("");

    charlie_listado_anexos.renderAll();

});



$(document).on("charlie.events.onAsignacionyCargaDeAfiliados", function (ev) {
    if ($('#es-sin-sucursal').is(':checked') && charlie_listado_anexos.data.length == 0) {
        charlie_listado_anexos.data.push({
            nombre: $('#tNombreEmpresa').html(),
            direccion: $('#direccion-anexo-calle').val(),
            numeroDireccion: $('#direccion-anexo-numeracion').val(),
            local: $('#direccion-anexo-local').val(),
            region: $('select[id="region-anexo"] option:selected').text(),
            comuna: $('select[id="comuna-anexo"] option:selected').text(),//$('#comuna-anexo').val(),
            cantidadTrabajadores: parseInt($('#n-trabajadores-anexo').val()),
            guid: uuid4()
        });
        charlie_listado_anexos.renderListarAnexoCarga();
        charlie_listado_anexos.renderListarAnexoResumen();
        $('.bloqueable').hide();

    }

    $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/dotacion-oficina", function (menus) {
        $.each(menus, function (i, e) {
            $(".select-dotacion").append($("<option>").attr("value", e.Rut).html(e.Nombre + " - ( " + e.Cargo + " )"))
        });
        $('.select-dotacion').chosen({
            width: '80%'
        });

    });
});

$(document).on('charlie.events.onAsignarAnexos', function () {
    charlie_listado_anexos.company = {
        rut: $('.seleccionado').find('.elrut').text(),
        nombre: $('.seleccionado').find('.elnombre').text(),
        holding: $('.seleccionado').find('.elholding').text()
    };

    $.SecGetJSON('http://localhost/motor/api/perfil-empresas/lista-cartera-anexo', { RutEmpresa: charlie_listado_anexos.company.rut }, function (response) {
        console.log({ response })
        charlie_listado_anexos.import(response);
    });
});


$(document).on('click', '.editar-anexo', function () {
    let $t = $(this);
    let finded = charlie_listado_anexos.data.find(elm => elm.guid == $t.data('guid'));

    //$('#direccion-anexo').val(finded.direccion);

    $('#direccion-anexo-calle').val(finded.direccion);
    $('#direccion-anexo-numeracion').val(finded.numeroDireccion);
    $('#direccion-anexo-local').val(finded.local);
    $('select[id="region-anexo"] option:selected').text(finded.region),
    $('#comuna-anexo').val(finded.comuna);
    $('#n-trabajadores-anexo').val(finded.cantidadTrabajadores);
    $('#nombre-anexo').val(finded.nombre);

    $("#bt-agregar-anexo").text("Modificar Anexo");
    charlie_listado_anexos.state = { editing: finded.guid };
});


$(document).on('click', '.finish', function () {
    let $tfn = $(this);
    let finish = charlie_listado_anexos.data.find(elm => elm.guid);//charlie_listado_anexos.data.find(elm => elm.guid == $tfn.data('guid'));

    //$('#direccion-anexo').val(finded.direccion);
    //$('#comuna-anexo').val(finded.comuna);
    //$('#n-trabajadores-anexo').val(finded.cantidadTrabajadores);
    //$('#nombre-anexo').val(finded.nombre);

    //$("#bt-agregar-anexo").text("Modificar Anexo");
    //charlie_listado_anexos.state = { editing: finded.guid };


   //console.log(charlie_listado_anexos.data.pop())

});


//Controller & ViewModel
//GRILLA PASO 1 Y PASO 2
var charlie_listado_anexos = {
    company: {},
    data: [],
    state: { editing: null },
    bodySelectorAnexo: '#bdy-listado-anexos',
    renderAgregarAnexo: function (data = []) {
        data = data.length == 0 ? this.data : data;
        $(this.bodySelectorAnexo).html("");
        var html = ``;
        $.each(data, function (i, e) {
            html += `
                                <tr data-guid="${e.guid}">
                                   <td>${e.nombre}</td>
                                   <td>${e.direccion}</td>
                                   <td>${e.comuna == null ? '' : e.comuna}</td>
                                   <td>${e.cantidadTrabajadores}</td>
                                   <td><button type="button" class="btn btn-warning btn-sm editar-anexo" data-guid="${e.guid}">Editar</button></td>
                                </tr>
                            `;
        });

        $(this.bodySelectorAnexo).append(html);
    },
    bodySelectorAnexoCarga: '#bdy-listado-anexos-carga',
    renderListarAnexoCarga: function (data = []) {
        data = data.length == 0 ? this.data : data;
        $(this.bodySelectorAnexoCarga).html("");
        var html = ``;
        $.each(data, function (i, e) {
            html += `
                                <tr id="tr-${e.guid}">
                                   <td class="bloqueable">${e.nombre}</td>
                                   <td>${e.direccion}</td>
                                   <td>${e.comuna}</td>
                                   <td>${e.cantidadTrabajadores}</td>
                                   <td class="bloqueable">
                                        <span class="pull-left btn btn-primary btn-file">
                                            Selecciona
                                            <input type="file" name="archivafil[]" accept=".csv" class="archivos" id="file-${e.guid}" />
                                        </span>
                                    </td>
                                   <td><select id="sel-${e.guid}" class="from-control select-dotacion" multiple ><option value=""><Seleccione/option></select></td>
                                </tr>
                            `;
        });

        $(this.bodySelectorAnexoCarga).append(html);
    },
    bodySelectorAnexoResumen: '#bdy-listado-anexos-resumen',
    renderListarAnexoResumen: function (data = []) {
        data = data.length == 0 ? this.data : data;
        $(this.bodySelectorAnexoResumen).html("");
        var html = ``;
        $.each(data, function (i, e) {
            html += `
                                <tr id="tr-${e.guid}">
                                   <td>${e.nombre}</td>
                                   <td>${e.direccion}</td>
                                   <td>${e.region}</td>--
                                   <td>${e.comuna}</td>
                                   <td>${e.cantidadTrabajadores}</td>
                                </tr>
                            `;
        });

        $(this.bodySelectorAnexoResumen).append(html);
    },

    renderAll: function () {
        this.renderAgregarAnexo();
        this.renderListarAnexoCarga();
        this.renderListarAnexoResumen();
    },
    cleanData: function () {
        this.data = [];
        this.renderAgregarAnexo();
        this.renderListarAnexoCarga();
        this.renderListarAnexoResumen();
    },
    export: function () {

        charlie_listado_anexos.data.pop()


    },
    import: function (input = []) {
        input.forEach(function (e) {
            if (charlie_listado_anexos.data.findIndex(function (o) { return o.databaseId == e.IdEmpresaAnexo }) == -1) {
                charlie_listado_anexos.data.push({
                    nombre: e.Anexo,
                    direccion: e.Direccion,
                    numeroDireccion: e.numeroDireccion,
                    local: e.local,
                    region: e.region,
                    comuna: e.NombreComuna,
                    cantidadTrabajadores: e.NumTrabajadores,
                    guid: uuid4(),
                    databaseId: e.IdEmpresaAnexo,
                    NombreEmpresa: e.NombreEmpresa,
                    rutEmpresa: e.RutEmpresa
                });
            }
        });
        this.renderAll();
    }
}


function uuid4() {
    function hex(s, b) {
        return s +
            (b >>> 4).toString(16) +  // high nibble
            (b & 0b1111).toString(16);   // low nibble
    }

    let r = crypto.getRandomValues(new Uint8Array(16));

    r[6] = r[6] >>> 4 | 0b01000000; // Set type 4: 0100
    r[8] = r[8] >>> 3 | 0b10000000; // Set variant: 100

    return r.slice(0, 4).reduce(hex, '') +
        r.slice(4, 6).reduce(hex, '-') +
        r.slice(6, 8).reduce(hex, '-') +
        r.slice(8, 10).reduce(hex, '-') +
        r.slice(10, 16).reduce(hex, '-');
}



$.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-region-empresa", function (menus) {
    $("#region-anexo").html("");
    $("#region-anexo").append($("<option>").attr("value", " ").html("Seleccione"));
    $.each(menus, function (i, e) {
        $("#region-anexo").append($("<option>").attr("value", e.Region_codigo).html(e.Region_nombre))
    });
});

$('#region-anexo').change(function (e) {
    e.preventDefault();
    if ($(this).val() != '') {
        $("#comuna-anexo").attr("disabled", false);
        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-comuna-empresa", { ComunaCodigo: $(this).val() }, function (datos) {

            $("#comuna-anexo").html("");
            $("#comuna-anexo").append($("<option>").attr("value", " ").html("Seleccione"));
            $.each(datos, function (i, e) {
                $("#comuna-anexo").append($("<option>").attr("value", e.Comuna_codigo).html(e.Comuna_nombre))
            });
        });
    } else {
        $("#comuna-anexo").html("");
        $("#comuna-anexo").attr("disabled", true);
    }
});




