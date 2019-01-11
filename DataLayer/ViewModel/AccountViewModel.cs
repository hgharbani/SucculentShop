using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace DataLayer.ViewModel
{
    public class RegisterViewModel
    {
        [DisplayName("نام کاربری")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        public string UserName { get; set; }
        [DisplayName("حساب الکترونیکی")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده  معتبر نمی باشد")]
        public string Email { get; set; }
        [DisplayName("رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("تکرار رمز عبور")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [DataType(DataType.Password)]
        [Compare("Password", ErrorMessage = "کلمه های عبور یکسان نمی باشند")]
        public string RePassword { get; set; }
    }

    public class LoginViewModel
    {
        [DisplayName("حساب کاربری")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده  معتبر نمی باشد")]
        public string Email { get; set; }
        [DisplayName("کلمه عبور")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
        [DisplayName("مرا به خاطر بسپار")]
        public bool RememberMe { get; set; }
    }

    public class ForgetPasswordViewModel
    {
        [DisplayName("حساب کاربری")]
        [Required(ErrorMessage = "لطفا {0} وارد شود.")]
        [EmailAddress(ErrorMessage = "ایمیل وارد شده  معتبر نمی باشد")]
        public string Email { get; set; }
    }
}
