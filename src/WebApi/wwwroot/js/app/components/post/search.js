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
            dataService.getSearchResult(params ? params.url : undefined, searchString, function (data) {
                //searchResult(data.result);
                //curPage(data.url);
                postman.publish(config.events.searchPost, { resultList: data.result, url: data.url });
            });
            //var postData = "{'searchstring':'" + searchString + "'}";
            //console.log(postData);
            //request.open(method, historyUrl, async);
            //request.setRequestHeader("Content-Type", "application/json");
            //request.send(postData);
        };

        

        return {
            searchString,
            searchPost
            //searchResult
        }
    };
});
