using System.Globalization;
using System.Xml.Linq;
using System.Data;
using DalDbFirst;
using DalDbFirst.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleAppDbFirst
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestDb();

            //InitDb();

            Queries();

            Console.WriteLine("OK");
        }

        private static void Queries()
        {
            using (SchoolDbFirstContext context = new SchoolDbFirstContext())
            {
                // Affichez toutes les personnes

                IQueryable<Person> people = context.People;
                foreach (Person p in people)
                {
                    Console.WriteLine($"{p.FirstName} {p.LastName}");
                }




                Console.WriteLine("-------");
                // Affichez tous les étudiants

                context.Students.ToList().ForEach(s => Console.WriteLine($"{s.FirstName} {s.LastName} : {s.Average} / 20"));



                Console.WriteLine("-------");
                // Affichez la personne ayant la clé primaire égale à 2

                Person person = context.People.Find(2);
                Console.WriteLine($"{person.FirstName} {person.LastName}");



                Console.WriteLine("-------");
                // Filtrez et affichez les personnes ayant un âge supérieur ou égal à 30 ans

                context.People.Where(p => p.Age >= 30).ToList().ForEach(p => Console.WriteLine($"{p.FirstName} {p.LastName}"));



                Console.WriteLine("-------");
                // Sélectionnez et affichez le prénom des personnes

                IQueryable<string> firstNames = context.People.Select(p => p.FirstName);
                foreach (string firstName in firstNames)
                {
                    Console.WriteLine(firstName);
                }



                Console.WriteLine("-------");
                // Sélectionnez et affichez le prénom et le nom des personnes

                var fullNames = context.People.Select(p => new { p.FirstName, p.LastName });
                foreach (var fullName in fullNames)
                {
                    Console.WriteLine($"{fullName.FirstName} {fullName.LastName}");
                }



                Console.WriteLine("-------");
                // Récupérez et affichez la première personne de la liste qui a un âge supérieur à 30 ans

                Person firstPerson = context.People.First(p => p.Age > 30);
                Console.WriteLine($"{firstPerson.FirstName} {firstPerson.LastName}");



                Console.WriteLine("-------");
                // Récupérez et affichez la dernière personne de la liste qui a un âge supérieur à 30 ans

                Person? lastPerson = context.People.OrderBy(p => p.PersonId).LastOrDefault(p => p.Age > 30);

                if (lastPerson != null)
                {
                    Console.WriteLine($"{lastPerson.FirstName} {lastPerson.LastName}");
                }



                Console.WriteLine("-------");
                // Récupérez et affichez la seule personne qui a plus de 60 ans

                Person oldestPerson = context.People.Single(p => p.Age > 60);
                Console.WriteLine($"{oldestPerson.FirstName} {oldestPerson.LastName}");



                Console.WriteLine("-------");
                // Affichez la liste triée par prénoms

                List<Person> orderedPeopleByName = context.People.OrderBy(p => p.FirstName).ToList();

                foreach (Person p in orderedPeopleByName)
                {
                    Console.WriteLine($"{p.FirstName} {p.LastName}");
                }



                Console.WriteLine("-------");
                // Affichez la liste triée par âge, puis par nom en tri secondaire, puis par prénom en tri tertiaire

                List<Person> orderedPeopleWithMultiSort = context.People
                                                                 .OrderBy(p => p.Age)
                                                                 .ThenBy(p => p.LastName)
                                                                 .ThenBy(p => p.FirstName)
                                                                 .ToList();

                foreach (Person p in orderedPeopleWithMultiSort)
                {
                    Console.WriteLine($"{p.FirstName} {p.LastName}");
                }



                Console.WriteLine("-------");
                // Filtrez les personnes dont le nom commence par la lettre S, puis triez les données par âge, puis sélectionnez uniquement l'âge

                List<int> ages = context.People
                                        .Where(p => p.LastName.StartsWith("S"))
                                        .OrderBy(p => p.Age)
                                        .Select(p => p.Age)
                                        .ToList();

                ages.ForEach(age => Console.WriteLine(age));



                Console.WriteLine("-------");
                // Récupérez et affichez la classroom avec l’id égale à 1, ainsi que ses étudiants et son professeur

                Classroom classroom = context.Classrooms
                                             .Include(c => c.Students)
                                             .Include(c => c.Teacher)
                                             .Single(c => c.ClassroomId == 1);

                Console.WriteLine($"{classroom.Classname} avec comme professeur : {classroom.Teacher.FirstName} {classroom.Teacher.LastName}");

                Console.WriteLine("étudiants de la classe : ");
                foreach (Student student in classroom.Students)
                {
                    Console.WriteLine($"{student.FirstName} {student.LastName}");
                }



                Console.WriteLine("-------");
                // Affichez le nombre et la moyenne de tous les étudiants

                Console.WriteLine($"nombre d'étudiants de l'école : {context.Students.Count()}");

                Console.WriteLine($"moyenne des étudiants de l'école : {context.Students.Average(s => s.Average)}");



                Console.WriteLine("-------");
                // Affichez la moyenne des étudiants de chaque classroom

                List<Classroom> classrooms = context.Classrooms
                                                    .Include(c => c.Students)
                                                    .ToList();

                foreach (Classroom classroomWithStudent in classrooms)
                {
                    Console.WriteLine($"moyenne des étudiants de la classe : {classroomWithStudent.Students.Average(s => s.Average)}");
                }


                // --- not working ---
                //var groups = context.Students.GroupBy(s => s.ClassroomID).ToList();

                //foreach (var group in groups)
                //{
                //    Console.WriteLine($"classroom {group.Key} : {group.Average(s => s.Average)}");
                //}

                Console.WriteLine("-------");
            }
        }

        private static void InitDb()
        {
            using (SchoolDbFirstContext context = new SchoolDbFirstContext())
            {

                context.Database.EnsureCreated();


                XDocument doc = XDocument.Load("file.xml");


                // classrooms 
                var classrooms = doc.Descendants("classroom").Select(e => new Classroom()
                {
                    Classname = e.Element("name").Value,
                    Floor = int.Parse(e.Element("floor").Value),
                    Corridor = e.Element("corridor").Value
                });

                context.Classrooms.AddRange(classrooms);
                context.SaveChanges();


                // teachers
                var teachers = doc.Descendants("teacher").Take(1).Select(e => new Teacher()
                {
                    FirstName = e.Element("firstname").Value,
                    LastName = e.Element("lastname").Value,
                    Age = int.Parse(e.Element("age").Value),
                    Discipline = e.Element("discipline").Value,
                    Salary = int.Parse(e.Element("salary").Value),
                    ClassroomId = 1
                });

                context.Teachers.AddRange(teachers);
                context.SaveChanges();


                teachers = doc.Descendants("teacher").Skip(1).Take(1).Select(e => new Teacher()
                {
                    FirstName = e.Element("firstname").Value,
                    LastName = e.Element("lastname").Value,
                    Age = int.Parse(e.Element("age").Value),
                    Discipline = e.Element("discipline").Value,
                    Salary = int.Parse(e.Element("salary").Value),
                    ClassroomId = 2
                });

                context.Teachers.AddRange(teachers);
                context.SaveChanges();



                // students
                List<Student> students = doc.Descendants("student").Select(e => new Student()
                {
                    FirstName = e.Element("firstname").Value,
                    LastName = e.Element("lastname").Value,
                    Age = int.Parse(e.Element("age").Value),
                    Average = double.Parse(e.Element("average").Value, CultureInfo.InvariantCulture),
                    IsClassDelegate = bool.Parse("true"),
                    ClassroomId = 1
                }).ToList();


                students.GetRange(3, 3).ForEach(s => s.ClassroomId = 2);

                context.Students.AddRange(students);
                context.SaveChanges();

            }

        }

        // création de la base
        private static void TestDb()
        {
            using (SchoolDbFirstContext context = new SchoolDbFirstContext())
            {
                //context.Database.EnsureDeleted();
                context.Database.EnsureCreated();


                //// insertion
                //var classroomToInsert = new Classroom()
                //{
                //    Name = "Salle Satya Nadella",
                //    Corridor = "Rouge",
                //    Floor = 2
                //};

                //context.Classrooms.Add(classroomToInsert);
                //context.SaveChanges();


                //// mise à jour
                //var classroomToUpdate = context.Classrooms.Find(1);

                //classroomToUpdate.Name = "Salle Scott Guthrie";

                //context.SaveChanges();


                // suppression
                //var classroomToDelete = context.Classrooms.First();

                //context.Classrooms.Remove(classroomToDelete);
                //context.SaveChanges();

                context.Database.EnsureDeleted();
            }
        }
    }
}