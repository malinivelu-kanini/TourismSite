using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;
using TourFeedBackApp.Interfaces;
using TourFeedBackApp.Models;
using TourFeedBackApp.Services;

namespace TourFeedBackApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedBackController : ControllerBase
    {
        private IFeedBack _feedbackService;
        private ILogger<FeedBackController> _logger;

        public FeedBackController(IFeedBack feedbackService, ILogger<FeedBackController> logger)
        {
            _feedbackService=feedbackService;
            _logger=logger;
        }

        [HttpPost]
        [ProducesResponseType(typeof(FeedBack), StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]

        public async Task<ActionResult<FeedBack>> AddFeedBack(FeedBack feedback)
        {
            try
            {
                if(feedback !=null)
                {
                    var result = await _feedbackService.AddFeedback(feedback);
                    if (result != null)
                    {
                        return Created("Add Feedback Added", result);
                    }

                }
                
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return BadRequest("Unable to Add feedback Right now");
        }

        [HttpGet]
        [ProducesResponseType(typeof(ICollection<FeedBack>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]

        public async Task<ActionResult<ICollection<FeedBack>>> GetTopRatingsFeedBack()
        {
            try
            {
                var topratingfeddback = await _feedbackService.GetTopRatingsFeedBack();
                if(topratingfeddback != null)
                {
                    return Ok(topratingfeddback);
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex.Message);
            }
            return NotFound("FeedBack not Available");
        }



    }
}
