using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WebApi.OData.Models
{
    public class Student
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public double GPA { get; set; }

    }
}