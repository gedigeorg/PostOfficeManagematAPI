namespace PostOfficeManagematAPI.Models.Domain
{
    public class Shipment
    {
        public Guid Id { get; set; }
        public string ShipmentNumber { get; set; }
        public Airport Airport { get; set; }
        public string FlightNumber { get; set; }
        public DateTime FlightDate { get; set; }
        public bool Finalized { get; set; }
        public List<ParcelBag> ParcelBags { get; set; }
        public List<LetterBag> LetterBags { get; set; }
    }

    public enum Airport
    {
        TLL = 5,
        RIX = 10,
        HEL = 15
    }
}
