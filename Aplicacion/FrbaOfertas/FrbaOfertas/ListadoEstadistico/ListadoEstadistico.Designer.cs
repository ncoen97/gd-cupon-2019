﻿namespace FrbaOfertas
{
    partial class ListadoEstadistico
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
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.btn_mayorDescuento = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.btn_mayorFactr = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(260, 508);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(112, 34);
            this.button1.TabIndex = 0;
            this.button1.Text = "Volver";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // comboBox1
            // 
            this.comboBox1.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Location = new System.Drawing.Point(207, 92);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(278, 28);
            this.comboBox1.TabIndex = 1;
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(207, 62);
            this.textBox1.MaxLength = 4;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(278, 26);
            this.textBox1.TabIndex = 2;
            this.textBox1.Text = "AAAA";
            this.textBox1.Click += new System.EventHandler(this.textBox1_Click);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // dataGridView1
            // 
            this.dataGridView1.AllowUserToAddRows = false;
            this.dataGridView1.AllowUserToDeleteRows = false;
            this.dataGridView1.AllowUserToOrderColumns = true;
            this.dataGridView1.AllowUserToResizeColumns = false;
            this.dataGridView1.AllowUserToResizeRows = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 182);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(650, 320);
            this.dataGridView1.TabIndex = 3;
            // 
            // btn_mayorDescuento
            // 
            this.btn_mayorDescuento.Location = new System.Drawing.Point(34, 135);
            this.btn_mayorDescuento.Name = "btn_mayorDescuento";
            this.btn_mayorDescuento.Size = new System.Drawing.Size(285, 40);
            this.btn_mayorDescuento.TabIndex = 4;
            this.btn_mayorDescuento.Text = "Mayor descuento ofrecido";
            this.btn_mayorDescuento.UseVisualStyleBackColor = true;
            this.btn_mayorDescuento.Click += new System.EventHandler(this.btn_mayorDescuento_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(202, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(283, 20);
            this.label1.TabIndex = 5;
            this.label1.Text = "VISUALIZAR TOP 5 PROVEEDORES";
            // 
            // btn_mayorFactr
            // 
            this.btn_mayorFactr.Location = new System.Drawing.Point(358, 135);
            this.btn_mayorFactr.Name = "btn_mayorFactr";
            this.btn_mayorFactr.Size = new System.Drawing.Size(285, 40);
            this.btn_mayorFactr.TabIndex = 6;
            this.btn_mayorFactr.Text = "Mayor facturacion";
            this.btn_mayorFactr.UseVisualStyleBackColor = true;
            this.btn_mayorFactr.Click += new System.EventHandler(this.btn_mayorFactr_Click);
            // 
            // ListadoEstadistico
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(674, 552);
            this.Controls.Add(this.btn_mayorFactr);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_mayorDescuento);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.comboBox1);
            this.Controls.Add(this.button1);
            this.Name = "ListadoEstadistico";
            this.Text = "Listado estadístico";
            this.Load += new System.EventHandler(this.ListadoEstadistico_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button btn_mayorDescuento;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btn_mayorFactr;

    }
}