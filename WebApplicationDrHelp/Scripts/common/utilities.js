
$(function () {
    $(document).ajaxStart(function () {
        //var $loader = $("<div/>").text("Cargando...").addClass("loader").hide().appendTo($("header"));
        //$loader.show();

    }).ajaxStop(function () {

        checkPendingRequest();

    }).ajaxSuccess(function (event, response, options) {

        var respuestaJson = validateResponse(response);

        if (respuestaJson != undefined) {
            VerificarAlInicioDespuesAjax(respuestaJson);
        }
        else {
            ShowCommonError(response, options);
        }
        checkPendingRequest();

    }).ajaxError(AjaxError);
});

function AjaxError(event, response, options) {
    var respuestaJson = validateResponse(response);
    if (respuestaJson != undefined) {

        VerificarAlInicioDespuesAjax(respuestaJson);

        validateErrorUrlRedirect(respuestaJson);
    }
    else {
        ShowCommonError(response, options);
    }
    checkPendingRequest();
}

function validateErrorUrlRedirect(respuestaJson) {
    if (respuestaJson.ErrorUrlRedirect != null && respuestaJson.ErrorUrlRedirect != "") {
        $(location).attr('href', respuestaJson.ErrorUrlRedirect);
    }
}

function checkPendingRequest() {
    if (jQuery.active == 0) {
        $("header").find(".loader").remove();
    }
}

function validateResponse(response) {
    if (response.responseText != undefined) {
        try {
            return $.parseJSON(response.responseText);
        }
        catch (err) { }
    }
    return undefined;
}

function VerificarAlInicioDespuesAjax(respuestaJson) {

    var msgError;
    var esError;
    if (respuestaJson.MessageTextNoRowsFound) {
        $.fn.dataTable.defaults.oLanguage.sZeroRecords = respuestaJson.MessageTextNoRowsFound;
        $.fn.dataTable.defaults.oLanguage.sEmptyTable = respuestaJson.MessageTextNoRowsFound;
    }

    esError = false;

    if (respuestaJson == undefined) {
        esError = true;
    }
    else {
        if (respuestaJson.Messages != undefined) {
            displayMessages(respuestaJson.Messages);
        }
    }

    if (esError) {
        respuestaJson.message = isNullOrUndefined(respuestaJson.message) ?
                "Se presento un error, intente mas tarde o comuniquese con el administrador"
                : respuestaJson.message;
        alert(respuestaJson);
    }
    return !esError;
}

function isNullOrUndefined(mensaje) {
    if (mensaje == null || mensaje == undefined) {
        return true;
    }

    return false;
}

function displayMessages(Messages, Display) {

    if (Messages && Messages.length > 0) {
        for (var i = 0; i < Messages.length; i++) {
            var message = Messages[i];
            //if (Display == true) {
            var parent = $("div.content-inner");
            parent.find(".alert").remove();
            //}
            if (Display === true || checkPendingMessage()) {
                showMessage(message);
            }
        }
    }
}

function showMessage(message) {
    var className = message.NameType;
    var btn = $('<button aria-hidden="true" type="button" class="close" data-dismiss="alert" href="#">\u00D7</button>');

    var o = $("<div />").addClass("alert-" + className + " alert alert-dismissable").text(message.Text).prepend(btn);
    var parent = $("div.modal-header");

    if (!parent.length) {
        parent = $("div.content-inner");
    }
    else if ($('div.modal-header').is(':hidden')) {
        parent = $("div.content-inner");
    }

    parent.prepend(o);
}

function checkPendingMessage() {
    var parent = $("div.content-inner");
    if (jQuery.active > 0) {
        parent.find(".alert").remove();
        return true;
    }
    return false;
}

/**
 * Muestra mensaje generico para solicitudes ajax fallidas.
 * @param {jqXHR} xhr - contains the XMLHttpRequest object.
 * @param {PlainObject} opt - contains the options used in the AJAX request.
 */
function ShowCommonError(xhr, opt) {
    if (xhr.status != "200") {
        var message = { NameType: "danger", Text: "Error en la solicitud " + opt.url + ": " + xhr.status + " " + xhr.statusText };
        showMessage(message);
    }
}


