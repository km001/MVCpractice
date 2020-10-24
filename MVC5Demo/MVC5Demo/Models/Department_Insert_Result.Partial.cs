namespace MVC5Demo.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;
    
    [MetadataType(typeof(Department_Insert_ResultMetaData))]
    public partial class Department_Insert_Result
    {
    }
    
    public partial class Department_Insert_ResultMetaData
    {
        [Required]
        public int DepartmentID { get; set; }
        [Required]
        public byte[] RowVersion { get; set; }
    }
}
