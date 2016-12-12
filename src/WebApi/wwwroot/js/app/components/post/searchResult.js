define(['knockout', 'postman', 'config', 'dataservice', 'toastr'], function (ko, postman, config, dataService, toastr) {
   
    return function (params) {
        console.log(params);
        var posts = ko.observableArray([]);
        var searchResult = ko.observableArray(params.resultList);
        var curPage = ko.observable(params ? params.url : undefined);
        var selectPost = function (post) {
            postman.publish(config.events.selectPost, {
                post,
                url: curPage(),
                howToGetBack: function () {
                    postman.publish(config.events.searchPost, params);
                    toastr.success("Back to search result");
                }
            });
        };
        var setData = function (result) {
            posts(result.data);
            curPage(result.url);
        };

        dataService.getPosts(curPage(), function (result) {
            setData(result);
        });
        
        return {
            searchResult,
            selectPost
        };
    };
});
