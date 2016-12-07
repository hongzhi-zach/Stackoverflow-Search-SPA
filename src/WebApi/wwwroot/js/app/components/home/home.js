define(['knockout', 'dataservice', 'postman', 'config'], function (ko, dataService, postman, config) {
    return function () {
        var comments = ko.observableArray([]);
        var commentlist = dataService.getComments(function (data) {
            comments(data);
        });
        postman.subscribe(config.events.Search, commentlist);
        
        

        return {
            comments,
            commentlist,

        };
    };
});
