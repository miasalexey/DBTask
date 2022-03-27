using System;
using System.Collections.Generic;
using DBTask.DB;
using DBTask.DB.Entities;

namespace DBTask.Utils
{
    public class Generator
    {
        public static void DataGenerator()
        {
            var context = new Context();
            var listPersons = new List<Person>()
            {
                new Person()
                {
                    Name = "Алексей", SurName = "Мясниченко", Address = "Москва,пр-кт Ленина , 22/1",
                    CountCriminalRecord = 1
                },
                new Person()
                {
                    Name = "Степан", SurName = "Наибиулин", Address = "Москва, Московский, татьянин парк, 17/5",
                    CountCriminalRecord = 0
                },
                new Person()
                {
                    Name = "Петр", SurName = "Ванчинов", Address = "Москва, ул Москвитина, , 228/1",
                    CountCriminalRecord = 0
                },
                new Person()
                {
                    Name = "Иван", SurName = "Макаров", Address = "Москва,  г Щербинка, Остафьевское ш, 28",
                    CountCriminalRecord = 0
                },
                new Person()
                {
                    Name = "Дарья", SurName = "Дарьевенко", Address = "Москва, Головинское ш, 312 ",
                    CountCriminalRecord = 2
                },
                new Person()
                {
                    Name = "Анна", SurName = "Анненко", Address = "Москва,  Грайвороновский 2-й проезд, 4412",
                    CountCriminalRecord = 0
                },
                new Person()
                {
                    Name = "Ксения", SurName = "Ким", Address = "Москва, Дмитровское ш, 33", CountCriminalRecord = 4
                },
                new Person()
                {
                    Name = "Виктор", SurName = "Ляшкин", Address = "Москва, Долгопрудная аллея, 30/1",
                    CountCriminalRecord = 0
                },
                new Person()
                {
                    Name = "Давид", SurName = "Амарян", Address = "Москва, Долгопрудненское ш, 36/2",
                    CountCriminalRecord = 0
                }
            };
            foreach (var item in listPersons)
            {
                context.Persons.Add(item);
            }

            var listMessageRegistation = new List<MessageRegistration>()
            {
                new MessageRegistration()
                {
                    DataRegistration = new DateTime(2020, 12, 31),
                    Plot = "Мужчина избил на красной площади деда мороза",
                },
                new MessageRegistration()
                {
                    DataRegistration = new DateTime(2021, 1, 3),
                    Plot = "Пьяный мужчина вылетел с ледяной горки",
                },
                new MessageRegistration()
                {
                    DataRegistration = new DateTime(2021, 1, 7),
                    Plot = "Мужчина с криком во имя Христа пустил салют во дворе, попав в окно",
                },
                new MessageRegistration()
                {
                    DataRegistration = new DateTime(2021, 2, 14),
                    Plot = "Девушка обратилась о громких криках соседей,ориентировчно не насильственного характера",
                },
            };

            foreach (var messageRegistration in listMessageRegistation)
            {
                context.MessageRegistrations.Add(messageRegistration);
            }

            var criminalDecision = new CriminalDecision()
            {
                MessageRegistration = listMessageRegistation[0],
                IsCriminalCase = true,
                CriminalCase = new CriminalCase()
                {
                    Info = listMessageRegistation[0].Plot,
                    Region = "Москва"
                }
            };

            var criminalDecision2 = new CriminalDecision()
            {
                MessageRegistration = listMessageRegistation[2],
                IsCriminalCase = true,
                CriminalCase = new CriminalCase()
                {
                    Info = listMessageRegistation[2].Plot,
                    Region = "Москва"
                }
            };

            var criminalDecision3 = new CriminalDecision()
            {
                MessageRegistration = listMessageRegistation[3],
                IsCriminalCase = true,
                CriminalCase = new CriminalCase()
                {
                    Info = listMessageRegistation[3].Plot,
                    Region = "Москва"
                }
            };

            var criminalDecision4 = new CriminalDecision()
            {
                MessageRegistration = listMessageRegistation[1],
                IsCriminalCase = false,
                CriminalCase = null,
            };

            context.CriminalDecisions.AddRange(criminalDecision, criminalDecision2, criminalDecision3,
                criminalDecision4);


            var personInCriminalCase = new PersonInCriminalCase()
            {
                CriminalCase = criminalDecision.CriminalCase,
                Person = listPersons[2],
                Category = Constans.Categories.Witness
            };


            var personInCriminalCase2 = new PersonInCriminalCase()
            {
                CriminalCase = criminalDecision2.CriminalCase,
                Person = listPersons[1],
                Category = Constans.Categories.Suspect
            };

            var personInCriminalCase3 = new PersonInCriminalCase()
            {
                CriminalCase = criminalDecision3.CriminalCase,
                Person = listPersons[2],
                Category = Constans.Categories.Witness
            };
            context.PersonInCriminalCase.AddRange(personInCriminalCase, personInCriminalCase2, personInCriminalCase3);
            context.SaveChanges();
        }
    }
}