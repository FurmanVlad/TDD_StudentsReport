using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

public enum FirstNames
{
    Noa,
    Itay,
    Lior,
    Tamar,
    Yotam,
    Yarden,
    Aviv,
    Yuval,
    Liel,
    Tomer,
    Shani,
    Nitzan,
    Mayan,
    Ron,
    Michal,
    Adi,
    Omer,
    Dafna,
    Asaf,
    Moran
}


public enum LastNames
{
    Levi,
    Cohen,
    Mizrahi,
    Peretz,
    Azulay,
    Biton,
    Yosef,
    Shoshan,
    Harel,
    Lev,
    Dahan,
    Sabag,
    Abuksis,
    Twito,
    Ohana,
    Hazan,
    Sasson,
    Amar,
    Grinberg,
    Dagan
}

public enum EmailOperator
{
    gmail,
    yahoo,
    hotmail,
    outlook,
    iCloud,
    walla
}




namespace TDD_HW
{
    public partial class Form1 : Form
    {
        // Define a field to keep track of the number of active students
        static int studentsCounter = 0;

        // Define a label control to display the number of active students
        private readonly Label _activeStudentsLabel = new Label();

        private List<Student> studentsList;

        public Form1()
        {
            InitializeComponent();
            studentsList = new List<Student>();

            // Set the properties of the active students label
            _activeStudentsLabel.AutoSize = true;
            _activeStudentsLabel.Location = new Point(10, 10);
            _activeStudentsLabel.Font = new Font(_activeStudentsLabel.Font, FontStyle.Bold);
            _activeStudentsLabel.Text = $"Active Students: {studentsCounter}";

            // Add the active students label to the form
            Controls.Add(_activeStudentsLabel);
        }

        private void Add100000Students()
        {
            Random rand = new Random();
            for (int i = 0; i < 10000; i++)
            {
                Student student = new Student();

                // ID
                student.Id = rand.Next(100000000, 1000000000).ToString();


                // Generate random indices for the FirstNames and LastNames enums
                int firstNameIndex = rand.Next(Enum.GetNames(typeof(FirstNames)).Length);
                int lastNameIndex = rand.Next(Enum.GetNames(typeof(LastNames)).Length);

                // Get the values at the random indices
                FirstNames firstName = (FirstNames)firstNameIndex;
                LastNames lastName = (LastNames)lastNameIndex;

                student.FirstName = firstName.ToString();
                student.LastName = lastName.ToString();


                // Generate random indices for the EmailOperator enums
                int emailOperatorIndex = rand.Next(Enum.GetNames(typeof(EmailOperator)).Length);

                // Get the values at the random indices
                EmailOperator emailOperator = (EmailOperator)emailOperatorIndex;

                student.Email = student.FirstName + student.LastName + (studentsCounter + 1) + "@" + emailOperator + ".com";


                // PhoneNumber
                student.PhoneNumber = "05";
                for (int j = 0; j < 8; j++)
                {
                    student.PhoneNumber += rand.Next(10).ToString();
                }


                // Grades
                student.Grades = new int[5];
                for (int j = 0; j < 5; j++)
                {
                    int grade = rand.Next(0, 102); // Generate a grade between 0 and 100
                    if (grade == 101)
                    {
                        student.Grades[j] = 777; // Use 777 to represent "no grade"
                    }
                    else student.Grades[j] = grade;
                }


                // Average
                student.Average = student.AverageGrade();


                studentsList.Add(student);
                studentsCounter++;
            }

            // Display a message to confirm that the students have been added
            MessageBox.Show("10,000 random students added.");
        }
    
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        // Adding a student to studentsList after adding manually
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            int flag = 0;
            AddStudentForm addStudentForm = new AddStudentForm();
            while (flag == 0)
            {
                DialogResult result = addStudentForm.ShowDialog();
                if (result == DialogResult.OK)
                {
                    Student student = addStudentForm.GetStudent();
                    if (student != null)
                    {
                        studentsList.Add(student);
                        studentsCounter++;
                        _activeStudentsLabel.Text = $"Active Students: {studentsCounter}";
                        break;
                    }
                }

                // User exits the app with X button
                else if (result == DialogResult.Cancel) flag = 1;
            }
        }

        // Display students list
        private void pictureBox1_Click(object sender, EventArgs e)
        {

            if (studentsCounter > 0) {
                var students = studentsList.ToList();
                StudentsReportForm studentsForm = new StudentsReportForm(students);
                studentsForm.ShowDialog();
            }
            else MessageBox.Show("There is no students in the system");
        }
            

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (studentsCounter > 0)
            {
                // Display a message box with Yes/No options
                DialogResult result = MessageBox.Show($"There is already {studentsCounter} student in the system. Are you sure you want to add?",
                    "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                // If the user clicks Yes, add the student to the system
                if (result == DialogResult.Yes)
                {
                    Add100000Students();
                    _activeStudentsLabel.Text = $"Active Students: {studentsCounter}";
                }
            }
            else
            {
                // If there are no students in the system, just add the student
                Add100000Students();
                _activeStudentsLabel.Text = $"Active Students: {studentsCounter}";
            }
        }

        // Opening mail app with mail to contact
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("mailto:vladfu@ac.sce.ac.il");

        }

        // User want to exit the app with X button event handler
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
            {
                e.Cancel = true;
                DialogResult result = MessageBox.Show("Are you sure you want to exit?", "Confirm Exit", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    // exit the application
                    Environment.Exit(0);
                }
            }
        }
    }

    public class Student
    {
        public string Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string PhoneNumber { get; set; }
        public int[] Grades { get; set; }
        public double Average { get; set; }

        public Student() { }
        public Student(string id, string firstName, string lastName, string email, string phoneNumber, int[] grades)
        {
            this.Id = id;
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Email = email;
            this.PhoneNumber = phoneNumber;
            this.Grades = grades;
            this.Average = AverageGrade();
        }
        public override string ToString()
        {
            string firstName = FirstName.PadRight(20, ' ');
            string lastName = LastName.PadRight(20, ' ');
            string email = Email.PadRight(44, ' ').ToLower();
            string gradesStr = string.Join(", ", Grades);
            return $"ID: {Id}\t{firstName}\t{lastName}\tEmail: {email}\tPhone: {PhoneNumber}\t Grades: {gradesStr}\t\tAverage: {Average.ToString("F1")}";
        }
        
        // Getting the average grade of a student, if 777, we don't count it
        public double AverageGrade()
        {
            if (Grades != null && Grades.Length != 5) return 0;
            double sum = 0;
            double numberOfCourses = 0;
            for (int i = 0; i < Grades.Length; i++)
            {
                if  (Grades[i] != 777)
                {
                    sum += Grades[i];
                    numberOfCourses++;
                }
            }
            if (numberOfCourses == 0) return 0;
            return (sum / numberOfCourses);
        }
    }

}
