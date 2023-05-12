using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.DormitoryManagement
{
    public class Dormitory : Entity
    {
        public HouseType House { get; private set; }
        public int NFloors { get; private set; }
        public int NRoomsPerFloor { get; private set; }
        public int NBedsPerRoom { get; private set; }
        public int NOccupiedBeds { get; set; }

        public ICollection<Room> Rooms { get; private set; }

        public int FloorCapacity => NRoomsPerFloor * NBedsPerRoom;

        public int TotalCapacity => NFloors * NRoomsPerFloor * NBedsPerRoom;

        public Dormitory(HouseType house, int nFloors, int nRoomsPerFloor, int nBedsPerRoom)
            : base()
        {
            House = house;
            NFloors = nFloors;
            NRoomsPerFloor = nRoomsPerFloor;
            NBedsPerRoom = nBedsPerRoom;
            NOccupiedBeds = 0;
            Rooms = new List<Room>();
        }
    }
}
