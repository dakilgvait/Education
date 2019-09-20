function TableModule(lookups) {
    function Table(dom) {
        var domElement = dom;
        var table = null;
        var urls = {
            view: domElement.attr("action-view"),
            create: domElement.attr("action-create"),
            edit: domElement.attr("action-edit"),
            delete: domElement.attr("action-delete"),
        };
        var actions = {
            onAddRow: function (datatable, rowdata, success, error) {
                $.ajax({
                    "url": urls.create,
                    "type": "POST",
                    "data": rowdata,
                    "success": success,
                    "error": error
                });
            },
            onDeleteRow: function (datatable, rowdata, success, error) {
                $.ajax({
                    "url": urls.delete,
                    "type": "POST",
                    "data": rowdata,
                    "success": success,
                    "error": error
                });
            },
            onEditRow: function (datatable, rowdata, success, error) {
                $.ajax({
                    "url": urls.edit,
                    "type": "POST",
                    "data": rowdata,
                    "success": success,
                    "error": error
                });
            }
        };
        var fnInitialize = function (opt) {
            $.extend(opt, {
                "processing": true,
                "serverSide": true,
                "pageLength": 10,
                "ordering": false,
                "language": {
                    "search": "",
                    "searchPlaceholder": "Search..."
                },
                "ajax": $.extend(opt.ajax, {
                    "url": urls.view,
                    "type": "POST"
                }),
                "dom": 'Bfrtip',
                "select": 'single',
                "responsive": true,
                "altEditor": true,
                "buttons": [
                    { "text": 'Add', "name": 'add' },
                    { "extend": 'selected', "text": 'Edit', "name": 'edit' },
                    { "extend": 'selected', "text": 'Delete', "name": 'delete' },
                    { "text": 'Refresh', "name": 'refresh' }
                ],
                "onAddRow": actions.onAddRow,
                "onDeleteRow": actions.onDeleteRow,
                "onEditRow": actions.onEditRow
            });
            table = domElement.DataTable(opt);
        };
        var fnGetSelectedRowData = function () {
            return table.rows({ selected: true }).data()[0];
        };
        return {
            getSelectedRowData: fnGetSelectedRowData,
            getUrls: urls,
            getActions: actions,
            initalize: fnInitialize
        };
    }

    var tables = {
        person: new Table($('#personGrid'))
    };

    tables.person.initalize({
        "ajax": {
            "dataSrc": function (json) {
                $(json.data).each(function (index, element) {
                    element.birthdate = $.format.date(element.birthdate, "dd MMM yyyy");
                });
                return json.data;
            }
        },

        "columns": [
            { "data": "id", "type": "hidden" },
            { "data": "firstName", "type": "text", "maxLength": 25 },
            { "data": "lastName", "type": "text", "maxLength": 50 },
            { "data": "personNumber", "type": "text", "pattern": "^\\d{11}$", "errorMsg": "digits only", "maxLength": 11 },
            {
                "data": "birthdate",
                "type": "text",
                "datetimepicker": {
                    "timepicker": false,
                    "format": "d M Y"
                }
            },
            {
                "data": "gender",
                "type": "select",
                "select2": {
                    "placeholder": 'Select a gender',
                    "width": "100%",
                    "dataAdapter": $.fn.select2.amd.require('select2/data/customAjaxAdapter'),
                    "minimumResultsForSearch": -1,
                    "ajax": {
                        "url": lookups.genders.url,
                        "type": "POST",
                        "dataType": "json",
                        "processResults": function (data) {
                            return {
                                results: data.items
                            };
                        }
                    },
                    "row": function () {
                        return tables.person.getSelectedRowData();
                    },
                }
            },
            {
                "data": "salary",
                "type": "text",
                "pattern": "^\\d{1,10}$|^\\d{1,10}[.,]\\d{2,4}$",
                "errorMsg": "digits only",
            }
        ],
        "columnDefs": [{
            "targets": [0],
            "visible": false,
            "searchable": false
        }]
    });
};