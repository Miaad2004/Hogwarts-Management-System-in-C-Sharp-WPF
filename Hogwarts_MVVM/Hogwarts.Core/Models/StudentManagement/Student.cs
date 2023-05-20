using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.Authentication.DTOs;
using Hogwarts.Core.Models.CourseManagement;
using Hogwarts.Core.Models.DormitoryManagement;
using Hogwarts.Core.Models.ForestManagement;
using Hogwarts.Core.Models.HouseManagement;

namespace Hogwarts.Core.Models.StudentManagement
{
    public sealed class Student : User
    {
        public int MaxAllowedCourses { get; private set; } = 4;
        public House House { get; private set; }
        public Guid HouseId { get; private set; }
        public HouseType HouseType { get; private set; }
        public bool HasLuggage { get; private set; }
        public PetType Pet { get; private set; }
        public DormitoryRoom DormitoryRoom { get; set; }    
        public Year Year { get; set; }

        public ICollection<Course> Courses { get; private set; } = new List<Course>();
        public ICollection<Grade> Grades { get; private set; } = new List<Grade>();
        public ICollection<StudentPlant> StudentPlants { get; private set; } = new List<StudentPlant>();
        public ICollection<StudentAssignment> StudentAssignments { get; private set; } = new List<StudentAssignment>();

        public Student() { }
        public Student(StudentRegistrationDTO DTO, string passwordHash, House house)
            : base(DTO, passwordHash)
        {
            HasLuggage = DTO.HasLuggage;
            Pet = DTO.Pet;
            Year = Year.First;
            House = house;
            HouseType = house.HouseType;
        }
    }
}
