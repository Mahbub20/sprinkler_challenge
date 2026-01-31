using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sprinkler_Challenge
{
    public class Pipe
    {
        public Point3D Start;
        public Point3D End;

        public Pipe(Point3D start, Point3D end)
        {
            Start = start;
            End = end;
        }

        public Point3D ClosestPoint(Point3D p)
        {
            var ab = End - Start;
            var ap = p - Start;

            double t = ap.Dot(ab) / ab.Dot(ab);
            t = Math.Max(0, Math.Min(1, t));

            return Start + ab * t;
        }
    }
}