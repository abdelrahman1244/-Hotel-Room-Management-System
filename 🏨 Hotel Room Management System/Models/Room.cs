using System.ComponentModel.DataAnnotations;

namespace __Hotel_Room_Management_System.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Enter a valid Room Number")]
        public int RoomNumber { get; set; }


        [Required(ErrorMessage = "You have to provide a valid Type")]
        public string Type { get; set; }


        [Range(100,double.MaxValue, ErrorMessage = "Choose a valid Price")]
        public decimal PricePerNight { get; set; }
    }
}
