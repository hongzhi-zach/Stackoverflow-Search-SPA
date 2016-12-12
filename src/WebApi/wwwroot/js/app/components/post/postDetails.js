define(['knockout', 'postman', 'config', 'toastr'], function (ko, postman, config, toastr) {
   
    return function (params) {
        var post = ko.observable(params.post);

        var back = function () {
            params.howToGetBack();
            //postman.publish(
            //    config.events.changeMenu,
            //    { title: config.menuItems.posts, params });
            //console.log(params);
            
        };

        //back = params.howToGetBack;
        return {
            post,
            back
        };
    };
});