/**
 * Renderiza acciones permitidas para un registro del datatables en un elemento Html.
 * @param {String} nombreVisible - Nombre para asignar al boton que despliega las acciones.
 * @param {Array Json} opciones - Arreglo de opciones a renderizar en Html.
 *
 *      Ejemplo:       
 *      var opciones = {
 *                          "tipo": 'link',
 *                          "url": 'http://localhost/Sitio/Controlador/Accion', // Opcional, Url a ejecutar para las todas las acciones.
 *                          "args":   // Opcional, parametros para enviar en todas las acciones                   
 *                          [
 *                              {
 *                                  "nombre": 'RoleId',  // Nombre de parametro query string 
 *	                                "valor": '1',        // Valor de parametro query string   
 *                              }  
 *                          ], 
 *                          "acciones":
 *                          [
 *                              {    
 *                                  "attr": 'data-inbox-id="1"', // Opcional, attributos html adicionales
 *                                  "args": [], // Opcional, Utilizar solo si la acción requiere parámetros específicos 
 *                                  "url": 'http://localhost/Sitio/Controlador/Accion', // Opcional, Utilizar solo si la acción requiere una url especifica
 *                                  "texto": 'Editar'  // Texto para visualizar en el elemento Html
 *                                  "visible": true|false // Indicador de mostrar acción, por defecto visible.
 *                              },                                                   
 *                           ]
 *                      }; 
 *
 * @return {String} accionesHtml - Html para renderizar.
 */
function renderizarAcciones(nombreVisible, opciones) {
    var htmlAcciones = '<div class="btn-group"> <button class="btn btn-primary btn-sm dropdown-toggle" data-toggle="dropdown" type="button">';
    htmlAcciones += nombreVisible;
    htmlAcciones += '<i class="fa fa-angle-down"></i></button><ul class="dropdown-menu">';

    var opcionesTexto = JSON.stringify(opciones);

    try {
        $.parseJSON(opcionesTexto);
    }
    catch (err) {
        console.error("El parámetro acciones no tiene un formato Json valido. [" + err.message + "]")
        return htmlAcciones += '</ul></div>'
    }

    if (opciones != undefined) {
        var args = opciones.args;
        var url = opciones.url;
        $.each(opciones.acciones, function (i, item) {
            item.visible = parseBool(item.visible);
            if (item.visible == undefined) {
                item.visible = true;
            }
            if (opciones.args == null) {
                args = item.args
            }
            if (opciones.url == null) {
                url = item.url;
            }
            if (item.visible) {
                htmlAcciones += '<li>';
                htmlAcciones += renderizarAccion(opciones.tipo,
                                                item.attr,
                                                args,
                                                url,
                                                item.texto);
                htmlAcciones += '</li>';
            }
        });
    }

    htmlAcciones += '</ul></div>';

    return htmlAcciones;
}

function renderAction(opciones) {
    var htmlAcciones = '<div class="btn-group">';

    var opcionesTexto = JSON.stringify(opciones);

    try {
        $.parseJSON(opcionesTexto);
    }
    catch (err) {
        console.error("El parámetro acciones no tiene un formato Json valido. [" + err.message + "]")
        return htmlAcciones += '</div>'
    }

    if (opciones != undefined) {
        var args = opciones.args;
        var url = opciones.url;
        $.each(opciones.acciones, function (i, item) {
            item.visible = parseBool(item.visible);
            if (item.visible == undefined) {
                item.visible = true;
            }
            if (opciones.args == null) {
                args = item.args
            }
            if (opciones.url == null) {
                url = item.url;
            }
            if (item.visible) {
                item.attr += " class='btn btn-primary btn-sm'";
                htmlAcciones = renderizarAccion(opciones.tipo,
                                                item.attr,
                                                args,
                                                url,
                                                item.texto);
            }
        });
    }

    return htmlAcciones;
}


/**
 * Renderiza accion en un elemento Html.
 * @param {String} tipo - Tipo de elemento Html (checkbox | link).
 * @param {String} [attr] - Define atributos Html adicionales.
 * @param {Array Json} [args] - Parametros que se deben pasar por query string. 
 * @param {String} url - Url que procesa la acción.
 * @param {String} texto - Texto visible para elemento html.
 */
