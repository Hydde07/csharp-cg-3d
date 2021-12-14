using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual3D.Entidade;

namespace Visual3D.Metodos
{
	class Iluminacao
	{
		public static double[] Ambiente(double[,] l, double[,] s)
		{
			double[] cor = new double[3];
			cor[0] = l[0, 0] * s[0, 0];
			cor[1] = l[0, 1] * s[0, 1];
			cor[2] = l[0, 2] * s[0, 2];
			return cor;
		}

		public static double[] Difusa(double[,] l, double[,] s, double d)
		{
			double[] cor = new double[3];
			cor[0] = l[1, 0] * s[1, 0] * d;
			cor[1] = l[1, 1] * s[1, 1] * d;
			cor[2] = l[1, 2] * s[1, 2] * d;
			return cor;
		}

		public static double[] Especular(double[,] l, double[,] s, double sp)
		{
			double[] cor = new double[3];
			cor[0] = l[2, 0] * s[2, 0] * sp;
			cor[1] = l[2, 1] * s[2, 1] * sp;
			cor[2] = l[2, 2] * s[2, 2] * sp;
			return cor;
		}

		public static double[] Iluminar(Vertice normal, Button btnLuz, int[] cor, int width, int height, bool amb, bool dif, bool esp)
		{
			double nR = cor[0] / 255.0;
			double nG = cor[1] / 255.0;
			double nB = cor[2] / 255.0;

			Vertice luz = new Vertice((btnLuz.Location.X + btnLuz.Width / 2) - width / 2, (btnLuz.Location.Y + btnLuz.Height / 2) - height / 2, 0);
			luz = Vertice.Normalizar(luz);

			Vertice olho = new Vertice(0, 0, 1);

			double[,] fonteLuz = { { nR, nG, nB }, { 150.0 / 255.0, 150.0 / 255.0, 150.0 / 255.0 }, { 150.0 / 255.0, 150.0 / 255.0, 150.0 / 255.0 } };
			double[,] superficie = { { 0.5, 0.5, 0.5 }, { nR, nG, nB }, { 0.9, 0.9, 0.9 } };

			Vertice hw = Vertice.Normalizar(Vertice.Soma(luz, olho));
			double d = Vertice.Escalar(luz, normal);
			double s = Math.Pow(Vertice.Escalar(hw, normal), 10);
			double[] corMain = { 0, 0, 0 };


			if (amb)
			{
				double[] col = Ambiente(fonteLuz, superficie);

				corMain[0] += col[0];
				corMain[1] += col[1];
				corMain[2] += col[2];
			}

			if (dif)
			{
				double[] col = Difusa(fonteLuz, superficie, d);

				corMain[0] += col[0];
				corMain[1] += col[1];
				corMain[2] += col[2];
			}

			if (esp)
			{
				double[] col = Especular(fonteLuz, superficie, s);

				corMain[0] += col[0];
				corMain[1] += col[1];
				corMain[2] += col[2];
			}

			corMain[0] *= 255;
			corMain[1] *= 255;
			corMain[2] *= 255;

			if (corMain[0] > 255)
			{
				corMain[0] = 255;
			}
			if (corMain[1] > 255)
			{
				corMain[1] = 255;
			}
			if (corMain[2] > 255)
			{
				corMain[2] = 255;
			}
			if (corMain[0] < 0)
			{
				corMain[0] = 0;
			}
			if (corMain[1] < 0)
			{
				corMain[1] = 0;
			}
			if (corMain[2] < 0)
			{
				corMain[2] = 0;
			}
			return corMain;
		}

	}
}
