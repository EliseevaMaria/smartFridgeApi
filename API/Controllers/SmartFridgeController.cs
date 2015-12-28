using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Models;
using DAL;

namespace API.Controllers
{
    public class SmartFridgeController : ApiController
    {
        public Fridge GetFridge(int id)
        {
            int idInt32 = Convert.ToInt32(id);
            Fridge fridge = FridgeDataAccess.GetFridge(idInt32);
            return fridge;// JsonConvert.SerializeObject(fridge, new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss" });
        }
        
        public void AddFridge(string fridgeJson)
        {
            Fridge fridge = JsonConvert.DeserializeObject<Fridge>(fridgeJson, new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss" });
            FridgeDataAccess.AddFridge(fridge);
        }

        public void UpdateFridge(string fridgeJson)
        {
            Fridge fridge = JsonConvert.DeserializeObject<Fridge>(fridgeJson, new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss" });
            FridgeDataAccess.UpdateFridge(fridge);
        }
    }
}