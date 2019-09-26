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
            return GetStudentsFromDbV1();
        }

        public IEnumerable<StudentV2> GetAllV2()
        {
            return GetStudentsFromDbV2();
        }

        public Student GetStudentById(int id)
        {
            return GetStudentsFromDbV1().FirstOrDefault(n => n.Id == id);
        }

        private IEnumerable<Student> GetStudentsFromDbV1()
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

        private IEnumerable<StudentV2> GetStudentsFromDbV2()
        {
            List<StudentV2> students = new List<StudentV2>()
            {
                new StudentV2
                {
                    Id = 1,
                    FullName = "John Smith",
                    GPA = 3.5,
                    Age = 20
                },

                new StudentV2
                {
                    Id = 2,
                    FullName = "Jimmy Wright",
                    GPA = 3.9,
                    Age = 19
                }
            };

            return students;
        }
    }
}