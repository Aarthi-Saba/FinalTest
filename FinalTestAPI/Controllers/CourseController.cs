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
    public class CourseController : ControllerBase
    {
        private readonly Logic _logic;
        private readonly EFCrud _crud;

        public CourseController()
        {
            _logic = new Logic();
            _crud = new EFCrud();
        }
        [HttpGet]
        [Route("course/{id}")]
        public ActionResult Get(Guid id)
        {
            var course = _crud.GetCourse(id);
            if (course == null)
            {
                return NotFound();
            }
            return Ok(course);
        }
        [HttpPost]
        [Route("course")]
        public ActionResult Post([FromBody] Course course)
        {
            _logic.VerifyCourse(course);
            _crud.Add<Course>(course);
            return Ok();
        }
        [HttpPut]
        [Route("course")]
        public ActionResult Put([FromBody] Course course)
        {
            _logic.VerifyCourse(course);
            _crud.Update<Course>(course);
            return Ok();
        }
        [HttpDelete]
        [Route("course")]
        public ActionResult Delete([FromBody] Course course)
        {
            _logic.VerifyCourse(course);
            _crud.Delete<Course>(course);
            return Ok();
        }
    }
}