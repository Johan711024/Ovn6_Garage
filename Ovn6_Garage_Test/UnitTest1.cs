using Moq;
using Ovn6_Garage;
using Ovn6_Garage.UserInterface;

namespace Ovn6_Garage_Test
{
    public class UnitTest1
    {
        //    [Fact]

        //    public void Garage_Constructor_SetCorrectCapacity()
        //    {
        //        const int expected = 10;
        //        IUI ui = null!;

        //        var mockHandler = new Mock<IHandler>();


        //        //mockHandler.Setup(m => m.MaximumSpots);

        //        var garage = new Mock<IGarage<Vehicle>>();

        //        var handler = new Handler(garage, expected, ui);



        //        Assert.Equal(expected, garage.);
        //    }
        [Fact]
        public void Garage_Constructor_SetCorrectCapacity()
        {
            // Arrange
            const int expected = 10;

            IUI ui = null!;

            

            

            var garage = new Garage<Vehicle>(expected, ui);

            //  var handler = new Handler(expected, ui);



            // Act
            var actual = garage.Capacity;

            // Assert
            Assert.True(actual == expected);
            //Assert.AreEqual(expected, actual);
        }


    }

    
}