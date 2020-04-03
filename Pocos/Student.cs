using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Pocos
{
    [Table("Students")]
    public class Student
    {
        [Key]
        public Guid StudentId { get; set; }
        public string StudentName { get; set; }
        public Guid CourseId { get; set; }
        public string BatchInfo { get; set; }
        public virtual Course StudentCourse { get; set; }
    }
}
