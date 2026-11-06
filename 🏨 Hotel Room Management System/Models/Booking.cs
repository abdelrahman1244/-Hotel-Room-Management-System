using System.ComponentModel.DataAnnotations;

namespace __Hotel_Room_Management_System.Models
{
    public class Booking
    {
        public int Id { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a room.")]
        public int RoomId { get; set; }

        [Range(1, int.MaxValue, ErrorMessage = "Please select a customer.")]
        public int CustomerId { get; set; }

        [Required(ErrorMessage = "Check In is required.")]
        public DateTime CheckIn { get; set; }

        [Required(ErrorMessage = "Check Out is required.")]
        public DateTime CheckOut { get; set; }

        public Room Room { get; set; }

        public Customer Customer { get; set; }



    }
}
