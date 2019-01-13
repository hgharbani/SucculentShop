using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.ViewModel
{
    public class RegisterViewModel
    {
        [DisplayName(displayName: "نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        public string UserName { get; set; }
        [DisplayName(displayName: "حساب الکترونیکی")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده  معتبر نمی باشد")]
        public string Email { get; set; }
        [DisplayName(displayName: "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [DataType(dataType: DataType.Password)]
        public string Password { get; set; }
        [DisplayName(displayName: "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [DataType(dataType: DataType.Password)]
        [Compare(otherProperty: "Password", ErrorMessage = "کلمه های عبور یکسان نمی باشند")]
        public string RePassword { get; set; }
    }

    public class LoginViewModel
    {
        [DisplayName(displayName: "حساب کاربری")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده  معتبر نمی باشد")]
        public string Email { get; set; }
        [DisplayName(displayName: "کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [DataType(dataType: DataType.Password)]
        public string Password { get; set; }
        [DisplayName(displayName: "مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }

    public class ForgetPasswordViewModel
    {
        [DisplayName(displayName: "حساب کاربری")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده  معتبر نمی باشد")]
        public string Email { get; set; }
    }

    public class RecoveyPasswordViewModel
    {
        [DisplayName(displayName: "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [DataType(dataType: DataType.Password)]
        public string Password { get; set; }
        [DisplayName(displayName: "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [DataType(dataType: DataType.Password)]
        [Compare(otherProperty: "Password", ErrorMessage = "کلمه های عبور یکسان نمی باشند")]
        public string RePassword { get; set; }
    }

    public class ChangePasswordViewModel
    {
        [DisplayName(displayName: "  رمز عبور قبلی")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [DataType(dataType: DataType.Password)]
        public string OldPassword { get; set; }

        [DisplayName(displayName: "رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [DataType(dataType: DataType.Password)]
        public string Password { get; set; }
        [DisplayName(displayName: "تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [DataType(dataType: DataType.Password)]
        [Compare(otherProperty: "Password", ErrorMessage = "کلمه های عبور یکسان نمی باشند")]
        public string RePassword { get; set; }
    }
}
