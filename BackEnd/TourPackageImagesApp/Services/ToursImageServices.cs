using Azure.Storage.Blobs;
using TourPackageImagesApp.Interfaces;
using TourPackageImagesApp.Models;
using TourPackageImagesApp.Models.DTO;

namespace TourPackageImagesApp.Services
{
    public class ToursImageServices : ITourImageService
    {

        private readonly IRepo<int, Tour> _tourRepo;
        private readonly IRepo<int, TourImages> _tourImageRepo;

        public ToursImageServices(
            IRepo<int, Tour> tourRepo,
            IRepo<int, TourImages> tourImageRepo)
        {
            _tourRepo = tourRepo;
            _tourImageRepo = tourImageRepo;
        }

        public async Task<ICollection<ImageDTO>> GetAllImagesByTourId(int tourId)
        {
            var allTourImages = await _tourImageRepo.GetAll();
            var images = allTourImages.Where(a => a.TourId == tourId).Select(x => new ImageDTO { ImagePaths = x.ImagePaths });
            if (images != null)
            {
                return images.ToList();
            }
            throw new Exception("no images found");
        }

        public async Task UploadImagesAsync(Tour tour, List<IFormFile> images)
        {
            var tours = await _tourRepo.GetAll();
            var existingTour = tours.FirstOrDefault(t => t.TourId == tour.TourId);

            if (existingTour == null)
            {
                // Add the new tour to the Tours table
                await _tourRepo.Add(tour);
            }
            // Connect to Azure Blob Storage
            string connectionString = "BlobEndpoint=http://127.0.0.1:8888/devstoreaccount1;SharedAccessSignature=sv=2021-10-04&ss=btqf&srt=sco&st=2023-08-08T11%3A58%3A28Z&se=2023-08-09T11%3A58%3A28Z&sp=rwdftlacup&sig=ZAMl1zpEMHrcfz9l5isr3PtnXrc0Uss6J8SqvbHGBnc%3D";

            BlobServiceClient blobServiceClient = new BlobServiceClient(connectionString);

            BlobContainerClient containerClient = blobServiceClient.GetBlobContainerClient("samples-workitems");

            // Create the container if it doesn't exist
            containerClient.CreateIfNotExists();

            foreach (var image in images)
            {
                // Generate a unique blob name
                string uniqueBlobName = Guid.NewGuid().ToString() + Path.GetExtension(image.FileName);

                // Upload the image to Azure Blob Storage
                BlobClient blobClient = containerClient.GetBlobClient(uniqueBlobName);
                using (var stream = image.OpenReadStream())
                {
                    await blobClient.UploadAsync(stream, true);
                }

                // Retrieve the newly created Tour entity with updated Id
                var addedTour = await _tourRepo.Get(tour.Id);

                // Create a new image entry and associate it with the tour
                TourImages tourImage = new TourImages
                {
                    TourId = addedTour.TourId, // Use the Id property of the retrieved Tour object
                    ImagePaths = blobClient.Uri.ToString(), // Store Blob Storage URL
                };

                await _tourImageRepo.Add(tourImage);
            }
        }
    }
}
