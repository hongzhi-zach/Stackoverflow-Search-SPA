using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DomainModel;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.JsonModels
{
    public class ModelFactory
    {
        public static SearchResultModel SearchMap(SearchResult searchresult, IUrlHelper url, string searchstring)
        {

            return new SearchResultModel
            {
                Url = url.Link(Config.SearchResultRoute, new { id = searchstring }),
                title = searchresult.title,
                body = searchresult.body,
                score = searchresult.score
            };
        }

        public static SearchResult SearchMap(SearchResultModel model)
        {

            return new SearchResult
            {
                title = model.title,
                body = model.body,
                score = model.score
            };
        }

        public static CommentModel cMap(Comment comment, IUrlHelper url)
        {
            
            return new CommentModel
            {
                Url = url.Link(Config.CommentRoute, new { id = comment.id}),
                score = comment.score,
                id = comment.id,
                text = comment.text,
                createdate = comment.createdate
            };
        }

        public static Comment cMap(CommentModel model)
        {
            
            return new Comment
            {
                score = model.score,
                id = model.id,
                text = model.text,
                createdate = model.createdate
            };
        }

        public static PostModel pMap(Post post, IUrlHelper url)
        {
           
            return new PostModel
            {
                Url = url.Link(Config.PostRoute, new { id = post.id }),
                score = post.score,
                id = post.id,
                body = post.body,
                creationdate = post.creationdate
            };
        }

        public static Post pMap(PostModel model)
        {
           
            return new Post
            {
                score = model.score,
                id = model.id,
                body = model.body,
                creationdate = model.creationdate
            };
        }
    }
}
