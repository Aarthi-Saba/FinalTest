using Pocos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace RepoLayer
{
    public class EFCrud
    {
        private readonly DataContext _context;

        public EFCrud()
        {
            _context = new DataContext();
        }
        public void Add<T>(T poco)
        {
            _context.Add(poco);
            _context.SaveChanges();
        }
        public Student GetStudent(Guid id)
        {
            return _context.Students.Where(s => s.StudentId == id).FirstOrDefault();

        }
        public Course GetCourse(Guid id)
        {
            return _context.Courses.Where(c => c.CourseId == id).FirstOrDefault();
        }
        public void Update<T>(T poco)
        {
            _context.Update(poco);
            _context.SaveChanges();
        }
        public void Delete<T>(T poco)
        {
            _context.Remove(poco);
            _context.SaveChanges();
        }
    }
}
