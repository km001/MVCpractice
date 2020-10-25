﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MVC5Demo.Models
{
    public class DepartmentEdit : IValidatableObject
    {
        public DepartmentEdit()
        {
        }

        [Required]
        public string Name { get; set; }
        [Required]
        [MustBeEven(ErrorMessage = "請輸入偶數的 Budget 資料")]
        public decimal Budget { get; set; }
        public Nullable<System.DateTime> StartDate { get; set; }
        public Nullable<int> InstructorID { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.Name != "Will" && this.Budget < 100)
            {
                yield return new ValidationResult("您的預算不足", new string[] { "Budget" });
            }
        }
    }
}