define(['knockout', 'postman', 'config', 'dataservice', 'toastr'], function (ko, postman, config, dataService, toastr) {
   
    return function (params) {
        var posts = ko.observableArray([]);
        var searchResult = ko.observableArray(params.resultList);
        var searchString = ko.observable(params.searchString);
        var total = ko.observable();
        var prevUrl = ko.observable();
        var nextUrl = ko.observable();
        var canPrev = function () {
            return prevUrl();
        };
        var canNext = function () {
            return nextUrl();
        };

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

        var showPrev = function () {
            dataService.getSearchResult(prevUrl(), searchString, function (result) {
                setData(result);
            });
        }

        var showNext = function () {
            dataService.getSearchResult(nextUrl(), searchString,function (result) {
                setData(result);
            });
        }
        var setData = function (result) {
            posts(result.data);
            total(result.total);
            prevUrl(result.prev);
            nextUrl(result.next);
            curPage(result.url);
        };

        dataService.getSearchResult(curPage(), searchString, function (result) {
            setData(result);
        });
        
        return {
            searchResult,
            selectPost,
            total,
            canPrev,
            canNext,
            showPrev,
            showNext
        };
    };
});
