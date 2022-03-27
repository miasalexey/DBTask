using System;
using System.Linq;

namespace DBTask.DB.Services
{
    public class PersonsInCriminalCaseService
    {
        public void ChangePersonCategoryById(Guid PersonID, Guid CriminalCaseId, string Category)
        {
            using (var context = new Context())
            {
                var person = context.PersonInCriminalCase.FirstOrDefault(picc =>
                    picc.CriminalCaseId == CriminalCaseId && picc.PersonId == PersonID);

                if (person != null)
                {
                    person.Category = Category;
                }

                context.SaveChanges();
            }
        }
    }
}