using PostOfficeManagematAPI.Models.Domain;

namespace PostOfficeManagematAPI.Models.DTO
{
    public class ParcelBagDto
    {
        public Guid Id { get; set; }
        public string BagNumber { get; set; }
        public List<Parcel> Parcels { get; set; }
    }
}
