using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourPackageApp.Interfaces;
using TourPackageApp.Models;
using TourPackageApp.Models.DTO;

namespace TourPackageApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TourController : ControllerBase
    {
        private readonly IServices _tourServices;
        private readonly ILogger<TourController> _logger;


        public TourController(IServices tourServices, ILogger<TourController> logger)
        {

            _tourServices = tourServices;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Tours), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Tours>> AddNewTourPackage(Tours tours)
        {
            try
            {
                if (tours != null)
                {
                    // Add the new tour and associated images
                    var result = await _tourServices.AddNewTour(tours);

                    return Created("tourPackages created", result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest("Unable to register");
        }

        [HttpPost]
        [ProducesResponseType(typeof(TourDetailsDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<TourDetailsDTO>> GetAllTourDetailsByTourName(string tourName)
        {
            try
            {
                if (!string.IsNullOrEmpty(tourName))
                {
                    var tourDetails = await _tourServices.GetTourDetailsByTourName(tourName);
                    return Ok(tourDetails);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest("unable to find");
        }


        [HttpGet]
        [ProducesResponseType(typeof(CountDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]


        public async Task<ActionResult<CountDTO>> GetCountByTourSpecailty(string tourSpecailty)
        {
            try
            {
                if (string.IsNullOrEmpty(tourSpecailty))
                {
                    var Count = await _tourServices.GetCountOfToursBySpecailty(tourSpecailty);
                    return Ok(Count);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest("unable to fetch");
        }

        [HttpPost]
        [ProducesResponseType(typeof(TourDetailsDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<Tours>> GetATourByTourId(int tourId)
        {
            try
            {
                if (tourId > 0)
                {
                    var tour = await _tourServices.GetTourDetailsByTourId(tourId);
                    return Ok(tour);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest("unable to find");
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<TourNameDTO>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<ActionResult<ICollection<TourNameDTO>>> GetAllTourNamesBySpeciality(string tourSpecialty)
        {
            try
            {
                if (tourSpecialty != null)
                {
                    var result = await _tourServices.GetAllTourNameBySpeciality(tourSpecialty);
                    if (result != null)
                        return Ok(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest("unable to fetch");
        }
    }
}
