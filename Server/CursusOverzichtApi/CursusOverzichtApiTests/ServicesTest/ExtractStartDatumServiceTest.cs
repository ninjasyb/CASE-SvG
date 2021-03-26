using CursusOverzichtApi.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace CursusOverzichtApiTests.ServicesTest
{
    class ExtractStartDatumServiceTest
    {
        [TestMethod]
        public void ValidInputTextExtractsValidCode() {

            //Arrange
            string inputText = "Startdatum: 15/10/2018";
            DateTime expected = new DateTime(2018, 10, 15);
            CheckFile checkFile = new CheckFile();

            //Act
            DateTime actual = checkFile.ExtractStartDatum(inputText);

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
            checkFile.ExtractStartDatum(input);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]

        public void ShouldThrowExceptionWhenNotDateButFormatted() {

            //Arrange
            string inputText = "Startdatum: 15/13/2018"; // 13e maand
            CheckFile checkFile = new CheckFile();

            //Act & Assert
            checkFile.ExtractStartDatum(inputText);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        public void ShouldThrowExceptionWhenNotDateNotFormatted() {

            //Arrange
            string inputText = "Startdatum: testing"; // Geen datum
            CheckFile checkFile = new CheckFile();

            //Act & Assert
            checkFile.ExtractStartDatum(inputText);
        }
    }
}
