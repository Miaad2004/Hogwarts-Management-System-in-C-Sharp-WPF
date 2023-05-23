namespace Hogwarts.Core.Models.HouseManagement.Services
{
    public interface IHouseService
    {
        Task AddHouseAsync(HouseType houseType, string? profileImagePath);
        public Task<House> SortAsync();
        Task UpdatePointsAsync(Guid houseId, int dPoint);
        Task<HouseType> GetHouseTypeAsync(Guid studentId);
        Task<int> GetHousePointsAsync(Guid studentOrHouseId);
        Task<int> GetAvgHousePointsAsync();
    }
}
