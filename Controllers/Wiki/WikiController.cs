using Microsoft.AspNetCore.Mvc;
using Redmine.Net.Api.Types;
namespace WebSupport.Controllers.Wiki
{
    public class WikiController : Controller
    {
        private readonly ILogger<WikiController> _logger;
        public WikiController(ILogger<WikiController> logger)
        {
            _logger = logger;
        }

        [Route("Wiki")]
        public IActionResult GetAllWikiPages()
        {
            var wiki = RedmineLibrary.Repository.Repository.WikiPages.ToList();
         
            return View(model:wiki);
        }
        [Route("Wiki/{id:int}")]
        public IActionResult GetWikiPage(WikiPage model)
        {
            return View(model:model);
        }
    }
}
