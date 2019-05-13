var rutE = httpGet('rutEmp');
var valida = httpGet('validador');
var ID = httpGet('Id');
var idEmpresa = httpGet('rutEmpA');
var RutEmpAnexo = httpGet('rutEmAnexo');
var IJ = httpGet('IJ');
var result = [];
var rutAsig = []
var idEmp = '';
var idEnvta = 0;
var idCabManGest = 0;
var compromiso = 0;
var alerta = 0;
var alertaGestion = 0;

var codOficina = getCookie("Oficina");
var cargo = getCookie("Cargo");

if (cargo != 'Agente' && cargo != 'Jefe Servicio al Cliente' && cargo != 'Jefe Empresas y Trabajadores') {
    $('#btNewAnexo').css('display', 'none');
}

if (idEmpresa != 0) {
    $("#tab_anexos").css('display', 'none')
}

if (idEmpresa == 0) {
    $("#tab_comercial").css('display', 'none')
    $("#tab_Planificacion").css('display', 'none')
    $("#tab_anexos").tab('show');

}


Dropzone.autoDiscover = false;
var myDropzone = new Dropzone("div#dzMain", {
    url: "#",
    maxFiles: 1,
    uploadMultiple: false,
    maxFilesize: 15,
    acceptedFiles: '.csv'
});
myDropzone.on("addedfile", function (file) {
    document.getElementById("overlay").style.display = "block";
});

myDropzone.on("complete", function (file) {

    document.getElementById("overlay").style.display = "none";
    myDropzone.removeFile(file);
});

//if (IJ == 0) {
//    $("#tab_anexos").css('display', 'none')
//}



$(function () {

    $(".anexo").val(idEmpresa);
    $(".oficina").val(codOficina);

    $('#dateTimepk').timepicker();
    $('#dateTimeDiaria').timepicker();
    $('#dateTimeSemanal').timepicker();
    $('#dateTimeMensual').timepicker();
    $('#demo-dp-component .input-group.date').datepicker({
        format: "dd-mm-yyyy",
        autoclose: true,
        language: "es"
    }).datepicker("setDate", new Date());
});



var rutEmpresa = 0;
if (rutE != "" && rutE != 'undefined' && rutE != null) {
    rutEmpresa = rutE;
} else {
    rutEmpresa = RutEmpAnexo
}

$.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-perfil-empresa", {
    RutEmpresa: rutEmpresa
}, function (result) {
    var NomHolding = ""
    if (result.Holding == 0) {
        NomHolding = 'Sin Holding'
    } else {
        NomHolding = result.NombreHolding
    }
    $("#tituloEmp").css('font-size', '20px').css('color', '#b3b3b3').css('margin-left', '20px')
    $("#tituloEmp").html(result.NombreEmpresa)
    $("#RutEmp").val(result.RutEmpresa)
    $("#NombreEmpresaPer").html(result.NombreEmpresa)
    $("#nTrabajadores").val(result.NTrabajador)
    $("#SegmentoEmp").val(result.Segmento)
    $("#AntiguedadA").val(result.FechaAntiguedad)
    $("#HoldingEmp").val(NomHolding)
    $("#slEmperesa_multiselect").val(result.NombreEmpresa)
    $("#txRutEmp").val(result.RutEmpresa)


});


$('#demo-lg-modal-AsigEmp').on('show.bs.modal', function (events) {
    var Anexosss = $(events.relatedTarget);
    idEmp = Anexosss.data('idemp')
    console.log(idEmp);
    $("#demo-cs-multiselectEje").val(' -').trigger("chosen:updated");
    $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-ejecutivo-asignado", {
        IdEmpresa: idEmp
    }, function (respuesta) {
        rutAsig.length = 0;
        $.each(respuesta, function (ix, ex) {
            rutAsig[ix] = ex.RutEjecutivoAsignado
            $('#demo-cs-multiselectEje').val(rutAsig).trigger('chosen:updated');
        });
    });
});


$("#demo-cs-multiselectEjeEmpresa").on("change", function (event, params) {
    if (typeof params.deselected != 'undefined') {
        // console.log('no-selectionado', params.deselected)
        var WebCarteraEmpresaAsig = {
            Tipo: 'Empresas',
            Id: ID,
            EjecAsignado: params.deselected
        }
        $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/elimina-asignacion-empresa-anexo", WebCarteraEmpresaAsig, function (respuesta) {
            if (respuesta.Estado === "OK") {
                $.niftyNoty({
                    type: 'success',
                    container: 'floating',
                    html: '<strong>OK</strong> ' + respuesta.Mensaje,
                    focus: false,
                    timer: 2000
                });
            } else {
                $.niftyNoty({
                    type: 'danger',
                    container: 'floating',
                    html: '<strong>Error</strong> ' + respuesta.Mensaje,
                    timer: 5000
                });
            }
        });
    }
})

