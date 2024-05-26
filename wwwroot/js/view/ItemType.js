var _me = {

    init: function () {        
        //datatable config
        var config = {
            columns: [
                { data: 'Name' },
                { data: '_Fun' },
            ],
            columnDefs: [
				{ targets: [1], render: function (data, type, full, meta) {
                    return _crudR.dtCrudFun(full.Id, full.Name, true, true, true);
                }},
            ],
        };

        //initial
        _crudR.init(config);
    },
}; //class