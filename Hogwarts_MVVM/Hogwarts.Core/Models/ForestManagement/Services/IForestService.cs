using Hogwarts.Core.Models.ForestManagement.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.ForestManagement.Services
{
    public interface IForestService
    {
        void AddPlant(PlantDTO DTO);
        void CollectPlant(Guid plantId, Guid studentId);
        int GetStudentPlantQuantity(Guid plantId, Guid studentId);
        int GetCollectablePlantCount();
    }
}
