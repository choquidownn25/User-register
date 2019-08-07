(function ($) {
    var exportButton;
    jQuery.dataTableSettings = {};

    jQuery.fn.dataTableExt.oApi.fnProcessingIndicator = function (oSettings, onoff) {
        if (typeof (onoff) == 'undefined') {
            onoff = true;
        }
        this.oApi._fnProcessingDisplay(oSettings, onoff);
    };

    jQuery.fn.getMessageKey = function (defaultValue) {
        var value;
        if (!value) { value = defaultValue; }
        return value;
    };
    var commonFilters1 = 'input[type="input"],input[type="text"],input[type="number"],input[type="email"]';
    jQuery.fn.dataTableWithFilter = function (settings) {
        settings.bExportData = false;

        if (settings.filterOptions === undefined)
        { settings.filterOptions = { searchButton: "Search", searchContainer: "SearchContainer" }; }

        // alias the original jQuery object passed in since there is a possibility of multiple dataTables and search containers on a single page.
        // If we don't do this then we run the risk of having the wrong jQuery object before forcing a dataTable.fnDraw() call
        var $dataTable = this,
        searchCriteria = [],
        filterOptions = settings.filterOptions,
        // retrieves all inputs that we want to filter by in the searchContainer
        $searchContainerInputs = $('#' + filterOptions.searchContainer).find(commonFilters1 +
            ',select,textarea,input[type="radio"],input[type="checkbox"]');//aplicar cambios de este selector en sdlkex08d
        // remove the filterOptions object from the object literal (json) that will be passed to dataTables
        delete settings.filterOptions;

        var sZeroRecords = $.fn.getMessageKey("No se encontraron resultados");

        $.extend(settings,
            { // sentencias de idioma
                oLanguage: {
                    "sProcessing": "Procesando...",
                    "sLengthMenu": "_MENU_ registros por página",
                    "sZeroRecords": sZeroRecords,
                    "sEmptyTable": sZeroRecords,
                    "sInfo": "Mostrando _START_-_END_ de _TOTAL_ registros",
                    "sInfoEmpty": "Mostrando 0 al 0 de 0 registros",
                    "sInfoFiltered": "(filtrado de un total de _MAX_ registros)",
                    "sInfoPostFix": "",
                    "sSearch": "Buscar:",
                    "sUrl": "",
                    "sInfoThousands": ",",
                    "sLoadingRecords": "Cargando...",
                    "oPaginate": {
                        "sFirst": "Primero",
                        "sLast": "Último",
                        "sNext": "Siguiente",
                        "sPrevious": "Anterior"
                    }
                },
                // valores por defecto para listas
                bProcessing: false,
                bfilter: false,
                bServerSide: true,
                sServerMethod: "POST",
                dom: '<"toolbar">lfrtip',
                //sPaginationType: "full_numbers",
                fnServerData: function (url, data, callback) {
                    if (settings.bEnableExport && settings.bExportData == true) {
                        var urlExport = url;
                        if (settings.sActionToExport != undefined && settings.sActionToExport != '') {
                            urlExport = settings.sActionToExport;
                        }

                        settings.bExportData = false;
                        exportButton.ladda('start');//Bloquea boton

                        $.fileDownload(urlExport, {
                            httpMethod: "POST",
                            data: data,
                            failCallback: function (html, url) {
                                var message = { NameType: "danger", Text: "Se presentó un error en la solicitud." };
                                showMessage(message);
                                exportButton.ladda('stop');
                            },
                            successCallback: function (url) {
                                exportButton.ladda('stop');
                            }
                        });

                        return false;
                    }
                    else {
                        $.ajax({
                            "url": url,
                            "data": data,
                            "success": function (json) {
                                if (json && json.aaData) {
                                    callback(json);
                                }
                            },
                            "contentType": "application/x-www-form-urlencoded; charset=utf-8",
                            "dataType": "json",
                            "type": "POST",
                            "cache": false,
                            "error": function (response) {
                                $dataTable.fnProcessingIndicator(false);
                            },
                        });

                        return false;
                    }
                },
                "footerCallback": function (row, data, start, end, display) {
                    this.api().columns('.sum').every(function () {
                        fnShowSum(this);
                    });
                }
            });

        $searchContainerInputs.keypress(function (e) {
            if (e.keyCode === 13) {
                // if an enter key was pressed on one of our inputs then force the searchButton click event to happen
                $("#" + filterOptions.searchButton).click();
            }
        });

        function refreshSearchCriteria() {
            searchCriteria = [];
            var searchContainer = $("#" + filterOptions.searchContainer);
            searchContainer.find(commonFilters1 +
                ',input[type="radio"]:checked,input[type="checkbox"]:checked,textarea[value!=""],select[value!=""]')//aplicar cambios de este selector en sdlkex08d
                .each(function () {
                    // all textboxes, radio buttons, checkboxes, textareas, and selects that actually have a value associated with them
                    var element = $(this), value = element.val();
                    if (typeof value === "string") {
                        searchCriteria.push({ "name": element.attr("name"), "value": value });
                    }
                    else if (Object.prototype.toString.apply(value) === '[object Array]') {
                        // multi select since it has an array of selected values
                        var i;
                        for (i = 0; i < value.length; i++) {
                            searchCriteria.push({ "name": element.attr("name"), "value": value[i] });
                        }
                    }
                });
        }

        $("#" + filterOptions.searchButton).click(function () {
            var $form = $(this).closest("form");
            if ($form != undefined && $form[0] != undefined) {
                $form.submit(function (ev) { ev.preventDefault(); });
                if (!$form[0].checkValidity()) { return; }
            }
            // clear exists alerts
            $("div.content-inner").find(".alert").remove();
            // force dataTables to make a server-side request
            refreshSearchCriteria();
            $dataTable.fnDraw();
        });

        $("#" + filterOptions.clearSearchButton).click(function () {
            searchCriteria = [];
            $searchContainerInputs.each(function () {
                var $input = $(this),
                tagName = this.tagName.toLowerCase();
                if (tagName === "input") {
                    var type = $input.attr("type").toLowerCase();
                    if (type === "checkbox"
                    || type === "radio") {
                        $input.removeAttr("checked");
                    }
                    else /*if (type === "text")*/ {
                        $input.val("");
                    }
                }
                else if (tagName === "select") {
                    if ($input.attr("multiple") !== undefined) {
                        $input.val([]);
                    }
                    else {
                        $input.val("");
                    }
                }
                else if (tagName === "textarea") {
                    $input.val("");
                }
            });
            $dataTable.fnDraw();
        });

        var externalFnServerParams = settings.fnServerParams;

        settings.fnServerParams = function (aoData) {
            var i;
            refreshSearchCriteria();
            for (i = 0; i < searchCriteria.length; i++) {
                // pushing each name/value pair that was found from the searchButton click event in to the aoData array
                // which will be sent to the server in the request
                aoData.push(searchCriteria[i]);
            }

            fnLoadExportData(aoData, settings);

            // call function defined by the user on the view
            if (externalFnServerParams) { externalFnServerParams(aoData); }
        };

        if (settings.bFilter) { settings.bServerSide = false; }

        var dt = $dataTable.dataTable(settings);
        fnInitializeExportButton($dataTable, settings);
        return dt;
    };

    fnLoadExportData = function (aoData, settings) {
        aoData.push({ "name": "bEnableExport", "value": settings.bEnableExport });
        aoData.push({ "name": "bExportData", "value": settings.bExportData });
    };

    fnInitializeExportButton = function (dataTable, settings) {
        if (settings.bEnableExport == true) {
            exportButton = $('<button class="ladda-button ladda-button-demo btn btn-primary dim" type="button" data-style="zoom-in"><i class="fa fa-file-excel-o"></i></button>').ladda();
            var divExportButton = $('<div class="btn-group" style="float:right;"></div>')
            divExportButton.append(exportButton);
            $("div.dataTables_length").last().after(divExportButton);//si hay mas de una tabla se deberia aplicar a this, pero como no tengo esa informacion se agrega a el ultimo agregado            
            exportButton.click(function (e) {
                e.preventDefault;
                settings.bExportData = true;
                dataTable.fnDraw();
            });
        }
        return exportButton;
    };

    fnShowSum = function (columnDt) {
        var column = columnDt;

        var intVal = function (i) {
            return typeof i === 'string' ?
            i.replace(/[\$,]/g, '') * 1 :
                typeof i === 'number' ?
                i : 0;
        };

        if (column.data().length) {
            var sum = column
                .data()
                .reduce(function (a, b) {
                    return intVal(a) + intVal(b);
                });
            $(column.footer()).html(ConverToNumber(sum));
        } else {
            $(column.footer()).html('');
        }
    }
}(jQuery));