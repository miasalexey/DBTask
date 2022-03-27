using System;
using System.Linq;
using DBTask.DB;
using DBTask.DB.Services;
using DBTask.Utils;

namespace DBTask
{
    class Program
    {
        static void Main(string[] args)
        {
            Generator.DataGenerator();

            var context = new Context();


            var personInCriminalCaseService = new PersonsInCriminalCaseService();
            var messageRegistrationService = new MessageRegistrationService();

            var personList = context.Persons.ToList();
            var criminalCaseList = context.CriminalCases.ToList();
            var mrList = context.MessageRegistrations.ToList();

        // 1) Рассчитать данные о количестве происшествий в указанный промежуток времени
            var startTime = new DateTime(2020, 12, 31);
            var endTime = new DateTime(2021, 01, 28);
            var res = CountCriminalCaseFromDateTimePeriod(startTime, endTime);
            Console.WriteLine($"Кол-во происшествий с {startTime.ToString("dd MMMM yyyy")} " +
                              $"по {endTime.ToString("dd MMMM yyyy")}:\n{res}\n");


            //  2) Для указанного лица получить количество происшествий, в которых он зарегистрирован
            var res2 = CountCriminalCaseForPerson(personList[2].PersonId);
            Console.WriteLine($"Кол-во уголовных дел, где фигурирует указанное лицо\n{res2}\n");


            //  3) Предоставить возможность добавления и изменения информации о лицах, участвующих в происшествиях,
            //  при этом предусмотреть курсоры, срабатывающие на некоторые пользовательские исключительные ситуации.
            //  Предусмотреть разработку триггеров, обеспечивающих каскад- ные изменения в связанных таблицах.

            //Я сделал только вариант изменения категории для человека в уголовном деле
            personInCriminalCaseService.ChangePersonCategoryById(personList[2].PersonId,
                criminalCaseList[0].CriminalCaseId, "dd");


        //  4)Предоставить возможность добавления и изменения информации о происшествиях

        // Я сделал только вариант изменение краткой фабулы в регистрации сообщении о происшествии и изменение инфорамции в самом уголовном деле 
            messageRegistrationService.ChangeMessageRegistrationPlotById(mrList[0].MessageRegistrationId,
                "Мужчина избил на красной площади деда мороза и приставал к Снегурочке");

            messageRegistrationService.ChangeMessageRegistrationPlotById(criminalCaseList[0].CriminalCaseId,
                "Мужчина избил на красной площади деда мороза и приставал к Снегурочке");


            static int CountCriminalCaseFromDateTimePeriod(DateTime start, DateTime end)
            {
                var context = new Context();
                var res = 0;
                var mr = context.MessageRegistrations
                    .Where(mr => (mr.DataRegistration >= start && mr.DataRegistration < end))
                    .ToList();


                foreach (var item in mr)
                {
                    Console.WriteLine(item.MessageRegistrationId);
                    Console.WriteLine(item.Plot);
                    Console.WriteLine("====================================");
                    res++;
                }

                return res;
            }

            static int CountCriminalCaseForPerson(Guid personalID)
            {
                var context = new Context();
                var res = 0;

                var person = context.Persons.Where(p => p.PersonId == personalID).ToList();
                var criminalCasesWithPerson = context.PersonInCriminalCase
                    .Where(picc => picc.PersonId == personalID).ToList();

                Console.WriteLine($"Личность:{person[0].SurName} {person[0].Name}");
                foreach (var item in criminalCasesWithPerson)
                {
                    Console.WriteLine($"{item.CriminalCaseId} роль {item.Category}");
                    res++;
                }

                return res;
            }
        }
    }
}