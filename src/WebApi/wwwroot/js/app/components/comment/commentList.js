define(['knockout', 'dataservice', 'postman', 'config'], function (ko, dataService, postman, config) {
    return function () {
        var comments = ko.observableArray([]);
        var selectedComment = ko.observable();

        var selectComment = function (comment) {
            selectedComment(comment);
            postman.publish(config.events.selectComment, comment);
        }

        var isSelected = function(comment) {
            return comment === selectedComment();
        }

        postman.subscribe(config.events.submitComment, function (comment) {
            var commentArray = comments();
            for (var i = 0; i < commentArray.length; i++) {
                if (commentArray[i].id === comment.id) {
                    commentArray[i] = comment;
                    break;
                }
            }
            comments(commentArray);
            selectedComment(comment);
        });

        dataService.getComments(function (data) {
            comments(data);
        });

        return {
            comments,
            selectComment,
            isSelected
        };
    };
});
