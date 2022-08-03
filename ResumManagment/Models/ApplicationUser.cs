using Microsoft.AspNetCore.Identity;

namespace ResumManagment.Models
{
    public class ApplicationUser :IdentityUser
    {
        public string City { get; set; }
    
    }
}
