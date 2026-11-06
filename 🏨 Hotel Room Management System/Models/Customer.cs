using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace __Hotel_Room_Management_System.Models
{
    public class Customer
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Eneter a Valid FullName.")]
        [MinLength(8,ErrorMessage ="FullName mustn't be less than 8 characters")]
        [MaxLength(30, ErrorMessage = "FullName mustn't be exceed than 30 characters")]
        public string FullName { get; set; }

        [Required(ErrorMessage = "Eneter a Valid Phone.")]
        [MinLength(1, ErrorMessage = "Phone mustn't be less than 11 number")]
        [MaxLength(11, ErrorMessage = "Phone mustn't be exceed than 11 number")]
        public string Phone { get; set; }


        [ValidateNever]
        [NotMapped]
        public IFormFile? ImageFile { get; set; }


        public string? ImagePath { get; set; }

    }
}
