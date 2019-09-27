using Microsoft.AspNet.OData;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
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

        public async Task<IHttpActionResult> Put([FromODataUri]int key, Student student)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            if(key != student.Id)
            {
                return BadRequest();
            }
            db.Entry(student).State = EntityState.Modified;
            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {

                if(!StudentExists(key))
                {
                    return NotFound();
                }
                throw;
            }
            return Updated(student);
        }

        public async Task<IHttpActionResult> Delete([FromODataUri]int key)
        {
            var student = await db.Students.FindAsync(key);
            if(student == null)
            {
                return NotFound();
            }
            db.Students.Remove(student);
            await db.SaveChangesAsync();
            return StatusCode(HttpStatusCode.NoContent);
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