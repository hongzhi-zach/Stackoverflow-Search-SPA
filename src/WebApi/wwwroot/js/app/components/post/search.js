define(['knockout', 'postman', 'config', 'dataservice', 'toastr'], function (ko, postman, config, dataService, toastr) {
   
    return function (params) {
        var searchString = ko.observable("");
        
        //var searchResult = ko.observableArray([]);

        //var curPage = ko.observable(params ? params.url : undefined);

        var searchPost = function (resultList) {
            dataService.getSearchResult(params ? params.url : undefined, searchString, function (data) {
                //searchResult(data.result);
                //curPage(data.url);
                postman.publish(config.events.searchPost, { resultList: data.result, url: data.url });
            });
            
        };
        

        return {
            searchString,
            searchPost
            //searchResult
        }
    };
});
