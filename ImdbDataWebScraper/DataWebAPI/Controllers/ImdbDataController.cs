using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Downloader;
using Parser;
using Common;
namespace DataWebAPI.Controllers
{
    [ApiController, Route("~/")]
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
            //DatasetDownloader downloader = new DatasetDownloader();
            DatasetParser parser = new DatasetParser();
            parser.Process(StringConstants.akasFile);
            parser.Process(StringConstants.crewFile);
            parser.Process(StringConstants.episodeFile);
            parser.Process(StringConstants.imdbDatasetURL);
            parser.Process(StringConstants.nameBasicsFile);
            parser.Process(StringConstants.principalsFile);
            parser.Process(StringConstants.ratingsFile);

            var dataset = parser.GetIMDBDataset();
            
			return Ok($"Done! Handler duration: {totalTime.Duration()}");
		}
    }
}
