$(function () {

    dialogAdd = $("#dialog-form-iniciar").dialog({
        autoOpen: false,
        height: 550,
        width: 675,
        modal: true,
        buttons: {
            Cancelar: function () {
                dialogAdd.dialog("close");
            }
        },
        close: function () {

            //allFields.removeClass("ui-state-error");
        }
    });

    $("#iniciar-entrevista").button().on("click", function () {
        dialogAdd.dialog("open");
    });

    $("#sortable1, #sortable2").sortable({
        connectWith: ".connectedSortable",
        
    }).disableSelection();

    $(".button-confirm").on({
        click: function( event, ui ) {
            $("#sortable2").find('li').each(function () {
                var current = $(this);
                $("#IDsTecnologiasCandidado").val($("#IDsTecnologiasCandidado").val() + "," + current.context.id);
                

            })
        }
    });
     

    });

