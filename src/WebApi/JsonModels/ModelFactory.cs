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
        public static CommentModel Map(Comments comment, IUrlHelper url)
        {
            // hint: use AutoMapper
            return new CommentModel
            {
                Url = url.Link(Config.CommentRoute, new { id = comment.id}),
                score = comment.score,
                id = comment.id,
                text = comment.text,
                createdate = comment.createdate
            };
        }

        public static Comments Map(CommentModel model)
        {
            // hint: use AutoMapper
            return new Comments
            {
                score = model.score,
                id = model.id,
                text = model.text,
                createdate = model.createdate
            };
        }
    }
}
