using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual3D.ScanLine
{
	class Caixinha
	{
		private Caixinha prox;
		private double yMax, xMin, zMin, rMin, gMin, bMin, normalxMin, normalyMin, normalzMin, plusX, plusZ, plusG, plusB, plusR, plusNormalX, plusNormalY, plusNormalZ;

		public Caixinha()
		{
		}

		public Caixinha(double yMax,
							double xMin,
							double zMin,
							double rMin,
							double gMin,
							double bMin,
							double normalxMin,
							double normalyMin,
							double normalzMin,
							double plusX,
							double plusZ,
							double plusR,
							double plusG,
							double plusB,
							double plusNormalX,
							double plusNormalY,
							double plusNormalZ)
		{
			this.yMax = yMax;
			this.xMin = xMin;
			this.zMin = zMin;
			this.rMin = rMin;
			this.gMin = gMin;
			this.bMin = bMin;
			this.normalxMin = normalxMin;
			this.normalyMin = normalyMin;
			this.normalzMin = normalzMin;
			this.plusX = plusX;
			this.plusZ = plusZ;
			this.plusG = plusG;
			this.plusB = plusB;
			this.plusR = plusR;
			this.plusNormalX = plusNormalX;
			this.plusNormalY = plusNormalY;
			this.plusNormalZ = plusNormalZ;
			this.prox = null;
		}

		public Caixinha(Caixinha copia)
		{
			this.yMax = copia.yMax;
			this.xMin = copia.xMin;
			this.zMin = copia.zMin;
			this.rMin = copia.rMin;
			this.gMin = copia.gMin;
			this.bMin = copia.bMin;
			this.normalxMin = copia.normalxMin;
			this.normalyMin = copia.normalyMin;
			this.normalzMin = copia.normalzMin;
			this.plusX = copia.plusX;
			this.plusZ = copia.plusZ;
			this.plusG = copia.plusG;
			this.plusB = copia.plusB;
			this.plusR = copia.plusR;
			this.plusNormalX = copia.plusNormalX;
			this.plusNormalY = copia.plusNormalY;
			this.plusNormalZ = copia.plusNormalZ;
			this.prox = copia.Prox;
		}

		public void Absorve(Caixinha copia)
		{
			this.yMax = copia.yMax;
			this.xMin = copia.xMin;
			this.zMin = copia.zMin;
			this.rMin = copia.rMin;
			this.gMin = copia.gMin;
			this.bMin = copia.bMin;
			this.normalxMin = copia.normalxMin;
			this.normalyMin = copia.normalyMin;
			this.normalzMin = copia.normalzMin;
			this.plusX = copia.plusX;
			this.plusZ = copia.plusZ;
			this.plusG = copia.plusG;
			this.plusB = copia.plusB;
			this.plusR = copia.plusR;
			this.plusNormalX = copia.plusNormalX;
			this.plusNormalY = copia.plusNormalY;
			this.plusNormalZ = copia.plusNormalZ;
		}

		public double YMax { get => yMax; set => yMax = value; }
		public double XMin { get => xMin; set => xMin = value; }
		public double ZMin { get => zMin; set => zMin = value; }
		public double RMin { get => rMin; set => rMin = value; }
		public double GMin { get => gMin; set => gMin = value; }
		public double BMin { get => bMin; set => bMin = value; }
		public double NormalxMin { get => normalxMin; set => normalxMin = value; }
		public double NormalyMin { get => normalyMin; set => normalyMin = value; }
		public double NormalzMin { get => normalzMin; set => normalzMin = value; }
		public double PlusX { get => plusX; set => plusX = value; }
		public double PlusZ { get => plusZ; set => plusZ = value; }
		public double PlusG { get => plusG; set => plusG = value; }
		public double PlusB { get => plusB; set => plusB = value; }
		public double PlusR { get => plusR; set => plusR = value; }
		public double PlusNormalX { get => plusNormalX; set => plusNormalX = value; }
		public double PlusNormalY { get => plusNormalY; set => plusNormalY = value; }
		public double PlusNormalZ { get => plusNormalZ; set => plusNormalZ = value; }
		internal Caixinha Prox { get => prox; set => prox = value; }
	}
}
