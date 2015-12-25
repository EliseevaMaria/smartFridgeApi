using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;
using Models;
using DAL;

namespace API.Controllers
{
    public class SmartFridgeController : Controller
    {
        public string GetFridge(string id)
        {
            int idInt32 = Convert.ToInt32(id);
            Fridge fridge = FridgeDataAccess.GetFridge(idInt32);
            return JsonConvert.SerializeObject(fridge, new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss" });
        }

        public void AddFridge(string fridgeJson)
        {
            string command = @"INSERT INTO Fridge VALUES (@Id, @Name, @FridgeTemp, @FreezerTemp, @Alarm, @FridgeOpened, @FreezerOpened, @TimeFridgeOpened, @TimeFreezerOpened, @UserEmail)";
            Fridge fridge = JsonConvert.DeserializeObject<Fridge>(fridgeJson, new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss" });
            FridgeDataAccess.ChangeFridge(command, fridge);
        }

        public void UpdateFridge(string fridgeJson)
        {
            string command = @"UPDATE Fridge SET Name = @Name, FridgeTemp = @FridgeTemp, FreezerTemp = @FreezerTemp, Alarm = @Alarm, FridgeOpened = @FridgeOpened, FreezerOpened = @FreezerOpened, TimeFridgeOpened = @TimeFridgeOpened, TimeFreezerOpened = @TimeFreezerOpened, UserEmail = @UserEmail WHERE Id = @Id";
            Fridge fridge = JsonConvert.DeserializeObject<Fridge>(fridgeJson, new IsoDateTimeConverter { DateTimeFormat = "yyyy'-'MM'-'dd'T'HH':'mm':'ss" });
            FridgeDataAccess.ChangeFridge(command, fridge);
        }
    }
}