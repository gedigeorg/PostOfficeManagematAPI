namespace PostOfficeManagematAPI.Models.DTO
{
    public class CreateLetterBagRequestDto
    {
        public string BagNumber { get; set; }
        public int LettersCount { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
    }
}
