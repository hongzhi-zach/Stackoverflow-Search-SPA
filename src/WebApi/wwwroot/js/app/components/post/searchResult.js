define(['knockout', 'postman', 'config', 'toastr'], function (ko, postman, config, toastr) {
   
    return function (params) {
        console.log(params);
        var searchResult = ko.observableArray(params.resultList);
        console.log(searchResult);
        
        var back = function () {
            postman.publish(
                config.events.changeMenu,
                { title: config.menuItems.posts, params });
            toastr.success("Back to post list");
        };
        return {
            searchResult,
            back
        };
    };
});
