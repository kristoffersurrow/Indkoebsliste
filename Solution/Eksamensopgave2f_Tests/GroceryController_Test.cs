using Eksamensopgave2f.Controllers;
using Eksamensopgave2f.Interfaces;
using Eksamensopgave2f.Models;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Eksamensopgave2f_Tests
{
    public class GroceryController_Test
    {
        [Fact]
        public void Get_ShouldReturnAllItems()
        {
            //Arrange
            var mockGroceryRepository = new Mock<IGroceryRepository>();
            mockGroceryRepository.Setup(repo => repo.Get()).Returns(groceryList);

            var controller = new GroceryController(mockGroceryRepository.Object);

            //Act
            var result = (List<GroceryTable>)controller.Get();

            //Assert
            Assert.NotNull(result);
            Assert.Equal(3, result.Count);
        }

        [Fact]
        public void Post_ShouldRunOnce()
        {
            //Arrange

            GroceryTable grocery = new GroceryTable { Id = 3, Name = "Cola", Checkmark = false };

            var mockGroceryRepository = new Mock<IGroceryRepository>();
            mockGroceryRepository.Setup(repo => repo.Post(grocery));

            var controller = new GroceryController(mockGroceryRepository.Object);

            //Act
            controller.Post(grocery);

            //Assert
            mockGroceryRepository.Verify(x => x.Post(grocery), Times.Exactly(1));
        }

        private List<GroceryTable> groceryList = new List<GroceryTable>
        {
            new GroceryTable{ Id = 0, Name = "Chokolade", Checkmark  = true},
            new GroceryTable{ Id = 1, Name = "Slik", Checkmark  = true},
            new GroceryTable{ Id = 2, Name = "Chips", Checkmark  = false}
        };
    }
}
