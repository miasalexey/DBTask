using System;
using DBTask.DB.Entities;


namespace DBTask.DB.Entities
{
    public class CriminalDecision
    {
        public Guid CriminalDecisionId { get; set; }


        public Guid MessageRegistrationId { get; set; }
        public MessageRegistration? MessageRegistration { get; set; }
        public bool IsCriminalCase { get; set; } = false;


        public Guid? CriminalCaseId { get; set; }

        public CriminalCase? CriminalCase { get; set; }
    }
}