using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace Domain
{
    public class User : IdentityUser
    {
        public string ProfilePicture { get; set; }
        public Wardrobe Wardrobe { get; set; }
    }
}