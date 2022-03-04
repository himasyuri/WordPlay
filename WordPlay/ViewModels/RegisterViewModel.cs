using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace WordPlay.ViewModels
{
    public class RegisterViewModel
    {

        [Required]
        [Display(Name ="Email")]
        public string Email { get; set; }

        [Required]
        [Display(Name ="Nickname")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Пароль")]
        public string Password { get; set; }

        [Required]
        [Compare("Password", ErrorMessage = "Пароли не совпадают")]
        [DataType(DataType.Password)]
        [Display(Name = "Подтвердить пароль")]
        public string PasswordConfirm { get; set; }

        public RegisterViewModel(string email, string userName, string password, string passwordConfirm)
        {
            Email = email;
            UserName = userName;
            Password = password;
            PasswordConfirm = passwordConfirm;
        }
    }
}
