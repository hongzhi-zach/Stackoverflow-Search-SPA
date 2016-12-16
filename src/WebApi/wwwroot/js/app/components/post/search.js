define(['knockout', 'postman', 'config', 'dataservice', 'toastr', 'jqcloud'], function (ko, postman, config, dataService, toastr, jq) {
   
    return function (params) {
        var searchString = ko.observable("");
        ////this is the HTTP post request
        //var historyUrl = "api/history";
        //var method = "POST";
        
        //var async = true;
        //var request = new XMLHttpRequest();
        //var searchResult = ko.observableArray([]);

        //var curPage = ko.observable(params ? params.url : undefined);

        var searchPost = function (resultList) {
            if(searchString() !== ""){
                dataService.getSearchResult(params ? params.url : undefined, searchString(), function (data) {

                    postman.publish(config.events.searchPost, { resultList: data.result, url: data.url });
                   // postman.publish(config.events.getWordCloud, { searchString: searchString() });

                });
                dataService.getWordCloud(searchString(), function (data) {
                    console.log(data);
                    $('#wordcloud').jQCloud(data.result, {
                        classPattern: null,
                        colors: ["#0cf", "#0cf",
                        "#0cf", "#39d", "#90c5f0", "#90a0dd",
                        "#a0ddff", "#99ccee", "#aab5f0"],

                        fontSize: {
                            from: 0.15,
                            to: 0.03
                        }
                    });
                });
            } else {
                alert("Value is empty");
            }
        };

       

        return {
            searchString,
            searchPost,
            
            //searchResult
        }
    };
});
