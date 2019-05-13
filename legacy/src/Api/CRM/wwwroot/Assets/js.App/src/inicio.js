$(function () {


    if (getCookie("Cargo") == 'Administrador Sistema' || getCookie("Cargo") == 'Usuario Avanzado' || getCookie("Cargo") == 'Zonal') {
        $('.no-admin').hide();
        $('.yes-admin').show();
    } else {
        $('.no-admin').show();
        $('.yes-admin').hide();
    }




    var today = new Date()
    var tperiodo = today.getFullYear().toString() + (today.getMonth() + 1).toString().paddingLeft("00");

    $.SecGetJSON(BASE_URL + "/motor/api/Informes/lista-traking-totalEjecutivo2", {
        Periodo: tperiodo
    }, function (menus) {


        if (getCookie("Cargo") == "Ejecutivo Normalización" || getCookie("Cargo") == "Ejecutivo Gestión de Nómina") {
            $("#demo-lft-tab-1").hide();
            //$("#totales").show();
            return false;

        }

        if (menus.SumaAsignadosWidEjec != 0) {
            $("#bdy_Brutas").css('display', 'block')
        }

        var opts = {
            lines: 10, // The number of lines to draw
            angle: 0, // The length of each line
            lineWidth: 0.41, // The line thickness
            radiusScale: 1, // Relative radius
            pointer: {
                length: 0.75, // The radius of the inner circle
                strokeWidth: 0.035, // The rotation offset
                color: 'rgba(0, 0, 0, 0.38)' // Fill color
            },
            limitMax: 'true', // If true, the pointer will not go past the end of the gauge
            colorStart: '#42a5f5', // Colors
            colorStop: '#42a5f5', // just experiment with them
            strokeColor: '#8bc34a', // to see which ones work best for you
            generateGradient: true,
            highDpiSupport: true,
        };


        var target = document.getElementById('demo-gauge'); // your canvas element
        var gauge = new Gauge(target).setOptions(opts); // create sexy gauge!
        gauge.maxValue = 100; // set max gauge value
        gauge.setMinValue = 20;
        gauge.animationSpeed = 54; // set animation speed (32 is default value)
        gauge.set((menus.SumaPorcentajeGestionadoWidEjec).toMoney(0)); // set actual value
        gauge.setTextField(document.getElementById("demo-gauge-text"));

    });

    $.SecGetJSON(BASE_URL + "/motor/api/Informes/obtener-gestion-comercial", function (menus) {

        $("#asigComercial").html(menus.Asignados);
        $("#gestComercial").html(menus.Gestionados);
        $("#contacComercial").html(menus.Contactados);
        $("#InterComercial").html(menus.Interesados);
        $("#CursComercial").html(menus.Cursados);

    });
    $.SecGetJSON(BASE_URL + "/motor/api/Informes/obtener-gestion-comercial-vencidas", function (menus) {

        $("#gestVencido").html(menus.Vencidos);
        $("#gestVenceHoy").html(menus.VenceHoy);
        $("#gestVenceProx").html(menus.VenceProx);

    });


    $.SecGetJSON(BASE_URL + "/motor/api/Informes/obtener-gestion-normalizacion", function (menus) {

        if (menus.AsignadosNorm != 0) {
            $("#bdy_BrutasNormalizacion").css('display', 'block')
        }
        $("#asigNormalizacion").html(menus.AsignadosNorm);
        $("#gestNormalizacion").html(menus.GestionadosNorm);
        $("#contacNormalizacion").html(menus.ContactadosNorm);
        $("#InterNormalizacion").html(menus.InteresadosNorm);
        $("#CursNormalizacion").html(menus.CursadosNorm);

        var opts = {
            lines: 10, // The number of lines to draw
            angle: 0, // The length of each line
            lineWidth: 0.41, // The line thickness
            radiusScale: 1, // Relative radius
            pointer: {
                length: 0.75, // The radius of the inner circle
                strokeWidth: 0.035, // The rotation offset
                color: 'rgba(0, 0, 0, 0.38)' // Fill color
            },
            limitMax: 'true', // If true, the pointer will not go past the end of the gauge
            colorStart: '#42a5f5', // Colors
            colorStop: '#42a5f5', // just experiment with them
            strokeColor: '#8bc34a', // to see which ones work best for you
            generateGradient: true,
            highDpiSupport: true,
        };
        var target = document.getElementById('demo-gauge_norm'); // your canvas element
        var gauge = new Gauge(target).setOptions(opts); // create sexy gauge!
        gauge.maxValue = 100; // set max gauge value
        gauge.setMinValue = 20;
        gauge.animationSpeed = 54; // set animation speed (32 is default value)
        gauge.set((menus.SumaPorcentajeCurNorm).toMoney(0)); // set actual value
        gauge.setTextField(document.getElementById("demo-gauge-textNorm"));

    });
    $.SecGetJSON(BASE_URL + "/motor/api/Informes/obtener-gestion-normalizacion-vencidas", function (menus) {

        $("#gestVencidoNorm").html(menus.VencidosNorm);
        $("#gestVenceHoyNorm").html(menus.VenceHoyNorm);
        $("#gestVenceProxNorm").html(menus.VenceProxNorm);

    });
});