$("#demo-cs-multiselectEje").on("change", function (event, params) {
    if (typeof params.deselected != 'undefined') {
        //console.log('no-selectionado', params.deselected)
        var WebCarteraEmpresaAsig = {
            Tipo: 'FAnexo',
            Id: idEmp,
            EjecAsignado: params.deselected
        }

        $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/elimina-asignacion-empresa-anexo", WebCarteraEmpresaAsig, function (respuesta) {
            if (respuesta.Estado === "OK") {
                $.niftyNoty({
                    type: 'success',
                    container: 'floating',
                    html: '<strong>OK</strong> ' + respuesta.Mensaje,
                    focus: false,
                    timer: 2000
                });
            } else {
                $.niftyNoty({
                    type: 'danger',
                    container: 'floating',
                    html: '<strong>Error</strong> ' + respuesta.Mensaje,
                    timer: 5000
                });
            }
        });
        cargador.CargaDatosAnexos();
    }
})




$("#btAsignaEmpresa").on("click", function () {
    var ejeAsig = [];
    $('#demo-cs-multiselectEjeEmpresa').chosen({
        width: '80%'
    });
    $('#demo-cs-multiselectEjeEmpresa :selected').each(function () {
        ejeAsig.push($(this).val())
    });
    $.each(ejeAsig, function (i, e) {
        var WebCarteraEmpresaAsig = {
            Tipo: 'Empresas',
            Id: ID,
            EjecAsignado: ejeAsig[i]
        }
        $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/guardar-asignacion-empresa-anexo", WebCarteraEmpresaAsig, function (respuesta) {
            if (respuesta.Estado === "OK") {
                $.niftyNoty({
                    type: 'success',
                    container: 'floating',
                    html: '<strong>OK</strong> ' + respuesta.Mensaje,
                    focus: false,
                    timer: 2000
                });

            } else {
                $.niftyNoty({
                    type: 'danger',
                    container: 'floating',
                    html: '<strong>Error</strong> ' + respuesta.Mensaje,
                    timer: 5000
                });
            }
            $('#demo-lg-modal-AsigEmp').modal('hide');
        });
    });
    cargador.CargaDatosAnexos();
    ejeAsig.length = 0;
});

$("#btAsigna").on("click", function () {
    var ejeAsig = [];
    $('#demo-cs-multiselectEje :selected').each(function () {
        ejeAsig.push($(this).val())
    });
    $.each(ejeAsig, function (i, e) {
        var WebCarteraEmpresaAsig = {
            Tipo: 'FAnexo',
            Id: idEmp,
            EjecAsignado: ejeAsig[i]
        }
        $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/guardar-asignacion-empresa-anexo", WebCarteraEmpresaAsig, function (respuesta) {
            if (respuesta.Estado === "OK") {
                $.niftyNoty({
                    type: 'success',
                    container: 'floating',
                    html: '<strong>OK</strong> ' + respuesta.Mensaje,
                    focus: false,
                    timer: 2000
                });

            } else {
                $.niftyNoty({
                    type: 'danger',
                    container: 'floating',
                    html: '<strong>Error</strong> ' + respuesta.Mensaje,
                    timer: 5000
                });
            }
            $('#demo-lg-modal-AsigEmp').modal('hide');
        });
    });
    cargador.CargaDatosAnexos();
    ejeAsig.length = 0;
});

$('#demo-dp-component .input-group.date').datepicker({
    format: "dd/mm/yyyy",
    autoclose: true,
    language: "es"
}).datepicker("setDate", new Date());
$('#FechaResolucion').val('01-01-1900')

$('#form_registro_anexo').bootstrapValidator({
    excluded: [':disabled', ':not(:visible)'],
    feedbackIcons: [],
    fields: {
        anexo: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar un anexo'
                }
            }
        },
        nTrajadores: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar N° trabajadores'
                }
            }
        },
        slComuna_multiselect: {
            validators: {
                notEmpty: {
                    message: 'Debe seleccionar una comuna'
                }
            }
        },
        direccionAnexo: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar una dirección'
                }
            }
        }
    }
}).on('success.form.bv', function (e) {
    e.preventDefault();
    var originalText = $("#btGuardaEmpresa").text();
    $("#btGuardaEmpresa").text("Cargando...");
    $("#btGuardaEmpresa").prop("disabled", true);
    var $form = $(e.target);
    var idcomuna = 0;
    var objeto_envio_anexo = {
        RutEmpresa: $('#txRutEmp').val(),
        NombreEmpresa: $("#slEmperesa_multiselect").val(),
        Anexo: $('#anexo').val(),
        NumTrabajadores: $('#nTrajadores').val(),
        IdComuna: $('#slComuna_multiselect option:selected').val(),
        NombreComuna: $('#slComuna_multiselect option:selected').text(),
        Direccion: $('#direccionAnexo').val()
    }
    $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/ingresa-nuevo-anexo", objeto_envio_anexo, function (datos) {
        $("#form_registro_anexo").bootstrapValidator('resetForm', true);
        $('#demo-lg-modal-newAnexo').modal('hide');
        $.niftyNoty({
            type: 'success',
            icon: 'pli-like-2 icon-2x',
            message: 'Nuevo Anexo Creado Correctamente.',
            container: 'floating',
            timer: 5000
        });
        cargador.CargaDatosAnexos();
        $("#btGuardaEmpresa").text(originalText);
        $("#btGuardaEmpresa").prop("disabled", false);
    });
});

