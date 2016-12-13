using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using WebApi.JsonModels;

namespace WebApi.Controllers
{
    [Route("api/history")]
    public class HistoryController : BaseController
    {
        public HistoryController(IDataService dataService) : base(dataService)
        {
        }

        [HttpGet(Name = Config.HistoryListRoute)]
        public IActionResult Get(int page = 0, int pagesize = Config.DefaultPageSize)
        {
            var data = DataService.GetHistoryList(page, pagesize)
                .Select(h => ModelFactory.hMap(h, Url));
            var total = DataService.GetCountOfHistoryList();

            var result = new
            {
                total = total,
                Url = Url.Link(Config.HistoryListRoute, new { page, pagesize }),
                prev = GetPrevCommentUrl(Url, page, pagesize),
                next = GetNextCommentUrl(Url, page, pagesize, total),
                data = data
            };

            return Ok(result);
        }

        // GET api/values/5
        [HttpGet("{id}", Name = Config.HistoryRoute)]
        public IActionResult Get(int id)
        {
            var history = DataService.GetHistory(id);
            if (history == null) return NotFound();
            return Ok(ModelFactory.hMap(history, Url));
        }

        // POST api/values
        [HttpPost]
        public IActionResult Post([FromBody] HistoryModel model)
        {
            var history = ModelFactory.hMap(model);
            DataService.AddHistory(history);
            return Ok(ModelFactory.hMap(history, Url));
        }
    }
}
