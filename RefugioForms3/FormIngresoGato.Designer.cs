namespace RefugioForms
{
    partial class FormIngresoGato
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
            label5 = new Label();
            checkBoxDomestico = new CheckBox();
            TBComportamiento = new TextBox();
            label10 = new Label();
            CBRaza = new ComboBox();
            SuspendLayout();
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ActiveCaptionText;
            label5.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(39, 321);
            label5.Name = "label5";
            label5.Size = new Size(67, 21);
            label5.TabIndex = 30;
            label5.Text = "* RAZA:";
            // 
            // checkBoxDomestico
            // 
            checkBoxDomestico.Anchor = AnchorStyles.None;
            checkBoxDomestico.AutoSize = true;
            checkBoxDomestico.BackColor = SystemColors.ActiveCaptionText;
            checkBoxDomestico.CheckAlign = ContentAlignment.MiddleRight;
            checkBoxDomestico.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            checkBoxDomestico.ForeColor = SystemColors.ButtonFace;
            checkBoxDomestico.Location = new Point(400, 248);
            checkBoxDomestico.Name = "checkBoxDomestico";
            checkBoxDomestico.Size = new Size(185, 25);
            checkBoxDomestico.TabIndex = 33;
            checkBoxDomestico.Text = "¿ES DOMESTICADO?:";
            checkBoxDomestico.UseVisualStyleBackColor = false;
            // 
            // TBComportamiento
            // 
            TBComportamiento.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            TBComportamiento.Location = new Point(218, 367);
            TBComportamiento.Name = "TBComportamiento";
            TBComportamiento.Size = new Size(315, 28);
            TBComportamiento.TabIndex = 35;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.BackColor = SystemColors.ActiveCaptionText;
            label10.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label10.ForeColor = SystemColors.ButtonHighlight;
            label10.Location = new Point(39, 374);
            label10.Name = "label10";
            label10.Size = new Size(173, 21);
            label10.TabIndex = 34;
            label10.Text = "*COMPORTAMIENTO:";
            // 
            // CBRaza
            // 
            CBRaza.DropDownStyle = ComboBoxStyle.DropDownList;
            CBRaza.Font = new Font("Ebrima", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            CBRaza.FormattingEnabled = true;
            CBRaza.ImeMode = ImeMode.NoControl;
            CBRaza.Location = new Point(112, 321);
            CBRaza.Name = "CBRaza";
            CBRaza.Size = new Size(232, 25);
            CBRaza.TabIndex = 36;
            // 
            // FormIngresoGato
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_ingreso_gatos;
            ClientSize = new Size(717, 506);
            Controls.Add(CBRaza);
            Controls.Add(TBComportamiento);
            Controls.Add(label10);
            Controls.Add(checkBoxDomestico);
            Controls.Add(label5);
            Name = "FormIngresoGato";
            Text = "INGRESAR GATO";
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(checkBoxDomestico, 0);
            Controls.SetChildIndex(label10, 0);
            Controls.SetChildIndex(TBComportamiento, 0);
            Controls.SetChildIndex(CBRaza, 0);
            Controls.SetChildIndex(textBoxNombre, 0);
            Controls.SetChildIndex(textBoxPeso, 0);
            Controls.SetChildIndex(textBoxColorOjos, 0);
            Controls.SetChildIndex(buttonAceptar, 0);
            Controls.SetChildIndex(buttonCancelar, 0);
            Controls.SetChildIndex(textBoxEdad, 0);
            Controls.SetChildIndex(CBSexo, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private CheckBox checkBoxDomestico;
        protected TextBox TBComportamiento;
        private Label label10;
        protected ComboBox CBRaza;
    }
}