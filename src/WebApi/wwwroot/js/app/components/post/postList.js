define(['knockout', 'postman', 'config', 'dataservice', 'toastr'], function (ko, postman, config, dataService, toastr) {
    return function (params) {
            var posts = ko.observableArray(params ? params.posts : []);

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
                curPage(result.url);
            };

            if (params === undefined) {
                dataService.getPosts(curPage(), function (result) {
                    setData(result);
                });
            }
              
            return {
                posts,
                selectPost
            };
        };
    });