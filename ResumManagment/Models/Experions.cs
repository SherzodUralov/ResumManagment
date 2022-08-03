using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ResumManagment.Models
{
    public class Experions
    {
        [Key]
        public int  Id { get; set; }
        [ForeignKey("Applicat")]
        public int ApplicaId { get; set; }
        public Applicat Applicat { get; set; }
        public string CompanyName { get; set; }
        public string Designation { get; set; }
        [Range(1, 25, ErrorMessage = "Years must be between 1 snd 25")]
        [Required]
        public int YearsWorked { get; set; }
    }
}
