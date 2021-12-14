
namespace Visual3D
{
	partial class fPrincipal
	{
		/// <summary>
		/// Variável de designer necessária.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Limpar os recursos que estão sendo usados.
		/// </summary>
		/// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
		protected override void Dispose(bool disposing)
		{
			if (disposing && (components != null))
			{
				components.Dispose();
			}
			base.Dispose(disposing);
		}

		#region Código gerado pelo Windows Form Designer

		/// <summary>
		/// Método necessário para suporte ao Designer - não modifique 
		/// o conteúdo deste método com o editor de código.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(fPrincipal));
			this.label1 = new System.Windows.Forms.Label();
			this.btnArquivo = new System.Windows.Forms.Button();
			this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
			this.pbImg = new System.Windows.Forms.PictureBox();
			this.checkFace = new System.Windows.Forms.CheckBox();
			this.groupBox1 = new System.Windows.Forms.GroupBox();
			this.tbDistancia = new System.Windows.Forms.NumericUpDown();
			this.radioPersp = new System.Windows.Forms.RadioButton();
			this.radioCabiner = new System.Windows.Forms.RadioButton();
			this.radioCavalier = new System.Windows.Forms.RadioButton();
			this.radioSuperior = new System.Windows.Forms.RadioButton();
			this.radioLateral = new System.Windows.Forms.RadioButton();
			this.radioFrontal = new System.Windows.Forms.RadioButton();
			this.label2 = new System.Windows.Forms.Label();
			this.pControl = new System.Windows.Forms.Panel();
			this.pAramado = new System.Windows.Forms.Panel();
			this.checkSolido = new System.Windows.Forms.CheckBox();
			this.gbIlumina = new System.Windows.Forms.GroupBox();
			this.btnCor = new System.Windows.Forms.Button();
			this.gbMetodo = new System.Windows.Forms.GroupBox();
			this.radioPhong = new System.Windows.Forms.RadioButton();
			this.radioGourard = new System.Windows.Forms.RadioButton();
			this.radioFlat = new System.Windows.Forms.RadioButton();
			this.gbLuz = new System.Windows.Forms.GroupBox();
			this.checkAmb = new System.Windows.Forms.CheckBox();
			this.checkDif = new System.Windows.Forms.CheckBox();
			this.checkEsp = new System.Windows.Forms.CheckBox();
			this.btnLuz = new System.Windows.Forms.Button();
			this.colorDialog = new System.Windows.Forms.ColorDialog();
			((System.ComponentModel.ISupportInitialize)(this.pbImg)).BeginInit();
			this.groupBox1.SuspendLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbDistancia)).BeginInit();
			this.pControl.SuspendLayout();
			this.pAramado.SuspendLayout();
			this.gbIlumina.SuspendLayout();
			this.gbMetodo.SuspendLayout();
			this.gbLuz.SuspendLayout();
			this.SuspendLayout();
			// 
			// label1
			// 
			this.label1.AutoSize = true;
			this.label1.Font = new System.Drawing.Font("Gabriola", 26.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
			this.label1.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
			this.label1.Location = new System.Drawing.Point(715, 44);
			this.label1.Name = "label1";
			this.label1.Size = new System.Drawing.Size(133, 65);
			this.label1.TabIndex = 1;
			this.label1.Text = "Visual 3D";
			// 
			// btnArquivo
			// 
			this.btnArquivo.Location = new System.Drawing.Point(861, 65);
			this.btnArquivo.Name = "btnArquivo";
			this.btnArquivo.Size = new System.Drawing.Size(85, 33);
			this.btnArquivo.TabIndex = 2;
			this.btnArquivo.Text = "Abrir Arquivo";
			this.btnArquivo.UseVisualStyleBackColor = true;
			this.btnArquivo.Click += new System.EventHandler(this.btnArquivo_Click);
			// 
			// openFileDialog
			// 
			this.openFileDialog.FileName = "openFileDialog1";
			// 
			// pbImg
			// 
			this.pbImg.Image = ((System.Drawing.Image)(resources.GetObject("pbImg.Image")));
			this.pbImg.InitialImage = ((System.Drawing.Image)(resources.GetObject("pbImg.InitialImage")));
			this.pbImg.Location = new System.Drawing.Point(12, 12);
			this.pbImg.Name = "pbImg";
			this.pbImg.Size = new System.Drawing.Size(672, 672);
			this.pbImg.TabIndex = 3;
			this.pbImg.TabStop = false;
			this.pbImg.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pbImg_MouseDown);
			this.pbImg.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pbImg_MouseMove);
			this.pbImg.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pbImg_MouseUp);
			// 
			// checkFace
			// 
			this.checkFace.AutoSize = true;
			this.checkFace.ForeColor = System.Drawing.SystemColors.Control;
			this.checkFace.Location = new System.Drawing.Point(57, 2);
			this.checkFace.Name = "checkFace";
			this.checkFace.Size = new System.Drawing.Size(105, 17);
			this.checkFace.TabIndex = 4;
			this.checkFace.Text = "Backface culling";
			this.checkFace.UseVisualStyleBackColor = true;
			this.checkFace.CheckedChanged += new System.EventHandler(this.checkFace_CheckedChanged);
			// 
			// groupBox1
			// 
			this.groupBox1.Controls.Add(this.tbDistancia);
			this.groupBox1.Controls.Add(this.radioPersp);
			this.groupBox1.Controls.Add(this.radioCabiner);
			this.groupBox1.Controls.Add(this.radioCavalier);
			this.groupBox1.Controls.Add(this.radioSuperior);
			this.groupBox1.Controls.Add(this.radioLateral);
			this.groupBox1.Controls.Add(this.radioFrontal);
			this.groupBox1.Controls.Add(this.label2);
			this.groupBox1.ForeColor = System.Drawing.SystemColors.Control;
			this.groupBox1.Location = new System.Drawing.Point(11, 25);
			this.groupBox1.Name = "groupBox1";
			this.groupBox1.Size = new System.Drawing.Size(202, 131);
			this.groupBox1.TabIndex = 5;
			this.groupBox1.TabStop = false;
			this.groupBox1.Text = "Projeções";
			// 
			// tbDistancia
			// 
			this.tbDistancia.Increment = new decimal(new int[] {
            50,
            0,
            0,
            0});
			this.tbDistancia.Location = new System.Drawing.Point(104, 105);
			this.tbDistancia.Maximum = new decimal(new int[] {
            1000,
            0,
            0,
            0});
			this.tbDistancia.Minimum = new decimal(new int[] {
            100,
            0,
            0,
            0});
			this.tbDistancia.Name = "tbDistancia";
			this.tbDistancia.Size = new System.Drawing.Size(85, 20);
			this.tbDistancia.TabIndex = 6;
			this.tbDistancia.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
			this.tbDistancia.Value = new decimal(new int[] {
            400,
            0,
            0,
            0});
			this.tbDistancia.ValueChanged += new System.EventHandler(this.tbDist_ValueChanged);
			// 
			// radioPersp
			// 
			this.radioPersp.AutoSize = true;
			this.radioPersp.Location = new System.Drawing.Point(6, 105);
			this.radioPersp.Name = "radioPersp";
			this.radioPersp.Size = new System.Drawing.Size(81, 17);
			this.radioPersp.TabIndex = 11;
			this.radioPersp.Text = "Perspectiva";
			this.radioPersp.UseVisualStyleBackColor = true;
			this.radioPersp.CheckedChanged += new System.EventHandler(this.radioPersp_CheckedChanged);
			// 
			// radioCabiner
			// 
			this.radioCabiner.AutoSize = true;
			this.radioCabiner.Location = new System.Drawing.Point(104, 42);
			this.radioCabiner.Name = "radioCabiner";
			this.radioCabiner.Size = new System.Drawing.Size(61, 17);
			this.radioCabiner.TabIndex = 10;
			this.radioCabiner.Text = "Cabiner";
			this.radioCabiner.UseVisualStyleBackColor = true;
			this.radioCabiner.CheckedChanged += new System.EventHandler(this.radioCabiner_CheckedChanged);
			// 
			// radioCavalier
			// 
			this.radioCavalier.AutoSize = true;
			this.radioCavalier.Location = new System.Drawing.Point(104, 19);
			this.radioCavalier.Name = "radioCavalier";
			this.radioCavalier.Size = new System.Drawing.Size(63, 17);
			this.radioCavalier.TabIndex = 9;
			this.radioCavalier.Text = "Cavalier";
			this.radioCavalier.UseVisualStyleBackColor = true;
			this.radioCavalier.CheckedChanged += new System.EventHandler(this.radioCavalier_CheckedChanged);
			// 
			// radioSuperior
			// 
			this.radioSuperior.AutoSize = true;
			this.radioSuperior.Location = new System.Drawing.Point(13, 65);
			this.radioSuperior.Name = "radioSuperior";
			this.radioSuperior.Size = new System.Drawing.Size(64, 17);
			this.radioSuperior.TabIndex = 8;
			this.radioSuperior.Text = "Superior";
			this.radioSuperior.UseVisualStyleBackColor = true;
			this.radioSuperior.CheckedChanged += new System.EventHandler(this.radioSuperior_CheckedChanged);
			// 
			// radioLateral
			// 
			this.radioLateral.AutoSize = true;
			this.radioLateral.Location = new System.Drawing.Point(13, 42);
			this.radioLateral.Name = "radioLateral";
			this.radioLateral.Size = new System.Drawing.Size(57, 17);
			this.radioLateral.TabIndex = 6;
			this.radioLateral.Text = "Lateral";
			this.radioLateral.UseVisualStyleBackColor = true;
			this.radioLateral.CheckedChanged += new System.EventHandler(this.radioLateral_CheckedChanged);
			// 
			// radioFrontal
			// 
			this.radioFrontal.AutoSize = true;
			this.radioFrontal.Checked = true;
			this.radioFrontal.Location = new System.Drawing.Point(13, 19);
			this.radioFrontal.Name = "radioFrontal";
			this.radioFrontal.Size = new System.Drawing.Size(57, 17);
			this.radioFrontal.TabIndex = 7;
			this.radioFrontal.TabStop = true;
			this.radioFrontal.Text = "Frontal";
			this.radioFrontal.UseVisualStyleBackColor = true;
			this.radioFrontal.CheckedChanged += new System.EventHandler(this.radioFrontal_CheckedChanged);
			// 
			// label2
			// 
			this.label2.AutoSize = true;
			this.label2.Location = new System.Drawing.Point(112, 89);
			this.label2.Name = "label2";
			this.label2.Size = new System.Drawing.Size(51, 13);
			this.label2.TabIndex = 7;
			this.label2.Text = "Distância";
			// 
			// pControl
			// 
			this.pControl.Controls.Add(this.pAramado);
			this.pControl.Controls.Add(this.checkSolido);
			this.pControl.Controls.Add(this.gbIlumina);
			this.pControl.Enabled = false;
			this.pControl.Location = new System.Drawing.Point(712, 112);
			this.pControl.Name = "pControl";
			this.pControl.Size = new System.Drawing.Size(234, 572);
			this.pControl.TabIndex = 6;
			// 
			// pAramado
			// 
			this.pAramado.Controls.Add(this.groupBox1);
			this.pAramado.Controls.Add(this.checkFace);
			this.pAramado.Location = new System.Drawing.Point(3, 3);
			this.pAramado.Name = "pAramado";
			this.pAramado.Size = new System.Drawing.Size(228, 162);
			this.pAramado.TabIndex = 8;
			// 
			// checkSolido
			// 
			this.checkSolido.AutoSize = true;
			this.checkSolido.ForeColor = System.Drawing.SystemColors.Control;
			this.checkSolido.Location = new System.Drawing.Point(87, 171);
			this.checkSolido.Name = "checkSolido";
			this.checkSolido.Size = new System.Drawing.Size(55, 17);
			this.checkSolido.TabIndex = 7;
			this.checkSolido.Text = "Sólido";
			this.checkSolido.UseVisualStyleBackColor = true;
			this.checkSolido.CheckedChanged += new System.EventHandler(this.checkSolido_CheckedChanged);
			// 
			// gbIlumina
			// 
			this.gbIlumina.Controls.Add(this.btnCor);
			this.gbIlumina.Controls.Add(this.gbMetodo);
			this.gbIlumina.Controls.Add(this.gbLuz);
			this.gbIlumina.Enabled = false;
			this.gbIlumina.ForeColor = System.Drawing.SystemColors.Control;
			this.gbIlumina.Location = new System.Drawing.Point(14, 194);
			this.gbIlumina.Name = "gbIlumina";
			this.gbIlumina.Size = new System.Drawing.Size(202, 178);
			this.gbIlumina.TabIndex = 6;
			this.gbIlumina.TabStop = false;
			this.gbIlumina.Text = "Iluminação";
			// 
			// btnCor
			// 
			this.btnCor.ForeColor = System.Drawing.SystemColors.ActiveCaptionText;
			this.btnCor.Location = new System.Drawing.Point(36, 134);
			this.btnCor.Name = "btnCor";
			this.btnCor.Size = new System.Drawing.Size(138, 34);
			this.btnCor.TabIndex = 6;
			this.btnCor.Text = "Selecionar Cor";
			this.btnCor.UseVisualStyleBackColor = true;
			this.btnCor.Click += new System.EventHandler(this.btnCor_Click);
			// 
			// gbMetodo
			// 
			this.gbMetodo.Controls.Add(this.radioPhong);
			this.gbMetodo.Controls.Add(this.radioGourard);
			this.gbMetodo.Controls.Add(this.radioFlat);
			this.gbMetodo.ForeColor = System.Drawing.SystemColors.Control;
			this.gbMetodo.Location = new System.Drawing.Point(13, 19);
			this.gbMetodo.Name = "gbMetodo";
			this.gbMetodo.Size = new System.Drawing.Size(85, 109);
			this.gbMetodo.TabIndex = 5;
			this.gbMetodo.TabStop = false;
			this.gbMetodo.Text = "Método";
			// 
			// radioPhong
			// 
			this.radioPhong.AutoSize = true;
			this.radioPhong.Location = new System.Drawing.Point(6, 65);
			this.radioPhong.Name = "radioPhong";
			this.radioPhong.Size = new System.Drawing.Size(56, 17);
			this.radioPhong.TabIndex = 2;
			this.radioPhong.Text = "Phong";
			this.radioPhong.UseVisualStyleBackColor = true;
			this.radioPhong.CheckedChanged += new System.EventHandler(this.radioPhong_CheckedChanged);
			// 
			// radioGourard
			// 
			this.radioGourard.AutoSize = true;
			this.radioGourard.Location = new System.Drawing.Point(6, 42);
			this.radioGourard.Name = "radioGourard";
			this.radioGourard.Size = new System.Drawing.Size(63, 17);
			this.radioGourard.TabIndex = 1;
			this.radioGourard.Text = "Gourard";
			this.radioGourard.UseVisualStyleBackColor = true;
			this.radioGourard.CheckedChanged += new System.EventHandler(this.radioGourard_CheckedChanged);
			// 
			// radioFlat
			// 
			this.radioFlat.AutoSize = true;
			this.radioFlat.Checked = true;
			this.radioFlat.Location = new System.Drawing.Point(6, 19);
			this.radioFlat.Name = "radioFlat";
			this.radioFlat.Size = new System.Drawing.Size(42, 17);
			this.radioFlat.TabIndex = 0;
			this.radioFlat.TabStop = true;
			this.radioFlat.Text = "Flat";
			this.radioFlat.UseVisualStyleBackColor = true;
			this.radioFlat.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
			// 
			// gbLuz
			// 
			this.gbLuz.Controls.Add(this.checkAmb);
			this.gbLuz.Controls.Add(this.checkDif);
			this.gbLuz.Controls.Add(this.checkEsp);
			this.gbLuz.ForeColor = System.Drawing.SystemColors.Control;
			this.gbLuz.Location = new System.Drawing.Point(104, 19);
			this.gbLuz.Name = "gbLuz";
			this.gbLuz.Size = new System.Drawing.Size(85, 109);
			this.gbLuz.TabIndex = 4;
			this.gbLuz.TabStop = false;
			this.gbLuz.Text = "Fonte";
			// 
			// checkAmb
			// 
			this.checkAmb.AutoSize = true;
			this.checkAmb.Checked = true;
			this.checkAmb.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkAmb.Location = new System.Drawing.Point(8, 19);
			this.checkAmb.Name = "checkAmb";
			this.checkAmb.Size = new System.Drawing.Size(70, 17);
			this.checkAmb.TabIndex = 0;
			this.checkAmb.Text = "Ambiente";
			this.checkAmb.UseVisualStyleBackColor = true;
			this.checkAmb.CheckedChanged += new System.EventHandler(this.checkAmb_CheckedChanged);
			// 
			// checkDif
			// 
			this.checkDif.AutoSize = true;
			this.checkDif.Checked = true;
			this.checkDif.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkDif.Location = new System.Drawing.Point(8, 65);
			this.checkDif.Name = "checkDif";
			this.checkDif.Size = new System.Drawing.Size(62, 17);
			this.checkDif.TabIndex = 1;
			this.checkDif.Text = "Difusão";
			this.checkDif.UseVisualStyleBackColor = true;
			this.checkDif.CheckedChanged += new System.EventHandler(this.checkDif_CheckedChanged);
			// 
			// checkEsp
			// 
			this.checkEsp.AutoSize = true;
			this.checkEsp.Checked = true;
			this.checkEsp.CheckState = System.Windows.Forms.CheckState.Checked;
			this.checkEsp.Location = new System.Drawing.Point(8, 42);
			this.checkEsp.Name = "checkEsp";
			this.checkEsp.Size = new System.Drawing.Size(73, 17);
			this.checkEsp.TabIndex = 2;
			this.checkEsp.Text = "Especular";
			this.checkEsp.UseVisualStyleBackColor = true;
			this.checkEsp.CheckedChanged += new System.EventHandler(this.checkEsp_CheckedChanged);
			// 
			// btnLuz
			// 
			this.btnLuz.Location = new System.Drawing.Point(389, 65);
			this.btnLuz.Name = "btnLuz";
			this.btnLuz.Size = new System.Drawing.Size(48, 44);
			this.btnLuz.TabIndex = 7;
			this.btnLuz.Text = "Luz";
			this.btnLuz.UseVisualStyleBackColor = true;
			this.btnLuz.MouseDown += new System.Windows.Forms.MouseEventHandler(this.btnLuz_MouseDown);
			this.btnLuz.MouseMove += new System.Windows.Forms.MouseEventHandler(this.btnLuz_MouseMove);
			this.btnLuz.MouseUp += new System.Windows.Forms.MouseEventHandler(this.btnLuz_MouseUp);
			// 
			// fPrincipal
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(91)))), ((int)(((byte)(91)))), ((int)(((byte)(91)))));
			this.ClientSize = new System.Drawing.Size(973, 696);
			this.Controls.Add(this.btnLuz);
			this.Controls.Add(this.pControl);
			this.Controls.Add(this.pbImg);
			this.Controls.Add(this.btnArquivo);
			this.Controls.Add(this.label1);
			this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximizeBox = false;
			this.Name = "fPrincipal";
			this.Text = "Visual 3D";
			this.Load += new System.EventHandler(this.fPrincipal_Load);
			this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.fPrincipal_KeyDown);
			this.KeyUp += new System.Windows.Forms.KeyEventHandler(this.fPrincipal_KeyUp);
			((System.ComponentModel.ISupportInitialize)(this.pbImg)).EndInit();
			this.groupBox1.ResumeLayout(false);
			this.groupBox1.PerformLayout();
			((System.ComponentModel.ISupportInitialize)(this.tbDistancia)).EndInit();
			this.pControl.ResumeLayout(false);
			this.pControl.PerformLayout();
			this.pAramado.ResumeLayout(false);
			this.pAramado.PerformLayout();
			this.gbIlumina.ResumeLayout(false);
			this.gbMetodo.ResumeLayout(false);
			this.gbMetodo.PerformLayout();
			this.gbLuz.ResumeLayout(false);
			this.gbLuz.PerformLayout();
			this.ResumeLayout(false);
			this.PerformLayout();

		}

		#endregion
		private System.Windows.Forms.Label label1;
		private System.Windows.Forms.Button btnArquivo;
		private System.Windows.Forms.OpenFileDialog openFileDialog;
		private System.Windows.Forms.PictureBox pbImg;
		private System.Windows.Forms.CheckBox checkFace;
		private System.Windows.Forms.GroupBox groupBox1;
		private System.Windows.Forms.Label label2;
		private System.Windows.Forms.RadioButton radioLateral;
		private System.Windows.Forms.RadioButton radioFrontal;
		private System.Windows.Forms.RadioButton radioPersp;
		private System.Windows.Forms.RadioButton radioCabiner;
		private System.Windows.Forms.RadioButton radioCavalier;
		private System.Windows.Forms.RadioButton radioSuperior;
		private System.Windows.Forms.NumericUpDown tbDistancia;
		private System.Windows.Forms.Panel pControl;
		private System.Windows.Forms.CheckBox checkSolido;
		private System.Windows.Forms.GroupBox gbIlumina;
		private System.Windows.Forms.GroupBox gbLuz;
		private System.Windows.Forms.CheckBox checkAmb;
		private System.Windows.Forms.CheckBox checkDif;
		private System.Windows.Forms.CheckBox checkEsp;
		private System.Windows.Forms.Button btnLuz;
		private System.Windows.Forms.Panel pAramado;
		private System.Windows.Forms.GroupBox gbMetodo;
		private System.Windows.Forms.RadioButton radioPhong;
		private System.Windows.Forms.RadioButton radioGourard;
		private System.Windows.Forms.RadioButton radioFlat;
		private System.Windows.Forms.Button btnCor;
		private System.Windows.Forms.ColorDialog colorDialog;
	}
}

