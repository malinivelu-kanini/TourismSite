using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TourPackageImagesApp.Interfaces;
using TourPackageImagesApp.Models;
using TourPackageImagesApp.Models.DTO;

namespace TourPackageImagesApp.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TourImagesController : ControllerBase
    {
        private readonly ITourImageService _tourImageService;
        private readonly IRepo<int, Tour> _tourRepo;

        public TourImagesController(ITourImageService tourImageService, IRepo<int, Tour> tourRepo)
        {
            _tourImageService = tourImageService;
            _tourRepo = tourRepo;
        }


        [HttpPost]
        public async Task<IActionResult> CreateTour([FromForm] Tour model, List<IFormFile> images)
        {
            if (model != null && images != null && images.Count > 0)
            {
                var addedTour = await _tourRepo.Add(model);

                await _tourImageService.UploadImagesAsync(addedTour, images);

                return Ok("Tour created with images.");
            }

            return BadRequest("Invalid input data.");
        }


        [HttpGet]
        public async Task<ActionResult<ICollection<ImageDTO>>> GetAllImagesByTourId(int tourId)
        {
            if (tourId > 0)
            {
                var result = await _tourImageService.GetAllImagesByTourId(tourId);
                return Ok(result);
            }

            return NotFound("not found");
        }
    }
}
