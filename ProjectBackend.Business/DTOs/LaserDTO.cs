
namespace ProjectBackend.Business.DTOs
{
    public class LaserDTO
    {
        public int LaserId { get; set; }
        public required string LaserName { get; set; }
        public string? SpotNumber { get; set; }
        public double? Weight { get; set; }
        public double? OperatingTemperature { get; set; }
        public double? StorageTemperature { get; set; }
        public double? Power { get; set; }
        public ICollection<LaserModeDTO> LaserModes { get; set; } = new List<LaserModeDTO>();


    }
    public class LaserModeDTO
    {
        public int LaserModeId { get; set; }
        public int LaserId { get; set; }
        public string? ModeInfo { get; set; }
        public double? ModePRI { get; set; }
        public double? ModePulseDuration { get; set; }
        public double? ScanPeriod { get; set; }



    }
}
