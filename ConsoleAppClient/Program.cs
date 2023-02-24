using ConsoleAppClient.Models;
using Newtonsoft.Json;
using System.Net.Http.Headers;
using System.Text;

namespace ConsoleAppClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            GetClassrooms();

            //var classroom = new Classroom()
            //{
            //    ClassroomID = 3,
            //    Name = "Salle Anders Hejlsberg",
            //    Floor = 8,
            //    Corridor = "Gris"
            //};

            //PostClassroom(classroom);
            //PutClassroom(classroom);
            //GetClassroom(classroom.ClassroomID);
            //DeleteClassroom(classroom.ClassroomID);

            Console.ReadLine();
        }

        private static async void GetClassrooms()
        {
            using (HttpClient client = new HttpClient())
            {
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage message = await client.GetAsync("https://localhost:7001/classroomtest");

                if (message.IsSuccessStatusCode)
                {
                    string content = await message.Content.ReadAsStringAsync();
                    Console.WriteLine(content);

                    var classrooms = JsonConvert.DeserializeObject<List<Classroom>>(content);
                }
            }
        }

        private static async void GetClassroom(int classroomId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7001/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage message = await client.GetAsync($"classroomtest/{classroomId}");

                if (message.IsSuccessStatusCode)
                {
                    string content = await message.Content.ReadAsStringAsync();

                    Console.WriteLine(content);

                    var classroom = JsonConvert.DeserializeObject<Classroom>(content);
                }
            }
        }

        private static async void PostClassroom(Classroom classroom)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7001/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = JsonConvert.SerializeObject(classroom);
                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

                HttpResponseMessage message = await client.PostAsync("classroomtest", httpContent);

                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine("Classroom ajouté");

                    string messageContent = await message.Content.ReadAsStringAsync();

                    Console.WriteLine(content);

                    var classroomResponse = JsonConvert.DeserializeObject<Classroom>(messageContent);
                }
            }
        }

        private static async void PutClassroom(Classroom classroom)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7001/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var content = JsonConvert.SerializeObject(classroom);
                var httpContent = new StringContent(content, Encoding.UTF8, "application/json");

                HttpResponseMessage message = await client.PutAsync($"classroomtest/{classroom.ClassroomID}", httpContent);

                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine("Classroom mis à jour");
                }
            }
        }

        private static async void DeleteClassroom(int classroomId)
        {
            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7001/");

                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                HttpResponseMessage message = await client.DeleteAsync($"classroomtest/{classroomId}");

                if (message.IsSuccessStatusCode)
                {
                    Console.WriteLine("Classroom supprimé");
                }
            }
        }
    }
}