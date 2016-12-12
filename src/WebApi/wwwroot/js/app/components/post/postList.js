define(['knockout', 'dataservice', 'postman', 'config'],
    function (ko, dataService, postman, config) {
    return function (params) {
            var posts = ko.observableArray([]);

            var curPage = ko.observable(params ? params.url : undefined);

            var selectPost = function (post) {
                postman.publish(config.events.selectPost, { post, url: curPage() });
            };

            var setData = function (result) {
                posts(result.data);
                curPage(result.url);
            };

            dataService.getPosts(curPage(), function (result) {
                setData(result);
            });
              
            return {
                posts,
                selectPost
            };
        };
    });