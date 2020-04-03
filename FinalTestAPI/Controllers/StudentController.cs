using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using LogicLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Pocos;
using RepoLayer;

namespace FinalTestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly Logic _logic;
        private readonly EFCrud _crud;

        public StudentController()
        {
            _logic = new Logic();
            _crud = new EFCrud();
        }
        [HttpGet]
        [Route("student/{id}")]
        public ActionResult Get(Guid id)
        {
            var student = _crud.GetStudent(id);
            if(student == null)
            {
                return NotFound();
            }
            return Ok(student);
        }
        [HttpPost]
        [Route("student")]
        public ActionResult Post([FromBody] Student student)
        {
            _logic.VerifyStudent(student);
            _crud.Add<Student>(student);
            return Ok();
        }
        [HttpPut]
        [Route("student")]
        public ActionResult Put([FromBody] Student student)
        {
            _logic.VerifyStudent(student);
            _crud.Update<Student>(student);
            return Ok();
        }
        [HttpDelete]
        [Route("student")]
        public ActionResult Delete([FromBody] Student student)
        {
            _logic.VerifyStudent(student);
            _crud.Delete<Student>(student);
            return Ok();
        }
    }
}