using PostOfficeManagematAPI.Models.Domain;

namespace PostOfficeManagematAPI.Models.DTO
{
    public class CreateParcelBagRequestDto
    {
        public string BagNumber { get; set; }
        public List<Parcel> Parcels { get; set; }
    }
}
