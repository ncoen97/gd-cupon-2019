namespace FrbaOfertas.AbmCliente
{
    partial class AbmCliente
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
            this.button6 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button3 = new System.Windows.Forms.Button();
            this.rb_email = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.rb_dni = new System.Windows.Forms.RadioButton();
            this.rb_apellido = new System.Windows.Forms.RadioButton();
            this.rb_nombre = new System.Windows.Forms.RadioButton();
            this.button2 = new System.Windows.Forms.Button();
            this.button1 = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // button6
            // 
            this.button6.Location = new System.Drawing.Point(610, 318);
            this.button6.Name = "button6";
            this.button6.Size = new System.Drawing.Size(134, 48);
            this.button6.TabIndex = 25;
            this.button6.Text = "Modificar cliente";
            this.button6.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(797, 472);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(134, 48);
            this.button5.TabIndex = 24;
            this.button5.Text = "Volver atras";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Location = new System.Drawing.Point(470, 318);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(134, 48);
            this.button4.TabIndex = 23;
            this.button4.Text = "Crear cliente";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(750, 318);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(134, 48);
            this.button3.TabIndex = 22;
            this.button3.Text = "Cambiar estado del cliente";
            this.button3.UseVisualStyleBackColor = true;
            // 
            // rb_email
            // 
            this.rb_email.AutoSize = true;
            this.rb_email.Location = new System.Drawing.Point(115, 330);
            this.rb_email.Name = "rb_email";
            this.rb_email.Size = new System.Drawing.Size(73, 24);
            this.rb_email.TabIndex = 21;
            this.rb_email.TabStop = true;
            this.rb_email.Text = "Email";
            this.rb_email.UseVisualStyleBackColor = true;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 295);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(83, 20);
            this.label1.TabIndex = 20;
            this.label1.Text = "Elegir filtro";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(19, 395);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(181, 26);
            this.textBox1.TabIndex = 19;
            // 
            // rb_dni
            // 
            this.rb_dni.AutoSize = true;
            this.rb_dni.Location = new System.Drawing.Point(115, 360);
            this.rb_dni.Name = "rb_dni";
            this.rb_dni.Size = new System.Drawing.Size(58, 24);
            this.rb_dni.TabIndex = 18;
            this.rb_dni.TabStop = true;
            this.rb_dni.Text = "Dni";
            this.rb_dni.UseVisualStyleBackColor = true;
            // 
            // rb_apellido
            // 
            this.rb_apellido.AutoSize = true;
            this.rb_apellido.Location = new System.Drawing.Point(19, 360);
            this.rb_apellido.Name = "rb_apellido";
            this.rb_apellido.Size = new System.Drawing.Size(90, 24);
            this.rb_apellido.TabIndex = 17;
            this.rb_apellido.TabStop = true;
            this.rb_apellido.Text = "Apellido";
            this.rb_apellido.UseVisualStyleBackColor = true;
            // 
            // rb_nombre
            // 
            this.rb_nombre.AutoSize = true;
            this.rb_nombre.Location = new System.Drawing.Point(19, 330);
            this.rb_nombre.Name = "rb_nombre";
            this.rb_nombre.Size = new System.Drawing.Size(90, 24);
            this.rb_nombre.TabIndex = 16;
            this.rb_nombre.TabStop = true;
            this.rb_nombre.Text = "Nombre";
            this.rb_nombre.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(159, 443);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(134, 48);
            this.button2.TabIndex = 15;
            this.button2.Text = "Quitar filtro";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(19, 443);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(134, 48);
            this.button1.TabIndex = 14;
            this.button1.Text = "Aplicar filtro";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(19, 14);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(888, 254);
            this.dataGridView1.TabIndex = 13;
            // 
            // AbmCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(947, 535);
            this.Controls.Add(this.button6);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.button4);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.rb_email);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.rb_dni);
            this.Controls.Add(this.rb_apellido);
            this.Controls.Add(this.rb_nombre);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.dataGridView1);
            this.Name = "AbmCliente";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button6;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RadioButton rb_email;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.RadioButton rb_dni;
        private System.Windows.Forms.RadioButton rb_apellido;
        private System.Windows.Forms.RadioButton rb_nombre;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}