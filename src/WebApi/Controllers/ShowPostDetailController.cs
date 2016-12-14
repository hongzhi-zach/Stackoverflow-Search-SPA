using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using WebApi.JsonModels;

namespace WebApi.Controllers
{
    [Route("api/postdetail")]
    public class ShowPostDetailController : BaseController
    {
        public ShowPostDetailController(IDataService dataService) : base(dataService)
        {
        }

        [HttpGet(Name = Config.PostDetailRoute)]
         public IActionResult Get(int questionid)
        {
            var data = DataService.EFShowPostDetail(questionid)
                .Select(p => ModelFactory.PostDetailMap(p, Url));
            var result = new
            {
                Url = Url.Link(Config.PostDetailRoute, new { questionid}),
                Result = data
            };

            return Ok(result);

        }
    }
}

