namespace FrbaOfertas
{
    partial class RegistroDeCliente
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
            this.Cli_ciudad = new System.Windows.Forms.TextBox();
            this.Cli_cp = new System.Windows.Forms.TextBox();
            this.Cli_direccion = new System.Windows.Forms.TextBox();
            this.Cli_telefono = new System.Windows.Forms.TextBox();
            this.Cli_mail = new System.Windows.Forms.TextBox();
            this.Cli_dni = new System.Windows.Forms.TextBox();
            this.Cli_apellido = new System.Windows.Forms.TextBox();
            this.Cli_nombre = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.Cli_fecha = new System.Windows.Forms.DateTimePicker();
            this.button5 = new System.Windows.Forms.Button();
            this.label_usu = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(202, 367);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(214, 40);
            this.button1.TabIndex = 9;
            this.button1.Text = "Crear cliente";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.Button1_Click);
            // 
            // Cli_ciudad
            // 
            this.Cli_ciudad.Location = new System.Drawing.Point(202, 318);
            this.Cli_ciudad.Name = "Cli_ciudad";
            this.Cli_ciudad.Size = new System.Drawing.Size(214, 26);
            this.Cli_ciudad.TabIndex = 8;
            // 
            // Cli_cp
            // 
            this.Cli_cp.Location = new System.Drawing.Point(202, 253);
            this.Cli_cp.Name = "Cli_cp";
            this.Cli_cp.Size = new System.Drawing.Size(214, 26);
            this.Cli_cp.TabIndex = 6;
            this.Cli_cp.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cli_cp_KeyPress);
            // 
            // Cli_direccion
            // 
            this.Cli_direccion.Location = new System.Drawing.Point(202, 222);
            this.Cli_direccion.Name = "Cli_direccion";
            this.Cli_direccion.Size = new System.Drawing.Size(214, 26);
            this.Cli_direccion.TabIndex = 5;
            // 
            // Cli_telefono
            // 
            this.Cli_telefono.Location = new System.Drawing.Point(202, 190);
            this.Cli_telefono.Name = "Cli_telefono";
            this.Cli_telefono.Size = new System.Drawing.Size(214, 26);
            this.Cli_telefono.TabIndex = 4;
            this.Cli_telefono.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cli_telefono_KeyPress);
            // 
            // Cli_mail
            // 
            this.Cli_mail.Location = new System.Drawing.Point(202, 158);
            this.Cli_mail.Name = "Cli_mail";
            this.Cli_mail.Size = new System.Drawing.Size(214, 26);
            this.Cli_mail.TabIndex = 3;
            // 
            // Cli_dni
            // 
            this.Cli_dni.Location = new System.Drawing.Point(202, 126);
            this.Cli_dni.Name = "Cli_dni";
            this.Cli_dni.Size = new System.Drawing.Size(214, 26);
            this.Cli_dni.TabIndex = 2;
            this.Cli_dni.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.Cli_dni_KeyPress);
            // 
            // Cli_apellido
            // 
            this.Cli_apellido.Location = new System.Drawing.Point(202, 93);
            this.Cli_apellido.Name = "Cli_apellido";
            this.Cli_apellido.Size = new System.Drawing.Size(214, 26);
            this.Cli_apellido.TabIndex = 1;
            // 
            // Cli_nombre
            // 
            this.Cli_nombre.Location = new System.Drawing.Point(202, 62);
            this.Cli_nombre.Name = "Cli_nombre";
            this.Cli_nombre.Size = new System.Drawing.Size(214, 26);
            this.Cli_nombre.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(275, 39);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(141, 20);
            this.label10.TabIndex = 58;
            this.label10.Text = "Registro de cliente";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(39, 321);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(59, 20);
            this.label9.TabIndex = 57;
            this.label9.Text = "Ciudad";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(39, 193);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(71, 20);
            this.label5.TabIndex = 56;
            this.label5.Text = "Telefono";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(39, 226);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(75, 20);
            this.label6.TabIndex = 55;
            this.label6.Text = "Direccion";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(39, 256);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(107, 20);
            this.label7.TabIndex = 54;
            this.label7.Text = "Código Postal";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(39, 289);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(157, 20);
            this.label8.TabIndex = 53;
            this.label8.Text = "Fecha de nacimiento";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(39, 161);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(37, 20);
            this.label4.TabIndex = 52;
            this.label4.Text = "Mail";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(39, 129);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(33, 20);
            this.label3.TabIndex = 51;
            this.label3.Text = "Dni";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(39, 96);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 20);
            this.label2.TabIndex = 50;
            this.label2.Text = "Apellido";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(39, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 20);
            this.label1.TabIndex = 49;
            this.label1.Text = "Nombre";
            // 
            // Cli_fecha
            // 
            this.Cli_fecha.Format = System.Windows.Forms.DateTimePickerFormat.Short;
            this.Cli_fecha.Location = new System.Drawing.Point(202, 286);
            this.Cli_fecha.MaxDate = new System.DateTime(2019, 12, 4, 0, 0, 0, 0);
            this.Cli_fecha.MinDate = new System.DateTime(1920, 1, 1, 0, 0, 0, 0);
            this.Cli_fecha.Name = "Cli_fecha";
            this.Cli_fecha.Size = new System.Drawing.Size(214, 26);
            this.Cli_fecha.TabIndex = 7;
            this.Cli_fecha.Value = new System.DateTime(2019, 11, 13, 0, 0, 0, 0);
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(202, 459);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(214, 40);
            this.button5.TabIndex = 10;
            this.button5.Text = "Atras";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.button5_Click);
            // 
            // label_usu
            // 
            this.label_usu.AutoSize = true;
            this.label_usu.Location = new System.Drawing.Point(39, 9);
            this.label_usu.Name = "label_usu";
            this.label_usu.Size = new System.Drawing.Size(60, 20);
            this.label_usu.TabIndex = 72;
            this.label_usu.Text = "label11";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(202, 413);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(214, 40);
            this.button2.TabIndex = 73;
            this.button2.Text = "Limpiar campos";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // RegistroDeCliente
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(580, 516);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label_usu);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.Cli_fecha);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.Cli_ciudad);
            this.Controls.Add(this.Cli_cp);
            this.Controls.Add(this.Cli_direccion);
            this.Controls.Add(this.Cli_telefono);
            this.Controls.Add(this.Cli_mail);
            this.Controls.Add(this.Cli_dni);
            this.Controls.Add(this.Cli_apellido);
            this.Controls.Add(this.Cli_nombre);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "RegistroDeCliente";
            this.Text = "Registro de Cliente";
            this.Load += new System.EventHandler(this.RegistroDeCliente_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Cli_ciudad;
        private System.Windows.Forms.TextBox Cli_cp;
        private System.Windows.Forms.TextBox Cli_direccion;
        private System.Windows.Forms.TextBox Cli_telefono;
        private System.Windows.Forms.TextBox Cli_mail;
        private System.Windows.Forms.TextBox Cli_dni;
        private System.Windows.Forms.TextBox Cli_apellido;
        private System.Windows.Forms.TextBox Cli_nombre;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker Cli_fecha;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Label label_usu;
        private System.Windows.Forms.Button button2;
    }
}