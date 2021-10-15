$(document).ready(function () {
    $('#showPacients').click(function (e) {
        e.preventDefault();
        $("#seachTextPacient").val($("#FIO").val());
        $.ajax({
            url: UrlGetPacientsData,
            data: { seachText: $("#seachTextPacient").val() },
            success: function (data) {
                $("#modalPacientsResult").html(data);
                $("#modalPacients").modal('show');
            }
        });
    });
    $('#searchPacients').click(function (e) {
        e.preventDefault();
        $.ajax({
            url: UrlGetPacientsData,
            data: { seachText: $("#seachTextPacient").val() },
            success: function (data) {
                $("#modalPacientsResult").html(data);
            }
        });
    });
    $('#searchPacientsClear').click(function (e) {
        e.preventDefault();
        $("#seachTextPacient").val("");
        $.ajax({
            url: UrlGetPacientsData,
            data: { seachText: $("#seachTextPacient").val() },
            success: function (data) {
                $("#modalPacientsResult").html(data);
            }
        });
    });
    $('#searchPacientsNew').click(function (e) {
        e.preventDefault();
        $("#modalNewPacient").load(UrlPacientsPartial);
        setTimeout(function () {
            if ($("#modalNewPacient #DateBirth").val() === "01.01.0001") {
                $("#modalNewPacient #DateBirth").val('');
            }
            $("#modalNewPacient").modal('show');
        }, 500);

    });
    $('#btnSetPacient').click(function (e) {
        e.preventDefault();
        var id = $("#modalPacients .selectRow:first > td:first").html();
        if (id) {
            $.ajax({
                data: { id: id },
                url: UrlGetPacientDataJson,
                success: function (data) {
                    loadPacient(data);
                }
            });
        }
    });
});

function EditPacient(id) {   
    $.ajax({
        url: UrlPacientsPartial,
        data: { PacientID: id },
        success: function (data) {
            $("#modalNewPacient").html(data);
            setTimeout(function () {
                if ($("#modalNewPacient #DateBirth").val() === "01.01.0001") {
                    $("#modalNewPacient #DateBirth").val('');
                }
                $("#modalNewPacient").modal('show');
            }, 500);
        }
    });
}

function SavePass(data) {    
    $("#modalNewPacient").html("");
    if (data.Success) {       
        $("#modalNewPacient").modal('hide');
        $.ajax({
            url: UrlGetPacientsData,
            data: { seachText: $("#seachTextPacient").val() },
            success: function (data) {
                $("#modalPacientsResult").html(data);
            }
        });
    }
    else {
        $("#modalNewPacient").html(data);
    }
}
