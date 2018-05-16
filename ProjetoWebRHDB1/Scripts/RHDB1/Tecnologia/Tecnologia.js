$(function () {


    dialogAdd = $("#dialog-form-add").dialog({
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

    dialogEdit = $("#dialog-form-edit").dialog({
        autoOpen: false,
        height: 550,
        width: 675,
        modal: true,
        buttons: {
            Cancelar: function () {
                dialogEdit.dialog("close");
            }
        },
        close: function () {

            //allFields.removeClass("ui-state-error");
        }
    });

    $("#create-tecno").button().on("click", function () {
        dialogAdd.dialog("open");
    });

    $(".editar-tecno").button().on("click", function () {
        ActionConsultarTecnologiaParaEdicao(this.id);
        dialogEdit.dialog("open");
    });

    function ActionConsultarTecnologiaParaEdicao(id_tec) {
        base_url = window.location.host;
        url = "/Tecnologias/ActionConsultarTecnologiaParaEdicao";
        full_url = base_url + url;
        $.ajaxSetup({ cache: false });
        $.ajax({
            url: url,
            data: { "id": id_tec },
            success: function (data) {

                $("#TecnologiaEdite_ID").val(data["ID"]);
                $("#TecnologiaEdite_Nome").val(data["Nome"]);
            },
            error: function () {
                $(".GifAjaxLoaderEntrega").hide();
                alert("Problema ao buscar vaga.");
            }
        });
    }
});