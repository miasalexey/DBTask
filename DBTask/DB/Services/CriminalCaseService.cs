using System;
using System.Linq;

namespace DBTask.DB.Services
{
    public class CriminalCaseService
    {
        public void ChangeMessageRegistrationPlotById(Guid messageRegistrationID, string textForChange)
        {
            using (var context = new Context())
            {
                var criminalCase =
                    context.CriminalCases
                        .FirstOrDefault(cc => cc.CriminalCaseId == messageRegistrationID);

                if (criminalCase != null)
                {
                    criminalCase.Info = textForChange;
                }

                context.SaveChanges();
            }
        }
    }
}