$('#form_registro_anexoUp').bootstrapValidator({
    excluded: [':disabled', ':not(:visible)'],
    feedbackIcons: [],
    fields: {
        anexoUp: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar un anexo'
                }
            }
        },
        nTrajadoresUp: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar N° trabajadores'
                }
            }
        },
        slComuna_multiselectUp: {
            validators: {
                notEmpty: {
                    message: 'Debe seleccionar una comuna'
                }
            }
        },
        direccionAnexoUp: {
            validators: {
                notEmpty: {
                    message: 'Debe ingresar una dirección'
                }
            }
        }
    }
}).on('success.form.bv', function (e) {
    e.preventDefault();
    var $form = $(e.target);
    var idcomuna = 0;
    var objeto_envio_anexoUp = {
        IdEmpresaAnexo: $('#ISeMPup').val(),
        Anexo: $('#anexoUp').val(),
        NumTrabajadores: $('#nTrajadoresUp').val(),
        IdComuna: $('#slComuna_multiselectUp option:selected').val(),
        NombreComuna: $('#slComuna_multiselectUp option:selected').text(),
        Direccion: $('#direccionAnexoUp').val()
    }
    $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/actualiza-nuevo-anexo", objeto_envio_anexoUp, function (datos) {
        $("#form_registro_anexoUp").bootstrapValidator('resetForm', true);
        $('#demo-lg-modal-updateAnexo').modal('hide');
        $.niftyNoty({
            type: 'success',
            icon: 'pli-like-2 icon-2x',
            message: 'Anexo Actualizado Correctamente.',
            container: 'floating',
            timer: 5000
        });
        cargador.CargaDatosAnexos();
    });
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

    var rutEmpresa = 0;
    if (rutE != "" && rutE != 'undefined' && rutE != null) {
        rutEmpresa = rutE;
    } else {
        rutEmpresa = RutEmpAnexo
    }

    var objeto_envio_entrevista = {
        RutEmpresa: rutEmpresa,
        FechaEntrevista: $('#FechaGestges').val(),
        NombreContacto: $("#nombContacto").val(),
        Estamento: $('#slEstamento').val(),
        Cargo: $('#txtCargo').val(),
        Comentarios: $('#txtComentariosCab').val(),
        TelefonoContacto: $('#tefContacto').val(),
        CorreoContacto: $('#correoContacto').val(),
        CodOficina: $('#ent_oficina').val(),
        IdAnexo: $('#ent_anexo').val(),

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
        Tema: $('select[id="slTema"] option:selected').text(),
        SubTema: $('select[id="slSubTema"] option:selected').text(),
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

    var rutEmpresa = 0;
    if (rutE != "" && rutE != 'undefined' && rutE != null) {
        rutEmpresa = rutE;
    } else {
        rutEmpresa = RutEmpAnexo
    }

    var objeto_envio_cab_gestion_man = {
        RutEmpresa: rutEmpresa,
        FechaIngreso: $('#FechaCabeceraGest').val(),
        Tipo: $("#slTipoGestion").val(),
        Comentarios: $('#comentarioCabeceraGestion').val(),
        Oficina: $('#man_oficina').val(),
        Anexo: $('#man_anexo').val()
    }
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
    var rutEmpresa = 0;
    if (rutE != "" && rutE != 'undefined' && rutE != null) {
        rutEmpresa = rutE;
    } else {
        rutEmpresa = RutEmpAnexo
    }

    var objeto_envio_gestion_mantencion = {
        IdCabGesMantencion: idCabManGest,
        RutEmpresa: rutEmpresa,
        Tema: $('select[id="slTemaGestion"] option:selected').text(),
        SubTema: $('select[id="slSubTemavisita"] option:selected').text(),
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

$(document).on('click', '.elimination', function () {
    // alert($(this).data("idanexo"))
    var rut_empresa = $(this).data("erut")
    var id_anexo = $(this).data("eanexo")

    $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/elimina-anexo-asignada", { RutEmpresa: rut_empresa, IdAnexo: id_anexo }, function (datos) {
        $.niftyNoty({
            type: 'success',
            icon: 'pli-like-2 icon-2x',
            message: 'SE ELIMINO ANEXO CORRECTAMENTE !.',
            container: 'floating',
            timer: 5000
        });
        cargador.CargaDatosAnexos();
    });

});



