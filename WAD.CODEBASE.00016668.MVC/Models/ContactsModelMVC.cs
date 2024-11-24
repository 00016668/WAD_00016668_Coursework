using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace WAD.CODEBASE._00016668.MVC.Models
{
    public class ContactsModelMVC
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int ID { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "First Name cannot be longer than 50 characters.")]
        [DisplayName("First name")]
        public string FirstName { get; set; }


        [Required]
        [StringLength(50, ErrorMessage = "Last Name cannot be longer than 50 characters.")]
        [DisplayName("Last name")]
        public string LastName { get; set; }


        [Required]
        [Phone]
        [DisplayName("Phone number")]
        public string PhoneNumber { get; set; }


        [DisplayName("Email")]
        [EmailAddress]
        public string Email { get; set; }


        [DisplayName("Date of birth")]
        [DataType(DataType.Date)]
        public DateTime? DateOfBirth { get; set; }

        [DisplayName("Group name")]
        public string GroupName { get; set; }
    }
}
