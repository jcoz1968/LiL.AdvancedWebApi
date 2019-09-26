using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApi.OData.Models
{
    public class AppDbContext:DbContext
    {
        public AppDbContext():base()
        {
            this.Database.Connection.ConnectionString = @"Data Source=(localdb)\mssqllocaldb; Integrated Security=true; Initial Catalog=schooldb";
        }
        public DbSet<Student> Students { get; set; }
    }
}