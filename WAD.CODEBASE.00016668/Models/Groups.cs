using System.ComponentModel.DataAnnotations;

namespace WAD.CODEBASE._00016668.Models
{
    public class Groups
    {
        [Key]
        public int GroupId { get; set; }
        public string GroupName { get; set; }

        // navigation property
        [Required]
        public ICollection<Contacts> Contacts { get; set; }
    }
}
