using ADP.Solution.Identity.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ADP.Solution.Identity
{
    public class ADPIdentityDbContext : IdentityDbContext<ApplicationUser>
    {
        public ADPIdentityDbContext(DbContextOptions<ADPIdentityDbContext> options) : base(options)
        {
        }
    }
}
