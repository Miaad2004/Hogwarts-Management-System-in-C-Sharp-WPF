namespace Hogwarts.Core.Models.ForestManagement.DTOs
{
    public class PlantDTO
    {
        public string Name { get; set; } = "";
        public string Description { get; set; } = "";
        public string Quantity { get; set; } = "";
        public TimeSpan GrowthTimeSpan { get; set; }
        public string ImagePath { get; set; } = "";
    }
}
