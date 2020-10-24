using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC5Demo.Models
{
    public class DepartmentEdit
    {
        public DepartmentEdit()
        {
        }

        public string Name { get; set; }
        public decimal Budget { get; set; }
        public System.DateTime StartDate { get; set; }
        public Nullable<int> InstructorID { get; set; }
    }
}