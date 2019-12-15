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
            this.textboxContraseña.Location = new System.Drawing.Point(230, 112);
            this.textboxContraseña.Name = "textboxContraseña";
            this.textboxContraseña.PasswordChar = '*';
            this.textboxContraseña.Size = new System.Drawing.Size(214, 26);
            this.textboxContraseña.TabIndex = 1;
            // 
            // textboxUsuario
            // 
            this.textboxUsuario.Location = new System.Drawing.Point(230, 82);
            this.textboxUsuario.Name = "textboxUsuario";
            this.textboxUsuario.Size = new System.Drawing.Size(214, 26);
            this.textboxUsuario.TabIndex = 0;
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(182, 31);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(147, 20);
            this.label10.TabIndex = 35;
            this.label10.Text = "Registro de usuario";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(33, 115);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 85);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Usuario";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(230, 192);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(214, 40);
            this.button5.TabIndex = 3;
            this.button5.Text = "Registrar";
            this.button5.UseVisualStyleBackColor = true;
            this.button5.Click += new System.EventHandler(this.Button5_Click);
            // 
            // Atras
            // 
            this.Atras.Location = new System.Drawing.Point(230, 238);
            this.Atras.Name = "Atras";
            this.Atras.Size = new System.Drawing.Size(214, 40);
            this.Atras.TabIndex = 4;
            this.Atras.Text = "Atras";
            this.Atras.UseVisualStyleBackColor = true;
            this.Atras.Click += new System.EventHandler(this.Atras_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 155);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(117, 20);
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
            this.comboBoxTipoDeUsuario.Location = new System.Drawing.Point(230, 151);
            this.comboBoxTipoDeUsuario.Margin = new System.Windows.Forms.Padding(4, 5, 4, 5);
            this.comboBoxTipoDeUsuario.Name = "comboBoxTipoDeUsuario";
            this.comboBoxTipoDeUsuario.Size = new System.Drawing.Size(214, 28);
            this.comboBoxTipoDeUsuario.TabIndex = 2;
            this.comboBoxTipoDeUsuario.SelectedIndexChanged += new System.EventHandler(this.comboBoxTipoDeUsuario_SelectedIndexChanged);
            // 
            // RegistroDeUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 303);
            this.Controls.Add(this.comboBoxTipoDeUsuario);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.Atras);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.textboxContraseña);
            this.Controls.Add(this.textboxUsuario);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "RegistroDeUsuario";
            this.Text = "Registro de Usuario";
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