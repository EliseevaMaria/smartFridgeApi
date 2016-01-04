using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using BusinessLayer;

namespace API.Controllers
{
    public class HomeController : ApiController
    {
        public string Index()
        {
            return ".Trim()";
        }

        public bool Post(int id)
        {
            return Converting.UseReceipt(id);
        }
    }
}
