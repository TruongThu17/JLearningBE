using BusinessObjects.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reporitories
{
    public interface ICourseRepository
    {
        List<Course> GetCourses();

        Course FindCourseById(int id);
    }
}
