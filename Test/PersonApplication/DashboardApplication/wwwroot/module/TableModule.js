function TableModule(lookups) {
    var customAdapter = $.fn.select2.amd.require('select2/data/customAjaxAdapter');
    let domtable = $('#personGrid');
    let oTable = domtable.DataTable({
        "processing": true,
        "serverSide": true,
        "pageLength": 10,
        "ordering": false,
        "ajax": {
            "url": domtable.attr("action-view"),
            "type": "POST",
            "dataSrc": function (json) {
                $(json.data).each(function (index, element) {
                    element.birthdate = $.format.date(element.birthdate, "dd MMM yyyy");
                });
                return json.data;
            }
        },
        "language": {
            "search": "",
            "searchPlaceholder": "Search..."
        },
        "columns": [
            {
                "data": "id",
                "type": "hidden"
            },
            {
                "data": "firstName",
                "type": "text",
                "maxLength": 25
            },
            {
                "data": "lastName",
                "type": "text",
                "maxLength": 50
            },
            {
                "data": "personNumber",
                "type": "text",
                "pattern": "^\\d{11}$",
                "errorMsg": "digits only",
                "maxLength": 11
            },
            {
                "data": "birthdate",
                "type": "text",
                "datetimepicker": {
                    timepicker: false,
                    format: "d M Y"
                }
            },
            {
                "data": "gender",
                "type": "select",
                "select2": {
                    "placeholder": 'Select a gender',
                    "width": "100%",
                    "dataAdapter": customAdapter,
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
                        return oTable.rows({ selected: true }).data()[0];
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
        "columnDefs": [
            {
                "targets": [0],
                "visible": false,
                "searchable": false
            }
        ],
        dom: 'Bfrtip',
        select: 'single',
        responsive: true,
        altEditor: true,
        buttons: [{
            text: 'Add',
            name: 'add'
        },
        {
            extend: 'selected',
            text: 'Edit',
            name: 'edit'
        },
        {
            extend: 'selected',
            text: 'Delete',
            name: 'delete'
        },
        {
            text: 'Refresh',
            name: 'refresh'
        }],
        onAddRow: function (datatable, rowdata, success, error) {
            $.ajax({
                "url": domtable.attr("action-create"),
                "type": "POST",
                "data": rowdata,
                "success": success,
                "error": error
            });
        },
        onDeleteRow: function (datatable, rowdata, success, error) {
            $.ajax({
                "url": domtable.attr("action-delete"),
                "type": "POST",
                "data": rowdata,
                "success": success,
                "error": error
            });
        },
        onEditRow: function (datatable, rowdata, success, error) {
            $.ajax({
                "url": domtable.attr("action-edit"),
                "type": "POST",
                "data": rowdata,
                "success": success,
                "error": error
            });
        }
    });
};