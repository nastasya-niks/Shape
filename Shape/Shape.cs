using Microsoft.Analytics.Interfaces;
using Microsoft.Analytics.Interfaces.Streaming;
using Microsoft.Analytics.Types.Sql;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Shape
{
        public abstract class Shape
        {
            public abstract decimal AreaValue { get; set; }
            public abstract decimal Area();
        }

        public class Circle : Shape
        {
            public double Radius { get; set; }
            public override decimal AreaValue { get; set; }
            public override decimal Area()
            {
                return AreaValue = (decimal)(Math.PI * Math.Pow(Radius, 2));
            }
        }

        public class Triangle : Shape
        {
            public int A;
            public int B;
            public int C;
            public int Perimetr { get; set; }
            public double cathets;
            public double hypotenuse;
            public override decimal AreaValue { get; set; }

            public int PerimetrValue()
            {
                return Perimetr = (A + B + C) / 2;
            }
            public override decimal Area()
            {
                return AreaValue = (decimal)Math.Sqrt(Perimetr * (Perimetr - A) * (Perimetr - B) * (Perimetr - C));
            }

            public bool IsRectangular()
            {
                double[] valueArray = new double[] { A, B, C };
                double valueMax = valueArray.Max();
                hypotenuse = Math.Pow(valueMax, 2);
                valueArray.ToList().Remove(valueMax);
                cathets = Math.Pow(valueArray[0], 2) * Math.Pow(valueArray[1], 2);
                if (cathets == hypotenuse) return true;
                else return false;
            }

        }
    }
