namespace PostOfficeManagematAPI.Models.Domain
{
    public class ParcelBag
    {
        public Guid Id { get; set; }
        public string BagNumber { get; set; }
        public List<Parcel> Parcels { get; set; }
    }
}
