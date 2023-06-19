using BusinessObjects.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CourseDAO
    {
        public static List<Course> GetCourses()
        {
            var listCourses = new List<Course>();
            try
            {
                using (var context = new JlearningContext())
                {
                    listCourses = context.Courses
                        .Include(x => x.Chapters)
                        .ToList();
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return listCourses;
        }
        public static Course FindCourseById(int id)
        {
            Course course = new Course();
            try
            {
                using (var context = new JlearningContext())
                {
                    course = context.Courses.Include(u => u.Chapters).SingleOrDefault(x => x.CourseId == id);
                }
            }
            catch (Exception e)
            {

                throw new Exception(e.Message);
            }
            return course;
        }
    }
}
