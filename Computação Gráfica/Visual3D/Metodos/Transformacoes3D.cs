using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Visual3D.Entidade;

namespace Visual3D.Metodos
{
	class Transformacoes3D
	{
		public static double[,] MatrizMult(double[,] m1, double[,] m2)
        {
            double[,] m3 = new double[m1.GetLength(0), m2.GetLength(0)];

            for (int i = 0; i < m1.GetLength(0); i++)
            {
                for (int j = 0; j < m2.GetLength(1); j++)
                {
                    double sum = 0;
                    for (int k = 0; k < m2.GetLength(0); k++)
                    {
                        sum += m1[i,k] * m2[k,j];
                    }
                    m3[i, j] = sum;
                }
            }
            return m3;
        }

        public static void Translacao(Objeto3D obj, double x, double y, double z)
        {
            double[,] matrizTranslacao = { { 1, 0, 0, x }, { 0, 1, 0, y }, { 0, 0, 1, z }, { 0, 0, 0, 1 } };
            obj.MatrizAcumulada = MatrizMult(matrizTranslacao, obj.MatrizAcumulada);
        }
        public static void Rotacao(Objeto3D obj, double x, double y, double z)
        {
            x *= 0.008;
            y *= 0.008;
            z *= 0.008;
            double[,] matrizRotacaoX = { { 1, 0, 0, 0 }, { 0, Math.Cos(x), -Math.Sin(x), 0 }, { 0, Math.Sin(x), Math.Cos(x), 0 }, { 0, 0, 0, 1 } };
            double[,] matrizRotacaoY = { { Math.Cos(y), 0, Math.Sin(y), 0 }, { 0, 1, 0, 0 }, { -Math.Sin(y), 0, Math.Cos(y), 0 }, { 0, 0, 0, 1 } };
            double[,] matrizRotacaoZ = { { Math.Cos(z), -Math.Sin(z), 0, 0 }, { Math.Sin(z), Math.Cos(z), 0, 0 }, { 0, 0, 1, 0 }, { 0, 0, 0, 1 } };
            obj.MatrizAcumulada = MatrizMult(matrizRotacaoX, obj.MatrizAcumulada);
            obj.MatrizAcumulada = MatrizMult(matrizRotacaoY, obj.MatrizAcumulada);
            obj.MatrizAcumulada = MatrizMult(matrizRotacaoZ, obj.MatrizAcumulada);
        }

        public static void Escala(Objeto3D obj, int aumento)
        {
            double fator = aumento > 0 ? 1.1 : 0.9;
            double[,] matrizEscala = { { fator, 0, 0, 0 }, { 0, fator, 0, 0 }, { 0, 0, fator, 0 }, { 0, 0, 0, 1 } };
            obj.MatrizAcumulada = MatrizMult(matrizEscala, obj.MatrizAcumulada);
        }   

    }
}
