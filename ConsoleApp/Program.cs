using Dal;

namespace ConsoleApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            TestDb();

            Console.WriteLine("OK");
        }

        private static void TestDb()
        {
            using (SchoolContext context = new SchoolContext())
            {
                context.Database.EnsureDeleted();
                context.Database.EnsureCreated();
            }
        }
    }
}