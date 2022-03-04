using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;

namespace WordPlay.Models
{
    public class CustomUserValidator : IUserValidator<User>
    {
        public Task<IdentityResult> ValidateAsync(UserManager<User> manager, User user)
        {
            List<IdentityError> errors = new List<IdentityError>();
            if (user.Email.ToLower().EndsWith("@spam.com"))
            {
                errors.Add(new IdentityError
                {
                    Description = "Укажите другой email адресс"
                });
            }
            if (user.UserName.Contains("admin"))
            {
                errors.Add(new IdentityError
                {
                    Description = "Ник пользователя не должен содержать слово 'admin'"
                });
            }
            return Task.FromResult(errors.Count == 0 ?
                IdentityResult.Success : IdentityResult.Failed(errors.ToArray()));
        }
    }
}
