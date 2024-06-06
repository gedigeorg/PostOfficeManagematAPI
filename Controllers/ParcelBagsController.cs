using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostOfficeManagematAPI.Models.Domain;
using PostOfficeManagematAPI.Models.DTO;
using PostOfficeManagematAPI.Repositories.Implementation;
using PostOfficeManagematAPI.Repositories.Interface;

namespace PostOfficeManagematAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelBagsController : ControllerBase
    {
        private readonly IParcelBagRepository _parcelBagRepository;

        public ParcelBagsController(IParcelBagRepository parcelBagRepository)
        {
            _parcelBagRepository = parcelBagRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateParcelBag(CreateParcelBagRequestDto request)
        {
            var parcelBag = new ParcelBag
            {
                BagNumber = request.BagNumber,
                Parcels = request.Parcels
            };

            await _parcelBagRepository.CreateAsync(parcelBag);

            var response = new ParcelBagDto
            {
                Id = parcelBag.Id,
                BagNumber = request.BagNumber,
                Parcels = request.Parcels
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParcelBags()
        {
            var parcelBags = await _parcelBagRepository.GetAllAsync();

            var response = parcelBags.Select(pb => new ParcelBagDto
            {
                Id = pb.Id,
                BagNumber = pb.BagNumber,
                Parcels = pb.Parcels
            }).ToList();

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetParcelBagById(Guid id)
        {
            var parcelBag = await _parcelBagRepository.GetByIdAsync(id);

            if (parcelBag == null)
            {
                return NotFound();
            }

            var response = new ParcelBagDto
            {
                Id = parcelBag.Id,
                BagNumber = parcelBag.BagNumber,
                Parcels = parcelBag.Parcels
            };

            return Ok(response);
        }


    }
}