var cargador = {
    CargaDatosAsignadosEmp: function () {
        $("#tbOportunidad").html("");
        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-asignados-empresa", {
            RutEmpresa: rutE
        }, function (menus) {
            $.each(menus, function (i, e) {
                $("#tbOportunidad")
                    .append(
                        $("<tr>")
                            .append($("<td>").append(''))
                            .append($("<td>").append(e.Id_Asign)).hide()
                            .append($("<td>").append(e.Afiliado_Rut + '-' + e.Afiliado_Dv))
                            .append($("<td>").append(e.Nombre + ' ' + e.Apellido))
                            .append($("<td>").append(e.PreAprobadoFinal.toMoney() + '<span class="badge badge-success" style="float: right;">' + e.Prioridad + '</span>'))
                            .append($("<td>").append(e.TipoCampania))
                            .append($("<td>").append(''))
                    )
            });
            $("#tblAsigEmp").bootstrapTable({
                striped: true,
                pagination: true,
                pageSize: 10,
                pageList: [],
                search: true,
                showColumns: false,
                showRefresh: true,
            });
        });
    },

    CargaDatosAsignadosAnexo: function () {
        $("#tbOportunidad").html("");
        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-preaprobado-anexo", {
            idAnexo: idEmpresa,
            RutEmpresa: RutEmpAnexo
        }, function (menus) {
            $.each(menus, function (i, e) {
                $("#tbOportunidad")
                    .append(
                        $("<tr>")
                            .append($("<td>").append(''))
                            .append($("<td>").append(e.Id_Asign)).hide()
                            .append($("<td>").append(e.Afiliado_Rut + '-' + e.Afiliado_Dv))
                            .append($("<td>").append(e.Nombre + ' ' + e.Apellido))
                            .append($("<td>").append(e.PreAprobadoFinal.toMoney() + '<span class="badge badge-success" style="float: right;">' + e.Prioridad + '</span>'))
                            .append($("<td>").append(e.TipoCampania))
                            .append($("<td>").append(''))
                    )
            })
            $("#tblAsigEmp").bootstrapTable({
                striped: true,
                pagination: true,
                pageSize: 10,
                pageList: [],
                search: true,
                showColumns: false,
                showRefresh: true,
            });
        });
    },

    CargaDatosAnexos: function () {
        $("#tbdyAnexo").html("");

        var kuky = getCookie('X-Support-Token');
        var vera = getCookie('Rut');

        if (kuky === "" || vera != '12825688-1') {
            console.log("deberia esconderse")
            $(".sergio-esconder").hide();
        }


        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-cartera-anexo", {
            RutEmpresa: rutE
        }, function (menus) {
            var contador = 0;
            var matriz = ''
            $.each(menus, function (i, e) {
                if (e.Anexo == 'MATRIZ') {
                    matriz = e.Anexo + '  (' + $('#tituloEmp').html() + ')'
                }
                else {
                    matriz = e.Anexo
                }

                var elim = ""
                if (kuky === "" || vera != '12825688-1') {

                    elim = "";
                }
                else {
                    elim = '<a class="btn btn-danger btn-icon btn-circle elimination sergio-esconder" data-erut="' + e.RutEmpresa + '"  data-eanexo="' + e.IdEmpresaAnexo + '"  title="Eliminar" href="#"><i class="ion-trash-a"></i></a>';
                }

                $("#tbdyAnexo")
                    .append(
                        $("<tr>")
                            .append($("<td>").append(e.RutEmpresa))
                            .append($("<td>").append('<a href="' + BASE_URL + '/motor/Emp/FichaEmpresa?rutEmpA=' + e.IdEmpresaAnexo + '&IJ=0' + '&rutEmAnexo=' + e.RutEmpresa + '" class="btn-link text-semibold" style="font-weight: 400;">' + matriz + '</a>'))
                            .append($("<td>").append('<div class="media-left pos-rel"><img class="img-circle img-sm" src="../Assets/img/profile-photos/2.png" alt="Profile Picture"><i class="badge badge-success badge-stat badge-icon pull-left">' + e.NumTrabajadores + '</i></div>'))
                            .append($("<td>").append('<button class="btn btn-primary btn-icon btn-circle" data-target="#demo-lg-modal-updateAnexo" data-toggle="modal" data-idAnexo="' + e.IdEmpresaAnexo + '"><i class="demo-psi-pen-5 icon-xs add-tooltip" data-toggle="tooltip" data-original-title="Actualiza datos de Anexo"></i></button>'))
                            .append($("<td>").append('<i href="#" data-toggle="modal" data-target="#demo-lg-modal-AsigEmp" data-idEmp="' + e.IdEmpresaAnexo + '"><i class="btn btn-sm demo-psi-add icon-lg" style="font-size: 31px;"></i><span class="badge badge-header badge-danger" style="position: unset;">' + e.TotalAsignados + '</span></i>'))
                            .append($("<td>").append(elim))
                    )
            });
        });

    },
    CargaDatosEntrevista: function () {
        $("#tbdyentrevista").html("");

        var rutEmpresa = 0;
        if (rutE != "" && rutE != 'undefined' && rutE != null) {
            rutEmpresa = rutE;
        } else {
            rutEmpresa = RutEmpAnexo
        }

        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-entrevista", {
            RutEmpresa: rutEmpresa,
            Anexo: idEmpresa
        }, function (menus) {
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
        var rutEmpresa = 0;
        if (rutE != "" && rutE != 'undefined' && rutE != null) {
            rutEmpresa = rutE;
        } else {
            rutEmpresa = RutEmpAnexo
        }


        console.log({ rutEmpresa })
        $("#tbdyGestMan").html("");
        $.SecGetJSON(BASE_URL + `/motor/api/perfil-empresas/lista-mantencion-gestion?RutEmpresa=${rutEmpresa}&idAnexo=${idEmpresa}`, function (menus) {
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
    CargaAgenda: function (rutEmp, rutEje, idAnexo) {
        var rutEmp = 0;
        var idEmp = 0;
        if (rutE != "" && rutE != 'undefined' && rutE != null) {
            rutEmp = rutE;
        } else {
            rutEmp = RutEmpAnexo;
            idEmp = idEmpresa;
        }


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
                $('#slComienzaDia_update').val(event.HoraInicio)
                $('#slDiasMensual_update').val(event.Dias)
                $('#txtHoraFin_update').val(event.HoraFin)
                $('#nomEmpCita').html(' Cita de Empresa:  ' + event.NombreEmpresa)

                $("#btCita_update").data("idagenda", event.IdAgenda).data("idregistro", event.IdRegistro)
                $("#btCita_elimina").data("idregistro", event.IdRegistro).data("idagenda", event.IdAgenda)

                if (event.Frecuencia == 'Diaria') {
                    $("#divMensual_update").css('display', 'none')
                    $("#divSemanal_update").css('display', 'none')
                    $("#divDiario_update").css('display', 'block')
                } else if (event.Frecuencia == 'Semanal') {
                    $("#divDiario_update").css('display', 'none')
                    $("#divMensual_update").css('display', 'none')
                    $("#divSemanal_update").css('display', 'block')
                } else if (event.Frecuencia == 'Quincenal') {
                    $("#divDiario_update").css('display', 'none')
                    $("#divMensual_update").css('display', 'none')
                    $("#divSemanal_update").css('display', 'block')
                } else if (event.Frecuencia == 'Mensual') {
                    $("#divDiario_update").css('display', 'none')
                    $("#divSemanal_update").css('display', 'none')
                    $("#divMensual_update").css('display', 'block')
                }
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
                    $('#demo-lg-modal-agenda').modal('show');
                } else {

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
            eventSources: [{
                url: '/motor/api/perfil-empresas/lista-cita-agenda-cartera/' + rutEmp + '/' + rutEje + '/' + idEmp,
                type: 'GET',
                headers: {
                    'Token': getCookie('Token')
                },
                success: function (i, e) {
                    if (i.length != 0) {
                        $('#ncitas').html(i[0].Ncitas)
                    } else {
                        $('#ncitas').html('0')
                    }
                }
            }]
        });
        //$('#demo-calendar').fullCalendar("refetchEvents");
        $('#demo-calendar').fullCalendar('render');
    }
}






