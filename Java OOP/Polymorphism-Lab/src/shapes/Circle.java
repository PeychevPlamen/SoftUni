package shapes;

public class Circle extends Shape implements CircleInterface{
    private Double radius;

    public Circle(Double radius) {
        setRadius(radius);
    }

    @Override
    Double calculatePerimeter() {
        return 2 * Math.PI * radius;
    }

    @Override
    Double calculateArea() {
        return Math.PI * radius * radius;
    }

    @Override
    public final Double getRadius() {
        return radius;
    }

    public void setRadius(Double radius) {
        this.radius = radius;
    }
}
