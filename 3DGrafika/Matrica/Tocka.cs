using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DGrafika.Matrica
{
    public class Tocka
    {
        public const int Size = 4;
        private double[] _tocka;

        public Tocka()
        {
            _tocka = new double[Size];

            for (int i = 0; i < Size; i++)
            {
                _tocka[i] = 0;
                if (i == Size - 1)
                    _tocka[i] = 1;
            }
        }

        public Tocka(double[] tocka)
        {
            if (tocka.GetLength(0) != Size )
            {
                throw new Exception("Tocka mora biti " + Size + " velicine.");
            }

            _tocka = tocka;
        }

        public double this[int index]
        {
            get { return _tocka[index]; }
            set { _tocka[index] = value; }
        }

        public static Tocka operator +(Tocka t1, Tocka t2)
        {
            var tSum = new Tocka();
            for (int i = 0; i < Size; i++)
            {
                tSum[i] = t1[i] + t2[i];
            }

            return tSum;
        }

        public static Tocka operator -(Tocka t1, Tocka t2)
        {
            var tDiff = new Tocka();
            for (int i = 0; i < Size; i++)
            {
                tDiff[i] = t1[i] - t2[i];
            }

            return tDiff;
        }

    }
}
