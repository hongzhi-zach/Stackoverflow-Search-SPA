using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using WebApi.JsonModels;

namespace WebApi.Controllers
{
    [Route("api/search")]
    public class SearchController : BaseController
    {
        public SearchController(IDataService dataService) : base(dataService)
        {
        }

        [HttpGet(Name = Config.SearchResultRoute)]
        public IActionResult Get(String searchstring, int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = DataService.EFShowSearchResult(searchstring, page, pagesize)
                .Select(s => ModelFactory.SearchMap(s, Url));
            var total = data.Count();
            System.Console.WriteLine(total);
            var result = new
            {
                Url = Url.Link(Config.SearchResultRoute, new { searchstring, page, pagesize }),
                total = total,
                prev = GetPrevResultUrl(Url, searchstring, page, pagesize),
                next = GetNextResultUrl(Url, searchstring, page, pagesize, total),
                Result = data
            };

            return Ok(result);

        }
    }
}

