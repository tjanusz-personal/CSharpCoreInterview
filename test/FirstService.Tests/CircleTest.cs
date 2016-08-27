using Xunit;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace FirstService.Tests
{
    public class CircleTest {
        
        delegate void Printer();

        [Fact]
        public void TestCanCalculateCircumferenceWithoutModifyingCircleByUsingRadiusInFunction() {
            Circle circle = new Circle(10);
            double getRadius = circle.Calculate(x => x);
            Assert.Equal((double) 31.4, getRadius * 3.14, 0);
        }

        [Fact]
        public void TestCanCalculateCircumferenceWithoutModifyingCircleByPassingFunctionFormula() {
            Circle circle = new Circle(10);
            Func<double, double> theFunc = ( x => x * 3.14);
            double theCircumference = circle.Calculate(theFunc);
            Assert.Equal((double) 31.4, theCircumference, 0);
        }

        [Fact]
        public void TestDelgateSkips() {
            List<Printer> printers = new List<Printer>();
            List<int> theInts = new List<int>();
            // Add in reference to delegate 
            for (int i = 0; i < 10; i++) {
                printers.Add( delegate { theInts.Add(i); } );
            }

            foreach(var printer in printers) {
                printer();
            }
            Assert.Equal(10, theInts.FindAll(x => x == 10).Count);
        }

        [Fact]
        public void TestMulticastDelegateInvokesAllDelegates() {
            int counter = 0;
            Printer printer1 = delegate { counter++; };
            Printer printer2 = delegate { counter = counter * 2; };
            Printer mutliDelegate = printer1 + printer2;
            mutliDelegate();
            Assert.Equal(2, counter);
        }

        [Fact]
        public void TestReflectionReturnsCorrectTypeInfo() {
            Circle circle = new Circle(10);
            Type theType = circle.GetType();
            Assert.Equal("Circle", theType.FullName);
            FieldInfo[] fields = theType.GetFields();
            Assert.Equal(0, fields.Length);
            MethodInfo methodInfo = theType.GetMethod("Calculate");
            Assert.NotNull(methodInfo);
            Assert.True(methodInfo.IsPublic);   
        }


    }

}

