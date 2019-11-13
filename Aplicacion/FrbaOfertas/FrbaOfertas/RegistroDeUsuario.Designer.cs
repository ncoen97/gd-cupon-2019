namespace FrbaOfertas
{
    partial class RegistroDeUsuario
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
            this.textboxContraseña = new System.Windows.Forms.TextBox();
            this.textboxUsuario = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.Atras = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.comboBoxTipoDeUsuario = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // textboxContraseña
            // 
            this.textboxContraseña.Location = new System.Drawing.Point(131, 73);
            this.textboxContraseña.Margin = new System.Windows.Forms.Padding(2);
            this.textboxContraseña.Name = "textboxContraseña";
            this.textboxContraseña.PasswordChar = '*';
            this.textboxContraseña.Size = new System.Drawing.Size(144, 20);
            this.textboxContraseña.TabIndex = 37;
            // 
            // textboxUsuario
            // 
            this.textboxUsuario.Location = new System.Drawing.Point(131, 53);
            this.textboxUsuario.Margin = new System.Windows.Forms.Padding(2);
            this.textboxUsuario.Name = "textboxUsuario";
            this.textboxUsuario.Size = new System.Drawing.Size(144, 20);
            this.textboxUsuario.TabIndex = 36;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(121, 20);
            this.label10.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(98, 13);
            this.label10.TabIndex = 35;
            this.label10.Text = "Registro de usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(22, 75);
            this.label4.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 34;
            this.label4.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(22, 55);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(43, 13);
            this.label1.TabIndex = 33;
            this.label1.Text = "Usuario";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(210, 140);
            this.button5.Margin = new System.Windows.Forms.Padding(2);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(65, 26);
            this.button5.TabIndex = 52;
            this.button5.Text = "Registrar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // Atras
            // 
            this.Atras.Location = new System.Drawing.Point(124, 140);
            this.Atras.Margin = new System.Windows.Forms.Padding(2);
            this.Atras.Name = "Atras";
            this.Atras.Size = new System.Drawing.Size(65, 26);
            this.Atras.TabIndex = 53;
            this.Atras.Text = "Atras";
            this.Atras.UseVisualStyleBackColor = true;
            this.Atras.Click += new System.EventHandler(this.Atras_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(22, 101);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(80, 13);
            this.label2.TabIndex = 54;
            this.label2.Text = "Tipo de usuario";
            // 
            // comboBoxTipoDeUsuario
            // 
            this.comboBoxTipoDeUsuario.AccessibleRole = System.Windows.Forms.AccessibleRole.None;
            this.comboBoxTipoDeUsuario.AutoCompleteCustomSource.AddRange(new string[] {
            "Proveedor",
            "Cliente"});
            this.comboBoxTipoDeUsuario.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.Suggest;
            this.comboBoxTipoDeUsuario.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.ListItems;
            this.comboBoxTipoDeUsuario.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxTipoDeUsuario.FormattingEnabled = true;
            this.comboBoxTipoDeUsuario.Location = new System.Drawing.Point(131, 98);
            this.comboBoxTipoDeUsuario.Name = "comboBoxTipoDeUsuario";
            this.comboBoxTipoDeUsuario.Size = new System.Drawing.Size(144, 21);
            this.comboBoxTipoDeUsuario.TabIndex = 55;
            this.comboBoxTipoDeUsuario.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoDeUsuario_SelectedIndexChanged);
            // 
            // RegistroDeUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(335, 185);
            this.Controls.Add(this.comboBoxTipoDeUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Atras);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textboxContraseña);
            this.Controls.Add(this.textboxUsuario);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "RegistroDeUsuario";
            this.Text = "RegistroDeUsuario";
            this.Load += new System.EventHandler(this.RegistroDeUsuario_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textboxContraseña;
        private System.Windows.Forms.TextBox textboxUsuario;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button Atras;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxTipoDeUsuario;
    }
}