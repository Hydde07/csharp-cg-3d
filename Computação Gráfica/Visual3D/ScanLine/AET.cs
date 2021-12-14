using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Visual3D.ScanLine
{
	class AET
	{
		private Caixinha inicio;
		private int quant;

		internal Caixinha Inicio { get => inicio; set => inicio = value; }
		public int Quant { get => quant; set => quant = value; }

		public AET()
		{
			this.Inicio = null;
			Quant = 0;
		}

		public void Add(Caixinha info)
		{
			Caixinha caixa = new Caixinha(info);
			caixa.Prox = null;
			if (Inicio == null)
				Inicio = caixa;
			else
			{
				Caixinha aux = Inicio;
				while (aux.Prox != null)
					aux = aux.Prox;
				aux.Prox = caixa;
			}
			Quant++;
		}

		public void Filtrar(int yMax)
		{
			Caixinha aux = Inicio;
			Caixinha ant = null;
			while (aux != null)
			{
				if ((int)aux.YMax == yMax)
					Remove(aux, ant);
				else
					ant = aux;
				aux = aux.Prox;
			}
		}

		public void Remove(Caixinha caixa, Caixinha ant)
		{
			if (caixa == Inicio)
				Inicio = caixa.Prox;
			else
				ant.Prox = caixa.Prox;
			Quant--;
		}

		public void Sort()
		{
			Caixinha aux, prox, troca;
			troca = new Caixinha();
			int fim = Quant;
			while (fim > 1)
			{
				aux = Inicio;
				prox = aux.Prox;
				for (int i = 0; i < fim-1; i++)
				{
					if (aux.XMin > prox.XMin)
					{
						troca.Absorve(aux);
						aux.Absorve(prox);
						prox.Absorve(troca);
					}
					aux = prox;
					prox = prox.Prox;
				}
				fim--;
			}
		}

		public bool isEmpty()
		{
			return Inicio == null;
		}

	}
}
