using Hogwarts.Core.Models.HouseManagement;
using Hogwarts.Core.Models.StudentManagement;

namespace Hogwarts.Core.Models.DormitoryManagement
{
    public class DormitoryRoom : Entity
    {
        public HouseType House { get; private set; }
        public Dormitory Dormitory { get; private set; }
        public Guid DormitoryId { get; private set; }
        public Guid OwnerId { get; private set; }
        public int FloorNumber { get; private set; }
        public int RoomNumber { get; private set; }
        public int BedNumber { get; private set; }

        public DormitoryRoom()
            : base()
        {

        }
        public DormitoryRoom(Dormitory dormitory, Student owner, int floorNumber, int roomNumber, int bedNumber)
            : base()
        {
            House = dormitory.House;
            Dormitory = dormitory;
            DormitoryId = dormitory.Id;
            OwnerId = owner.Id;
            FloorNumber = floorNumber;
            RoomNumber = roomNumber;
            BedNumber = bedNumber;
        }

        public override string ToString()
        {
            return $"{Dormitory.Title}-Floor{FloorNumber}\nRoom{RoomNumber}-Bed{BedNumber}";
        }
    }
}
