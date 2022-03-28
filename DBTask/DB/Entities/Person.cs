using System;
using System.Collections.Generic;
using DBTask.DB.Entities;


namespace DBTask.DB.Entities
{
    // Данные о личности 
    public class Person
    {
        public Guid PersonId { get; set; }
        public string? Name { get; set; }
        public string? SurName { get; set; }
        public string? Address { get; set; }
        public int CountCriminalRecord { get; set; }


        public ICollection<PersonInCriminalCase> PersonInCriminalCases { get; set; } = new List<PersonInCriminalCase>();
    }
}
