using FirstService;
using Xunit;
using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace FirstService.Tests
{
    public class AreaCalculatorTest
    {
        private AreaCalculator calculator;

        public void setup()
        {
            calculator = new AreaCalculator();
        }

        [Fact]
        public void AreaCalculatesForAllRectangles()
        {
            setup();
            List<Shape> rectangles = new List<Shape>();
            rectangles.Add(new Rectangle(10, 10));
            rectangles.Add(new Rectangle(5, 10));
            Assert.Equal(150, calculator.CalculatedTotalArea(rectangles));
        }

                [Fact]
        public void AreaCalculatesForRectanglesAndSquares()
        {
            setup();
            List<Shape> rectangles = new List<Shape>();
            rectangles.Add(new Rectangle(10, 10));
            rectangles.Add(new Square(5));
            Assert.Equal(125, calculator.CalculatedTotalArea(rectangles));
        }

    }

}