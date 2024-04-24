using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class LoginVM
    {
        [Display(Name = "Phone number")]
        [Required(ErrorMessage = "*")]
        [MaxLength(10, ErrorMessage = "Max is 10 words")]
        [RegularExpression(@"0[9875]\d{8}", ErrorMessage = "Phone number not valid")]
        public string PhoneNumber { get; set; }

        [Display(Name = "Password")]
        [Required(ErrorMessage = "*")]
        [DataType(DataType.Password)]
        public string Password { get; set; }
    }
}
