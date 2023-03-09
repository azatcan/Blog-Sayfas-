using EntityLayer.Entities;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Context
{       
        public class DataContext : IdentityDbContext<AppUser,AppRole,int>
        {
            public DataContext()
            {

            }
            public DataContext(DbContextOptions<DataContext> options) : base(options)
            {

            }

            public DbSet<Article> Articles { get; set; }
            public DbSet<Comments> Comments { get; set; }
            public DbSet<Category> Categories { get; set; }
            

        }
}

