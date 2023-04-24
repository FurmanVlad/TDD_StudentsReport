using Microsoft.VisualStudio.TestTools.UnitTesting;
using TDD_HW;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;



namespace TDD_HW.Tests
{
    [TestClass]
    public class AverageGradeTests
    {
        private Student student;

        [TestInitialize]
        public void Setup()
        {
            student = new Student();
        }


        //////////////////////////// AverageGrade ////////////////////////////

        [TestMethod]
        public void AverageGrade_ReturnsCorrectAverage_GivenValidGrades()
        {
            student.Grades = new int[] { 90, 85, 95, 80, 100 };

            double average = student.AverageGrade();

            Assert.AreEqual(90, average);
        }


        [TestMethod]
        public void AverageGrade_ReturnsNoGrade_GivenAtLeastOneNoGrade()
        {
            student.Grades = new int[] { 90, 85, 777, 80, 100 };

            double average = student.AverageGrade();

            Assert.AreEqual(88.75, average);
        }

        [TestMethod]
        public void AverageGrade_WhenAllGradesAre777_ReturnsZero()
        {
            student.Grades = new int[] { 777, 777, 777, 777, 777 };

            double result = student.AverageGrade();

            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void AverageGrade_WhenNoGradesAreProvided_ReturnsZero()
        {
            student.Grades = new int[] { };

            double result = student.AverageGrade();

            Assert.AreEqual(0, result);
        }
    }
}