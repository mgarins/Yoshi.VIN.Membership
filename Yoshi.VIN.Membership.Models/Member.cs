using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Yoshi.VIN.Membership.Models
{
    [Table("Member", Schema = "dbo")]
    public class Member
    {
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        [Column(@"Id", Order = 1, TypeName = "bigint")]
        [Required]
        [Key]
        [Display(Name = "Id")]
        public long ID { get; set; }

        [Column(@"UserName", Order = 2)]
        [Required(ErrorMessage = "* Required")]
        [StringLength(12, MinimumLength = 4, ErrorMessage = "* {0} must be between {2} and {1} characters in length.")]
        [DataType(DataType.Text)]
        [Display(Name = "User name")]
        public string UserName { get; set; }

        [Column(@"LastName", Order = 3)]
        [Required(ErrorMessage = "* Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "* {0} must be between {2} and {1} characters in length.")]
        [DataType(DataType.Text)]
        [Display(Name = "Last name")]
        public string LastName { get; set; }

        [Column(@"FirstName", Order = 4)]
        [Required(ErrorMessage = "* Required")]
        [StringLength(100, MinimumLength = 2, ErrorMessage = "* {0} must be between {2} and {1} characters in length.")]
        [DataType(DataType.Text)]
        [Display(Name = "First name")]
        public string FirstName { get; set; }

        [Column(@"Email", Order = 5)]
        [Required(ErrorMessage = "* Required")]
        [StringLength(75)]
        [RegularExpression(@"^[A-Za-z0-9](([_\.\-]?[a-zA-Z0-9]+)*)@([A-Za-z0-9]+)(([\.\-]?[a-zA-Z0-9]+)*)\.([A-Za-z]{2,})$",
             ErrorMessage = "* Not a valid {0}")]
        [DataType(DataType.EmailAddress)]
        [Display(Name = "Email")]
        public string Email { get; set; }

        [Column(@"PhoneNumber", Order = 6)]
        [StringLength(10, MinimumLength = 10, ErrorMessage = "* {0} must be between {2} and {1} characters in length.")]
        [DataType(DataType.Text)]
        [RegularExpression(@"^[0-9]{45}*$", ErrorMessage = "* Not a valid {0}")]
        [Display(Name = "Phone Number")]
        public string PhoneNumber { get; set; }

        [Column(@"DOB", Order = 7, TypeName = "smalldatetime")]
        [Required(ErrorMessage = "* Required")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:MM-dd-yyyy}", ApplyFormatInEditMode = true)]
        [Display(Name = "DOB")]
        public DateTime DOB { get; set; }

    }
}
