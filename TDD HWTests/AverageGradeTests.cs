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


        // initializes the "student" object before each test method is run
        [TestInitialize]
        public void Setup()
        {
            student = new Student();
        }


        //////////////////////////// AverageGrade ////////////////////////////


        // Tests whether the "AverageGrade" method returns the correct average when valid grades are provided.
        [TestMethod]
        public void AverageGrade_ReturnsCorrectAverage_GivenValidGrades()
        {
            student.Grades = new int[] { 90, 85, 95, 80, 100 };

            double average = student.AverageGrade();

            Assert.AreEqual(90, average);
        }


        // Tests whether the "AverageGrade" method returns the correct average
        // when at least one "777" value is present in the grades array
        [TestMethod]
        public void AverageGrade_ReturnsNoGrade_GivenAtLeastOneNoGrade()
        {
            student.Grades = new int[] { 90, 85, 777, 80, 100 };

            double average = student.AverageGrade();

            Assert.AreEqual(88.75, average);
        }


        // Tests whether the "AverageGrade" method returns 0 when all grades are equal to "777"
        [TestMethod]
        public void AverageGrade_WhenAllGradesAre777_ReturnsZero()
        {
            student.Grades = new int[] { 777, 777, 777, 777, 777 };

            double result = student.AverageGrade();

            Assert.AreEqual(0, result);
        }


        // Tests whether the "AverageGrade" method returns 0 when no grades are provided
        [TestMethod]
        public void AverageGrade_WhenNoGradesAreProvided_ReturnsZero()
        {
            student.Grades = new int[] { };

            double result = student.AverageGrade();

            Assert.AreEqual(0, result);
        }
    }
}