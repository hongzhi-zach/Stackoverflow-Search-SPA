define(['knockout', 'postman', 'config', 'dataservice', 'toastr'], function (ko, postman, config, dataService, toastr) {
   
    return function (params) {
        var searchString = ko.observable("");
        ////this is the HTTP post request
        //var historyUrl = "api/history";
        //var method = "POST";
        
        //var async = true;
        //var request = new XMLHttpRequest();
        //var searchResult = ko.observableArray([]);

        //var curPage = ko.observable(params ? params.url : undefined);

        var searchPost = function (resultList) {
            if(searchString() !== ""){
                dataService.getSearchResult(params ? params.url : undefined, searchString(), function (data) {
                    postman.publish(config.events.searchPost, { resultList: data.result, url: data.url });
                });
            } else {
                alert("Value is empty");
            }
        };

       

        return {
            searchString,
            searchPost,
            
            //searchResult
        }
    };
});
