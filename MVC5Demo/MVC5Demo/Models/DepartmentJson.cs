using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models
{
    public class DepartmentJson
    {
        public DepartmentJson()
        {
        }

        public int DepartmentID { get; set; }
        public string Name { get; set; }
        public decimal Budget { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> InstructorID { get; set; }
        public bool IsDeleted { get; set; }
    }
}