using System.ComponentModel.DataAnnotations;

namespace WebApplication1.ViewModels
{
    public class RegisterVM
    {
        //[Key]
        //public int CustomerId { get; set; }

        [Display(Name = "First Name")]
        [Required(ErrorMessage = "*")]
        [MaxLength(20, ErrorMessage = "Max is 20 words")]
        public string FirstName { get; set; }

        [Display(Name = "Last Name")]
        [MaxLength(20, ErrorMessage = "Max is 20 words")]
        [Required(ErrorMessage = "*")]
        public string LastName { get; set; }

        [Display(Name = "Email")]
        [Required(ErrorMessage = "*")]
        [EmailAddress(ErrorMessage = "Email not valid")]
        public string Email { get; set; }    

        [Display(Name = "Address")]
        [MaxLength(60, ErrorMessage = "Max is 60 words")]
        public string Address { get; set; }

        [Display(Name = "Phone")]
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
