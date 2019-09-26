using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApi.DI.Models;

namespace WebApi.DI.Data
{
    public class StudentRepository : IStudentRepository
    {
        public IEnumerable<Student> GetAll()
        {
            return GetStudentsFromDb();
        }

        public Student GetStudentById(int id)
        {
            return GetStudentsFromDb().FirstOrDefault(n => n.Id == id);
        }

        private IEnumerable<Student> GetStudentsFromDb()
        {
            List<Student> students = new List<Student>()
            {
                new Student
                {
                    Id = 1,
                    FullName = "John Smith",
                    GPA = 3.5
                },

                new Student
                {
                    Id = 2,
                    FullName = "Jimmy Wright",
                    GPA = 3.9
                }
            };

            return students;
        }
    }
}