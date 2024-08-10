namespace RefugioForms
{
    partial class FormIngresoDatos
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
        public void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormIngresoDatos));
            label1 = new Label();
            label2 = new Label();
            textBoxNombre = new TextBox();
            label3 = new Label();
            label6 = new Label();
            textBoxPeso = new TextBox();
            label7 = new Label();
            label4 = new Label();
            textBoxColorOjos = new TextBox();
            buttonAceptar = new Button();
            buttonCancelar = new Button();
            textBoxEdad = new TextBox();
            label9 = new Label();
            label8 = new Label();
            CBSexo = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ActiveCaptionText;
            label1.Font = new Font("Ebrima", 21.75F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.ForeColor = SystemColors.ButtonHighlight;
            label1.Location = new Point(188, -1);
            label1.Name = "label1";
            label1.Size = new Size(393, 40);
            label1.TabIndex = 0;
            label1.Text = "- REGISTRO DE ANIMALES -";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.BackColor = SystemColors.ActiveCaptionText;
            label2.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label2.ForeColor = SystemColors.ButtonHighlight;
            label2.Location = new Point(12, 107);
            label2.Name = "label2";
            label2.Size = new Size(94, 21);
            label2.TabIndex = 1;
            label2.Text = "* NOMBRE:";
            // 
            // textBoxNombre
            // 
            textBoxNombre.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxNombre.Location = new Point(116, 100);
            textBoxNombre.Name = "textBoxNombre";
            textBoxNombre.Size = new Size(338, 28);
            textBoxNombre.TabIndex = 2;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.BackColor = SystemColors.ActiveCaptionText;
            label3.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label3.ForeColor = SystemColors.ButtonHighlight;
            label3.Location = new Point(464, 157);
            label3.Name = "label3";
            label3.Size = new Size(103, 42);
            label3.TabIndex = 3;
            label3.Text = "* EDAD \r\n(EN MESES):";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.BackColor = SystemColors.ActiveCaptionText;
            label6.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label6.ForeColor = SystemColors.ButtonHighlight;
            label6.Location = new Point(505, 107);
            label6.Name = "label6";
            label6.Size = new Size(65, 21);
            label6.TabIndex = 9;
            label6.Text = "* PESO:";
            // 
            // textBoxPeso
            // 
            textBoxPeso.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxPeso.Location = new Point(576, 100);
            textBoxPeso.Name = "textBoxPeso";
            textBoxPeso.Size = new Size(112, 28);
            textBoxPeso.TabIndex = 10;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.BackColor = SystemColors.ActiveCaptionText;
            label7.Font = new Font("Ebrima", 14.25F, FontStyle.Bold, GraphicsUnit.Point);
            label7.ForeColor = SystemColors.ButtonHighlight;
            label7.Location = new Point(270, 39);
            label7.Name = "label7";
            label7.Size = new Size(191, 25);
            label7.TabIndex = 11;
            label7.Text = "INGRESO DE DATOS";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.BackColor = SystemColors.ActiveCaptionText;
            label4.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label4.ForeColor = SystemColors.ButtonHighlight;
            label4.Location = new Point(27, 231);
            label4.Name = "label4";
            label4.Size = new Size(79, 42);
            label4.TabIndex = 12;
            label4.Text = "* COLOR \r\nDE OJOS:";
            // 
            // textBoxColorOjos
            // 
            textBoxColorOjos.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxColorOjos.Location = new Point(112, 245);
            textBoxColorOjos.Name = "textBoxColorOjos";
            textBoxColorOjos.Size = new Size(232, 28);
            textBoxColorOjos.TabIndex = 13;
            // 
            // buttonAceptar
            // 
            buttonAceptar.BackColor = Color.FromArgb(128, 255, 128);
            buttonAceptar.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonAceptar.ForeColor = SystemColors.ActiveCaptionText;
            buttonAceptar.Location = new Point(170, 426);
            buttonAceptar.Name = "buttonAceptar";
            buttonAceptar.Size = new Size(114, 38);
            buttonAceptar.TabIndex = 14;
            buttonAceptar.Text = "ACEPTAR";
            buttonAceptar.UseVisualStyleBackColor = false;
            buttonAceptar.Click += buttonAceptar_Click;
            // 
            // buttonCancelar
            // 
            buttonCancelar.BackColor = Color.FromArgb(255, 128, 128);
            buttonCancelar.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            buttonCancelar.Location = new Point(453, 426);
            buttonCancelar.Name = "buttonCancelar";
            buttonCancelar.Size = new Size(114, 38);
            buttonCancelar.TabIndex = 15;
            buttonCancelar.Text = "CANCELAR";
            buttonCancelar.UseVisualStyleBackColor = false;
            buttonCancelar.Click += buttonCancelar_Click;
            // 
            // textBoxEdad
            // 
            textBoxEdad.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxEdad.Location = new Point(574, 171);
            textBoxEdad.Name = "textBoxEdad";
            textBoxEdad.Size = new Size(114, 28);
            textBoxEdad.TabIndex = 16;
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.BackColor = SystemColors.ActiveCaptionText;
            label9.Font = new Font("Ebrima", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            label9.ForeColor = SystemColors.ButtonHighlight;
            label9.Location = new Point(134, 64);
            label9.Name = "label9";
            label9.Size = new Size(451, 17);
            label9.TabIndex = 25;
            label9.Text = "( los que contienen * deben completarse obligatoriamente para seguir )";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.BackColor = SystemColors.ActiveCaptionText;
            label8.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label8.ForeColor = SystemColors.ButtonHighlight;
            label8.Location = new Point(52, 178);
            label8.Name = "label8";
            label8.Size = new Size(54, 21);
            label8.TabIndex = 28;
            label8.Text = "SEXO:";
            // 
            // CBSexo
            // 
            CBSexo.DropDownStyle = ComboBoxStyle.DropDownList;
            CBSexo.Font = new Font("Ebrima", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            CBSexo.FormattingEnabled = true;
            CBSexo.ImeMode = ImeMode.NoControl;
            CBSexo.Location = new Point(116, 174);
            CBSexo.Name = "CBSexo";
            CBSexo.Size = new Size(150, 25);
            CBSexo.TabIndex = 29;
            // 
            // FormIngresoDatos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(717, 506);
            Controls.Add(CBSexo);
            Controls.Add(label8);
            Controls.Add(label9);
            Controls.Add(textBoxEdad);
            Controls.Add(buttonCancelar);
            Controls.Add(buttonAceptar);
            Controls.Add(textBoxColorOjos);
            Controls.Add(label4);
            Controls.Add(label7);
            Controls.Add(textBoxPeso);
            Controls.Add(label6);
            Controls.Add(label3);
            Controls.Add(textBoxNombre);
            Controls.Add(label2);
            Controls.Add(label1);
            Icon = (Icon)resources.GetObject("$this.Icon");
            MinimizeBox = false;
            Name = "FormIngresoDatos";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "INGRESAR DATOS";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label7;
        private Label label4;
        private Label label6;

        protected TextBox textBoxPeso;
        protected TextBox textBoxColorOjos;
        protected TextBox textBoxNombre;
        protected Button buttonAceptar;
        protected Button buttonCancelar;
        protected TextBox textBoxEdad;
        private Label label9;
        private Label label8;
        protected ComboBox CBSexo;
    }
}