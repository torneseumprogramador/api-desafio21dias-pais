using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api_desafio21dias.ModelViews;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace api_desafio21dias.Controllers
{
    [ApiController]
    [Route("/")]
    public class HomeController : ControllerBase
    {
        [HttpGet]
        public HomeView Index()
        {
            return new HomeView();
        }

        // public ActionResult Index()
        // {
        //     return Redirect("/swagger");
        // }
    }
}
