package ClassBoxDataValidation_01;

public class Box {
    private double length;
    private double width;
    private double height;

    public Box(double length, double width, double height) {
        setLength(length);
        setWidth(width);
        setHeight(height);
    }

    public double getLength() {
        return length;
    }

    private void setLength(double length) {
        if (Validation(length)) {
            throw new IllegalArgumentException("Length cannot be zero or negative.");
        }
        this.length = length;
    }

    public double getWidth() {
        return width;
    }

    private void setWidth(double width) {
        if (Validation(width)) {
            throw new IllegalArgumentException("Width cannot be zero or negative.");
        }
        this.width = width;
    }

    public double getHeight() {
        return height;
    }

    private void setHeight(double height) {
        if (Validation(height)) {
            throw new IllegalArgumentException("Height cannot be zero or negative.");
        }
        this.height = height;
    }

    public double calculateSurfaceArea() {
        return 2 * getLength() * getWidth() + 2 * getLength() * getHeight() + 2 * getHeight() * getWidth();
    }

    public double calculateLateralSurfaceArea() {
        return 2 * getHeight() * (getLength() + getWidth());
    }

    public double calculateVolume() {
        return getWidth() * getHeight() * getLength();
    }

    private boolean Validation(double num) {
        return num < 1;
    }

    @Override
    public String toString() {
        StringBuilder sb = new StringBuilder();
        sb.append("Surface Area").append(" - ").append(String.format("%.2f%n",calculateSurfaceArea()));
        sb.append("Lateral Surface Area").append(" - ").append(String.format("%.2f%n",calculateLateralSurfaceArea()));
        sb.append("Volume").append(" - ").append(String.format("%.2f%n",calculateVolume()));

        return sb.toString().trim();
    }
}
