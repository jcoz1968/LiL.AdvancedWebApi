using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
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

        [EnableQuery]
        public SingleResult<Student> Get([FromODataUri]int key)
        {
            IQueryable<Student> result = db.Students.Where(x => x.Id == key);
            return SingleResult.Create(result);
        }
        public async Task<IHttpActionResult> Post(Student student) 
        {
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            db.Students.Add(student);
            await db.SaveChangesAsync();
            return Created(student);
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