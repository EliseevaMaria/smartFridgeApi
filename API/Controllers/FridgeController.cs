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
using System.Net;

namespace API.Controllers
{
    public class FridgeController : ApiController
    {
        public List<Fridge> GetFridges(string email)
        {
            List<Fridge> fridge = FridgeDataAccess.GetFridges(email);
            return fridge;
        }

        public HttpResponseMessage PostFridge(Fridge fridge)
        {
            try
            {
                FridgeDataAccess.UpdateFridge(fridge);
            }
            catch (Exception e)
            {
                return Request.CreateResponse(HttpStatusCode.InternalServerError);
            }
            return Request.CreateResponse(HttpStatusCode.OK);
        }
    }
}
