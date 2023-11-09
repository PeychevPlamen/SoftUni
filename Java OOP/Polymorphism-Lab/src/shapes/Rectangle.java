package shapes;

public class Rectangle extends Shape implements RectangleInterface{
    private Double height;
    private Double width;

    public Rectangle(Double height, Double width) {
        setHeight(height);
        setHeight(width);
    }

    @Override
    Double calculatePerimeter() {
        return 2 * height + 2 * width;
    }

    @Override
    Double calculateArea() {
        return height * width;
    }

    public void setHeight(Double height) {
        this.height = height;
    }

    public void setWidth(Double width) {
        this.width = width;
    }

    @Override
    public Double getHeight() {
        return height;
    }

    @Override
    public Double getWidth() {
        return width;
    }
}
