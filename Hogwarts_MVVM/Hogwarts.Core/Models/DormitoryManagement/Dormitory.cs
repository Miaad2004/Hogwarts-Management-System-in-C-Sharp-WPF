using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.DormitoryManagement.Exceptions;
using Hogwarts.Core.Models.HouseManagement;
using Hogwarts.Core.Models.StudentManagement;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata.Ecma335;

namespace Hogwarts.Core.Models.DormitoryManagement
{
    public class Dormitory : Entity
    {
        private string _title;
        private int _floorCount;
        private int _roomsPerFloor;
        private int _bedsPerRoom;

        public string Title
        {
            get => _title;
            private set
            {
                if (string.IsNullOrEmpty(value))
                {
                    throw new ArgumentNullException("Title can not be empty.");
                }
                _title = value;
            }
        }

        public HouseType House { get; private set; }
        public int FloorCount
        {
            get => _floorCount;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Floor Count must be positive.");
                }
                _floorCount = value;
            }
        }

        public int RoomsPerFloor
        {
            get => _roomsPerFloor;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Rooms per floor must be positive");
                }
                _roomsPerFloor = value;
            }
        }
        public int BedsPerRoom
        {
            get => _bedsPerRoom;
            private set
            {
                if (value <= 0)
                {
                    throw new ArgumentOutOfRangeException("Rooms per floor must be positive");
                }
                _bedsPerRoom = value;
            }
        }
        public int OccupiedBedsCount { get; private set; }

        public ICollection<DormitoryRoom> Rooms { get; private set; }

        public int FloorCapacity => RoomsPerFloor * BedsPerRoom;

        public int TotalCapacity => FloorCount * RoomsPerFloor * BedsPerRoom;

        public int RoomCount => RoomsPerFloor * FloorCount;

        public int RemainingCapacity => TotalCapacity - OccupiedBedsCount;

        public Dormitory(): base()
        {
            Rooms = new List<DormitoryRoom>();
        }

        public Dormitory(string title, HouseType house, int floorsCount, int roomsPerFloor, int bedsPerRoom)
            : base()
        {
            Title = title;
            House = house;
            FloorCount = floorsCount;
            RoomsPerFloor = roomsPerFloor;
            BedsPerRoom = bedsPerRoom;
            OccupiedBedsCount = 0;
            Rooms = new List<DormitoryRoom>();
        }

        public DormitoryRoom ReserveRoom(Student owner)
        {
            if (owner == null)
            {
                throw new ArgumentNullException(nameof(owner));
            }

            if (OccupiedBedsCount == TotalCapacity)
            {
                throw new DormitoryFullException($"[{House}-{Title}] dormitory is full.");
            }

            int floorNumber = (OccupiedBedsCount / FloorCapacity) + 1;
            int studentsInFloor = OccupiedBedsCount % FloorCapacity;
            int roomNumber = (studentsInFloor / BedsPerRoom) + 1;
            int bedNumber = (studentsInFloor % BedsPerRoom) + 1;

            OccupiedBedsCount += 1;

            DormitoryRoom room = new(dormitory: this, owner, floorNumber, roomNumber, bedNumber);

            return room;
        }
    }
}
