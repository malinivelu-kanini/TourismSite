using TourPackageImagesApp.Models.DTO;
using TourPackageImagesApp.Models;

namespace TourPackageImagesApp.Interfaces
{
    public interface ITourImageService
    {
        public Task UploadImagesAsync(Tour tour, List<IFormFile> images);

        public Task<ICollection<ImageDTO>> GetAllImagesByTourId(int tourId);
    }
}
