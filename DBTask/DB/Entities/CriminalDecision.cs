using System;
using DBTask.DB.Entities;


namespace DBTask.DB.Entities
{
    // Решение о заведении уголовного дела на основании сообщения о регистрации проишествия
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
