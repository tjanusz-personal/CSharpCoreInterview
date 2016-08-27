namespace FirstService
{

    public class Rectangle : Shape {

        public double Width { get; set; }
        public double Height { get; set; }

        public Rectangle(double height, double width) {
            this.Height = height;
            this.Width = width;
        }
        
        public override double Area() {
            return this.Width * this.Height;
        }

    }

}


