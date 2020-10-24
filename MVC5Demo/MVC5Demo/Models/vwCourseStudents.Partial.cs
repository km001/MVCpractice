namespace MVC5Demo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(vwCourseStudentsMetaData))]
    public partial class vwCourseStudents
    {
    }
    
    public partial class vwCourseStudentsMetaData
    {
        public Nullable<int> DepartmentID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string DepartmentName { get; set; }
        [Required]
        public int CourseID { get; set; }
        
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string CourseTitle { get; set; }
        public Nullable<int> StudentID { get; set; }
        
        [StringLength(101, ErrorMessage="欄位長度不得大於 101 個字元")]
        public string StudentName { get; set; }
    }
}
