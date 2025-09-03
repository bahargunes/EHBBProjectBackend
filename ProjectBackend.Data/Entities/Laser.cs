namespace ProjectBackend.Data.Entities
{
    public class Laser
    {
        public int LaserId { get; set; }
        public required string LaserName { get; set; }
        public string? SpotNumber { get; set; }
        public double? Weight { get; set; }
        public double? OperatingTemperature { get; set; }
        public double? StorageTemperature { get; set; }
        public double? Power { get; set; }
        public ICollection<LaserMode> LaserModes { get; set; } = new List<LaserMode>();


    }
    public class LaserMode
    {
        public int LaserModeId { get; set; }
        public int LaserId { get; set; } //foreignkey
        public Laser Laser { get; set; }
        public string? ModeInfo { get; set; }
        public double? ModePRI { get; set; }
        public double? ModePulseDuration { get; set; }
        public double? ScanPeriod { get; set; }




    }
}
