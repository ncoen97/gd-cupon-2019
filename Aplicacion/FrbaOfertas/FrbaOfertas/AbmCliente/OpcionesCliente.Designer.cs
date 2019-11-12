namespace FrbaOfertas
{
    partial class OpcionesCliente
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
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(115, 205);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(238, 80);
            this.button1.TabIndex = 0;
            this.button1.Text = "Cargar Credito";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(124, 42);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(106, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Su usuario es";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(124, 74);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(51, 20);
            this.label2.TabIndex = 2;
            this.label2.Text = "label2";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(293, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(51, 20);
            this.label3.TabIndex = 4;
            this.label3.Text = "label3";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(293, 42);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(102, 20);
            this.label4.TabIndex = 3;
            this.label4.Text = "Su credito es";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(359, 205);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(238, 80);
            this.button2.TabIndex = 5;
            this.button2.Text = "Ver ofertas";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(115, 291);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(238, 82);
            this.button3.TabIndex = 6;
            this.button3.Text = "Mis cupones";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(608, 405);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(180, 33);
            this.button4.TabIndex = 7;
            this.button4.Text = "Cerrar sesion";
            this.button4.UseVisualStyleBackColor = true;
            this.button4.Click += new System.EventHandler(this.Button4_Click);
            // 
            // OpcionesCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Name = "OpcionesCliente";
            this.Text = "OpcionesCliente";
            this.Load += new System.EventHandler(this.OpcionesCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.Button button4;
    }
}