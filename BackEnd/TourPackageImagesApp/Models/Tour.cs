using System.ComponentModel.DataAnnotations;

namespace TourPackageImagesApp.Models
{
    public class Tour
    {

        [Key]
        public int Id { get; set; }
        public int TourId { get; set; }
    }
}
