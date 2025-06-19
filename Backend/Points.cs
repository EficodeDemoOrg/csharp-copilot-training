namespace Backend;

/// <summary>
/// Represents a point in a 2D space with X and Y coordinates.
/// </summary>
public class Points : IEquatable<Points>
{
    /// <summary>
    /// Gets or sets the X coordinate of the point.
    /// </summary>
    public double X { get; set; }

    /// <summary>
    /// Gets or sets the Y coordinate of the point.
    /// </summary>
    public double Y { get; set; }

    /// <summary>
    /// Initialises a new instance of the Points class with the specified coordinates.
    /// </summary>
    /// <param name="x">The X coordinate.</param>
    /// <param name="y">The Y coordinate.</param>
    public Points(double x, double y)
    {
        X = x;
        Y = y;
    }

    /// <summary>
    /// Initialises a new instance of the Points class at the origin (0, 0).
    /// </summary>
    public Points() : this(0, 0)
    {
    }

    /// <summary>
    /// Gets the origin point (0, 0).
    /// </summary>
    public static Points Origin => new(0, 0);    /// <summary>
    /// Calculates the distance from this point to another point.
    /// </summary>
    /// <param name="other">The other point.</param>
    /// <returns>The distance between the two points.</returns>
    public double DistanceTo(Points? other)
    {
        if (other is null)
            throw new ArgumentNullException(nameof(other));

        var deltaX = X - other.X;
        var deltaY = Y - other.Y;
        return Math.Sqrt(deltaX * deltaX + deltaY * deltaY);
    }

    /// <summary>
    /// Calculates the distance from the origin (0, 0) to this point.
    /// </summary>
    /// <returns>The distance from the origin.</returns>
    public double DistanceFromOrigin() => Math.Sqrt(X * X + Y * Y);    /// <summary>
    /// Calculates the midpoint between this point and another point.
    /// </summary>
    /// <param name="other">The other point.</param>
    /// <returns>The midpoint between the two points.</returns>
    public Points MidpointTo(Points? other)
    {
        if (other is null)
            throw new ArgumentNullException(nameof(other));

        return new Points((X + other.X) / 2, (Y + other.Y) / 2);
    }

    /// <summary>
    /// Translates this point by the specified offset.
    /// </summary>
    /// <param name="deltaX">The X offset.</param>
    /// <param name="deltaY">The Y offset.</param>
    /// <returns>A new point with the translated coordinates.</returns>
    public Points Translate(double deltaX, double deltaY)
    {
        return new Points(X + deltaX, Y + deltaY);
    }

    /// <summary>
    /// Scales this point by the specified factor.
    /// </summary>
    /// <param name="factor">The scaling factor.</param>
    /// <returns>A new point with the scaled coordinates.</returns>
    public Points Scale(double factor)
    {
        return new Points(X * factor, Y * factor);
    }

    /// <summary>
    /// Rotates this point around the origin by the specified angle.
    /// </summary>
    /// <param name="angleInRadians">The rotation angle in radians.</param>
    /// <returns>A new point with the rotated coordinates.</returns>
    public Points Rotate(double angleInRadians)
    {
        var cos = Math.Cos(angleInRadians);
        var sin = Math.Sin(angleInRadians);
        return new Points(X * cos - Y * sin, X * sin + Y * cos);
    }    /// <summary>
    /// Rotates this point around another point by the specified angle.
    /// </summary>
    /// <param name="center">The center point of rotation.</param>
    /// <param name="angleInRadians">The rotation angle in radians.</param>
    /// <returns>A new point with the rotated coordinates.</returns>
    public Points RotateAround(Points? center, double angleInRadians)
    {
        if (center is null)
            throw new ArgumentNullException(nameof(center));

        // Translate to origin, rotate, then translate back
        var translated = Translate(-center.X, -center.Y);
        var rotated = translated.Rotate(angleInRadians);
        return rotated.Translate(center.X, center.Y);
    }    /// <summary>
    /// Adds two points together.
    /// </summary>
    public static Points operator +(Points? left, Points? right)
    {
        if (left is null) throw new ArgumentNullException(nameof(left));
        if (right is null) throw new ArgumentNullException(nameof(right));
        return new Points(left.X + right.X, left.Y + right.Y);
    }

    /// <summary>
    /// Subtracts one point from another.
    /// </summary>
    public static Points operator -(Points? left, Points? right)
    {
        if (left is null) throw new ArgumentNullException(nameof(left));
        if (right is null) throw new ArgumentNullException(nameof(right));
        return new Points(left.X - right.X, left.Y - right.Y);
    }

    /// <summary>
    /// Multiplies a point by a scalar value.
    /// </summary>
    public static Points operator *(Points? point, double scalar)
    {
        if (point is null) throw new ArgumentNullException(nameof(point));
        return new Points(point.X * scalar, point.Y * scalar);
    }

    /// <summary>
    /// Multiplies a point by a scalar value.
    /// </summary>
    public static Points operator *(double scalar, Points? point)
    {
        return point * scalar;
    }    /// <summary>
    /// Divides a point by a scalar value.
    /// </summary>
    public static Points operator /(Points? point, double scalar)
    {
        if (point is null) throw new ArgumentNullException(nameof(point));
        if (Math.Abs(scalar) < double.Epsilon)
            throw new DivideByZeroException("Cannot divide by zero");
        return new Points(point.X / scalar, point.Y / scalar);
    }

    /// <summary>
    /// Determines whether two points are equal.
    /// </summary>
    public static bool operator ==(Points left, Points right)
    {
        if (ReferenceEquals(left, right)) return true;
        if (left is null || right is null) return false;
        return left.Equals(right);
    }

    /// <summary>
    /// Determines whether two points are not equal.
    /// </summary>
    public static bool operator !=(Points left, Points right)
    {
        return !(left == right);
    }

    /// <summary>
    /// Determines whether this point is equal to another point.
    /// </summary>
    public bool Equals(Points? other)
    {
        if (other is null) return false;
        if (ReferenceEquals(this, other)) return true;
        return Math.Abs(X - other.X) < double.Epsilon && Math.Abs(Y - other.Y) < double.Epsilon;
    }

    /// <summary>
    /// Determines whether this point is equal to another object.
    /// </summary>
    public override bool Equals(object? obj)
    {
        return Equals(obj as Points);
    }

    /// <summary>
    /// Returns the hash code for this point.
    /// </summary>
    public override int GetHashCode()
    {
        return HashCode.Combine(X, Y);
    }

    /// <summary>
    /// Returns a string representation of this point.
    /// </summary>
    public override string ToString()
    {
        return $"({X:F2}, {Y:F2})";
    }

    /// <summary>
    /// Returns a string representation of this point with the specified format.
    /// </summary>
    /// <param name="format">The format string for the coordinates.</param>
    public string ToString(string format)
    {
        return $"({X.ToString(format)}, {Y.ToString(format)})";
    }

    /// <summary>
    /// Creates a copy of this point.
    /// </summary>
    public Points Clone()
    {
        return new Points(X, Y);
    }
}