using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.StudentManagement;
using System.ComponentModel.DataAnnotations.Schema;

namespace Hogwarts.Core.Models.DormitoryManagement
{
    public class Room : Entity
    {
        [ForeignKey(nameof(House))]
        public HouseType House { get; private set; }
        public Guid OwnerId { get; private set; }
        public int FloorNumber { get; private set; }
        public int RoomNumber { get; private set; }
        public int BedNumber { get; private set; }

        public Room()
            : base()
        {

        }
        public Room(User owner, HouseType house, int floorNumber, int roomNumber, int bedNumber)
            : base()
        {
            OwnerId = owner.Id;
            House = house;
            FloorNumber = floorNumber;
            RoomNumber = roomNumber;
            BedNumber = bedNumber;
        }

        public override string ToString()
        {
            return $"{House}-Floor{FloorNumber}-Room{RoomNumber}-Bed{BedNumber}";
        }
        public override int GetHashCode()
        {
            return HashCode.Combine(House, OwnerId, FloorNumber, RoomNumber, BedNumber);
        }
    }
}
