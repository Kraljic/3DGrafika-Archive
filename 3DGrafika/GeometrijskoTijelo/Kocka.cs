using System;
using System.Collections.Generic;
using System.Drawing;
using _3DGrafika.Matrica;

namespace _3DGrafika.GeometrijskoTijelo
{
    public class Kocka
    {
        private List<Tocka> vrhovi = new List<Tocka>();

        public Tocka[] vrhovi3D
        {
             get { return vrhovi.ToArray(); }
        }

        public Kocka()
        {
        }
    }
}