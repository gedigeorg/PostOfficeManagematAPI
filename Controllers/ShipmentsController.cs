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
    public class ShipmentsController : ControllerBase
    {
        private readonly IShipmentRepository _shipmentRepository;

        public ShipmentsController(IShipmentRepository shipmentRepository)
        {
            _shipmentRepository = shipmentRepository;
        }

        [HttpPost]
        public async Task<IActionResult> CreateShipment(CreateShipmentRequestDto request)
        {
            var shipment = new Shipment
            {
                ShipmentNumber = request.ShipmentNumber,
                Airport = request.Airport,
                FlightNumber = request.FlightNumber,
                FlightDate = request.FlightDate,
                Finalized = request.Finalized,
                ParcelBags = request.ParcelBags,
                LetterBags = request.LetterBags
            };

            await _shipmentRepository.CreateAsync(shipment);

            var response = new ShipmentDto
            {
                Id = shipment.Id,
                ShipmentNumber = request.ShipmentNumber,
                Airport = request.Airport,
                FlightNumber = request.FlightNumber,
                FlightDate = request.FlightDate,
                Finalized = request.Finalized,
                ParcelBags = request.ParcelBags,
                LetterBags = request.LetterBags
            };

            return Ok(response);
        }

        [HttpGet]
        public async Task<IActionResult> GetAllShipments()
        {
            var shipments = await _shipmentRepository.GetAllAsync();

            var response = shipments.Select(s => new ShipmentDto
            {
                Id = s.Id,
                ShipmentNumber = s.ShipmentNumber,
                Airport = s.Airport,
                FlightNumber = s.FlightNumber,
                FlightDate = s.FlightDate,
                Finalized = s.Finalized,
                ParcelBags = s.ParcelBags,
                LetterBags = s.LetterBags
            }).ToList();

            return Ok(response);
        }

        [HttpGet("airport-enum")]
        public IActionResult GetAirportEnum()
        {
            var airportValues = Enum.GetValues(typeof(Airport)).Cast<Airport>().Select(a => (int)a).ToList();
            return Ok(airportValues);
        }

        [HttpGet("{id:guid}")]
        public async Task<IActionResult> GetShipmentById(Guid id)
        {
            var shipment = await _shipmentRepository.GetByIdAsync(id);

            if (shipment == null)
            {
                return NotFound();
            }

            var response = new ShipmentDto
            {
                Id = shipment.Id,
                ShipmentNumber = shipment.ShipmentNumber,
                Airport = shipment.Airport,
                FlightNumber = shipment.FlightNumber,
                FlightDate = shipment.FlightDate,
                Finalized = shipment.Finalized,
                ParcelBags = shipment.ParcelBags,
                LetterBags = shipment.LetterBags
            };

            return Ok(response);
        }

        [HttpPut("{id:guid}")]
        public async Task<IActionResult> UpdateShipment(Guid id, CreateShipmentRequestDto request)
        {
            var existingShipment = await _shipmentRepository.GetByIdAsync(id);

            if (existingShipment == null)
            {
                return NotFound();
            }

            existingShipment.Finalized = request.Finalized;

            await _shipmentRepository.UpdateAsync(existingShipment);

            var response = new ShipmentDto
            {
                Id = existingShipment.Id,
                ShipmentNumber = existingShipment.ShipmentNumber,
                Airport = existingShipment.Airport,
                FlightNumber = existingShipment.FlightNumber,
                FlightDate = existingShipment.FlightDate,
                Finalized = existingShipment.Finalized,
                ParcelBags = existingShipment.ParcelBags,
                LetterBags = existingShipment.LetterBags
            };

            return Ok(response);
        }


    }
}
