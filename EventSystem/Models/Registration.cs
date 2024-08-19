using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace EventSystem.Models
{
    public class Registration
    {
        public int Id { get; set; }
        public int EventId { get; set; }
        public Event Event { get; set; }
        public string UserId { get; set; }
        public IdentityUser User { get; set; } 
        public string ReferenceNumber { get; set; }

        [Required(ErrorMessage = "Email is required.")]
        [EmailAddress(ErrorMessage = "Invalid email address.")]
        public string EmailAddress { get; set; }
       
    }
}
