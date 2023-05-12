using Hogwarts.Core.Models.Forest.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.Forest.Services
{
    public interface IForestService
    {
        void AddPlant(PlantDTO DTO);
        void UpdatePlantQuantity(Guid plantId, int newQuantity);
    }
}
