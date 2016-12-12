define(['knockout', 'postman', 'config', 'toastr'], function (ko, postman, config, toastr) {
   
    return function (params) {
        var post = ko.observable(params.post);

        var back = function () {
            postman.publish(
                config.events.changeMenu,
                { title: config.menuItems.posts, params });
            toastr.success("Back to post list");
        };
        return {
            post,
            back
        };
    };
});
