using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace TourPackageApp.Models
{
    public class Inclusion
    {
        [Key]
        public int InclusionId { get; set; }

        public int TourId { get; set; }
        [ForeignKey("TourId")]
        [JsonIgnore]

        public string? Accommodation { get; set; }
        public string? Meals { get; set; }
        public string? Transfer { get; set; }
        public int TotalNights { get; set; }
        public int TotalDays { get; set; }
        public ICollection<TotalDaysDescription>? TotalDaysDescriptions { get; set; }
    }
}
