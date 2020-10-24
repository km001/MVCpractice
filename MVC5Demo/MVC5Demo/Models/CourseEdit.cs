using System;
using System.Collections.Generic;

namespace MVC5Demo.Models
{
    public class CourseEdit
    {
        public string Title { get; set; }
        public int Credits { get; set; }
        public int DepartmentID { get; set; }
        public string Memo { get; set; }
    }
}