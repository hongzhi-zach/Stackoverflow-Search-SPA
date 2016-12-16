using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using WebApi.JsonModels;

namespace WebApi.Controllers
{
    [Route("api/wordcloud")]
    public class CloudController : BaseController
    {
        public CloudController(IDataService dataService) : base(dataService)
        {
        }

        [HttpGet(Name = Config.CloudRoute)]
        public IActionResult Get(String word)
        {
            var data = DataService.EFShowWordCloud(word)
                .Select(c => ModelFactory.CloudMap(c, Url));
            var result = new
            {
                Url = Url.Link(Config.CloudRoute, new { word }),
                Result = data
            };

            return Ok(result);

        }
    }
}

