using DomainModel;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            LoadData();
        }

        private void comboBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private async void LoadData()
        {
            // ---- classrooms ----

            List<Classroom> classrooms = await LoadClassrooms();

            this.cbClassrooms.ItemsSource = classrooms;

            // ---- students ----

            List<Student> students = await LoadStudentsByClassroomId(classrooms.First().ClassroomID);

            this.dgStudents.ItemsSource = students;

            // ---- teacher ----

            Teacher teacher = await LoadTeacherByClassroomId(classrooms.First().ClassroomID);

            this.tbTeacherFirstName.Text = teacher.FirstName;
            this.tbTeacherLastName.Text = teacher.LastName;
        }

        private async Task<List<Classroom>> LoadClassrooms()
        {
            using HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:7001/");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage message = await client.GetAsync("classroom");

            if (message.IsSuccessStatusCode)
            {
                string content = await message.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                var classrooms = JsonConvert.DeserializeObject<List<Classroom>>(content);

                return classrooms;
            }

            return null;
        }

        private async Task<List<Student>> LoadStudentsByClassroomId(int classroomId)
        {
            using HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:7001/");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage message = await client.GetAsync($"student/class/{classroomId}");

            if (message.IsSuccessStatusCode)
            {
                string content = await message.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                var students = JsonConvert.DeserializeObject<List<Student>>(content);

                return students;
            }

            return null;
        }

        private async Task<Teacher> LoadTeacherByClassroomId(int classroomId)
        {
            using HttpClient client = new HttpClient();

            client.BaseAddress = new Uri("https://localhost:7001/");

            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            HttpResponseMessage message = await client.GetAsync($"teacher/class/{classroomId}");

            if (message.IsSuccessStatusCode)
            {
                string content = await message.Content.ReadAsStringAsync();
                Console.WriteLine(content);

                var teacher = JsonConvert.DeserializeObject<Teacher>(content);

                return teacher;
            }

            return null;
        }
    }
}
