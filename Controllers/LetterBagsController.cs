using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostOfficeManagematAPI.Models.Domain;
using PostOfficeManagematAPI.Models.DTO;
using PostOfficeManagematAPI.Repositories.Interface;

namespace PostOfficeManagematAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LetterBagsController : ControllerBase
    {
        private readonly ILetterBagRepository _letterBagRepository;

        public LetterBagsController(ILetterBagRepository letterBagRepository)
        {
            _letterBagRepository = letterBagRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateLetterBag(CreateLetterBagRequestDto request)
        {
            var letterBag = new LetterBag
            {
                BagNumber = request.BagNumber,
                LettersCount = request.LettersCount,
                Weight = request.Weight,
                Price = request.Price
            };

            await _letterBagRepository.CreateAsync(letterBag);

            var response = new LetterBagDto
            {
                Id = letterBag.Id,
                BagNumber = request.BagNumber,
                LettersCount = request.LettersCount,
                Weight = request.Weight,
                Price = request.Price
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllLetterBags()
        {
            var letterBags = await _letterBagRepository.GetAllAsync();

            var response = letterBags.Select(lb => new LetterBagDto
            {
                Id = lb.Id,
                BagNumber = lb.BagNumber,
                LettersCount = lb.LettersCount,
                Weight = lb.Weight,
                Price = lb.Price
            }).ToList();

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetLetterBagById(Guid id)
        {
            var letterBag = await _letterBagRepository.GetByIdAsync(id);

            if (letterBag == null)
            {
                return NotFound();
            }

            var response = new LetterBagDto
            {
                Id = letterBag.Id,
                BagNumber = letterBag.BagNumber,
                LettersCount = letterBag.LettersCount,
                Weight = letterBag.Weight,
                Price = letterBag.Price
            };

            return Ok(response);
        }


    }
}