if (rutE != "" && rutE != 'undefined' && rutE != null) {


    cargador.CargaDatosAsignadosEmp();
    cargador.CargaDatosAnexos();
    cargador.CargaDatosEntrevista();
    cargador.CargaDatosGestionMan();
    cargador.CargaAgenda(rutEmpresa, '0', 0);
} else {
    /*$.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-perfil-empresaAnexo", {
        IdEmpresaA: idEmpresa
    }, function (result) {
        var NomHolding = ""
        if (result.Holding == 0) {
            NomHolding = 'Sin Holding'
        } else {
            NomHolding = result.NombreHolding
        }
        $("#tituloEmp").css('font-size', '20px').css('color', '#b3b3b3').css('margin-left', '20px')
        $("#tituloEmp").html(result.Anexo)
        $("#RutEmp").val(result.RutEmpresa)
        $("#NombreEmpresaPer").html(result.NombreEmpresa)
        $("#nTrabajadores").val(result.NumTrabajadores)
        $("#SegmentoEmp").val(result.Segmento)
        $("#AntiguedadA").val(result.FechaAntiguedad)
        $("#HoldingEmp").val(NomHolding)
        $("#slEmperesa_multiselect").val(result.NombreEmpresa)
        $("#txRutEmp").val(result.RutEmpresa)
    });*/
    cargador.CargaDatosAsignadosAnexo();
    cargador.CargaDatosEntrevista();
    cargador.CargaDatosGestionMan();
    cargador.CargaAgenda(rutEmpresa, '0', idEmpresa);
}

