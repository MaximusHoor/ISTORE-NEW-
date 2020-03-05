namespace Domain.EF_Models
{
    public class Characteristic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Value { get; set; }
        public int ProductCharacteristicId { get; set; }
        public ProductCharacteristic ProductCharacteristic { get; set; }
    }
}