function renderizarAccion(tipo, attr, args, url, texto) {

    var htmlListaParametro = "";

    if (args != undefined) {
        var operador = "?";
        $.each(args, function (i, item) {
            if (i > 0) {
                operador = '&amp;'
            }
            htmlListaParametro += operador + item.nombre + '=' + item.valor;
            i++;
        });
    }

    var htmlAccion;
    var prop = "";
    if (attr != null) {
        prop = attr;
    }
    var htmlLink = '<a ' + prop + ' href="' + url + htmlListaParametro + '">' + texto + '</a>';

    switch (tipo) {
        case "checkbox":
            htmlAccion = '<div class="checkbox checkbox-success"><input type="checkbox"' + prop + '/><label></label></div>';
            break;

        case "link":
            htmlAccion = htmlLink;
            break;

        default:
            htmlAccion = htmlLink;
            break;
    }

    return htmlAccion;
}


/**
 * Muestra ventana modal para detalle de lista.
 * @param {Control Html} action - Control html por referencia.
 * @param {funcion js} fnOnSuccess - Funcion que se ejecuta al finalizar el success
 * @param {String} divDetailEntity - Nombre del div donde se renderiza el partial view de detalle.
 */
function showModal(action, fnOnSuccess, divDetailEntity) {
    var div;
    if (divDetailEntity == undefined) {
        div = $('#divDetailEntity');
    }
    else {
        div = $('#' + divDetailEntity);
    }

    div.empty();
    var params = $(action).data();

    $.ajax({
        url: $(action).attr("entity-url"),
        type: 'GET',
        data: params,
        cache: false,
        success: function (response) {
            div.html(response);
            //$($("#" + $(action).attr("entity-form"))).validator();
            if (fnOnSuccess) { fnOnSuccess(action); }
        },
        fail: function (response) {
            $(".modal-backdrop").remove();
        },
        error: function (response) {
            $(".modal-backdrop").remove();
        }
    });
    return false;
}

function parseBool(value) {
    if (typeof value === "boolean") { return value; }

    if (typeof value === "string") {
        value = value.replace(/^\s+|\s+$/g, "").toLowerCase();
        if (value === "true" || value === "false")
            return value === "true";
    }
    return; // returns undefined
}

function getQueryString(key) {
    var url = window.location.href;
    KeysValues = url.split(/[\?&]+/);
    for (i = 0; i < KeysValues.length; i++) {
        KeyValue = KeysValues[i].split("=");
        if (KeyValue[0] == key) {
            return KeyValue[1];
        }
    }
}

function removeQueryString(url) {
    url = (url.split('?')[0]);
    return url;
}

/**
 * Adiciona validacion de si dos campos son iguales.
 * @param {String} fieldId - Id del campo a comparar.
 * @param {String} fieldConfirmId - Id del campo de confirmación.
 */
function addFieldConfirmation(fieldId, fieldConfirmId) {
    var password = $('#' + fieldId).get(0);
    var confirm_password = $('#' + fieldConfirmId).get(0);

    function validateFieldsPrivate() {
        if (password.value != confirm_password.value) {
            confirm_password.setCustomValidity("Los campos no coinciden!");
        } else {
            confirm_password.setCustomValidity('');
        }
    }

    password.onchange = validateFieldsPrivate;
    confirm_password.onkeyup = validateFieldsPrivate;
}

