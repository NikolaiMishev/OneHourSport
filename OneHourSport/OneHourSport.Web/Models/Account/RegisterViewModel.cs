namespace OneHourSport.Web.Models.Account
{
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Web;

    public class RegisterViewModel
    {
        [Required]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Required]
        [StringLength(100, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 6)]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }

        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} characters long.", MinimumLength = 2)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} characters long.", MinimumLength = 2)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Required]
        [StringLength(9, ErrorMessage = "The Phone number must be exactly {2} characters long.", MinimumLength = 9)]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Only diggits are alowed!")]
        [Display(Name = "Phone number: (+359)")]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "The {0} must be atleast {2} characters long.", MinimumLength = 5)]
        [Index(IsUnique = true)]
        [Display(Name = "Username")]
        public string UserName { get; set; }

        [Display(Name = "Have Complex?")]
        public bool IsComplex { get; set; }

        [Required]
        public HttpPostedFileBase ProfilePicture { get; set; }
    }
}