
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace ProjectBackend.Data.Entities
{

    public class Emitter
    {
        public int EmitterId { get; set; }
        public string? Notation { get; set; }
        public required string EmitterName { get; set; }
        public string SpotNo { get; set; }
        public required string Function { get; set; }
        public string? Description { get; set; }
        public int? NumOfModes { get; set; }

        public ICollection<EmitterMode> Modes { get; set; } = new List<EmitterMode>();
    }
    public class EmitterMode
    {
        public int EmitterModeId { get; set; }
        public int EmitterId { get; set; } // Foreign Key
        public required string ModeName { get; set; }
        public double RFLimits { get; set; }
        public double PRILimits { get; set; }
        public double PDLimits { get; set; }
        public double ScanLimits { get; set; }

        // Navigation Property
        public Emitter Emitter { get; set; }
    }
}
