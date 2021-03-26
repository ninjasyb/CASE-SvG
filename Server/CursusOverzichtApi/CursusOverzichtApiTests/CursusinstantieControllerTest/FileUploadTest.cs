using CursusOverzichtApi.Controllers;
using CursusOverzichtApi.Models;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Moq;


namespace CursusOverzichtApiTests.CursusinstantieControllerTest
{
    class FileUploadTest
    {
        [TestMethod]
        public void ValidInputShouldReturn() {
            //Arrange
            var DbMock = new Mock<CursusContext>();

            string input = '';
            CursusinstantiesController cursusinstantieController = new CursusinstantiesController(DbMock.);
            //Act

            //Assert

        }
    }
}
