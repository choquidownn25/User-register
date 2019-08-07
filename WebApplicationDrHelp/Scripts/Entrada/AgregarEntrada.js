function AgregarEntrada() {

    var Titulo = $("#titulo").val();
    var Autor = $("#autor").val();
    
        $.ajax({
            type: 'GET',
            url: '/Entrada/EntradaDetails',
            contentType: "application/json; charset=utf-8",
            dataType: "json",
            data: {
                Titulo: Titulo,
                Autor: Autor
            
        },
        success: function (data) {

            existeUsuario = true;
            alert(data.success);
            
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