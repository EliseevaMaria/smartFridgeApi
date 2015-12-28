using System;
using Models;

namespace DAL
{
    public static class Services
    {
        /*public static void AddFridge(int id, string name, int fridgeTemp, int freezerTemp, bool alarm, bool fridgeOpened, bool freezerOpened, DateTime timeFridgeOpened, DateTime timeFreezerOpened, string userEmail)
        {
            string command = @"INSERT INTO Fridge VALUES (@Id, @Name, @FridgeTemp, @FreezerTemp, @Alarm, @FridgeOpened, @FreezerOpened, @TimeFridgeOpened, @TimeFreezerOpened, @UserEmail)";
            FridgeDataAccess.AddFridge(new Fridge(id, name, fridgeTemp, freezerTemp, alarm, fridgeOpened, freezerOpened, timeFridgeOpened, timeFreezerOpened, userEmail), command);
        }

        public static void UpdateFridge(int id, string name, int fridgeTemp, int freezerTemp, bool alarm, bool fridgeOpened, bool freezerOpened, DateTime timeFridgeOpened, DateTime timeFreezerOpened, string userEmail)
        {
            string command = @"UPDATE Fridge SET Name = @Name, FridgeTemp = @FridgeTemp, FreezerTemp = @FreezerTemp, Alarm = @Alarm, FridgeOpened = @FridgeOpened, FreezerOpened = @FreezerOpened, TimeFridgeOpened = @TimeFridgeOpened, TimeFreezerOpened = @TimeFreezerOpened, UserEmail = @UserEmail WHERE Id = @Id";
            FridgeDataAccess.UpdateFridge(command, new Fridge(id, name, fridgeTemp, freezerTemp, alarm, fridgeOpened, freezerOpened, timeFridgeOpened, timeFreezerOpened, userEmail), command);
        }*/
    }
}
