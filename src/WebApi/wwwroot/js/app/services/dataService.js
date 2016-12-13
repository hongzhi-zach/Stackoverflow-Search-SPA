define(['jquery'], function ($) {
    var postsUrl = "api/posts";
    

    var getComments = function (callback) {
        var url = "api/comments";
        $.getJSON(url, function (data) {
            callback(data);
        });
    };

    var getPosts = function (url, callback) {
        if (url === undefined) {
            url = postsUrl;
        }
        $.getJSON(url, function (data) {
            callback(data);
        });
    };

    var getHistoryList = function ( callback) {
        var url = "api/history";
        $.getJSON(url, function (data) {
            callback(data);
        });
    };


    var getSearchResult = function (url, searchString, callback) {
        if (url === undefined) {
            url = "api/search?=" + searchString();
        }
        $.getJSON(url, function (data) {
            callback(data);
        });
    };
    //var getSearchResult = function (searchString, callback) {
    //    var searchUrl = "api/search?=" + searchString();
    //    $.getJSON(searchUrl, function (data) {
    //        callback(data);
    //    });
    //};

    return {
        getComments,
        getPosts,
        getSearchResult,
        getHistoryList
    };
});




        