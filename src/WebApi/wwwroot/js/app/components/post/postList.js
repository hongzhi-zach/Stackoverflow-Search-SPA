define(['knockout', 'postman', 'config', 'dataservice', 'toastr'], function (ko, postman, config, dataService, toastr) {
    return function (params) {
            var posts = ko.observableArray(params ? params.posts : []);

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
                        postman.publish(config.events.changeMenu, {
                            title: config.menuItems.posts,
                            params: { posts: posts() }
                        });
                        toastr.success("Back to post list");
                    }
                });
            };

            var setData = function (result) {
                posts(result.data);
                total(result.total);
                prevUrl(result.prev);
                nextUrl(result.next);
                curPage(result.url);
            };

            var showPrev = function () {
                dataService.getPosts(prevUrl(), function (result) {
                    setData(result);
                });
            }

            var showNext = function () {
                dataService.getPosts(nextUrl(), function (result) {
                    setData(result);
                });
            }
            //if (params === undefined) {
                dataService.getPosts(curPage(), function (result) {
                    setData(result);
                });
            //}
              

            return {
                posts,
                selectPost,
                total,
                canPrev,
                canNext,
                showPrev,
                showNext
            };
        };
    });