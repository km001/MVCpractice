namespace MVC5Demo.Models
{
    using Newtonsoft.Json;
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Web.Script.Serialization;

    [MetadataType(typeof(DepartmentMetaData))]
    public partial class Department : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Name != "Will" && this.Budget > 100)
            {
                yield return new ValidationResult("您的預算不足", new string[] { "Budget" });
            }
        }
    }

    public partial class DepartmentMetaData
    {
        //[Required]
        public int DepartmentID { get; set; }

        [Required]
        [StringLength(50, ErrorMessage="欄位長度不得大於 50 個字元")]
        public string Name { get; set; }
        [Required]
        [MustBeEven]
        public decimal Budget { get; set; }
        [Required]
        [DataType(DataType.Date)]//只有用日期，所以限制
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]//DisplayFormat顯示格式不是用編輯
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> InstructorID { get; set; }
        //[Required]
        public byte[] RowVersion { get; set; }
        [ScriptIgnore]
        public virtual ICollection<Course> Course { get; set; }//留著沒差，但可註解 buddy是認名字對
        public virtual Person Person { get; set; }
    }
}