/// <signature>  
///   <summary>verifica los elementos del dom que contengan el atributo data-dinamicTableName, para cada uno   
///    genera un select temporal con la informacion que se encuentra en el atributo data-tupleText  
///    y luego inicia llamados ajax con el proposito de obtener toda la lista completa y renderizar el DDL con toda la informacion completa  
///   </summary>  
///   <param name="textDefaultLoading" type="string">texto que se muestra en caso que no exista un texto de tupla a mostrar... generalmente es el texto "Cargando..."   
/// </signature>  
function DDLDynamicListsLoad(textDefaultLoading) {
    //renderiza los DDL temporalmente mientras se cargan sus datos con ajax  
    var $dllsFirtsLevel = $("[data-dinamicTableName]:not([data-parentTableName]):not(.processedDL)");//se seleccionan antes de modificarlos
    $("[data-dinamicTableName]:not(.processedDL)").each(function () {
        var $thisDiv = $(this);

        if ($thisDiv.data('select-bind') != undefined) {
            return; //Siguiente div
        }

        var text = $thisDiv.attr('data-tupleText');
        var valueId = $thisDiv.attr('data-tupleId');
        var componetName = $thisDiv.attr('data-componet-name');
        var componetId = $thisDiv.attr('data-componet-id');

        var attrMap = $.extend(true, {}, $thisDiv[0].attributes);//Deep copy

        $thisDiv.html('<select id="' + componetId + '" name="' + componetName + '" >' + (text == undefined || text == null || text == "" ? textDefaultLoading : text) + '</option></select>');

        var $thisDdl = $('#' + componetId);
        $.each(attrMap, function (i, e) {
            if (e != undefined && !e.name.match("^(data|id|name)")) {
                $thisDdl.attr(e.name, e.value);
                $thisDiv.removeAttr(e.name);
            }
        });

        if ($thisDdl.hasClass('select-ml-search')) {
            if ($.isFunction($.fn.select2)) {
                $thisDdl.select2({
                    placeholder: $thisDiv.attr('data-placeholder'),
                    allowClear: true
                });
            } else {
                console.error("Debe importar los bundles para el plugin select2.");
            }
        }
        $thisDiv.addClass('processedDL');
        $thisDiv.data('select-bind', 'true');//Se marca el div enlazado
    });

    DDLDynamicListsLoadPrivate($dllsFirtsLevel, null);
}


/// <signature>  
///   <summary>Carga los DDL de listas dinamicas con peticiones ajax, toma del elemento </summary>  
///   <param name="$selector" type="jqueryElement">los elementos/divs con los atributos escritos en DDLDinamicListRender</param>  
///   <param name="parentValue" type="int">en caso de tratarse de un DDL hijo, se envia este valor para realizar la carga del hijo con base a la informacion del padre</param>  
///   <param name="urlModifier" type="string">es posible que el DDL se desee utilizar en un area diferente a la raiz... por ello se puede modificar la direccion...   
///    por omision la direccion es "/ManageListRecord/DDLDynamicListAction" donde urlModifier es ".."</param>  
/// </signature>  
function DDLDynamicListsLoadPrivate($selector, parentValue, urlModifier) {
    $selector.each(function () {
        var $thisDivParent = $(this);
        var urlAction;
        if (!urlModifier) {
            urlAction = manageListUrl; //Toma variable global en layout
        }
        else { urlAction = urlModifier + "/ManageListRecord/DDLDynamicList"; }

        $.get(urlAction, {
            dinamicTableName: $thisDivParent.attr('data-dinamicTableName'),
            defaultValue: $thisDivParent.attr('data-tupleId'),
            parentValue: parentValue
        },
         function (data) {
             var selectedValues = $thisDivParent.attr('data-tupleId') ? $thisDivParent.attr('data-tupleId').split(',') : "";
             $thisDivParent.removeAttr("data-tupleid");//se elimina para evitar que en onchange de padre tome valores que ya no son validos  

             var $ddlrelacionado = $("select", $thisDivParent);
             $ddlrelacionado.empty();

             //Se agrega el texto por defecto
             if (!$ddlrelacionado.hasClass('select-ml-search')) {
                 var placeholderTmp = $thisDivParent.attr('data-placeholder');
                 if (placeholderTmp != "") {
                     var $opt = new Option(placeholderTmp, "");
                     $opt.setAttribute("selected", "true");
                     $ddlrelacionado.append($opt);
                 }
             }
             ///////////////////////////////////////////  
             if (data) {
                 $.each(data.items, function (index, item) {
                     var $opt = new Option(item.Text, item.Value);

                     if (item.Selected) {
                         $opt.setAttribute("selected", "true");
                     }//else no es el seleccionado  
                     $opt.setAttribute("parentValue", data.parentValue);

                     $ddlrelacionado.append($opt);
                 });
             }

             $ddlrelacionado.val(selectedValues).trigger("change");

             var $childDiv = $("[data-parentTableName=" + $thisDivParent.attr("data-dinamicTableName") + "]");

             if ($childDiv.length > 0) {
                 $("select", $thisDivParent).change(function () {
                     var $optionSelectedParent = $("option:selected", $(this));
                     if ($optionSelectedParent.length > 0 && $optionSelectedParent.val()) {
                         var parentSelectedValue = $optionSelectedParent.attr("parentValue") + "-" + $optionSelectedParent.val();
                         DDLDynamicListsLoadPrivate($childDiv, parentSelectedValue);
                     }
                     else {//no trajo informacion del padre asi que se limpia el hijo  
                         var $ddlchild = $("select", $childDiv);
                         $ddlchild.empty();
                     }
                 }).change();
             }
         });
    });
}


