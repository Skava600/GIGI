using Microsoft.AspNetCore.Identity;

namespace Web_953501_Skavarodnik.Entities
{
    public class ApplicationUser: IdentityUser
    {
        public byte[] AvatarImage { get; set; }
    }
}
