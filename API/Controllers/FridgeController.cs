using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Mvc;
using System.Net.Http;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Models;
using DAL;

namespace API.Controllers
{
    public class FridgeController : ApiController
    {
        public List<Fridge> GetFridges(string email)
        {
            List<Fridge> fridge = FridgeDataAccess.GetFridges(email);
            return fridge;
        }
    }
}