function InitDomDate(isReadOnly, format, defaultValue) {//TODO DAvid: promovido a arquitectura por Edson
    var $dp = $('.input-group.date').datepicker({
        todayBtn: "linked",
        keyboardNavigation: false,
        forceParse: false,
        autoclose: true,
        format: format
    });
    if (isReadOnly) { $dp.find('input.form-control').prop("readonly", true); }
    if (defaultValue != undefined) { $dp.datepicker("setDate", defaultValue); }
}

function ConverToViewDate(jsonDate) {//TODO DAvid: promovido a arquitectura por Edson
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(jsonDate);
    var strDate;
    if (results) {
        var dt = new Date(parseFloat(results[1]));
        strDate = dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear();
    }
    else { strDate = ""; }
    return "<div>" + strDate + "</div>";
}

function ConverToViewDateMonth(jsonDate) {//TODO DAvid: promovido a arquitectura por Edson
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(jsonDate);
    var strDate;
    if (results) {
        var dt = new Date(parseFloat(results[1]));
        strDate = (dt.getMonth() + 1) + "/" + dt.getFullYear();
    }
    else { strDate = ""; }
    return "<div>" + strDate + "</div>";
}

function ConverToViewDateHours(jsonDate) {//TODO DAvid: promovido a arquitectura por Edson
    var pattern = /Date\(([^)]+)\)/;
    var results = pattern.exec(jsonDate);
    var strDate;
    if (results) {
        var dt = new Date(parseFloat(results[1]));
        var min = dt.getMinutes();
        strDate = dt.getDate() + "/" + (dt.getMonth() + 1) + "/" + dt.getFullYear() + " " + dt.getHours() + ":" + (min < 10 ? "0" + min : min);
    }
    else { strDate = ""; }
    return "<div>" + strDate + "</div>";
}

function ConverToMoney(num) {//TODO DAvid: promovido a arquitectura por Edson
    if (num != undefined) {
        return '<div style = "text-align: right;"><span>$</span> ' + ConvertToNumberFix2Come(num) + "</div>"
    }

    return '<div style = "text-align: right;"></div>';
}

function ConverToNumber(num) {//TODO DAvid: promovido a arquitectura por Edson
    if (num != undefined) {
        return '<div style = "text-align: right;"> ' + ConvertToNumberFix2Come(num) + "</div>"
    }

    return '<div style = "text-align: right;"></div>';
}

function ConvertToNumberFix2Come(num) {
    var formatoPunto = num.toString().replace(",", ".");
    var dosDecimales = parseFloat(formatoPunto).toFixed(2)
    var formatoComa = dosDecimales.replace(".", ",");
    return formatoComa;
}

