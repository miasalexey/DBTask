using System;
using DBTask.DB.Entities;


namespace DBTask.DB.Entities
{
    public class MessageRegistration
    {
        public Guid MessageRegistrationId { get; set; } = Guid.NewGuid();
        public DateTime DataRegistration { get; set; } = DateTime.Now;
        public string Plot { get; set; } = "";

        public CriminalDecision? CriminalDecision { get; set; }
    }
}