using CursusOverzichtApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursusOverzichtApiTests.ServicesTest
{
    class ExtractDuurServiceTest
    {
        [TestMethod]
        public void ValidInputTextExtractsValidCode() {

            //Arrange
            string inputText = "Duur: 5 dagen";
            int expected = 5;
            CheckFile checkFile = new CheckFile();

            //Act
            int actual = checkFile.ExtractDuur(inputText);

            // Assert
            Assert.IsTrue(actual == expected);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NullValueShouldThrowError() {
            
            // Arrange
            string input = null;
            CheckFile checkFile = new CheckFile();
            
            // Act
            checkFile.ExtractDuur(input);
        }
    }
}
