using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_HW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TDD_HW.Tests
{
    [TestClass()]
    public class SortStudentsTests
    {
        private List<Student> students;

        [TestInitialize]
        public void Setup()
        {
            // Create a list of students with different average grades
            students = new List<Student>()
            {
                new Student("123123123","John","Doe", "dsadsa@dsa.cs" , "0545968476" ,new int[5] {0,0,0,0,0 }),
                new Student("456456456","Avi","Doe", "dsadsa@dsa.cs" , "0545968476" ,new int[5] {20,20,777,10,80 }),
                new Student("789789789","Eli","Doe", "dsadsa@dsa.cs" , "0545968476" ,new int[5] {100,100,100,100,100 }),

            };
        }


        [TestMethod]
        // Checks if actually return value and array has not lost records
        public void SortStudentsByAverageGrade_ChecksIfActuallyReturnValue_AND_ArrayHasNotLostRecords()
        {
            StudentsReportForm form = new StudentsReportForm(students);

            var sortedStudents = form.SortStudentsByAverageGrade(students);

            Assert.IsNotNull(sortedStudents);
            Assert.AreEqual(3, sortedStudents.Count);

            var unsortedStudents = students.OrderBy(s => s.FirstName).ToList();
            var sortedStudents2 = sortedStudents.OrderBy(s => s.FirstName).ToList();
            for (int i = 0; i < sortedStudents.Count; i++)
            {
                Assert.AreEqual(unsortedStudents[i].FirstName, sortedStudents2[i].FirstName);
                Assert.AreEqual(unsortedStudents[i].LastName, sortedStudents2[i].LastName);
                Assert.AreEqual(unsortedStudents[i].Id, sortedStudents2[i].Id);
                Assert.AreEqual(unsortedStudents[i].Email, sortedStudents2[i].Email);
                Assert.AreEqual(unsortedStudents[i].PhoneNumber, sortedStudents2[i].PhoneNumber);
                CollectionAssert.AreEqual(unsortedStudents[i].Grades, sortedStudents2[i].Grades);
            }
        }

        [TestMethod]
        // Sorts students by average grade in descending order
        public void SortStudentsByAverageGrade_SortsStudentsByAverageGradeInDescendingOrder()
        {
            StudentsReportForm form = new StudentsReportForm(students);

            students = form.SortStudentsByAverageGrade(students);

            Assert.AreEqual("Eli", students[0].FirstName);
            Assert.AreEqual("Avi", students[1].FirstName);
            Assert.AreEqual("John", students[2].FirstName);
        }
    }
}