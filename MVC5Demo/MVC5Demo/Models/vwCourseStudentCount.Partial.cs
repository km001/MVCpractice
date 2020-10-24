namespace MVC5Demo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(vwCourseStudentCountMetaData))]
    public partial class vwCourseStudentCount
    {
    }
    
    public partial class vwCourseStudentCountMetaData
    {
        public Nullable<int> DepartmentID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Name { get; set; }
        [Required]
        public int CourseID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Title { get; set; }
        public Nullable<int> StudentCount { get; set; }
    }
}
