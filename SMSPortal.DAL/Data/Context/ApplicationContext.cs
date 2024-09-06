using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using SMSPortal.DAL.Data.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace SMSPortal.DAL.Data.Context
{
    public class ApplicationContext: IdentityDbContext<ApplicationUser>
    {
        public DbSet<MessageTemplete> MessageTempletes { get; set; }
        public DbSet <Report>  Reports { get; set; }
        public ApplicationContext(DbContextOptions options) : base(options)
        {
 
        }
        
    }
}
