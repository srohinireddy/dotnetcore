using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace DataWebAPI.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ImdbDataController : ControllerBase
    {

        private readonly ILogger<ImdbDataController> _logger;

        public ImdbDataController(ILogger<ImdbDataController> logger)
        {
            _logger = logger;
        }

        public ActionResult Index()
		{
			var startTime = DateTime.Now;
			// TODO: implement scraper and parser logic
			var totalTime = startTime - DateTime.Now;

			return Ok($"Done! Handler duration: {totalTime.Duration()}");
		}
    }
}
