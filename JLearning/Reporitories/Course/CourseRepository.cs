using BusinessObjects.Models;
using DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporitories
{
    public class CourseRepository : ICourseRepository
    {
        public Course FindCourseById(int id) =>CourseDAO.FindCourseById(id);

        public List<Course> GetCourses() =>CourseDAO.GetCourses();
    }
}
