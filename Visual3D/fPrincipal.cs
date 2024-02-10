using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using Visual3D.Entidade;
using Visual3D.Metodos;

namespace Visual3D
{
	public partial class fPrincipal : Form
	{
		private Image imagemOrigem, image;
		private Bitmap imageBitmap;
		private Objeto3D obj;
		private bool isRightPressed, isShiftPressed, isLeftPressed, isCtrlPressed;
		private int xAtual, yAtual, type, tipoScan;
		private int[] cor = { 255, 245, 112 };
		bool isDragged;
		Point ptOffset;

		public fPrincipal()
		{
			InitializeComponent();
		}

		private void btnArquivo_Click(object sender, EventArgs e)
		{
			obj = new Objeto3D();
			openFileDialog.FileName = "";
			openFileDialog.Filter = "Arquivos de Objeto 3D (*.obj)|*.obj";
			if (openFileDialog.ShowDialog() == DialogResult.OK)
			{
				FileStream buffer = File.Open(openFileDialog.FileName, FileMode.Open);
				StreamReader leitor = new StreamReader(buffer);
				string linha;
				while (!leitor.EndOfStream)
				{
					linha = leitor.ReadLine().Replace(".", ",");
					string[] lnSplit = linha.Split(' ');
					if (lnSplit[0] == "v")
					{
						obj.VtAtual.Add(new Vertice(Convert.ToDouble(lnSplit[1]), Convert.ToDouble(lnSplit[2]), Convert.ToDouble(lnSplit[3])));
						obj.VtOrigem.Add(new Vertice(Convert.ToDouble(lnSplit[1]), Convert.ToDouble(lnSplit[2]), Convert.ToDouble(lnSplit[3])));
					}
					else if (lnSplit[0] == "vn")
						obj.Vtn.Add(new Vertice(Convert.ToDouble(lnSplit[1]), Convert.ToDouble(lnSplit[2]), Convert.ToDouble(lnSplit[3])));
					else if (lnSplit[0] == "f")
					{
						string[] splitFace;
						obj.NFace.Add(null);
						obj.Faces.Add(new List<int>());
						for (int i = 1; i < lnSplit.Length; i++)
						{
							splitFace = lnSplit[i].Split('/');
							obj.Faces[obj.Faces.Count - 1].Add(Convert.ToInt32(splitFace[0]));
							if (splitFace[1] != "")
								obj.Faces[obj.Faces.Count - 1].Add(Convert.ToInt32(splitFace[1]));
							else
								obj.Faces[obj.Faces.Count - 1].Add(-1);
							obj.Faces[obj.Faces.Count - 1].Add(Convert.ToInt32(splitFace[2]));
						}
					}
				}
				pControl.Enabled = true;
				Desenha();
			}
		}

