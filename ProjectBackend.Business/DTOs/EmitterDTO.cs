namespace ProjectBackend.Business.DTOs
{
    public class EmitterDTO
    {
        public int EmitterId { get; set; }
        public string? Notation { get; set; }
        public required string EmitterName { get; set; }
        public string SpotNo { get; set; }
        public required string Function { get; set; }
        public string? Description { get; set; }
        public int? NumOfModes { get; set; }

        public ICollection<EmitterModeDTO> Modes { get; set; } = new List<EmitterModeDTO>();
    }
    public class EmitterModeDTO
    {
        public int EmitterModeId { get; set; }
        public int EmitterId { get; set; } // Foreign Key
        public required string ModeName { get; set; }
        public  double RFLimits { get; set; }
        public  double PRILimits { get; set; }
        public  double PDLimits { get; set; }
        public  double ScanLimits { get; set; }

    }

}
