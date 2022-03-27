using System;
using System.Collections.Generic;
using DBTask.DB.Entities;

namespace DBTask.DB.Entities
{
    public class CriminalCase
    {
        public Guid CriminalCaseId { get; set; } = new Guid();
        public string Info { get; set; } = "";
        public string Region { get; set; } = "";


        public CriminalDecision? CriminalDecision { get; set; }

        public ICollection<PersonInCriminalCase> PersonInCriminalCases { get; set; } = new List<PersonInCriminalCase>();
    }
}