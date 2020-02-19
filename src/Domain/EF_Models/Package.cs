namespace Domain.EF_Models
{
    public class Package
    {
        public int Id { get; set; }
        public int CountInPackage { get; set; }
        public double Volume { get; set; }
        public double Weight { get; set; }
        public double Width { get; set; }
        public double Height { get; set; }
    }
}