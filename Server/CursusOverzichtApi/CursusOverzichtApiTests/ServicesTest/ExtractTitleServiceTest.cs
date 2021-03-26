using CursusOverzichtApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursusOverzichtApiTests.ServicesTest
{
    [TestClass]
    class ExtractTitleServiceTest
    {
        [TestMethod]
        public void ValidInputTextExtractsValidTitle() {

            //Arrange
            string inputText = "Titel: C# Programmeren";
            string expected = " C# Programmeren";
            CheckFile checkFile = new CheckFile();

            //Act
            string actual = checkFile.ExtractTitle(inputText);

            // Assert
            Assert.IsTrue(string.Equals(actual, expected));
        }


        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullValueShouldThrowError() {
            // Arrange

            string input = null;
            CheckFile checkFile = new CheckFile();
            // Act
            checkFile.ExtractTitle(input);

        }
    }
}

