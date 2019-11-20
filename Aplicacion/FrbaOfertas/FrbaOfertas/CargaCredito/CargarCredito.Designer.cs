namespace FrbaOfertas
{
    partial class CargarCredito
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
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.comboBoxTarjeta = new System.Windows.Forms.ComboBox();
            this.button2 = new System.Windows.Forms.Button();
            this.buttonCargarTarjeta = new System.Windows.Forms.Button();
            this.numericUpDownMonto = new System.Windows.Forms.NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonto)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(196, 366);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(120, 38);
            this.button1.TabIndex = 5;
            this.button1.Text = "Realizar carga";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(192, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(52, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Carga";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(86, 126);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(54, 20);
            this.label3.TabIndex = 3;
            this.label3.Text = "Monto";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(86, 180);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(117, 20);
            this.label4.TabIndex = 5;
            this.label4.Text = "Forma de pago";
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(266, 177);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(259, 28);
            this.comboBox1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(86, 240);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(173, 20);
            this.label5.TabIndex = 7;
            this.label5.Text = "Elegir tarjeta registrada";
            // 
            // comboBoxTarjeta
            // 
            this.comboBoxTarjeta.FormattingEnabled = true;
            this.comboBoxTarjeta.Location = new System.Drawing.Point(266, 237);
            this.comboBoxTarjeta.Name = "comboBoxTarjeta";
            this.comboBoxTarjeta.Size = new System.Drawing.Size(259, 28);
            this.comboBoxTarjeta.TabIndex = 3;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(196, 411);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(120, 38);
            this.button2.TabIndex = 6;
            this.button2.Text = "Atras";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.Button2_Click);
            // 
            // buttonCargarTarjeta
            // 
            this.buttonCargarTarjeta.Location = new System.Drawing.Point(168, 288);
            this.buttonCargarTarjeta.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.buttonCargarTarjeta.Name = "buttonCargarTarjeta";
            this.buttonCargarTarjeta.Size = new System.Drawing.Size(192, 35);
            this.buttonCargarTarjeta.TabIndex = 4;
            this.buttonCargarTarjeta.Text = "Cargar tarjeta nueva";
            this.buttonCargarTarjeta.UseVisualStyleBackColor = true;
            this.buttonCargarTarjeta.Click += new System.EventHandler(this.buttonCargarTarjeta_Click);
            // 
            // numericUpDownMonto
            // 
            this.numericUpDownMonto.DecimalPlaces = 2;
            this.numericUpDownMonto.Location = new System.Drawing.Point(266, 123);
            this.numericUpDownMonto.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.numericUpDownMonto.Maximum = new decimal(new int[] {
            -1486618625,
            232830643,
            0,
            131072});
            this.numericUpDownMonto.Name = "numericUpDownMonto";
            this.numericUpDownMonto.Size = new System.Drawing.Size(123, 26);
            this.numericUpDownMonto.TabIndex = 1;
            // 
            // CargarCredito
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(537, 486);
            this.Controls.Add(this.numericUpDownMonto);
            this.Controls.Add(this.buttonCargarTarjeta);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.comboBoxTarjeta);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "CargarCredito";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.numericUpDownMonto)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox comboBoxTarjeta;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button buttonCargarTarjeta;
        private System.Windows.Forms.NumericUpDown numericUpDownMonto;
    }
}