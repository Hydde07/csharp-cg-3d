using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual3D.Entidade;

namespace Visual3D.Metodos
{
	class EquacaoLinha
    {
        public static List<Vertice> pontoMedio(Vertice p1, Vertice p2)
        {
            double dx, dy;
            List<Vertice> lista = new List<Vertice>();
            dx = p2.X - (int) p1.X;
            dy = p2.Y - (int) p1.Y;

            if (Math.Abs(dx) > Math.Abs(dy))
            {
                if ((int) p1.X > p2.X)
                    lista = pontoMedioBaixo(p2, p1);
                else
                    lista = pontoMedioBaixo(p1, p2);
            }
            else
            {
                if ((int) p1.Y > p2.Y)
                    lista = pontoMedioAlto(p2, p1);
                else
                    lista = pontoMedioAlto(p1, p2);
            }
            return lista;
        }

        private static List<Vertice> pontoMedioBaixo(Vertice p1, Vertice p2)
        {
            List<Vertice> pontos = new List<Vertice>();

            int declive = 1;
            double dx = p2.X - (int) p1.X;
            double dy = p2.Y - (int) p1.Y;

            if (dy < 0)
            {
                dy = -dy;
                declive = -1;
            }
            double incE = dy * 2;
            double incNE = (dy * 2) - (dx * 2);
            double d = (dy - dx) * 2;
            int y = (int) p1.Y;

            for (int x = (int) p1.X; x <= p2.X; x++)
            {
                pontos.Add(new Vertice(x, y));

                if (d <= 0)
                {
                    d += incE;
                }
                else
                {
                    d += incNE;
                    y += declive;
                }
            }
            return pontos;
        }
        private static List<Vertice> pontoMedioAlto(Vertice p1, Vertice p2)
        {
            List<Vertice> pontos = new List<Vertice>();
            int declive = 1;
            double dx = p2.X - (int) p1.X;
            double dy = p2.Y - (int) p1.Y;

            if (dx < 0)
            {
                dx = -dx;
                declive = -1;
            }
            double incE = dx * 2;
            double incNE = (dx * 2) - (dy * 2);
            double d = (dx - dy) * 2;
            int x = (int) p1.X;

            for (int y = (int) p1.Y; y <= p2.Y; y++)
            {
                pontos.Add(new Vertice(x, y));

                if (d <= 0)
                {
                    d += incE;
                }
                else
                {
                    d += incNE;
                    x += declive;
                }
            }
            return pontos;
        }
    }
}
