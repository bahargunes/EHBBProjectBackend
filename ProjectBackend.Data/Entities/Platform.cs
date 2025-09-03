namespace ProjectBackend.Data.Entities
{
    public enum PlatformType
    {
        // Deniz-Suüstü
        ZirhlıMuharebе = 1,
        Kruvazör = 2,
        Destroyer = 3,
        Fırkateyn = 4,
        Korvet = 5,
        Hücumbot = 6,
        Karakol = 7,
        UçakGemisi = 8,
        KıyıMuharebe = 9,
        MayınAvlama = 10,
        Çıkarma = 11,
        Römork = 12,
        İstihbaratGemisi = 13,
        İnsansızSuÜstüAracı = 14,
        SivilGemi = 15,
        DiğerSuÜstü = 16,

        // Deniz-Sualtı
        Denizaltı = 17,
        İnsansızSuAltıAracı = 18,
        SivilSuAltı = 19,
        DiğerSuAltı = 20,

        // Hava-Sabit-Döner Kanat
        Taarruz = 21,
        Bombardıman = 22,
        Yakıtİkmal = 23,
        Kargo = 24,
        İstihbaratUçak = 25,
        Erkenİhbar = 26,
        Nakliye = 27,
        SivilUçak = 28,

        // Kara
        Tesis = 29,
        Araç = 30,
        Şelter = 31
    }

    public enum PlatformCategory
    {
        DenizSuÜstü = 1,
        DenizSuAltı = 2,
        HavaSabitKanat = 3,
        HavaDönerKanat = 4,
        HavaİHA = 5,
        HavaBalon = 6,
        KaraSabit = 7,
        KaraMobil = 8,
        KaraNakledilebilir = 9,
        Uzay = 10
    }
    public class Platform
    {
        public int PlatformId { get; set; }
        public string? PlatformName { get; set; }
        public PlatformType? PlatformType { get; set; }
        public PlatformCategory? PlatformCategory { get; set; }
        public string? Remarks { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateLastUpdated { get; set; }
        public double Lenght { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
        public double Weight { get; set; }
        public double MaxSpeed { get; set; }
        public double MinSpeed { get; set; }
        public decimal Latitude { get; set; }
        public decimal Longitude { get; set; }

    }
}
