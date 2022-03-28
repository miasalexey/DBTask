using System;

namespace DBTask.DB.Entities
{
    // Привязка личности к уголовному делу с назначением роли ( свидетель, обвиняемый, потерпевший )
    public class PersonInCriminalCase
    {
        public Guid PersonInCriminalCaseId { get; set; }

        public Guid PersonId { get; set; }
        public Person Person { get; set; }

        public string Category { get; set; }

        public Guid CriminalCaseId { get; set; }
        public CriminalCase CriminalCase { get; set; }
    }
}
