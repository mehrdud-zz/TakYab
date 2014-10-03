using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity;
using System.Globalization;
using System.Web.Security;

namespace TakYab.Models
{
    public class UsersContext : DbContext
    {
        public UsersContext()
            : base("DefaultConnection")
        {
        }

        public DbSet<UserProfile> UserProfiles { get; set; }
    }

    [Table("UserProfile")]
    public class UserProfile
    {
        [Key]
        [DatabaseGeneratedAttribute(DatabaseGeneratedOption.Identity)]
        public int UserId { get; set; }
        public string UserName { get; set; }
    }

    public class RegisterExternalLoginModel
    {
        [Required]
        [Display(Name = "اسم کاربری")]
        public string UserName { get; set; }

        public string ExternalLoginData { get; set; }
    }

    public class LocalPasswordModel
    {
        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "رمز ورود فعلی")]
        public string OldPassword { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "طول رمز ورود مجاز {2} کاراکتر میباشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز ورود جدید")]
        public string NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تایید رمز ورود جدید")]
        [Compare("NewPassword", ErrorMessage = "رمز ورود و تاید رمز ورود متفاوت هستند!")]
        public string ConfirmPassword { get; set; }
    }

    public class LoginModel
    {
        [Required]
        [Display(Name = "اسم کاربری")]
        public string UserName { get; set; }

        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "رمز ورود")]
        public string Password { get; set; }

        [Display(Name = "من را بخاطر بسپار")]
        public bool RememberMe { get; set; }
    }

    public class RegisterModel
    {
        [Required]
        [Display(Name = "اسم کاربری")]
        public string UserName { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "طول رمز ورود مجاز {2} کاراکتر میباشد", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "رمز ورود")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "تایید رمز ورود")]
        [Compare("Password", ErrorMessage = "رمز ورود و تاید رمز ورود متفاوت هستند!")]
        public string ConfirmPassword { get; set; }
    }

    public class ExternalLogin
    {
        public string Provider { get; set; }
        public string ProviderDisplayName { get; set; }
        public string ProviderUserId { get; set; }
    }
}
