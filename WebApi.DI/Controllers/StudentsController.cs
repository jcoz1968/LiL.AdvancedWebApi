﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using WebApi.DI.Data;

namespace WebApi.DI.Controllers
{
    public class StudentsController : ApiController
    {
        private StudentRepository _repository = new StudentRepository();

        public StudentsController()
        {
        }

        public IHttpActionResult Get()
        {
            return Ok(_repository.GetAll());
        }
    }
}
