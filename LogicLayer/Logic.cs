using Pocos;
using System;
using System.Collections.Generic;

namespace LogicLayer
{
    public class Logic
    {
        public void VerifyStudent(Student student)
        {
            List<ExceptionDetails> explist = new List<ExceptionDetails>();
            if (string.IsNullOrEmpty(student.StudentName))
            {
                explist.Add(new ExceptionDetails(101,$"Student Name cannot be empty"));
            }
            if( student.BatchInfo.Length < 3)
            {
                explist.Add(new ExceptionDetails(102, $"Batch number of student {student.BatchInfo} should be atleast 3 char long"));
            }
            if (explist.Count > 0)
            {
                throw new AggregateException(explist);
            }
        }
        public void VerifyCourse(Course course)
        {
            List<ExceptionDetails> explist = new List<ExceptionDetails>();
            if (string.IsNullOrEmpty(course.CourseName))
            {
                explist.Add(new ExceptionDetails(103, $"Course Name cannot be empty"));
            }
            if (course.StartDate > DateTime.Now)
            {
                explist.Add(new ExceptionDetails(104,$"Start Date {course.StartDate} should be greater than present Date"));
            }
            if (course.EndDate < course.StartDate)
            {
                explist.Add(new ExceptionDetails(105,$"End Date {course.EndDate} cannot be before the Course Start Date {course.StartDate}"));
            }
            if (explist.Count > 0)
            {
                throw new AggregateException(explist);
            }
        }
    }
    public class ExceptionDetails : Exception
    {
        public int ErrorCode { get; set; }
        public ExceptionDetails(int code, string message) : base(message)
        {
            ErrorCode = code;
        }
    }
}
