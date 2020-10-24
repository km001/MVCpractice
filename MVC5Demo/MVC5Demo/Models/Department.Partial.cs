using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models
{
    [MetadataType(typeof(DepartmentMetaData))]//[MetadataType(typeof(DepartmentMetaData))] 表示Department的驗證屬性到DepartmentMetaData找
    public partial class Department//擴充
    {
        public class DepartmentMetaData
        {
            public int DepartmentID { get; set; }
            public string Name { get; set; }
            public decimal Budget { get; set; }
            [Required]//必填
            public Nullable<System.DateTime> StartDate { get; set; }
            [Required]
            public Nullable<int> InstructorID { get; set; }
            public byte[] RowVersion { get; set; }
        }
    }
}