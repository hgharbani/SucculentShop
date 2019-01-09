﻿//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer
{
    public class UserMetaData
    {
        [Key]
        public int UserId { get; set; }
        [DisplayName("نوع کاربری"),
     Required(ErrorMessage = "لطفا {0} وارد شود.")]
        public int RoleId { get; set; }
        [DisplayName("نام کاربری"),
        Required(ErrorMessage = "لطفا {0} وارد شود.")]
        public string UserName { get; set; }
        [DisplayName("شماره پرسنلی"),
        Required(ErrorMessage = "لطفا {0} وارد شود.")]
        public string Password { get; set; }
        [DisplayName("ایمیل "),
        Required(ErrorMessage = "لطفا {0} وارد شود.")]
        public string Email { get; set; }
        [DisplayName("کد فعال سازی"),
        Required(ErrorMessage = "لطفا {0} وارد شود.")]
        public string ActiveCode { get; set; }
        [DisplayName("فعال"),
       Required(ErrorMessage = "لطفا {0} وارد شود.")]
        public bool IsActive { get; set; }
        [DisplayName("تاریخ ثبت"),
       DataType(DataType.Date),
       Required(ErrorMessage = "لطفا {0} وارد شود.")]
        public System.DateTime RegisterDate { get; set; }
    }
}