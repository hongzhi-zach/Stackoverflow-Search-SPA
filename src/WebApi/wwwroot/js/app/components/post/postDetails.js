define(['knockout', 'postman', 'config', 'dataservice', 'toastr'], function (ko, postman, config, dataService, toastr) {
   
    return function (params) {
        var postdetail = ko.observableArray([]);
        
        //var postdetail = dataService.getPostDetail(params.post.id)

        var back = function () {
            params.howToGetBack();
            //postman.publish(
            //    config.events.changeMenu,
            //    { title: config.menuItems.posts, params });
            //console.log(params);
            
        };
        var setData = function (result) {
            postdetail(result.result);
            console.log(result.url);
        };

        dataService.getPostDetail(params.post.id, function (result) {
            console.log(params.post.id);
            setData(result);
        });

        //back = params.howToGetBack;
        return {
            postdetail,

            back
        };
    };
});
