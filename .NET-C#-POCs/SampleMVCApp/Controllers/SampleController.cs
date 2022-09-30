using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SampleMVCWebApplication.Controllers
{
    public class SampleController : Controller
    {
        // GET: SampleController
       
        public ActionResult Index()
        {
            return View();
        }
       
        public ActionResult Contact()
        {
            return View();
        }
        public ActionResult Aboutus()
        {
            return View();
        }

        // GET: SampleController/Details/5

    }
}
