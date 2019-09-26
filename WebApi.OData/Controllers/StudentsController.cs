using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.OData.Models;

namespace WebApi.OData.Controllers
{
    public class StudentsController:ODataController
    {
        AppDbContext db = new AppDbContext();

        [EnableQuery]
        public IQueryable<Student> Get()
        {
            return db.Students;
        }

        private bool StudentExists(int key)
        {
            return db.Students.Any(n => n.Id == key);
        }

        protected override void Dispose(bool disposing)
        {
            db.Dispose();
            base.Dispose(disposing);
        }
    }
}