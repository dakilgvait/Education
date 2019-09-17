function TableModule() {
    let domtable = $('#personGrid');
    domtable.DataTable({
        "processing": true,
        "serverSide": true,
        "pageLength": 10,
        "ordering": false,
        "ajax": {
            "url": domtable.attr("action-view"),
            "type": "POST"
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
                    format: "Y/m/d"
                }
            },
            {
                "data": "gender",
                "type": "select",
                "select2": {
                    "placeholder": 'Select a gender',
                    "width": "100%",
                    "ajax": {
                        "url": domtable.attr("action-lookup-genders"),
                        "type": "POST",
                        "dataType": "json",
                        "processResults": function (data) {
                            return {
                                results: data.items
                            };
                        }
                    }
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