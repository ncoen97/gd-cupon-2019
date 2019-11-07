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
            this.Provee_mail = new System.Windows.Forms.TextBox();
            this.Provee_rs = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.button5 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Provee_mail
            // 
            this.Provee_mail.Location = new System.Drawing.Point(196, 113);
            this.Provee_mail.Name = "Provee_mail";
            this.Provee_mail.Size = new System.Drawing.Size(214, 26);
            this.Provee_mail.TabIndex = 37;
            // 
            // Provee_rs
            // 
            this.Provee_rs.Location = new System.Drawing.Point(196, 81);
            this.Provee_rs.Name = "Provee_rs";
            this.Provee_rs.Size = new System.Drawing.Size(214, 26);
            this.Provee_rs.TabIndex = 36;
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
            this.label4.Location = new System.Drawing.Point(33, 116);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(92, 20);
            this.label4.TabIndex = 34;
            this.label4.Text = "Contraseña";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(33, 84);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 20);
            this.label1.TabIndex = 33;
            this.label1.Text = "Usuario";
            // 
            // button5
            // 
            this.button5.Location = new System.Drawing.Point(196, 169);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(98, 40);
            this.button5.TabIndex = 52;
            this.button5.Text = "Registrar";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // RegistroDeUsuario
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(502, 229);
            this.Controls.Add(this.button5);
            this.Controls.Add(this.Provee_mail);
            this.Controls.Add(this.Provee_rs);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label1);
            this.Name = "RegistroDeUsuario";
            this.Text = "RegistroDeUsuario";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Provee_mail;
        private System.Windows.Forms.TextBox Provee_rs;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button5;
    }
}