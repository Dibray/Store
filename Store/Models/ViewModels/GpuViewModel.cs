namespace Store.Models.ViewModels
{
    public struct GpuViewModel
    {
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string Series { get; set; }
        public int? FrequencyMgh { get; set; }
        public int? VramMb { get; set; }
    }
}
