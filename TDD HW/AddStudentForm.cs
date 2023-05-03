using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace TDD_HW
{
    public partial class AddStudentForm : Form
    {
        public AddStudentForm()
        {
            InitializeComponent();
        }


        // Returns true if the input string contains only alphabetical characters
        public bool IsAlphabetic(string s) {
            if (s == null || s.Length == 0) return false;
            foreach (char c in s)
            {
                if (!((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z')))
                {
                    return false;
                }
            }
            return true;
        }

        // Returns true if the input string contains only numeric characters
        public bool IsNumeric(string s)
        {
            if (s == null || s.Length == 0) return false;
            foreach (char c in s)
            {
                if (!(c >= '0' && c <= '9'))
                {
                    return false;
                }
            }
            return true;
        }


        // Returns true if the input string has a length of exactly 9 characters
        public bool IsValidIdLength(string s)
        {

            if (s != null && s.Length == 9) {
                return true;
            }
            return false;
        }


        // Returns true if the input string is a 10-digit phone number starting with "05"
        public bool IsValidPhone(string s)
        {
            if (s == null) return false;

            if (s.Length == 10)
            {
                if ((s[0] == '0' && s[1] == '5'))
                {
                    return true;
                }
            }
            return false;
        }


        // Returns true if the input string is a valid email address in the format of "xxx@xxx.xxx"
        public bool IsValidEmail(string s)
        {
            if (s == null) return false;
            int indexShtrudle = s.IndexOf('@');
            if (indexShtrudle == -1 || indexShtrudle == 0) {
                return false;
            }

            string toShtrudle = s.Substring(indexShtrudle);

            if (toShtrudle.Contains('.') && toShtrudle[1] != '.'){
                int indexDot = toShtrudle.IndexOf('.');
                string toDot = toShtrudle.Substring(indexShtrudle);
                if (toDot.Length >= 1) {
                    return true;
                }
            }
            return false;
        }


        // Returns true if the input integer is between 0-100 or is equal to 777
        public bool IsValidGrade(int n)
        {
            if ((n >= 0 && n <= 100) || n == 777) {
                return true;
            }
            return false;
        }


        public Student GetStudent()
        {
            Student student = new Student();

            // Validate and set the first name
            if (string.IsNullOrWhiteSpace(firstNameTextBox.Text) || !IsAlphabetic(firstNameTextBox.Text))
            {
                MessageBox.Show("Please enter a valid first name.");
                return null;
            }
            student.FirstName = firstNameTextBox.Text;

            // Validate and set the last name
            if (string.IsNullOrWhiteSpace(lastNameTextbox.Text) || !IsAlphabetic(lastNameTextbox.Text))
            {
                MessageBox.Show("Please enter a last name.");
                return null;
            }
            
            student.LastName = lastNameTextbox.Text;

            // Validate and set the student ID
            if (string.IsNullOrWhiteSpace(idTextBox.Text) || !IsValidIdLength(idTextBox.Text) || !IsNumeric(idTextBox.Text))
            {
                MessageBox.Show("Please enter a valid student ID.");
                return null;
            }
            
            student.Id = idTextBox.Text;


            // Validate and set the student email
            if (string.IsNullOrWhiteSpace(emailTextbox.Text) || !IsValidEmail(emailTextbox.Text))
            {
                MessageBox.Show("Please enter a valid email address.");
                return null;
            }
            student.Email = emailTextbox.Text;


            // Validate and set the phone number
            if (string.IsNullOrWhiteSpace(phoneNumberTextbox.Text) || !IsValidPhone(phoneNumberTextbox.Text) || !IsNumeric(phoneNumberTextbox.Text))
            {
                MessageBox.Show("Please enter a valid phone number.");
                return null;
            }
            student.PhoneNumber = phoneNumberTextbox.Text;


            // Validate and set the grades
            int[] grades = new int[5];

            if (!IsNumeric(grade1Textbox.Text) || !IsValidGrade(int.Parse(grade1Textbox.Text)))
            {
                MessageBox.Show("Please enter a valid grade for the first subject.");
                return null;
            }
            int.TryParse(grade1Textbox.Text, out grades[0]);


            if (!IsNumeric(grade2Textbox.Text) || !IsValidGrade(int.Parse(grade2Textbox.Text)))
            {
                MessageBox.Show("Please enter a valid grade for the second subject.");
                return null;
            }
            int.TryParse(grade2Textbox.Text, out grades[1]);


            if (!IsNumeric(grade3Textbox.Text) || !IsValidGrade(int.Parse(grade3Textbox.Text)))
            {
                MessageBox.Show("Please enter a valid grade for the third subject.");
                return null;
            }
            int.TryParse(grade3Textbox.Text, out grades[2]);


            if (!IsNumeric(grade4Textbox.Text) || !IsValidGrade(int.Parse(grade4Textbox.Text)))
            {
                MessageBox.Show("Please enter a valid grade for the fourth subject.");
                return null;
            }
            int.TryParse(grade4Textbox.Text, out grades[3]);


            if (!IsNumeric(grade5Textbox.Text) || !IsValidGrade(int.Parse(grade5Textbox.Text)))
            {
                MessageBox.Show("Please enter a valid grade for the fifth subject.");
                return null;
            }
            int.TryParse(grade5Textbox.Text, out grades[4]);

            student.Grades = grades;

            // Calculate and set the student's average grade
            student.Average = student.AverageGrade();


            // Return the student object
            return student;
        }
    }
}
