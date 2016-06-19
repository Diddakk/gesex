$(function () {
    //console.log("ready!");
});

$("#loginButton").click(function () {
    $(".infoDiv").toggleClass("hidden");
    $(".loginDiv").toggleClass("hidden");
    $(this).text(function (i, text) {
        return text === "Entrar" ? "Inicio" : "Entrar";
    })
});

$("#verInscribirseButton").click(function () {
    $(".mostrarAsigDiv").toggleClass("hidden");    
    $(".inscribAsigDiv").toggleClass("hidden");
    $(this).text(function (i, text) {
        return text === "Tus asignaturas" ? "Inscribirse en una asignatura" : "Tus asignaturas";
    })
});

$(".nav-tabs a").click(function () {
    $(this).tab('show');
});
$('.nav-tabs a').on('shown.bs.tab', function (event) {
    var x = $(event.target).text();         // active tab
    var y = $(event.relatedTarget).text();  // previous tab
    $(".act span").text(x);
    $(".prev span").text(y);
});

$("#MainContent_passTextBox").keypress(function (e) {
    if (e.which == 13) {
        $("#MainContent_entrarButton").click;
    }
});

$("#verCrearAsignaturasButton").click(function () {
    $(".crearPage").toggleClass("hidden");
    $(".mostrarAsigDiv").toggleClass("hidden");
    $(this).text(function (i, text) {
        return text === "Nueva asignatura" ? "Tus asignaturas" : "Nueva asignatura";
    })
});
$("#verCrearExamenButton").click(function () {
    $(".crearExamenDiv").toggleClass("hidden");
    $(".mostrarExamenesDiv").toggleClass("hidden");
    $(this).text(function (i, text) {
        return text === "Nuevo Examen" ? "Exámenes" : "Nuevo Examen";
    })
});
$("#verValidarExamenesButton").click(function () {
    $(".notasPDiv").toggleClass("hidden");
    $(".pyrDiv").toggleClass("hidden");
    $(this).text(function (i, text) {
        return text === "Notas" ? "Examen" : "Notas";
    })
});


/*Validar preguntas y respuestas del alumno*/

$("#MainContent_EnviarPregYRespButton").click(function (e) {
    
    var chivato = 0;
    $('#pyrVal').find('input, textarea').each(function () {

        
        if (($.trim($(this).val()) == '')) {
            $(this).addClass("red")
            chivato = chivato + 1;
        } else {
            $(this).removeClass("red");
        }
        

    });

    if (chivato > 0) {
        e.preventDefault();
        alert("Hay " + chivato + " preguntas o respuestas vacias");
            
    }
    //console.log(chivato);

});











