namespace MVC5Demo.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    [MetadataType(typeof(CourseMetaData))]
    public partial class Course
    {
    }

    public partial class CourseMetaData
    {
        [Required]
        public int CourseID { get; set; }

        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        [Required]
        public string Title { get; set; }
        [Required]
        public int Credits { get; set; }
        [Required]
        public int DepartmentID { get; set; }

        [StringLength(200, ErrorMessage="欄位長度不得大於 200 個字元")]
        public string Memo { get; set; }

        public virtual Department Department { get; set; }
        public virtual ICollection<Enrollment> Enrollments { get; set; }
        public virtual ICollection<Person> Teachers { get; set; }
    }

    public class CourseBatchEditVM//放在一起方便管理
    {
        [Required]
        public int CourseID { get; set; }

        [StringLength(50, ErrorMessage = "欄位長度不得大於 50 個字元")]
        [Required]
        public string Title { get; set; }
        [Required]
        [Range(1, 5)]
        public int Credits { get; set; }
    }
}
