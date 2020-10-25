using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace MVC5Demo.Models
{
    public class MustBeEvenAttribute :DataTypeAttribute
    {
        public MustBeEvenAttribute() : base(DataType.Text)
        {
            ErrorMessage = "請輸入偶數";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;//本來就有[Required]驗證是否需要填，所以自訂驗證遇到null要回傳true
            }
            int data = Convert.ToInt32(value);//
            //int data = (int)value;//不能轉

            return (data % 2 == 0);
            //return base.IsValid(value);
        }
    }
}