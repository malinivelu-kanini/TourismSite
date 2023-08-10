using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text.Json.Serialization;

namespace TourBookingApp.Models
{
    public class UserTourBooking
    {
        [Key]
        public  int BookingUserId { get; set; }
        public  int BookingId { get; set; }
        [ForeignKey("BookingId")]
        [JsonIgnore]

        public Booking? Booking { get; set; }
        public string? BookingUserName { get; set; }

        public  string? BookingUserPhnNo { get; set; }
        public  string? BookingUserEmail { get; set; }
        public  string? BookingUserGender { get; set; }

    }
}
