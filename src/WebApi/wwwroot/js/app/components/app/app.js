define(['knockout', 'postman', 'config', 'dataservice', 'jquery', 'bootstrap'], function (ko, postman, config, dataService, $, bt) {
    return function () {
        var menuItems = [
            //{ title: config.menuItems.searchPost, component: 'search-post' },
            //{ title: config.menuItems.comments, component: 'comment-list'}, 
            { title: config.menuItems.posts, component: 'post-list' },
            { title: config.menuItems.history, component: 'history-list' }
        ];

        //var searchString = ko.observable("");
        //var searchResult = ko.observableArray([]);
        //var view = ko.observable("default");
        var currentComponent = ko.observable();
        var currentParams = ko.observable();
        var selectedMenu = ko.observable();

        //var curPage = ko.observable(params ? params.url : undefined);
        //var callback = function (data) {
        //    searchResult(data.result);
        //    curPage(data.url);
        //};

        //var searchPost = function (resultList) {
        //    dataService.getSearchResult(searchString, function (data) {
        //        searchResult(data.result);
        //        curPage(data.url);
        //    });
        //    postman.publish(config.events.searchPost, { resultList, url: curPage() });
        //};
        //postman.subscribe(config.events.searchPost, function (params) {
        //    currentParams(params);
        //    currentComponent("search-result");
        //});
        

        var selectMenu = function (menu, params) {
            selectedMenu(menu);
            currentParams(params);
            currentComponent(menu.component);
        }

        var isSelected = function (menu) {
            return menu === selectedMenu();
        }

        postman.subscribe(config.events.selectPost, function (params) {
            currentParams(params);
            currentComponent("post-details");
        });
        postman.subscribe(config.events.searchPost, function (params) {
            currentParams(params);
            currentComponent("search-result");
        });

        postman.subscribe(config.events.changeMenu, function (data) {
            for (var i = 0; i < menuItems.length; i++) {
                if (menuItems[i].title === data.title) {
                    selectMenu(menuItems[i], data.params);
                    break;
                }
            }
        });

        selectMenu(menuItems[0]);



        return {
            menuItems,
            currentComponent,
            currentParams,
            selectMenu,
            isSelected,
            //searchString,
            //searchPost,
            //searchResult
            //view

        }
    }
});