$(function () {
    $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-tipologia-gestion", {
        tipoCampagna: 1,
        padre: 0
    }, function (datos) {
        $("#slTemaGestion").html("");
        $("#slTemaGestion").append($("<option>").attr("value", "").html("Seleccione"));
        $("#slTema").html("");
        $("#slTema").append($("<option>").attr("value", "").html("Seleccione"));
        $.each(datos, function (i, e) {
            $("#slTemaGestion").append($("<option>").attr("value", e.IdTema).html(e.GlosaGestion))
            $("#slTema").append($("<option>").attr("value", e.IdTema).html(e.GlosaGestion))
        });
    });

    $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", {
        tipoCampagna: 1,
        padre: 0
    }, function (datos) {
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
        $('#slComuna_multiselect').chosen({
            width: '100%'
        });
        $('#slComuna_multiselectUp').chosen({
            width: '100%'
        });
    });

    if (rutE != "" && rutE != 'undefined' && rutE != null) {
        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-afiliado-oficina", {
            RutEmpresa: rutE
        }, function (menus) {
            $.each(menus, function (i, e) {
                $("#slAfiliadoSelect").append($("<option>").attr("value", e.RutAfiliado).html(e.NombreAfiliado))
            });
            $('#demo-chosen-select').chosen();
            $('#slAfiliadoSelect').chosen({
                width: '100%'
            });
        });
    } else {
        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-afiliado-oficina", {
            RutEmpresa: RutEmpAnexo
        }, function (menus) {
            $.each(menus, function (i, e) {
                $("#slAfiliadoSelect").append($("<option>").attr("value", e.RutAfiliado).html(e.NombreAfiliado))
            });
            $('#demo-chosen-select').chosen();
            $('#slAfiliadoSelect').chosen({
                width: '100%'
            });
        });
    }

    $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/dotacion-oficina", function (menus) {
        $.each(menus, function (i, e) {
            $("#demo-cs-multiselectEje").append($("<option>").attr("value", e.Rut).html(e.Nombre + " - ( " + e.Cargo + " )"))
            $("#demo-cs-multiselectEjeEmpresa").append($("<option>").attr("value", e.Rut).html(e.Nombre + " - ( " + e.Cargo + " )"))
        });
        $('#demo-chosen-select').chosen();
        $('#demo-cs-multiselectEje').chosen({
            width: '70%'
        });
        $('#demo-cs-multiselectEjeEmpresa').chosen({
            width: '80%'
        });
    });

    $('#demo-lg-modal-updateAnexo').on('show.bs.modal', function (event) {
        var Anexo = $(event.relatedTarget);
        var idAnexo = Anexo.data('idanexo')
        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-datos-anexo", {
            IdEmpresa: idAnexo
        }, function (respuesta) {


            console.log({
                respuesta
            });
            if (respuesta.EsMatriz == 1) {
                $('#anexoUp').prop('disabled', true);
            }

            $("#txRutEmpUp").val(respuesta.RutEmpresa)
            $("#slEmperesa_multiselectUp").val(respuesta.NombreEmpresa)
            $('#anexoUp').val(respuesta.Anexo)
            $('#nTrajadoresUp').val(respuesta.NumTrabajadores)
            $('#direccionAnexoUp').val(respuesta.Direccion)
            $('#slComuna_multiselectUp').val(respuesta.IdComuna).trigger('chosen:updated');
            $('#ISeMPup').val(idAnexo)
        });
        myDropzone.options.url = "/motor/api/perfil-empresas/carga-afiliados-dropzone/" + idAnexo;
    });


    $('#demo-lg-modal-updateAnexo').on('hidden.bs.modal', function (event) {
        location.reload();
    });

    $('#slTemaGestion').change(function (e) {
        e.preventDefault();
        if ($(this).val() != '') {
            $("#slSubTemavisita").attr("disabled", false);
            $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-tipologia-Subgestion", {
                IdTema: $(this).val()
            }, function (datos) {
                $("#slSubTemavisita").html("");
                $("#slSubTemavisita").append($("<option>").attr("value", " ").html("Seleccione"));
                $.each(datos, function (i, e) {
                    $("#slSubTemavisita").append($("<option>").attr("value", e.IdSubTema).html(e.GlosaSubTema))
                });
            });
        } else {
            $("#slSubTemavisita").html("");
            $("#slSubTemavisita").attr("disabled", true);
        }
    });

    $('#slTema').change(function (e) {
        e.preventDefault();
        if ($(this).val() != '') {
            $("#slSubTema").attr("disabled", false);
            $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-tipologia-Subgestion", {
                IdTema: $(this).val()
            }, function (datos) {
                $("#slSubTema").html("");
                $("#slSubTema").append($("<option>").attr("value", " ").html("Seleccione"));
                $.each(datos, function (i, e) {
                    $("#slSubTema").append($("<option>").attr("value", e.IdSubTema).html(e.GlosaSubTema))
                });
            });
        } else {
            $("#slSubTema").html("");
            $("#slSubTema").attr("disabled", true);
        }
    });

    $('#selecEstado').change(function (e) {
        e.preventDefault();
        if ($(this).val() != '') {
            $("#selecSubEstado").attr("disabled", false);
            $.SecGetJSON(BASE_URL + "/motor/api/Gestion/lista-estados-gestion", {
                tipoCampagna: 1,
                padre: $(this).val()
            }, function (datos) {
                $("#selecSubEstado").html("");
                $("#selecSubEstado").append($("<option>").attr("value", " ").html("Seleccione"));
                $("#selecSubEstado").append($("<option>").attr("value", "-1").html("Sin Gestión"));
                $.each(datos, function (i, e) {
                    $("#selecSubEstado").append($("<option>").attr("value", e.eges_id).html(e.eges_nombre))
                });
            });
        } else {
            $("#selecSubEstado").html("");
            $("#selecSubEstado").attr("disabled", true);
        }
    });

    $('#slPeriodicidad').change(function (e) {
        e.preventDefault();
        if ($(this).val() == 0) {
            $("#divUnaVez").css('display', 'block')
            $("#divPeriodico").css('display', 'none')
        } else {

            $("#divPeriodico").css('display', 'block')
            $("#divUnaVez").css('display', 'none')
        }
    });

    $('#slFrecuencia').change(function (e) {
        e.preventDefault();
        if ($(this).val() == 'Diaria') {

            $("#divSemanal").css('display', 'none')
            $("#divMensual").css('display', 'none')
            $("#tituloFecuencia").html('Frecuencia Diaria')
            $("#divDiario").css('display', 'block')
        } else if ($(this).val() == 'Semanal') {

            $("#divDiario").css('display', 'none')
            $("#divMensual").css('display', 'none')
            $("#tituloFecuencia").html('Frecuencia Semanal')
            $("#divSemanal").css('display', 'block')
        } else if ($(this).val() == 'Quincenal') {

            $("#divDiario").css('display', 'none')
            $("#divMensual").css('display', 'none')
            $("#tituloFecuencia").html('Frecuencia Quicenal')
            $("#divSemanal").css('display', 'block')
        } else if ($(this).val() == 'Mensual') {

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
        } else if ($(this).val() == 'Semanal') {

            $("#divDiario_update").css('display', 'none')
            $("#divMensual_update").css('display', 'none')
            $("#tituloFecuencia_update").html('Frecuencia Semanal')
            $("#divSemanal_update").css('display', 'block')
        } else if ($(this).val() == 'Quincenal') {

            $("#divDiario_update").css('display', 'none')
            $("#divMensual_update").css('display', 'none')
            $("#tituloFecuencia_update").html('Frecuencia Quicenal')
            $("#divSemanal_update").css('display', 'block')
        } else if ($(this).val() == 'Mensual') {

            $("#divSemanal_update").css('display', 'none')
            $("#divDiario_update").css('display', 'none')
            $("#tituloFecuencia_update").html('Frecuencia Mensual')
            $("#divMensual_update").css('display', 'block')
        }
    });

    var result = [];
    $('#btGestion').click(function () {
        result.length = 0;
        var i = 0;
        $("input[type=checkbox]:checked").each(function () {
            if ($(this).parent().parent().find('td').eq(1).text() != "") {
                result[i] = $(this).parent().parent().find('td').eq(1).text();
                ++i;
            }
        });
        $("#cantAfiScheck").html(result['length'])
        console.log(result);
    });

    $('#tblAsigEmp').on('check.bs.table uncheck.bs.table check-all.bs.table uncheck-all.bs.table', function (e, row) {
        result.length = 0;
        var i = 0;
        $("input[type=checkbox]:checked").each(function () {
            if ($(this).parent().parent().find('td').eq(1).text() != "") {
                result[i] = $(this).parent().parent().find('td').eq(1).text();
                ++i;
            }
        });
        $("#cantAfiScheck").html(result['length'])
        console.log(result);
    });

    $('#radioEmpresa').on("click", function () {
        $('#tipoAsignacionAnexo').css('display', 'none')
        $('#tipoAsignacionEmpresa').css('display', 'block')
        $.SecGetJSON(BASE_URL + "/motor/api/perfil-empresas/lista-ejecutivo-asignado", {
            IdEmpresa: ID
        }, function (result) {
            rutAsig.length = 0;
            $.each(result, function (i, e) {
                rutAsig[i] = e.RutEjecutivoAsignado
                $('#demo-cs-multiselectEjeEmpresa').val(rutAsig).trigger('chosen:updated');
            });
        });
    });

    $('#radioAnexo').on("click", function () {
        $('#tipoAsignacionEmpresa').css('display', 'none')
        $('#tipoAsignacionAnexo').css('display', 'block')
    });

    $('#ckCargaAfi').on('change', function () {
        if ($(this).is(':checked')) {
            $('.demo-dropzone').css('display', 'block')
        } else {
            $('.demo-dropzone').css('display', 'none')
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



    //$('#form-registro-gestion').bootstrapValidator({
    //    excluded: [':disabled', ':not(:visible)'],
    //    feedbackIcons: [],
    //    fields: {
    //        selecEstado: {
    //            validators: {
    //                notEmpty: {
    //                    message: 'Debe seleccionar un Estado'
    //                }
    //            }
    //        },
    //        selecSubEstado: {
    //            validators: {
    //                notEmpty: {
    //                    message: 'Debe seleccionar una sub-estado'
    //                }
    //            }
    //        },
    //        FehaGest: {
    //            validators: {
    //                notEmpty: {
    //                    message: 'La fecha compromete no puede ser vacia'
    //                },
    //                date: {
    //                    format: 'dd/mm/yyyy"',
    //                    message: 'La fecha de compromete no es valida'
    //                }
    //            }
    //        },
    //        comentarioGest: {
    //            validators: {
    //                notEmpty: {
    //                    message: 'Debe ingresar un comentario'
    //                }
    //            }
    //        }
    //    }
    //}).on('success.form.bv', function (e) {
    //    // Prevén que se mande el formulario
    //    //e.preventDefault();
    //    //var $form = $(e.target);


    //    //$.SecGetJSON(BASE_URL + "/motor/api/Contactos/ingresa-nuevo-contacto", objeto_envio_gestion, function (datos) {
    //    //    $("#form-registro-contacto").bootstrapValidator('resetForm', true);
    //    //    $('#demo-lg-modal-new').modal('hide');
    //    //    Cargador.CargaDatosContactos(rutAf)



    //    //           public int ges_estado { get; set;
    //    //    }
    //    //public int ges_subestado { get; set; }
    //    //public string ges_prox_gestion { get; set; }
    //    //public string ges_comentarios { get; set; }
    //    //public int ges_id_asignacion { get; set; }


    //    //  $.each(datos, function (i, e)

    //    $.each(result, function (i, e) {
    //        var objeto_envio_gestion = {
    //            RutAfiliado: result[e],
    //            Estado: $('select[name="selecEstado"] option:selected').text(),
    //            Subestado: $('select[name="selecSubEstado"] option:selected').text(),
    //            Comentario: $('#comentarioGest').val()
    //        }
    //        $.SecPostJSON(BASE_URL + "/motor/api/Gestion/guardar-gestion", objeto_envio_gestion, function (respuesta) {

    //            if (respuesta.Estado === 'OK') {

    //                $.niftyNoty({
    //                    type: 'success',
    //                    container: '#mensahes-must',
    //                    html: '<strong>OK</strong> Gestion guardada exitosamente.',
    //                    focus: false,
    //                    timer: 3000
    //                });
    //            } else {
    //                $.niftyNoty({
    //                    type: 'danger',
    //                    container: '#mensahes-must',
    //                    html: '<strong>Error</strong> ' + respuesta.Mensaje,
    //                    focus: false,
    //                    timer: 3000
    //                });
    //            }
    //        });
    //    });

    //    $('#btGestion').click()
    //    $.niftyNoty({
    //        type: 'success',
    //        icon: 'pli-like-2 icon-2x',
    //        message: result['length'] + '  Gestiones Guardas correctamente.',
    //        container: 'floating',
    //        timer: 5000
    //    });
    //    //});

    //});

    $("input:radio[name=groupCkeckAlertaGestion]").click(function () {
        switch (this.value) {
            case "SI":
                alertaGestion = 1;
                break;
            case "NO":
                alertaGestion = 0;
                break;
        }
    });

    $("input:radio[name=groupCkeckAlerta]").click(function () {
        switch (this.value) {
            case "SI":
                alerta = 1;
                break;
            case "NO":
                alerta = 0;
                break;
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
});

$("input:radio[name=groupCkeckAlerta_visitas]").click(function () {
    switch (this.value) {
        case "Mantenedor":
            //alert(this.value);
            $('.colap2').collapse('hide')
            $('.colap1').collapse('show')

            break;
        case "Visita":
            $('.colap1').collapse('hide')
            $('.colap2').collapse('show')
            break;
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
        } else {
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
        } else {
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
        } else {
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
        } else {
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
    var rutEmpresa = 0;
    var IDAnexo = 0;
    if (rutE != "" && rutE != 'undefined' && rutE != null) {
        rutEmpresa = rutE;
    } else {
        rutEmpresa = RutEmpAnexo;
        IDAnexo = idEmpresa;
    }
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
    } else if ($('#slFrecuencia').val() == 'Mensual') {
        results = $('#slDiasMensual').val()
    } else if ($('#slFrecuencia').val() == 'Diaria') {
        results = "Null"
    }

    var objeto_envio_agenda_empresa = {
        RutEmpresa: rutEmpresa,
        NombreEmpresa: $('#NombreEmpresaPer').html(),
        Glosa: $('#txtObsCita').val(),
        FechaInico: fechaPop + ' ' + $('#slComienzaDia').val(),
        FechaFin: fechaPop + ' ' + $('#txtHoraFin').val(),
        HoraInicio: $('#slComienzaDia').val(),
        HoraFin: $('#txtHoraFin').val(),
        Frecuencia: $('#slFrecuencia').val(),
        Dias: results,
        TipoVisita: $('#slTipoVisita').val(),
        IdAnexo: IDAnexo,
        DiasSucede: $('#slSucedeDia').val(),
    }

    $.SecPostJSON(BASE_URL + "/motor/api/perfil-empresas/ingresa-cita-agenda-empresa", objeto_envio_agenda_empresa, function (datos) {
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
        }
    }
}).on('success.form.bv', function (e) {
    e.preventDefault();
    var rutEmpresa = 0;
    if (rutE != "" && rutE != 'undefined' && rutE != null) {
        rutEmpresa = rutE;
    } else {
        rutEmpresa = RutEmpAnexo
    }

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
    } else if ($('#slFrecuencia_update').val() == 'Mensual') {
        results = $('#slDiasMensual_update').val()
    } else if ($('#slFrecuencia_update').val() == 'Diaria') {
        results = "Null"
    }

    var objeto_envio_agenda_empresa_update = {
        IdAgenda: $("#btCita_update").data("idagenda"),
        RutEmpresa: rutEmpresa,
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

    var rutEmpresa = 0;
    if (rutE != "" && rutE != 'undefined' && rutE != null) {
        rutEmpresa = rutE;
    } else {
        rutEmpresa = RutEmpAnexo
    }

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
                        RutEmpresa: rutEmpresa,
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
                        RutEmpresa: rutEmpresa,
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