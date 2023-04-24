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
    [TestClass()]
    public class ManuallyAddStudentTests
    {

        //////////////////////////// IsAlphabetic ////////////////////////////

        [TestClass()]
        public class IsAlphabetic
        {
            private AddStudentForm addStudentForm;

            [TestInitialize]
            public void Setup()
            {
                addStudentForm = new AddStudentForm();
            }

            [TestMethod()]
            public void IsAlphabetic_ReturnsTrue_ForValidInput()
            {

                // Arrange
                string input = "John";

                // Act
                bool result = addStudentForm.IsAlphabetic(input);

                // Assert
                Assert.IsTrue(result);
            }

            [TestMethod()]
            public void IsAlphabetic_ReturnsFalse_ForInputWithNumbers()
            {

                // Arrange
                string input = "John123";

                // Act
                bool result = addStudentForm.IsAlphabetic(input);

                // Assert
                Assert.IsFalse(result);
            }

            [TestMethod()]
            public void IsAlphabetic_ReturnsFalse_ForInputWithSpecialCharacters()
            {

                // Arrange
                string input = "John@#$";

                // Act
                bool result = addStudentForm.IsAlphabetic(input);

                // Assert
                Assert.IsFalse(result);
            }

            [TestMethod()]
            public void IsAlphabetic_ReturnsFalse_ForEmptyInput()
            {

                // Arrange
                string input = "";

                // Act
                bool result = addStudentForm.IsAlphabetic(input);

                // Assert
                Assert.IsFalse(result);
            }

            [TestMethod()]
            public void IsAlphabetic_ReturnsFalse_ForNullInput()
            {

                // Arrange
                string input = null;

                // Act
                bool result = addStudentForm.IsAlphabetic(input);

                // Assert
                Assert.IsFalse(result);
            }
        }


        //////////////////////////// IsNumeric ////////////////////////////

        [TestClass()]
        public class IsNumeric
        {
            private AddStudentForm addStudentForm;

            [TestInitialize]
            public void Setup()
            {
                addStudentForm = new AddStudentForm();
            }

            [TestMethod()]
            public void IsNumeric_GivenNumericString_ReturnsTrue()
            {

                string input = "1234567890";

                bool result = addStudentForm.IsNumeric(input);

                Assert.IsTrue(result);
            }

            [TestMethod()]
            public void IsNumeric_GivenNonNumericString_ReturnsFalse()
            {

                string input = "abcde";

                bool result = addStudentForm.IsNumeric(input);

                Assert.IsFalse(result);
            }

            [TestMethod()]
            public void IsNumeric_GivenEmptyString_ReturnsFalse()
            {

                string input = "";

                bool result = addStudentForm.IsNumeric(input);

                Assert.IsFalse(result);
            }

            [TestMethod()]
            public void IsNumeric_GivenNull_ReturnsFalse()
            {

                string input = null;

                bool result = addStudentForm.IsNumeric(input);

                Assert.IsFalse(result);
            }

            [TestMethod()]
            public void IsNumeric_GivenMixedString_ReturnsFalse()
            {

                string input = "123abc";

                bool result = addStudentForm.IsNumeric(input);

                Assert.IsFalse(result);
            }

        }


        //////////////////////////// IsValidIdLength ////////////////////////////

        [TestClass()]
        public class IsValidIdLength
        {
            private AddStudentForm addStudentForm;

            [TestInitialize]
            public void Setup()
            {
                addStudentForm = new AddStudentForm();
            }

            [TestMethod()]
            public void IsValidIdLength_GivenValidLengnth_ReturnsTrue()
            {

                string input = "123123123";

                bool result = addStudentForm.IsValidIdLength(input);

                Assert.IsTrue(result);
            }

            [TestMethod()]
            public void IsValidIdLength_GivenInvalidLengnth_ReturnsFalse()
            {

                string input = "0555555555";

                bool result = addStudentForm.IsValidIdLength(input);

                Assert.IsFalse(result);
            }

            [TestMethod()]
            public void IsValidIdLength_GivenEmptyString_ReturnsFalse()
            {

                string input = "";

                bool result = addStudentForm.IsValidIdLength(input);

                Assert.IsFalse(result);
            }

            [TestMethod()]
            public void IsValidIdLength_GivenNull_ReturnsFalse()
            {

                string input = null;

                bool result = addStudentForm.IsValidIdLength(input);

                Assert.IsFalse(result);
            } 

        }


        //////////////////////////// IsValidPhone ////////////////////////////

        [TestClass()]
        public class IsValidPhone
        {
            private AddStudentForm addStudentForm;

            [TestInitialize]
            public void Setup()
            {
                addStudentForm = new AddStudentForm();
            }

            [TestMethod()]
            public void IsValidPhone_GivenValidPhone_ReturnsTrue()
            {

                string input = "0555555555";

                bool result = addStudentForm.IsValidPhone(input);

                Assert.IsTrue(result);
            }

            [TestMethod()]
            public void IsValidPhone_GivenLetters_ReturnsFalse()
            {

                string input = "dsadsadas";

                bool result = addStudentForm.IsValidPhone(input);

                Assert.IsFalse(result);
            }

            [TestMethod()]
            public void IsValidPhone_GivenInvalidLength_ReturnsFalse()
            {

                string input = "051234567";

                bool result = addStudentForm.IsValidPhone(input);

                Assert.IsFalse(result);
            }

            [TestMethod()]
            public void IsValidPhone_GivenInvalidStart_ReturnsFalse()
            {

                string input = "0212345678";

                bool result = addStudentForm.IsValidPhone(input);

                Assert.IsFalse(result);
            }


            [TestMethod()]
            public void IsValidPhone_GivenEmptyString_ReturnsFalse()
            {

                string input = "";

                bool result = addStudentForm.IsValidPhone(input);

                Assert.IsFalse(result);
            }

            [TestMethod()]
            public void IsValidPhone_GivenNull_ReturnsFalse()
            {

                string input = null;

                bool result = addStudentForm.IsValidPhone(input);

                Assert.IsFalse(result);
            }

        }

        //////////////////////////// IsValidEmail ////////////////////////////

        [TestClass()]
        public class IsValidEmail
        {
            private AddStudentForm addStudentForm;

            [TestInitialize]
            public void Setup()
            {
                addStudentForm = new AddStudentForm();
            }

            [TestMethod()]
            public void IsValidEmail_GivenValidEmail_ReturnsTrue()
            {

                string input = "shamoon23@gmail.com";
                bool result = addStudentForm.IsValidEmail(input);

                Assert.IsTrue(result);
            }

            [TestMethod()]
            public void IsValidEmail_NoShtrudle_ReturnsFalse()
            {

                string input = "shamoon23";

                bool result = addStudentForm.IsValidEmail(input);

                Assert.IsFalse(result);
            }

            [TestMethod()]
            public void IsValidEmail_NoDot_ReturnsFalse()
            {

                string input = "shamoon23@sce";

                bool result = addStudentForm.IsValidEmail(input);

                Assert.IsFalse(result);
            }

            [TestMethod()]
            public void IsValidEmail_NoCharsBetweenShrudleAndDot_ReturnsFalse()
            {

                string input = "shamoon23@.";

                bool result = addStudentForm.IsValidEmail(input);

                Assert.IsFalse(result);
            }

            [TestMethod()]
            public void IsValidEmail_NoName_ReturnsFalse()
            {

                string input = "@sce.ac";

                bool result = addStudentForm.IsValidEmail(input);

                Assert.IsFalse(result);
            }


            [TestMethod()]
            public void IsValidEmail_GivenEmptyString_ReturnsFalse()
            {

                string input = "";

                bool result = addStudentForm.IsValidEmail(input);

                Assert.IsFalse(result);
            }

            [TestMethod()]
            public void IsValidEmail_GivenNull_ReturnsFalse()
            {

                string input = null;

                bool result = addStudentForm.IsValidEmail(input);

                Assert.IsFalse(result);
            }

        }


        //////////////////////////// IsValidGrade ////////////////////////////

        [TestClass()]
        public class IsValidGrade
        {
            private AddStudentForm addStudentForm;

            [TestInitialize]
            public void Setup()
            {
                addStudentForm = new AddStudentForm();
            }

            [TestMethod()]
            public void IsValidGrade_GivenValidGrades_ReturnsTrue()
            {

                int input1 = 0;
                int input2 = 50;
                int input3 = 100;
                int input4 = 777;

                bool result1 = addStudentForm.IsValidGrade(input1);
                bool result2 = addStudentForm.IsValidGrade(input2);
                bool result3 = addStudentForm.IsValidGrade(input3);
                bool result4 = addStudentForm.IsValidGrade(input4);

                Assert.IsTrue(result1);
                Assert.IsTrue(result2);
                Assert.IsTrue(result3);
                Assert.IsTrue(result4);


            }

            [TestMethod()]
            public void IsValidGrade_InvalidGrade_ReturnsFalse()
            {

                int input1 = 101;
                int input2 = -1;

                bool result1 = addStudentForm.IsValidGrade(input1);
                bool result2 = addStudentForm.IsValidGrade(input2);


                Assert.IsFalse(result1);
                Assert.IsFalse(result2);


            }

        }
    }
}