using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual3D.Metodos;

namespace Visual3D.Entidade
{
	class Objeto3D
	{
		private List<Vertice> vtOrigem, vtAtual, vtn;
		private List<Vertice> nFace;
		private List<List<int>> faces, vizinhos;
		private double[,] matrizAcumulada = { { 1, 0, 0, 0 }, { 0, 1, 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };

		public Objeto3D()
		{
			vtOrigem = new List<Vertice>();
			vtAtual = new List<Vertice>();
			vtn = new List<Vertice>();
			nFace = new List<Vertice>();
			faces = new List<List<int>>();
			Vizinhos = new List<List<int>>();
		}

		public Objeto3D(List<Vertice> vtOrigem, List<Vertice> vtAtual, List<Vertice> vtn, List<List<int>> faces, List<Vertice> nFace, List<List<int>> vizinhos)
		{
			this.vtOrigem = vtOrigem;
			this.vtAtual = vtAtual;
			this.vtn = vtn;
			this.faces = faces;
			this.nFace = nFace;
			this.Vizinhos = vizinhos;
		}

		public void AlteraPos()
		{
			for(int i = 0; i < vtOrigem.Count; i++){
				double[,] vetPos = { { vtOrigem[i].X }, { vtOrigem[i].Y }, { vtOrigem[i].Z }, { 1 } };
				vetPos = Transformacoes3D.MatrizMult(MatrizAcumulada, vetPos);
				vtAtual[i].X = vetPos[0, 0];
				vtAtual[i].Y = vetPos[1, 0];
				vtAtual[i].Z = vetPos[2, 0];
			}
		}

		public void AtualizarNormalFace()
		{
			for (int i = 0; i < faces.Count; i++)
			{
				nFace[i] = Vertice.Normalizar(Vertice.Produto(Vertice.Subtracao(vtAtual[faces[i][0] - 1], vtAtual[faces[i][3] - 1]), Vertice.Subtracao(vtAtual[faces[i][0] - 1], vtAtual[faces[i][faces[i].Count - 3] - 1])));
			}
		}

		public List<List<int>> Faces { get => faces; set => faces = value; }
		public List<Vertice> NFace { get => nFace; set => nFace = value; }
		public List<List<int>> Vizinhos { get => vizinhos; set => vizinhos = value; }
		public double[,] MatrizAcumulada { get => matrizAcumulada; set => matrizAcumulada = value; }
		internal List<Vertice> VtOrigem { get => vtOrigem; set => vtOrigem = value; }
		internal List<Vertice> VtAtual { get => vtAtual; set => vtAtual = value; }
		internal List<Vertice> Vtn { get => vtn; set => vtn = value; }
	}
}
