namespace PostOfficeManagematAPI.Models.Domain
{
    public class Parcel
    {
        public Guid Id { get; set; }
        public string ParcelNumber { get; set; }
        public string RecipientName { get; set; }
        public string DestinationCountry { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
    }
}
