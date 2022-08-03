using System.ComponentModel.DataAnnotations;

namespace ResumManagment.Models
{
    public class Applicat
    {
        [Key]
        public int  Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Gender { get; set; }
        [Required]
        public int Age { get; set; }
        [Required]
        public string Qualification { get; set; }
        [Required]
        public int TotalExperions { get; set; }
        public IList<Experions> Experions { get; set; } = new List<Experions>();
    }
}
