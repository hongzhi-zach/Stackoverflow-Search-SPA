define(['knockout', 'postman', 'config', 'dataservice', 'toastr'], function (ko, postman, config, dataService, toastr) {
    return function (params) {
        var historyList = ko.observableArray([]);

        

        dataService.getHistoryList(function (result) {
            historyList(result.data);
        });
        

        return {
            historyList
            
        };
    };
});