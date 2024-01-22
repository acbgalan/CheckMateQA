using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using CheckMateQA.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace CheckMateQA.DataAccess.Data
{
    public class AuthentificationContext : IdentityDbContext<ApplicationUser>
    {
        public AuthentificationContext(DbContextOptions<AuthentificationContext> options) : base(options)
        {
        }
    }
}