var ctecargandoText = "Cargando...";
function LoadDependentSelect(dataConfig) {
    //dataConfig.elementoPadre,             /*this o $elemento con id*/
    //dataConfig.nombreHijo,
    //dataConfig.urlConsultaHijos,
    //dataConfig.cache,
    //dataConfig.doCallBackOnEmpty,
    //dataConfig.elementNameFiltro2,         /*undefined*/, 
    //dataConfig.elementNameFiltro3,         /*undefined*/,
    //dataConfig.elementNameFiltro4,         /*undefined*/    

    var $ddlHijo = $("#" + dataConfig.nombreHijo);
    if ($ddlHijo && $ddlHijo.length > 0) {
        $ddlHijo.empty().append(new Option(ctecargandoText, ctecargandoText));
        $ddlHijo.val('').trigger('change');//para los select2
    }

    $elementoPadre = $(dataConfig.elementoPadre);
    var $selectsAdditionalToCleanSelector = $($elementoPadre.attr("selectsAdditionalToCleanSelector"));
    if ($selectsAdditionalToCleanSelector && $selectsAdditionalToCleanSelector.length > 0) {
        $selectsAdditionalToCleanSelector.empty().append(new Option(ctecargandoText, ctecargandoText));
        $selectsAdditionalToCleanSelector.val('').trigger('change');//para los select2
    }

    var doCallBack;
    if (dataConfig.doCallBackOnEmpty) { doCallBack = true; }
    else if ($elementoPadre.val()) { doCallBack = true; }
    else { doCallBack = false; }

    if (doCallBack) {
        if (!dataConfig.cache) { dataConfig.cache = false; }//Por defecto no realiza cache!

        $.ajax({
            url: dataConfig.urlConsultaHijos,
            type: 'GET',
            data: {
                filtro: $elementoPadre.val(),
                filtro2: $("#" + dataConfig.elementNameFiltro2).val(),
                filtro3: $("#" + dataConfig.elementNameFiltro3).val(),
                filtro4: $("#" + dataConfig.elementNameFiltro4).val(),
                defaultSelected: $ddlHijo.attr("defaultSelected")
            },
            datatype: 'json',
            cache: dataConfig.cache,
            success: function (data) {
                if ($ddlHijo && $ddlHijo.length > 0) { $ddlHijo.empty(); }
                $.each(data, function (index, item) {
                    var $opt = new Option(item.Text, item.Value);

                    if (item.Selected) {
                        $opt.setAttribute("selected", "true");
                    }//else no es el seleccionado

                    $ddlHijo.append($opt);
                });

                if ($ddlHijo && $ddlHijo.length > 0) {
                    $ddlHijo.trigger('change');/*para los select2*/
                    ResizeSelec2($ddlHijo);
                }
            }
        });
    }
    //else, no se realiza callback... esto es para casi all los casos, solo algunos casos en los cuales null significa traer all los registros tiene sentido activarse
}

///Depricated - obsolet use intead LoadDependentSelect
function LoadDependentDDL(elementoPadre/*this o $elemento con id*/, nombreHijo, urlConsultaHijos, cache
    , elementNameFiltro2/*undefined*/, elementNameFiltro3/*undefined*/, elementNameFiltro4/*undefined*/) {
    LoadDependentSelect({
        elementoPadre: elementoPadre, nombreHijo: nombreHijo, urlConsultaHijos: urlConsultaHijos,
        cache: cache, elementNameFiltro2: elementNameFiltro2, elementNameFiltro3: elementNameFiltro3, elementNameFiltro4: elementNameFiltro4
    });
}

function ResizeSelec2($elemento) {
    var $spanVisibleSubPlan = $elemento.next().find("[role='combobox']");
    if ($spanVisibleSubPlan) {
        if ($spanVisibleSubPlan.height() > 150) { $spanVisibleSubPlan.addClass("select2-maxHeigth"); }
        else { $spanVisibleSubPlan.removeClass("select2-maxHeigth"); }
    }
}

/* Add confirm alert to all close's buttons */
$(document).on('click', "[data-dismiss='modal']", function () {
    var url = $(this).data("url");
    swal({
        title: "¿Desea guardar la información?",
        text: "Al salir se perdera la información del formulario!",
        type: "warning",
        showCancelButton: true,
        cancelButtonText: "Salir",
        confirmButtonColor: "#DD6B55",
        confirmButtonText: "Regresar",
        closeOnConfirm: true,
        closeOnCancel: true
    },
        function (isConfirm) {
            if (isConfirm) {
                if (url == undefined) {
                    var btnConfirm = $(":button.confirm");
                    btnConfirm.attr('data-toggle', 'modal');
                    btnConfirm.attr('data-target', '#modalEntity');
                }
                //No hace nada para ventanas NO modales
            } else {
                if (url == undefined) {
                    $(".modal-backdrop").remove();
                } else {
                    $(location).attr('href', url);
                }
            }
        }
    );
});
