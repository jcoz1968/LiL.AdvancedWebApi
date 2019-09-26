using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.OData.Models
{
    public class AppDbContext : DbContext
    {
        public DbSet<Student> Students { get; set; }
        public AppDbContext() : base()
        {

        }
    }
}