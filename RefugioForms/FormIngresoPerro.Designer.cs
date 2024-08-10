namespace RefugioForms
{
    partial class FormIngresoPerro
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
            textBoxRaza = new TextBox();
            label5 = new Label();
            label10 = new Label();
            CBTamanio = new ComboBox();
            SuspendLayout();
            // 
            // textBoxRaza
            // 
            textBoxRaza.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxRaza.Location = new Point(112, 303);
            textBoxRaza.Name = "textBoxRaza";
            textBoxRaza.Size = new Size(271, 28);
            textBoxRaza.TabIndex = 34;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ActiveCaptionText;
            label5.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(39, 310);
            label5.Name = "label5";
            label5.Size = new Size(67, 21);
            label5.TabIndex = 33;
            label5.Text = "* RAZA:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.ActiveCaptionText;
            label10.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.ButtonHighlight;
            label10.Location = new Point(389, 310);
            label10.Name = "label10";
            label10.Size = new Size(92, 21);
            label10.TabIndex = 37;
            label10.Text = "*TAMAÑO:";
            // 
            // CBTamanio
            // 
            CBTamanio.DropDownStyle = ComboBoxStyle.DropDownList;
            CBTamanio.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            CBTamanio.FormattingEnabled = true;
            CBTamanio.Location = new Point(487, 302);
            CBTamanio.Name = "CBTamanio";
            CBTamanio.Size = new Size(185, 29);
            CBTamanio.TabIndex = 38;
            // 
            // FormIngresoPerro
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_ingreso_perros;
            ClientSize = new Size(717, 506);
            Controls.Add(CBTamanio);
            Controls.Add(label10);
            Controls.Add(textBoxRaza);
            Controls.Add(label5);
            Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            Margin = new Padding(4);
            Name = "FormIngresoPerro";
            Text = "INGRESAR PERRO";
            Controls.SetChildIndex(textBoxNombre, 0);
            Controls.SetChildIndex(textBoxPeso, 0);
            Controls.SetChildIndex(textBoxColorOjos, 0);
            Controls.SetChildIndex(buttonAceptar, 0);
            Controls.SetChildIndex(buttonCancelar, 0);
            Controls.SetChildIndex(textBoxEdad, 0);
            Controls.SetChildIndex(CBSexo, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(textBoxRaza, 0);
            Controls.SetChildIndex(label10, 0);
            Controls.SetChildIndex(CBTamanio, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        protected TextBox textBoxRaza;
        private Label label5;
        private Label label10;
        private ComboBox CBTamanio;
    }
}