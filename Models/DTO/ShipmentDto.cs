using PostOfficeManagematAPI.Models.Domain;

namespace PostOfficeManagematAPI.Models.DTO
{
    public class ShipmentDto
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
}
