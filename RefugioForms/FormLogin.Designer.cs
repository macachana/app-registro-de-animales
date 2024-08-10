namespace RefugioForms
{
    partial class FormLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormLogin));
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            textBox1 = new TextBox();
            textBox2 = new TextBox();
            button_ingresar = new Button();
            label4 = new Label();
            buttonMostrar = new Button();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.Font = new Font("Ebrima", 20.25F, FontStyle.Bold, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(424, 81);
            label1.Name = "label1";
            label1.Size = new Size(100, 37);
            label1.TabIndex = 0;
            label1.Text = "LOGIN";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaptionText;
            label2.Font = new Font("Ebrima", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(12, 143);
            label2.Name = "label2";
            label2.Size = new Size(292, 32);
            label2.TabIndex = 1;
            label2.Text = "CORREO ELECTRONICO :";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaptionText;
            label3.Font = new Font("Ebrima", 18F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(12, 288);
            label3.Name = "label3";
            label3.Size = new Size(189, 32);
            label3.TabIndex = 2;
            label3.Text = "CONTRASEÑA :";
            // 
            // textBox1
            // 
            textBox1.Font = new Font("Ebrima", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            textBox1.Location = new Point(12, 193);
            textBox1.Name = "textBox1";
            textBox1.Size = new Size(447, 34);
            textBox1.TabIndex = 3;
            // 
            // textBox2
            // 
            textBox2.Font = new Font("Ebrima", 15.75F, FontStyle.Bold, GraphicsUnit.Point);
            textBox2.Location = new Point(12, 340);
            textBox2.Name = "textBox2";
            textBox2.PasswordChar = '*';
            textBox2.Size = new Size(447, 34);
            textBox2.TabIndex = 4;
            // 
            // button_ingresar
            // 
            button_ingresar.Font = new Font("Ebrima", 18F, FontStyle.Bold, GraphicsUnit.Point);
            button_ingresar.Location = new Point(147, 448);
            button_ingresar.Name = "button_ingresar";
            button_ingresar.Size = new Size(157, 46);
            button_ingresar.TabIndex = 5;
            button_ingresar.Text = "INGRESAR";
            button_ingresar.UseVisualStyleBackColor = true;
            button_ingresar.Click += button_ingresar_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = Color.Black;
            label4.Font = new Font("Ebrima", 26.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonFace;
            label4.Location = new Point(244, 25);
            label4.Name = "label4";
            label4.Size = new Size(482, 47);
            label4.TabIndex = 6;
            label4.Text = "- REGISTRO DE ANIMALES -";
            // 
            // buttonMostrar
            // 
            buttonMostrar.Font = new Font("Ebrima", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            buttonMostrar.Location = new Point(376, 340);
            buttonMostrar.Name = "buttonMostrar";
            buttonMostrar.Size = new Size(83, 34);
            buttonMostrar.TabIndex = 7;
            buttonMostrar.Text = "MOSTRAR";
            buttonMostrar.UseVisualStyleBackColor = true;
            // 
            // pictureBox1
            // 
            pictureBox1.Image = Properties.Resources.imagen_form_login;
            pictureBox1.Location = new Point(515, 134);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(360, 360);
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // FormLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.principal_fondo;
            ClientSize = new Size(904, 525);
            Controls.Add(pictureBox1);
            Controls.Add(buttonMostrar);
            Controls.Add(label4);
            Controls.Add(button_ingresar);
            Controls.Add(textBox2);
            Controls.Add(textBox1);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "FormLogin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "LOGIN";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox textBox1;
        private TextBox textBox2;
        private Button button_ingresar;
        private Label label4;
        private Button buttonMostrar;
        private PictureBox pictureBox1;
    }
}
