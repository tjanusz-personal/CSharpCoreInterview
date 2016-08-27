using System.Collections;
using System.Linq;
using System.Collections.Generic;

namespace FirstService
{
    public class AreaCalculator {

        public double CalculatedTotalArea(List<Shape> shapes) {
            double total = 0;
            shapes.ForEach( x => total += x.Area() );
            return total;
        }
    }
}