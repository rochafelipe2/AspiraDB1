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

    $("#create-candidato").button().on("click", function () {
        dialogAdd.dialog("open");
    });

    $(".editar-candidato").button().on("click", function () {
        ActionCarregarCandidatoParaEdicao(this.id);
        dialogEdit.dialog("open");
    });

    function ActionCarregarCandidatoParaEdicao(id_candidato) {
        base_url = window.location.host;
        url = "/Candidato/ActionCarregarCandidatoParaEdicao";
        full_url = base_url + url;
        $.ajaxSetup({ cache: false });
        $.ajax({
            url: url,
            data: { "id": id_candidato },
            success: function (data) {

                $("#CandidatoEdite_ID").val(data["ID"]);
                $("#CandidatoEdite_Nome").val(data["Nome"]);
                $("#CandidatoEdite_Formacao").val(data["Formacao"]);
                $("#CandidatoEdite_Idade").val(data["Idade"]);
                $("#CandidatoEdite_TempoExperiencia").val(data["TempoExperiencia"]);
            },
            error: function () {
                $(".GifAjaxLoaderEntrega").hide();
                alert("Problema ao buscar candidato.");
            }
        });
    }
});