namespace FrbaOfertas
{
    partial class CargaTarjeta
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonCargar = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNumeroDeTarjeta = new System.Windows.Forms.TextBox();
            this.textBoxNombreDelTitular = new System.Windows.Forms.TextBox();
            this.buttonCancelar = new System.Windows.Forms.Button();
            this.comboBoxMes = new System.Windows.Forms.ComboBox();
            this.comboBoxAnio = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // buttonCargar
            // 
            this.buttonCargar.Location = new System.Drawing.Point(214, 205);
            this.buttonCargar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCargar.Name = "buttonCargar";
            this.buttonCargar.Size = new System.Drawing.Size(112, 35);
            this.buttonCargar.TabIndex = 0;
            this.buttonCargar.Text = "Cargar";
            this.buttonCargar.UseVisualStyleBackColor = true;
            this.buttonCargar.Click += new System.EventHandler(this.buttonCargar_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 75);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(136, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Numero de tarjeta";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 120);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(164, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "Fecha de vencimiento";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(33, 157);
            this.label3.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(133, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Nombre del titular";
            // 
            // textBoxNumeroDeTarjeta
            // 
            this.textBoxNumeroDeTarjeta.Location = new System.Drawing.Point(214, 71);
            this.textBoxNumeroDeTarjeta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNumeroDeTarjeta.MaxLength = 16;
            this.textBoxNumeroDeTarjeta.Name = "textBoxNumeroDeTarjeta";
            this.textBoxNumeroDeTarjeta.Size = new System.Drawing.Size(256, 26);
            this.textBoxNumeroDeTarjeta.TabIndex = 4;
            this.textBoxNumeroDeTarjeta.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            // 
            // textBoxNombreDelTitular
            // 
            this.textBoxNombreDelTitular.Location = new System.Drawing.Point(214, 152);
            this.textBoxNombreDelTitular.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.textBoxNombreDelTitular.Name = "textBoxNombreDelTitular";
            this.textBoxNombreDelTitular.Size = new System.Drawing.Size(256, 26);
            this.textBoxNombreDelTitular.TabIndex = 5;
            this.textBoxNombreDelTitular.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // buttonCancelar
            // 
            this.buttonCancelar.Location = new System.Drawing.Point(214, 250);
            this.buttonCancelar.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCancelar.Name = "buttonCancelar";
            this.buttonCancelar.Size = new System.Drawing.Size(112, 35);
            this.buttonCancelar.TabIndex = 7;
            this.buttonCancelar.Text = "Cancelar";
            this.buttonCancelar.UseVisualStyleBackColor = true;
            this.buttonCancelar.Click += new System.EventHandler(this.buttonCancelar_Click);
            // 
            // comboBoxMes
            // 
            this.comboBoxMes.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxMes.FormattingEnabled = true;
            this.comboBoxMes.Location = new System.Drawing.Point(214, 111);
            this.comboBoxMes.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxMes.Name = "comboBoxMes";
            this.comboBoxMes.Size = new System.Drawing.Size(122, 28);
            this.comboBoxMes.TabIndex = 8;
            this.comboBoxMes.SelectedIndexChanged += new System.EventHandler(this.comboBoxMes_SelectedIndexChanged);
            // 
            // comboBoxAnio
            // 
            this.comboBoxAnio.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxAnio.FormattingEnabled = true;
            this.comboBoxAnio.Location = new System.Drawing.Point(348, 111);
            this.comboBoxAnio.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxAnio.Name = "comboBoxAnio";
            this.comboBoxAnio.Size = new System.Drawing.Size(122, 28);
            this.comboBoxAnio.TabIndex = 9;
            // 
            // CargaTarjeta
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(546, 402);
            this.Controls.Add(this.comboBoxAnio);
            this.Controls.Add(this.comboBoxMes);
            this.Controls.Add(this.buttonCancelar);
            this.Controls.Add(this.textBoxNombreDelTitular);
            this.Controls.Add(this.textBoxNumeroDeTarjeta);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.buttonCargar);
            this.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.Name = "CargaTarjeta";
            this.Text = "Carga Tarjeta";
            this.Load += new System.EventHandler(this.CargaTarjeta_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonCargar;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textBoxNumeroDeTarjeta;
        private System.Windows.Forms.TextBox textBoxNombreDelTitular;
        private System.Windows.Forms.Button buttonCancelar;
        private System.Windows.Forms.ComboBox comboBoxMes;
        private System.Windows.Forms.ComboBox comboBoxAnio;
    }
}