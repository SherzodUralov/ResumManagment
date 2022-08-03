using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using ResumManagment.Data;
using ResumManagment.Models;

namespace ResumManagment.Repository
{
    public class ApplicatRepo : IApplicatRepo
    {
        private readonly AppDbContext context;

        public ApplicatRepo(AppDbContext context)
        {
            this.context = context;
        }

        public void Create(Applicat applicat)
        {
            context.Applicats.Add(applicat);
            context.SaveChanges();
        }

        public void Delete(Applicat applicat)
        {
            context.Applicats.Remove(applicat);
            context.SaveChanges();
        }

        public IList<Applicat> GetAll()
        {
            return context.Applicats.ToList();
        }

        public Applicat GetById(int id)
        {
            return context.Applicats.Include(e => e.Experions).Where(a => a.Id == id).FirstOrDefault();
        }

        public List<SelectListItem> GetGender()
        {
            List<SelectListItem> selecgender = new List<SelectListItem>();

            var selItem = new SelectListItem() { Value = " ", Text = "Select gender" };

            selecgender.Insert(0, selItem);

            selItem = new SelectListItem()
            {
                Value = "Male",
                Text = "Male"
            };
            selecgender.Add(selItem);

            selItem = new SelectListItem()
            {
                Value = "FeMale",
                Text = "FeMale"
            };
            selecgender.Add(selItem);

            return selecgender; 
        }

        public void Update(Applicat applicat)
        {
            context.Applicats.Update(applicat);
            context.SaveChanges();
        }
    }
}
