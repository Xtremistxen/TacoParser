using System;
using Xunit;

namespace LoggingKata.Test
{
    public class TacoParserTests
    {
        [Fact]
        public void ShouldReturnNonNullObject()
        {
            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse("34.073638, -84.677017, Taco Bell Acwort...");

            //Assert
            Assert.NotNull(actual);

        }

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", -84.677017)]
        //Below are my own tacos bells in fortworth
        [InlineData("32.77285, -97.40084, Taco bell Riveroak...", -97.40084)] 
        [InlineData("32.76217, -97.48288, Taco Bell Whitesettl...", -97.48288)]
        [InlineData("32.75423,-97.33937,Taco Bell Weatherfrd...", -97.33937)]
        //Add additional inline data. Refer to your CSV file.
        public void ShouldParseLongitude(string line, double expected)
        {
            
            // TODO: Complete the test with Arrange, Act, Assert steps below.
            //       Note: "line" string represents input data we will Parse 
            //       to extract the Longitude.  
            //       Each "line" from your .csv file
            //       represents a TacoBell location

            //Arrange
            var tacoPaser = new TacoParser();

            //Act
            var actual = tacoPaser.Parse(line).Location.Longitude;

            //Assert
            Assert.Equal(expected, actual);
        }
        //TODO: Create a test called ShouldParseLatitude
        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", 34.073638)]
        //Below are my own tacos bells in fortworth
        [InlineData("32.77285, -97.40084, Taco bell Riveroak...", 32.77285)]
        [InlineData("32.76217, -97.48288, Taco Bell Whitesettl...", 32.76217)]
        [InlineData("32.75423,-97.33937,Taco Bell Weatherfrd...", 32.75423)]
        public void ShouldParseLatitude(string line, double expected)
        {


            //Arrange
            var tacoParser = new TacoParser();

            //Act
            var actual = tacoParser.Parse(line).Location.Latitude;

            //Assert
            Assert.Equal(expected, actual);
        }
        

        [Theory]
        [InlineData("34.073638, -84.677017, Taco Bell Acwort...", "Taco Bell Acwort...")]
        //Below are my own tacos bells in fortworth
        [InlineData("32.77285, -97.40084, Taco bell Riveroak...", "Taco Bell Roveroak...")]
        [InlineData("32.76217, -97.48288, Taco Bell Whitesettl...", "Taco Bell Whitesettl...")]
        [InlineData("32.75423,-97.33937,Taco Bell Weatherfrd...", "Weatherfrd...")]
        public void ShouldParseStoreName(string line, string expected) //Create a list to test storename
        {
            //Arrange
            var tacoPaser = new TacoParser();
            
            //Act
            var actual = tacoPaser.Parse(line).Name;

            //Assert
            Assert.Equal(expected, actual);
        }
        

    }
}
