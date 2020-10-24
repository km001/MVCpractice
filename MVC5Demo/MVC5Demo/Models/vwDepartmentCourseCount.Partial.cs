namespace MVC5Demo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(vwDepartmentCourseCountMetaData))]
    public partial class vwDepartmentCourseCount
    {
    }
    
    public partial class vwDepartmentCourseCountMetaData
    {
        [Required]
        public int DepartmentID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Name { get; set; }
        public Nullable<int> CourseCount { get; set; }
    }
}
