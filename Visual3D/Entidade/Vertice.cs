using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual3D.Entidade
{
	class Vertice
	{
		private double x, y, z;
		private double r, g, b;

		public Vertice(){ }

		public Vertice(double x, double y) : this(x, y, 0, 214, 214, 214) { }

		public Vertice(double x, double y, double z) : this(x, y, z, 214, 214, 214) { }

		public Vertice(double x, double y, double z, double r, double g, double b)
		{
			this.r = r;
			this.g = g;
			this.b = b;
			this.x = x;
			this.y = y;
			this.z = z;
		}

		public static Vertice Subtracao(Vertice v1, Vertice v2)
		{
			Vertice vt = new Vertice();
			vt.x = v2.x - v1.x;
			vt.y = v2.y - v1.y;
			vt.z = v2.z - v1.z;
			return vt;
		}

		public static Vertice Soma(Vertice v1, Vertice v2)
		{
			Vertice vt = new Vertice();
			vt.x = v2.x + v1.x;
			vt.y = v2.y + v1.y;
			vt.z = v2.z + v1.z;
			return vt;
		}

		public static Vertice Produto(Vertice v1, Vertice v2)
		{
			Vertice vt = new Vertice();
			vt.x = v1.y * v2.z - v2.y * v1.z;
			vt.y = v1.z * v2.x - v2.z * v1.x;
			vt.z = v1.x * v2.y - v2.x * v1.y;
			return vt;
		}

		public static double Escalar(Vertice v1, Vertice v2)
		{
			return v1.x * v2.x + v1.y * v2.y + v1.z * v2.z;
		}

		public static Vertice Normalizar(Vertice v1)
		{
			Vertice vt = new Vertice();
			double fator = Math.Sqrt(Math.Pow(v1.x, 2) + Math.Pow(v1.y, 2) + Math.Pow(v1.z, 2));
			vt.x = v1.x/fator;
			vt.y = v1.y/fator;
			vt.z = v1.z/fator;
			return vt;
		}

		public void NormalizaTela(int width, int height)
		{
			this.x += width / 2;
			this.y += height / 2;
		}

		public double X { get => x; set => x = value; }
		public double Y { get => y; set => y = value; }
		public double Z { get => z; set => z = value; }
		public double R { get => r; set => r = value; }
		public double G { get => g; set => g = value; }
		public double B { get => b; set => b = value; }
	}
}
