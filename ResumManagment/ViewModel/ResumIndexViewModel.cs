using ResumManagment.Models;

namespace ResumManagment.ViewModel
{
    public class ResumIndexViewModel
    {
        public IList<Applicat> Applicats { get; set; }
        public string Title { get; set; }
        public Applicat Applicat { get; set; }
    }
}
