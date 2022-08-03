using Microsoft.AspNetCore.Mvc.Rendering;
using ResumManagment.Models;

namespace ResumManagment.Repository
{
    public interface IApplicatRepo
    {
        IList<Applicat> GetAll();
        Applicat GetById(int id);   
        void Create(Applicat applicat);
        void Update(Applicat applicat);
        void Delete(Applicat applicat);
        List<SelectListItem> GetGender();
    }
}
