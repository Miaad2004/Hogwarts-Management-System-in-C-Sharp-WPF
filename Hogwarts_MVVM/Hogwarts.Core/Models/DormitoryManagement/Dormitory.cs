using Hogwarts.Core.Models.StudentManagement;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Windows.Input;

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

        public int FloorCapacity
        {
            get { return NRoomsPerFloor * NBedsPerRoom; }
        }

        public int TotalCapacity
        {
            get { return NFloors * NRoomsPerFloor * NBedsPerRoom; }
        }

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
