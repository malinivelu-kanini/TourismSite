using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TourPackageImagesApp.Models
{
    public class TourImages
    {
        [Key]
        public int ImageId { get; set; }
        public int TourId { get; set; }

        [ForeignKey(nameof(TourId))]
        [JsonIgnore]

        public Tour? Tour { get; set; } 

        public string? ImagePaths { get; set; }
        [NotMapped]
        public List<IFormFile> Images { get; set; }
    }
}
