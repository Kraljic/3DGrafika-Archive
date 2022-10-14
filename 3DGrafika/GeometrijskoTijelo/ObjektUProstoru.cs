using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using _3DGrafika.Matrica;

namespace _3DGrafika.GeometrijskoTijelo
{
    public class ObjektUProstoru
    {
        private List<Tocka> _vrhovi = new List<Tocka>();

        public Tocka[] vrhovi3D
        {
            get { return _vrhovi.ToArray(); }
        }

        public ObjektUProstoru(double[][] vrhovi)
        {
            foreach (var d in vrhovi)
            {
                _vrhovi.Add(new Tocka(d));
            }
        }
    }
}
