using System;
using System.Linq;

namespace DBTask.DB.Services
{
    public class MessageRegistrationService
    {
        public void ChangeMessageRegistrationPlotById(Guid messageRegistrationID, string textForChange)
        {
            using (var context = new Context())
            {
                var messageRegistration =
                    context.MessageRegistrations
                        .FirstOrDefault(mr => mr.MessageRegistrationId == messageRegistrationID);

                if (messageRegistration != null)
                {
                    messageRegistration.Plot = textForChange;
                }

                context.SaveChanges();
            }
        }
    }
}