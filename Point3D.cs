using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprinkler_Challenge
{
    public class Point3D
    {
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }

        public Point3D(double x, double y, double z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public static Point3D operator +(Point3D a, Point3D b)
    => new Point3D(a.X + b.X, a.Y + b.Y, a.Z + b.Z);

        public static Point3D operator -(Point3D a, Point3D b)
            => new Point3D(a.X - b.X, a.Y - b.Y, a.Z - b.Z);

        public static Point3D operator *(Point3D a, double t)
            => new Point3D(a.X * t, a.Y * t, a.Z * t);

        public double Dot(Point3D p)
            => X * p.X + Y * p.Y + Z * p.Z;

        public double Length()
            => Math.Sqrt(X * X + Y * Y + Z * Z);

        public override string ToString()
            => $"({X:F2}, {Y:F2}, {Z:F2})";
    }
}