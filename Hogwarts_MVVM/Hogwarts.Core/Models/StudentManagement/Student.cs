﻿using Hogwarts.Core.Models.Authentication;
using Hogwarts.Core.Models.Authentication.DTOs;
using System;

namespace Hogwarts.Core.Models.StudentManagement
{
    public sealed class Student : User
    {
        public int MaxAllowedCourses { get; private set; } = 4;
        public HouseType HouseType { get; private set; }
        public bool HasLuggage { get; private set; }
        public Pet Pet { get; private set; }

        public Year Year { get; set; }

        public Student() { }
        public Student(string username, string firstName, string lastName, string email, DateOnly birthDay,
                     BloodType bloodType, AccessLevel accessLeve, string passwordHash, Pet pet, int maxCourses=4)
            : base(username, firstName, lastName, email, birthDay, bloodType, accessLeve, passwordHash)
        {
            this.Pet = pet;
            Sort();
            MaxAllowedCourses = maxCourses;
            Year = Year.First;
        }

        public Student(StudentRegistrationDTO DTO, string passwordHash)
            : base(DTO, passwordHash)
        {
            HasLuggage = DTO.HasLuggage;
            Pet = DTO.Pet;
            Sort();
            Year = Year.First;
        }

        private void Sort()
        {
            Random random = new ();
            HouseType = (HouseType)random.Next(0, Enum.GetValues(typeof(HouseType)).Length);
        }
    }
}
