using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace _3DGrafika.Matrica
{
    public class Rotacija
    {
        public static Matrica XOsMatrica(double angle)
        {
            angle = (Math.PI / 180) * angle;

            var sin = Math.Sin(angle);
            var cos = Math.Cos(angle);

            Matrica m1 = new Matrica(new double[,]
            {
                {1, 0, 0, 0 },
                {0, cos, -sin, 0 },
                {0, sin, cos, 0 },
                {0, 0, 0, 0 },
            });
            return m1;
        }

        public static Matrica YOsMatrica(double angle)
        {
            angle = (Math.PI / 180) * angle;

            var sin = Math.Sin(angle);
            var cos = Math.Cos(angle);

            Matrica m1 = new Matrica(new double[,]
            {
                {cos, 0, sin, 0 },
                {0, 1, 0, 0 },
                {-sin, 0, cos, 0 },
                {0, 0, 0, 0 },
            });

            return m1;
        }

        public static Matrica ZOsMatrica(double angle)
        {
            angle = (Math.PI / 180) * angle;

            var sin = Math.Sin(angle);
            var cos = Math.Cos(angle);

            Matrica m1 = new Matrica(new double[,]
            {
                {cos, -sin, 0, 0 },
                {sin, cos, 0, 0 },
                {0, 0, 1, 0 },
                {0, 0, 0, 0 },
            });

            return m1;
        }
    }
}
