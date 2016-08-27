namespace FirstService
{
    public class Square : Shape {

        public double Side { get; set; }

        public Square(double side) {
            this.Side = side;
        }

        public override double Area() {
            return this.Side * this.Side;
        }
    }

}