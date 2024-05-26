var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Name' },
                { data: 'Contact' },
                { data: 'Tel' },
                { data: 'Address' },
                { data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [4], render: function (data, type, full, meta) {
                    return _crudR.dtCrudFun(full.Id, full.Name, true, true, true);
                }},
            ],
        };

        //initial
        _crudR.init(config);
    },
}; //class