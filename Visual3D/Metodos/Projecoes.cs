using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual3D.Entidade;

namespace Visual3D.Metodos
{
	class Projecoes
	{
		public static List<Vertice> EscolhaProjecao(int tipo, List<Vertice> vt, int dist)
		{
			switch (tipo)
			{
				case 1: return Lateral(vt);
				case 2: return Superior(vt);
				case 3: return Cavalier(vt);
				case 4: return Cabiner(vt);
				case 5: return Perspectiva(vt,dist);
				default: return vt;
			}
		}

		public static List<Vertice> Lateral(List<Vertice> vt)
		{
			List<Vertice> lista = new List<Vertice>();
			foreach (Vertice vert in vt)
			{
				lista.Add(new Vertice(vert.Z, vert.Y, vert.X));
			}
			return lista;
		}

		public static List<Vertice> Superior(List<Vertice> vt)
		{
			List<Vertice> lista = new List<Vertice>();
			foreach (Vertice vert in vt)
			{
				lista.Add(new Vertice(vert.X, vert.Z, vert.Y));
			}
			return lista;
		}

		public static List<Vertice> Cavalier(List<Vertice> vt)
		{
			List<Vertice> lista = new List<Vertice>();
			double[,] matriz = { { 1, 0, Math.Cos(45), 0 }, { 0, 1, Math.Sin(45), 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
			foreach (Vertice vert in vt)
			{
				double[,] vetPos = { { vert.X }, { vert.Y }, { vert.Z }, { 1 } };
				vetPos = Transformacoes3D.MatrizMult(matriz, vetPos);
				lista.Add(new Vertice(vetPos[0,0],vetPos[1,0],vetPos[2,0]));
			}
			return lista;
		}

		public static List<Vertice> Cabiner(List<Vertice> vt)
		{
			List<Vertice> lista = new List<Vertice>();
			double[,] matriz = { { 1, 0, Math.Cos(45)*0.5, 0 }, { 0, 1, Math.Sin(45)*0.5, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
			foreach (Vertice vert in vt)
			{
				double[,] vetPos = { { vert.X }, { vert.Y }, { vert.Z }, { 1 } };
				vetPos = Transformacoes3D.MatrizMult(matriz, vetPos);
				lista.Add(new Vertice(vetPos[0, 0], vetPos[1, 0], vetPos[2, 0]));
			}
			return lista;
		}

		public static List<Vertice> Perspectiva(List<Vertice> vt, int dist)
		{
			List<Vertice> lista = new List<Vertice>();
			foreach (Vertice vert in vt)
			{
				lista.Add(new Vertice((vert.X*dist)/(vert.Z+dist), (vert.Y * dist) / (vert.Z + dist), vert.Z));
			}
			return lista;
		}
	}
}
