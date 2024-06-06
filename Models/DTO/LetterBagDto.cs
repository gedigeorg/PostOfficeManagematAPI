﻿namespace PostOfficeManagematAPI.Models.DTO
{
    public class LetterBagDto
    {
        public Guid Id { get; set; }
        public string BagNumber { get; set; }
        public int LettersCount { get; set; }
        public decimal Weight { get; set; }
        public decimal Price { get; set; }
    }
}