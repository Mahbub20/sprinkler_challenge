using System;
using System.Collections.Generic;
using Sprinkler_Challenge;

class Program
{
    static void Main()
    {
        // Ceiling points
        var A = new Point3D(97500.01, 34000.00, 2500.00);
        var B = new Point3D(85647.67, 43193.61, 2500.00);
        var C = new Point3D(91776.75, 51095.16, 2530.00);
        var D = new Point3D(103629.07, 41901.55, 2530.00);

        var U = B - A;
        var V = D - A;

        double spacing = 2500.0;

        double uStep = spacing / U.Length();
        double vStep = spacing / V.Length();

        var sprinklers = new List<Point3D>();

        for (double u = uStep; u <= 1 - uStep; u += uStep)
        {
            for (double v = vStep; v <= 1 - vStep; v += vStep)
            {
                sprinklers.Add(A + U * u + V * v);
            }
        }

        var pipes = new List<Pipe>
        {
            new Pipe(
                new Point3D(98242.11, 36588.29, 3000.00),
                new Point3D(87970.10, 44556.09, 3500.00)
            ),
            new Pipe(
                new Point3D(99774.38, 38563.68, 3500.00),
                new Point3D(89502.37, 46531.47, 3000.00)
            ),
            new Pipe(
                new Point3D(101306.65, 40539.07, 3000.00),
                new Point3D(91034.63, 48507.01, 3000.00)
            )
        };

        Console.WriteLine($"Total sprinklers: {sprinklers.Count}\n");

        int index = 1;
        foreach (var s in sprinklers)
        {
            double minDist = double.MaxValue;
            Point3D bestPoint = null;

            foreach (var pipe in pipes)
            {
                var cp = pipe.ClosestPoint(s);
                double dist = (s - cp).Length();

                if (dist < minDist)
                {
                    minDist = dist;
                    bestPoint = cp;
                }
            }

            Console.WriteLine($"Sprinkler {index++}");
            Console.WriteLine($"  Position: {s}");
            Console.WriteLine($"  Connection Point: {bestPoint}");
            Console.WriteLine();
        }
    }
}
