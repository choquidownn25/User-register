function GetEntradas(regionId) {


    var ddlCiudad = $("#cmb_Entrada");
    ddlCiudad.empty().append('<option selected="selected" value="0" disabled = "disabled">Loading.....</option>');
    $.ajax({
        type: 'POST',
        url: "GetEntradas",
        data: '{}',
        contentType: "application/json; charset=utf-8",
        dataType: "json",
        success: function (data) {


            ddlCiudad.empty().append('<option selected="selected" value="0">Seleccione ...</option>');
            $.each(data, function () {
                ddlCiudad.append($("<option></option>").val(this['Value']).html(this['Text']));

            });
            // After updated data from database you need to trigger chosen:updated.
            //$("[data-rel='chosen']").trigger("chosen:updated");
        },
        failure: function (data) {
            alert(data.responseText);
        },
        error: function (data) {
            alert(data.responseText);
            existeUsuario = false;
        }
    });

}