		private void pbImg_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				isRightPressed = true;
				xAtual = this.PointToClient(Cursor.Position).X;
				yAtual = this.PointToClient(Cursor.Position).Y;
			}
			else if (e.Button == MouseButtons.Left)
			{
				isLeftPressed = true;
				xAtual = this.PointToClient(Cursor.Position).X;
				yAtual = this.PointToClient(Cursor.Position).Y;
			}
		}

		private void pbImg_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
				isRightPressed = false;
			else if (e.Button == MouseButtons.Left)
				isLeftPressed = false;
		}

		private void pbImg_MouseWheel(object sender, MouseEventArgs e)
		{
			if (isShiftPressed)
			{
				Thread t = new Thread(() => threadMouseMoveRotacao(0, 0, 0.05 * e.Delta));
				t.Start();
				Desenha();
			}
			else if (isCtrlPressed)
			{
				Thread t = new Thread(() => threadMouseMoveTranslacao(0, 0, 0.5 * e.Delta));
				t.Start();
				Desenha();
			}
			else
			{
				Transformacoes3D.Escala(obj, e.Delta);
				obj.AlteraPos();
				Desenha();
			}
		}

		private void pbImg_MouseMove(object sender, MouseEventArgs e)
		{
			if (isRightPressed)
			{
				int x = this.PointToClient(Cursor.Position).X - xAtual;
				int y = this.PointToClient(Cursor.Position).Y - yAtual;
				if (Math.Abs(x) > 5 || Math.Abs(y) > 5)
				{
					Thread t = new Thread(() => threadMouseMoveTranslacao(x, y, 0));
					t.Start();
					xAtual = this.PointToClient(Cursor.Position).X;
					yAtual = this.PointToClient(Cursor.Position).Y;
					Desenha();
				}
			}
			else if (isLeftPressed)
			{
				int x = this.PointToClient(Cursor.Position).X - xAtual;
				int y = this.PointToClient(Cursor.Position).Y - yAtual;
				if (Math.Abs(x) > 5 || Math.Abs(y) > 5)
				{
					Thread t = new Thread(() => threadMouseMoveRotacao(-y, x, 0));
					t.Start();
					xAtual = this.PointToClient(Cursor.Position).X;
					yAtual = this.PointToClient(Cursor.Position).Y;
					Desenha();
				}
			}
		}

		private void fPrincipal_KeyUp(object sender, KeyEventArgs e)
		{
			e.Handled = true;
			isShiftPressed = false;
			isCtrlPressed = false;
		}

		private void checkFace_CheckedChanged(object sender, EventArgs e)
		{
			Desenha();
		}

		private void radioFrontal_CheckedChanged(object sender, EventArgs e)
		{
			if (radioFrontal.Checked)
				checkFace.Enabled = true;
			Desenha();
		}

		private void radioLateral_CheckedChanged(object sender, EventArgs e)
		{
			if (radioLateral.Checked)
			{
				checkFace.Checked = false;
				checkFace.Enabled = false;
			}
			Desenha();
		}

		private void radioSuperior_CheckedChanged(object sender, EventArgs e)
		{
			if (radioSuperior.Checked)
			{
				checkFace.Checked = false;
				checkFace.Enabled = false;
			}
			Desenha();
		}

		private void radioCavalier_CheckedChanged(object sender, EventArgs e)
		{
			if (radioCavalier.Checked)
			{
				checkFace.Checked = false;
				checkFace.Enabled = false;
			}
			Desenha();
		}

		private void radioCabiner_CheckedChanged(object sender, EventArgs e)
		{
			if (radioCabiner.Checked)
			{
				checkFace.Checked = false;
				checkFace.Enabled = false;
			}
			Desenha();
		}

		private void radioPersp_CheckedChanged(object sender, EventArgs e)
		{
			if (radioPersp.Checked)
			{
				checkFace.Checked = false;
				checkFace.Enabled = false;
			}
			Desenha();
		}

		private void tbDist_ValueChanged(object sender, EventArgs e)
		{
			Desenha();
		}

		private void checkSolido_CheckedChanged(object sender, EventArgs e)
		{
			gbIlumina.Enabled = checkSolido.Checked;
			pAramado.Enabled = !checkSolido.Checked;
			obj.AlteraPos();
			Desenha();
		}

		private void btnLuz_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Left)
			{
				isDragged = true;
				Point ptStartPosition = btnLuz.PointToScreen(new Point(e.X, e.Y));

				ptOffset = new Point();
				ptOffset.X = btnLuz.Location.X - ptStartPosition.X;
				ptOffset.Y = btnLuz.Location.Y - ptStartPosition.Y;
			}
			else
			{
				isDragged = false;
			}
		}

		private void btnLuz_MouseMove(object sender, MouseEventArgs e)
		{
			if (isDragged)
			{
				Point newPoint = btnLuz.PointToScreen(new Point(e.X, e.Y));
				newPoint.Offset(ptOffset);
				if (newPoint.X > pbImg.Location.X && newPoint.X+btnLuz.Width < pbImg.Location.X + pbImg.Width && newPoint.Y > pbImg.Location.Y && newPoint.Y + btnLuz.Height < pbImg.Location.Y + pbImg.Height) 
					btnLuz.Location = newPoint;
			}
		}

		private void btnLuz_MouseUp(object sender, MouseEventArgs e)
		{
			isDragged = false;
			Desenha();
		}

		private void radioButton1_CheckedChanged(object sender, EventArgs e)
		{
			if (radioFlat.Checked)
				tipoScan = 0;
			Desenha();
		}

		private void radioGourard_CheckedChanged(object sender, EventArgs e)
		{
			if (radioGourard.Checked)
				tipoScan = 1;
			Desenha();
		}

		private void radioPhong_CheckedChanged(object sender, EventArgs e)
		{
			if (radioPhong.Checked)
				tipoScan = 2;
			Desenha();
		}

		private void checkAmb_CheckedChanged(object sender, EventArgs e)
		{
			Desenha();
		}

		private void checkEsp_CheckedChanged(object sender, EventArgs e)
		{
			Desenha();
		}

		private void checkDif_CheckedChanged(object sender, EventArgs e)
		{
			Desenha();
		}

		private void btnCor_Click(object sender, EventArgs e)
		{
			if (colorDialog.ShowDialog() == DialogResult.OK)
			{
				cor[0] = colorDialog.Color.R;
				cor[1] = colorDialog.Color.G;
				cor[2] = colorDialog.Color.B;
				Desenha();
			}
		}

		private void threadMouseMoveTranslacao(int x, int y, double z)
		{
			Transformacoes3D.Translacao(obj, x, y, z);
			obj.AlteraPos();
		}

		private void threadMouseMoveRotacao(int x, int y, double z)
		{
			Transformacoes3D.Rotacao(obj, x, y, z);
			obj.AlteraPos();
		}

		private void fPrincipal_KeyDown(object sender, KeyEventArgs e)
		{
			e.Handled = true;
			isShiftPressed = e.KeyCode == Keys.ShiftKey;
			isCtrlPressed = e.KeyCode == Keys.ControlKey;
		}

		private void Desenha()
		{
			EscolheTipo();
			image = imagemOrigem;
			imageBitmap = new Bitmap(image);
			if (checkSolido.Checked)
			{
				bool[] fontes = { checkAmb.Checked, checkEsp.Checked, checkDif.Checked };
				obj.AlteraPos();
				Desenho.pintaScanLine(imageBitmap, obj, tipoScan, cor, btnLuz,fontes);
			}
			else if (checkFace.Checked)
				Desenho.DrawSemFace(imageBitmap, obj);
			else
				Desenho.DrawGrade(imageBitmap, obj, type, Convert.ToInt32(tbDistancia.Text));
			pbImg.Image = imageBitmap;
		}

		private void EscolheTipo()
		{
			if (radioFrontal.Checked)
				type = 0;
			else if (radioLateral.Checked)
				type = 1;
			else if (radioSuperior.Checked)
				type = 2;
			else if (radioCavalier.Checked)
				type = 3;
			else if (radioCabiner.Checked)
				type = 4;
			else if (radioPersp.Checked)
				type = 5;
		}

		private void fPrincipal_Load(object sender, EventArgs e)
		{
			this.KeyPreview = true;
			imagemOrigem = pbImg.Image;
			image = pbImg.Image;
			isRightPressed = false;
			isLeftPressed = false;
			isCtrlPressed = false;
			isShiftPressed = false;
			isDragged = false;
			xAtual = 0;
			yAtual = 0;
			type = 0;
			tipoScan = 0;
			pbImg.MouseWheel += pbImg_MouseWheel;
		}
	}
}
