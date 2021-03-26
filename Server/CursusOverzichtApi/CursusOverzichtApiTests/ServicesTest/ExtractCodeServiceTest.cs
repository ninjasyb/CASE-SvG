using CursusOverzichtApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursusOverzichtApiTests.ServicesTest
{
    class ExtractCodeServiceTest
    {
        [TestMethod]
        public void ValidInputTextExtractsValidCode() {

            //Arrange
            string inputText = "Cursuscode: CNETIN";
            string expected = "CNETIN";
            CheckFile checkFile = new CheckFile();

            //Act
            string actual = checkFile.ExtractCode(inputText);

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
            checkFile.ExtractCode(input);

        }
    }
}
