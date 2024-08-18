using Microsoft.AspNetCore.Identity;

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
        public string EmailAddress { get; set; }
       
    }
}
