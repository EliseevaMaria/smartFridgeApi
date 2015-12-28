using System;

namespace Models
{
    public class Fridge
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int FridgeTemp { get; set; }
        public int FreezerTemp { get; set; }
        public bool Alarm { get; set; }
        public bool FridgeOpened { get; set; }
        public bool FreezerOpened { get; set; }
        public DateTime TimeFridgeOpened { get; set; }
        public DateTime TimeFreezerOpened { get; set; }
        public string UserEmail { get; set; }

        public Fridge()
        {

        }

        public Fridge(int id, string name, int fridgeTemp, int freezerTemp, bool alarm, bool fridgeOpened, bool freezerOpened, DateTime timeFridgeOpened, DateTime timeFreezerOpened, string userEmail)
        {
            Id = id;
            Name = name;
            FridgeTemp = fridgeTemp;
            FreezerTemp = freezerTemp;
            Alarm = alarm;
            FridgeOpened = fridgeOpened;
            FreezerOpened = freezerOpened;
            TimeFridgeOpened = timeFridgeOpened;
            TimeFreezerOpened = timeFreezerOpened;
            UserEmail = userEmail;
        }
    }
}
