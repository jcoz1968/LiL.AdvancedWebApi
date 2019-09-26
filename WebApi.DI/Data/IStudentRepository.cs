using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebApi.DI.Models;

namespace WebApi.DI.Data
{
    public interface IStudentRepository
    {
        IEnumerable<Student> GetAll();
        IEnumerable<StudentV2> GetAllV2();
        Student GetStudentById(int id);
    }
}
