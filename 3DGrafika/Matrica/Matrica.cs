using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _3DGrafika.Matrica
{
    public class Matrica
    {
        public const int Size = 4;
        private double[,] _matrica;

        public Matrica()
        {
            _matrica = new double[Size, Size];
            PretvoriUJedinicnu();
        }

        public Matrica(Matrica matrica)
        {
            _matrica = matrica._matrica;
        }

        public Matrica(double[,] matrica)
        {
            if (matrica.GetLength(0) != Size || matrica.GetLength(1) != Size)
            {
                throw new Exception("Matrica mora biti " + Size + "x" + Size  + " velicine.");
            }

            _matrica = matrica;
        }

        public double this[int indexX, int indexY]
        {
            get { return _matrica[indexX, indexY]; }
            set { _matrica[indexX, indexY] = value; }
        }

        public void PretvoriUJedinicnu()
        {
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    _matrica[i, j] = Convert.ToDouble(i == j);
                }
            }
        }
        
        public static Matrica operator +(Matrica m1, Matrica m2)
        {
            var mSum = new Matrica();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    mSum[i, j] = m1[i, j] + m2[i, j];
                }
            }

            return mSum;
        }

        public static Matrica operator -(Matrica m1, Matrica m2)
        {
            var mSum = new Matrica();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    mSum[i, j] = m1[i, j] - m2[i, j];
                }
            }

            return mSum;
        }

        public static Matrica operator *(Matrica m1, Matrica m2)
        {
            var m3 = new Matrica();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    m3[i, j] = 0;
                    for (int k = 0; k < Size; k++)
                    {
                        m3[i, j] += m1[i, k] * m2[k, j];
                    }
                }
            }

            return m3;
        }

        public static Tocka operator *(Tocka t1, Matrica m1)
        {
            var t2 = new Tocka();
            for (int i = 0; i < Size; i++)
            {
                for (int j = 0; j < Size; j++)
                {
                    t2[i] += (m1[i, j] * t1[j]);
                }
            }

            return t2;
        }
    }
}
