using Hogwarts.Core.Models.ForestManagement.DTOs;

namespace Hogwarts.Core.Models.ForestManagement.Services
{
    public interface IForestService
    {
        Task AddPlantAsync(PlantDTO DTO);
        Task CollectPlantAsync(Guid plantId, Guid studentId);
        Task<int> GetStudentPlantQuantityAsync(Guid plantId, Guid studentId);
        Task<int> GetCollectablePlantCountAsync();
    }
}
