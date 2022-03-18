using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ImportXML.Controllers
{
    [Route("Mainbody")]
    public class MainbodyController : Controller
    {
        [Route("Orders")]
        [Route("")]
        [Route("~/")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
