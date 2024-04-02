using Microsoft.AspNetCore.Mvc;
namespace WebSupport.Controllers.Wiki
{
    public class WikiController : Controller
    {
        private readonly ILogger<WikiController> _logger;
        public WikiController(ILogger<WikiController> logger)
        {
            _logger = logger;
        }

        [Route("/Wiki")]
        public IActionResult GetAllWikiPages()
        {
            return View() ;
        }
       /* [Route("/Wiki/{id:int}")]
        public IActionResult GetWikiPage(WikiPage model)
        {
            return View(model:model);
        }*/
    }
}