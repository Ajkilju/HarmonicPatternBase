using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace HarmonicPatternsBase.Models
{
    public class ApplicationUser : IdentityUser
    {
        public List<HarmonicPattern> HarmonicPatterns { get; set; }
        public byte[] Avatar { get; set; }
    }
}
