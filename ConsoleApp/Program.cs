using Dal;
using DomainModel;
using System.Globalization;
using System.Xml.Linq;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //TestDb();

            InitDb();

            Console.WriteLine("OK");
        }

        private static void InitDb()
        {
            using (SchoolContext context = new SchoolContext())
            {
                context.Database.EnsureCreated();


                XDocument doc = XDocument.Load("file.xml");


                // classrooms 
                var classrooms = doc.Descendants("classroom").Select(e => new Classroom()
                {
                    Name = e.Element("name").Value,
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
                    Discipline = e.Element("discipline").Value,
                    Salary = int.Parse(e.Element("salary").Value),
                    ClassroomID = 1
                });

                context.Teachers.AddRange(teachers);
                context.SaveChanges();


                teachers = doc.Descendants("teacher").Skip(1).Take(1).Select(e => new Teacher()
                {
                    FirstName = e.Element("firstname").Value,
                    LastName = e.Element("lastname").Value,
                    Discipline = e.Element("discipline").Value,
                    Salary = int.Parse(e.Element("salary").Value),
                    ClassroomID = 2
                });

                context.Teachers.AddRange(teachers);
                context.SaveChanges();



                // students
                List<Student> students = doc.Descendants("student").Select(e => new Student()
                {
                    FirstName = e.Element("firstname").Value,
                    LastName = e.Element("lastname").Value,
                    Average = double.Parse(e.Element("average").Value, CultureInfo.InvariantCulture),
                    IsClassDelegate = bool.Parse("true"),
                    ClassroomID = 1
                }).ToList();


                students.GetRange(3, 3).ForEach(s => s.ClassroomID = 2);

                context.Students.AddRange(students);
                context.SaveChanges();

            }

        }

        // création de la base
        private static void TestDb()
        {
            using (SchoolContext context = new SchoolContext())
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