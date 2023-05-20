using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Hogwarts.Core.Models.ForestManagement.DTOs
{
    public class PlantDTO
    {
        public string? Name { get; set; }
        public string? Description { get; set; }
        public string? Quantity { get; set; }
        public TimeSpan GrowthTimeSpan { get; set; }
        public string? ImagePath { get; set; }
    }
}
