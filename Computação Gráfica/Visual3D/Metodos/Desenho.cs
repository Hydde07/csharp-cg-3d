using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual3D.Entidade;
using Visual3D.ScanLine;

namespace Visual3D.Metodos
{
	class Desenho
	{

		public static void pintaScanLine(Bitmap imagem, Objeto3D obj, int tipo, int[] cor, Button btnLuz, bool[] fontes)
		{
			int width = imagem.Width;
			int height = imagem.Height;
			BitmapData bitmapDataSrc = imagem.LockBits(new Rectangle(0, 0, width, height),
			ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
			obj.AtualizarNormalFace();
			foreach (Vertice vert in obj.VtAtual)
				vert.NormalizaTela(width, height);

			for (int j = 0; j < obj.Faces.Count; j++)
				if (obj.NFace[j].Z >= 0)
					scanLine(bitmapDataSrc, obj.Faces[j], obj.VtAtual, obj.Vtn, width, height, tipo, cor, btnLuz, fontes);

			imagem.UnlockBits(bitmapDataSrc);
		}

		private static void scanLine(BitmapData bitmapDataSrc, List<int> face, List<Vertice> vts, List<Vertice> vtNormal, int width, int height, int tipo, int[] cor, Button btnLuz, bool[] fontes)
		{
			int y = height-5;
			AET aet = new AET();
			Caixinha[] ET = new Caixinha[1080];
			double[,] zBuffer = new double[width, height];
			for (int i = 0; i < width; i++)
				for (int j = 0; j < height; j++)
					zBuffer[i, j] = -9999;

			for (int i = 0; i <= face.Count - 3; i += 3)
			{
				Vertice min, max;
				double[] corMin = new double[3];
				double[] corMax = new double[3];
				int posMin, posMax;
				if (vts[face[i] - 1].Y < vts[face[(i+3)%face.Count] - 1].Y)
				{
					min = vts[face[i] - 1];
					posMin = face[i] - 1;
					max = vts[face[(i + 3) % face.Count] - 1];
					posMax = face[(i + 3) % face.Count] - 1;

				}
				else
				{
					max = vts[face[i] - 1];
					posMax = face[i] - 1;
					min = vts[face[(i + 3) % face.Count] - 1];
					posMin = face[(i + 3) % face.Count] - 1;
				}
				if (tipo == 0)
					corMin = corMax = Iluminacao.Iluminar(vtNormal[i], btnLuz, cor, width, height, fontes[0], fontes[2], fontes[1]);
				double dy = max.Y - min.Y;
				if (dy != 0)
				{
					if (min.Y < 0)
						min.Y = 0;
					if (min.Y < y)
						y = (int)min.Y;

					double dx = max.X - min.X;
					double dz = max.Z - min.Z;
					double dr = corMax[0] - corMin[0];
					double dg = corMax[1] - corMin[1];
					double db = corMax[2] - corMin[2];
					double dnx = vtNormal[posMax].X - vtNormal[posMin].X;
					double dny = vtNormal[posMax].Y - vtNormal[posMin].Y;
					double dnz = vtNormal[posMax].Z - vtNormal[posMin].Z;
					Caixinha caixa = new Caixinha(max.Y,
													min.X,
													min.Z,
													corMin[0],
													corMin[1],
													corMin[2],
													vtNormal[posMin].X,
													vtNormal[posMin].Y,
													vtNormal[posMin].Z,
													dx / dy,
													dz / dy,
													dr / dy,
													dg / dy,
													db / dy,
													dnx / dy,
													dny / dy,
													dnz / dy);
					if (ET[(int)min.Y] == null)
						ET[(int)min.Y] = caixa;
					else
					{
						caixa.Prox = ET[(int)min.Y];
						ET[(int)min.Y] = caixa;
					}
				}
			}

			Caixinha aux = ET[y];
			while (aux != null)
			{
				aet.Add(aux);
				aux = aux.Prox;
			}
			while (!aet.isEmpty())
			{
				aet.Filtrar(y);
				if (!aet.isEmpty())
				{
					aet.Sort();
					for (Caixinha box = aet.Inicio; box != null && box.Prox != null; box = box.Prox.Prox)
					{
						Caixinha obj1 = new Caixinha(box);
						Caixinha obj2 = new Caixinha(box.Prox);
						double dx = obj2.XMin - obj1.XMin;
						double dz = obj2.ZMin - obj1.ZMin;
						double dr = obj2.RMin - obj1.RMin;
						double dg = obj2.GMin - obj1.GMin;
						double db = obj2.BMin - obj1.BMin;
						double dnx = obj2.NormalxMin - obj1.NormalxMin;
						double dny = obj2.NormalyMin - obj1.NormalyMin;
						double dnz = obj2.NormalzMin - obj1.NormalzMin;

						double zincr = dz / dx;
						double rincr = dr / dx;
						double gincr = dg / dx;
						double bincr = db / dx;
						double nxincr = dnx / dx;
						double nyincr = dny / dx;
						double nzincr = dnz / dx;
						for (int x = (int)obj1.XMin; x <= (int)obj2.XMin; x++)
						{
							if (zBuffer[x, y] < obj1.ZMin)
							{
								DrawPixel(bitmapDataSrc, x, y, width, height, (int)obj1.RMin, (int)obj1.GMin, (int)obj1.BMin);
								zBuffer[x, y] = obj1.ZMin;
							}
							obj1.ZMin += zincr;
							obj1.RMin += rincr;
							obj1.GMin += gincr;
							obj1.BMin += bincr;
							obj1.NormalxMin += nxincr;
							obj1.NormalyMin += nyincr;
							obj1.NormalzMin += nzincr;
						}
						aux = aet.Inicio;
						while (aux != null)
						{
							aux.XMin += aux.PlusX;
							aux.ZMin += aux.PlusZ;
							aux.RMin += aux.PlusR;
							aux.GMin += aux.PlusG;
							aux.BMin += aux.PlusB;
							aux.NormalxMin += aux.PlusNormalX;
							aux.NormalyMin += aux.PlusNormalY;
							aux.NormalzMin += aux.PlusNormalZ;
							aux = aux.Prox;
						}
					}
				}
				y++;
				if (ET[y] != null)
				{
					aux = ET[y];
					while (aux != null)
					{
						aet.Add(aux);
						aux = aux.Prox;
					}
				}
			}
		}

		public static void DrawGrade(Bitmap imagem, Objeto3D obj, int tipo, int dist)
		{
			int width = imagem.Width;
			int height = imagem.Height;
			int wid2 = width / 2, hei2 = height / 2;

			BitmapData bitmapDataSrc = imagem.LockBits(new Rectangle(0, 0, width, height),
			ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
			List<Vertice> lista = Projecoes.EscolhaProjecao(tipo, obj.VtAtual, dist);
			foreach (List<int> face in obj.Faces)
			{
				for (int i = 0; i < face.Count - 3; i += 3)
					DrawPixel(bitmapDataSrc, EquacaoLinha.pontoMedio(lista[face[i] - 1], lista[face[i + 3] - 1]), wid2, hei2, width);
				DrawPixel(bitmapDataSrc, EquacaoLinha.pontoMedio(lista[face[face.Count - 3] - 1], lista[face[0] - 1]), wid2, hei2, width);
			}
			imagem.UnlockBits(bitmapDataSrc);
		}

		public static void DrawSemFace(Bitmap imagem, Objeto3D obj)
		{
			int width = imagem.Width;
			int height = imagem.Height;
			int wid2 = width / 2, hei2 = height / 2;

			BitmapData bitmapDataSrc = imagem.LockBits(new Rectangle(0, 0, width, height),
			ImageLockMode.WriteOnly, PixelFormat.Format24bppRgb);
			obj.AtualizarNormalFace();
			for (int j = 0; j < obj.Faces.Count; j++)
			{
				if (obj.NFace[j].Z >= 0)
				{
					List<int> face = obj.Faces[j];
					for (int i = 0; i < face.Count - 3; i += 3)
						DrawPixel(bitmapDataSrc, EquacaoLinha.pontoMedio(obj.VtAtual[face[i] - 1], obj.VtAtual[face[i + 3] - 1]), wid2, hei2, width);
					DrawPixel(bitmapDataSrc, EquacaoLinha.pontoMedio(obj.VtAtual[face[face.Count - 3] - 1], obj.VtAtual[face[0] - 1]), wid2, hei2, width);
				}
			}

			imagem.UnlockBits(bitmapDataSrc);
		}

		private static void DrawPixel(BitmapData bitmapDataSrc, List<Vertice> vt, int wid2, int hei2, int width)
		{
			unsafe
			{
				byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
				byte* dst;
				foreach (Vertice vtzin in vt)
				{
					int calc = 3 * ((int)(vtzin.X + wid2) + (int)(vtzin.Y + hei2) * width);
					if (calc > 0 && calc < hei2*2 * bitmapDataSrc.Stride)
					{
						dst = src + calc;
						*(dst++) = (byte)Convert.ToInt32(vtzin.B);
						*(dst++) = (byte)Convert.ToInt32(vtzin.G);
						*(dst++) = (byte)Convert.ToInt32(vtzin.R);
					}
				}
			}
		}

		private static void DrawPixel(BitmapData bitmapDataSrc, int x, int y, int width, int height, int r, int g, int b)
		{
			unsafe
			{
				byte* src = (byte*)bitmapDataSrc.Scan0.ToPointer();
				byte* dst;
				int calc = 3 * (x + y * width);
				if (calc > 0 && calc < height * bitmapDataSrc.Stride)
				{
					dst = src + calc;
					*(dst++) = (byte)Convert.ToInt32(b);
					*(dst++) = (byte)Convert.ToInt32(g);
					*(dst++) = (byte)Convert.ToInt32(r);
				}
			}
		}
	}
}
