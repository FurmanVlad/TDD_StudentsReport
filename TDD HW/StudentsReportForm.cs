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
    public partial class StudentsReportForm : Form
    {
        private List<Student> students;

        public StudentsReportForm(List<Student> s)
        {
            InitializeComponent();
            DateTime startTime = DateTime.Now;
            this.students = SortStudentsByAverageGrade(s.ToList());
            DateTime endTime = DateTime.Now;
            TimeSpan duration = endTime - startTime;
            double milliseconds = duration.TotalMilliseconds;

            DisplayStudents(milliseconds);
        }

        private void DisplayStudents(double m)
        {

            StudentReport.Items.Clear();
            StudentReport.Items.Add($"Sort function took {m} milliseconds to run ({m/1000} Seconds).");
            foreach (Student student in students)
            {
                if (student != null)
                {
                    StudentReport.Items.Add(student);
                }
            }
        }

        ///////////////// Bubble sort - n^2 /////////////////
        ///
        //public List<Student> SortStudentsByAverageGrade(List<Student> s)
        //{
        //    int n = s.Count;
        //    for (int i = 0; i < n - 1; i++)
        //    {
        //        for (int j = 0; j < n - i - 1; j++)
        //        {
        //            if (s[j].AverageGrade() < s[j + 1].AverageGrade())
        //            {
        //                // swap students[j] and students[j+1]
        //                Student temp = s[j];
        //                s[j] = s[j + 1];
        //                s[j + 1] = temp;
        //            }
        //        }
        //    }
        //    return s;
        //}

        ///////////////// Quick sort - nlogn /////////////////
        public List<Student> SortStudentsByAverageGrade(List<Student> s)
        {
            QuickSort(s, 0, s.Count - 1);
            return s;
        }

        private void QuickSort(List<Student> s, int left, int right)
        {
            if (left < right)
            {
                int pivotIndex = Partition(s, left, right);
                QuickSort(s, left, pivotIndex - 1);
                QuickSort(s, pivotIndex + 1, right);
            }
        }

        private int Partition(List<Student> s, int left, int right)
        {
            double pivot = s[right].AverageGrade();
            int i = left - 1;
            for (int j = left; j < right; j++)
            {
                if (s[j].AverageGrade() >= pivot)
                {
                    i++;
                    // swap students[i] and students[j]
                    Student temp = s[i];
                    s[i] = s[j];
                    s[j] = temp;
                }
            }
            // swap students[i+1] and students[right]
            Student temp2 = s[i + 1];
            s[i + 1] = s[right];
            s[right] = temp2;
            return i + 1;
        }


    }
}