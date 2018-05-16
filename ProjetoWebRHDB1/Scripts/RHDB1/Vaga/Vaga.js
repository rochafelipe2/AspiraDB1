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

    $("#create-vaga").button().on("click", function () {
        dialogAdd.dialog("open");
    });

    $(".editar-vaga").button().on("click", function () {
        ActionCarregarVagaParaEdicao(this.id);
        dialogEdit.dialog("open");
    });

    function ActionCarregarVagaParaEdicao(id_vaga) {
        base_url = window.location.host;
        url = "/Vagas/ActionCarregarVagaParaEdicao";
        full_url = base_url + url;
        $.ajaxSetup({ cache: false });
        $.ajax({
            url: url,
            data: { "id": id_vaga },
            success: function (data) {

                $("#VagaEdite_ID").val(data["ID"]);
                $("#VagaEdite_Nome").val(data["Nome"]);
                $("#VagaEdite_Descricao").val(data["Descricao"]);
                $("#VagaEdite_Responsavel").val(data["Responsavel"]);
            },
            error: function () {
                $(".GifAjaxLoaderEntrega").hide();
                alert("Problema ao buscar vaga.");
            }
        });
    }
});