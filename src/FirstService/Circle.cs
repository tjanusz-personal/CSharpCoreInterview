using System;

public sealed class Circle {

    private double radius;

    public Circle(double theRadius) {
        this.radius = theRadius;
    }

    public double Calculate(Func<double, double> op) {
        return op(radius);
    }

}