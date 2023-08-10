using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Linq.Expressions;
using TourBookingApp.Interfaces;
using TourBookingApp.Models;
using TourBookingApp.Models.DTO;

namespace TourBookingApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TourBookingController : ControllerBase
    {
        private ITourBooking _tourBookingService;
        private readonly ILogger<TourBookingController> _logger;

        public TourBookingController(ITourBooking tourBookingService, ILogger<TourBookingController> logger)
        {
            _tourBookingService = tourBookingService;
            _logger = logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(Booking),StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<Booking>>AddBooking(Booking booking)
        {
            try
            { 
                if (booking!=null)
                {
                    var result = await _tourBookingService.TourBooking(booking);
                    if (result!=null)
                        return Created("booking Added Successfully", result);

                }
               
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest("Booking Not Added");
        }

        [HttpDelete]
        [ProducesResponseType(typeof(BookingCountDTO),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<Booking>>CancelBooking(int bookingId)
        {
            try
            {
                if(bookingId > 0)
                {
                    var cancelbooking = await _tourBookingService.CancelTourBooking(bookingId);
                    if (cancelbooking != null)
                        return Ok(cancelbooking);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return NotFound("Booking Not Found to Cancel");
        }

        [HttpGet]
        [ProducesResponseType(typeof(BookingCountDTO), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<BookingCountDTO>> GetTourBookingCount(int tourId)
        {
            try
            {
                if (tourId > 0)
                {
                    var result = await _tourBookingService.GetTourCount(tourId);
                    if (result != null)
                        return Ok(result);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return NotFound("cannot get tour booking count right now");
        }
    }
   
}
