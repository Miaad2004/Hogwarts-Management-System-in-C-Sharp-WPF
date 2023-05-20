namespace Hogwarts.Core.Models.HouseManagement.Services
{
    public interface IHouseService
    {
        void AddHouse(HouseType houseType, string? profileImagePath);
        public House Sort();
        void UpdatePoints(Guid houseId, int dPoint);
        HouseType GetHouseType(Guid studentId);
        int GetHousePoints(Guid studentOrHouseId);
        int GetAvgHousePoints();
    }
}
