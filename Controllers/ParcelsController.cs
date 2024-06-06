using Azure.Core;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PostOfficeManagematAPI.Data;
using PostOfficeManagematAPI.Models.Domain;
using PostOfficeManagematAPI.Models.DTO;
using PostOfficeManagematAPI.Repositories.Implementation;
using PostOfficeManagematAPI.Repositories.Interface;

namespace PostOfficeManagematAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ParcelsController : ControllerBase
    {
        private readonly IParcelRepository _parcelRepository;

        public ParcelsController(IParcelRepository parcelRepository)
        {
            _parcelRepository = parcelRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateParcel(CreateParcelRequestDto request)
        {
            var parcel = new Parcel
            {
                ParcelNumber = request.ParcelNumber,
                RecipientName = request.RecipientName,
                DestinationCountry = request.DestinationCountry,
                Weight = request.Weight,
                Price = request.Price
            };

            await _parcelRepository.CreateAsync(parcel);

            var response = new ParcelDto
            {
                Id = parcel.Id,
                ParcelNumber = request.ParcelNumber,
                RecipientName = request.RecipientName,
                DestinationCountry = request.DestinationCountry,
                Weight = request.Weight,
                Price = request.Price
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllParcels()
        {
            var parcels = await _parcelRepository.GetAllAsync();

            var response = parcels.Select(p => new ParcelDto
            {
                Id = p.Id,
                ParcelNumber = p.ParcelNumber,
                RecipientName = p.RecipientName,
                DestinationCountry = p.DestinationCountry,
                Weight = p.Weight,
                Price = p.Price
            }).ToList();

            return Ok(response);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetParcelById(Guid id)
        {
            var parcel = await _parcelRepository.GetByIdAsync(id);

            if (parcel == null)
            {
                return NotFound();
            }

            var response = new ParcelDto
            {
                Id = parcel.Id,
                ParcelNumber = parcel.ParcelNumber,
                RecipientName = parcel.RecipientName,
                DestinationCountry = parcel.DestinationCountry,
                Weight = parcel.Weight,
                Price = parcel.Price
            };

            return Ok(response);
        }


    }
}
