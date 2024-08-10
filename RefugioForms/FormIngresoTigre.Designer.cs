namespace RefugioForms
{
    partial class FormIngresoTigre
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
            label12 = new Label();
            label5 = new Label();
            textBoxHabitat = new TextBox();
            CBSubEspecie = new ComboBox();
            SuspendLayout();
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.BackColor = SystemColors.ActiveCaptionText;
            label12.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label12.ForeColor = SystemColors.ButtonHighlight;
            label12.Location = new Point(25, 319);
            label12.Name = "label12";
            label12.Size = new Size(81, 21);
            label12.TabIndex = 35;
            label12.Text = "HABITAT:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.BackColor = SystemColors.ActiveCaptionText;
            label5.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            label5.ForeColor = SystemColors.ButtonHighlight;
            label5.Location = new Point(383, 228);
            label5.Name = "label5";
            label5.Size = new Size(75, 42);
            label5.TabIndex = 33;
            label5.Text = "SUB \r\nESPECIE:";
            // 
            // textBoxHabitat
            // 
            textBoxHabitat.Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            textBoxHabitat.Location = new Point(112, 312);
            textBoxHabitat.Name = "textBoxHabitat";
            textBoxHabitat.Size = new Size(232, 28);
            textBoxHabitat.TabIndex = 36;
            // 
            // CBSubEspecie
            // 
            CBSubEspecie.DropDownStyle = ComboBoxStyle.DropDownList;
            CBSubEspecie.Font = new Font("Ebrima", 9.75F, FontStyle.Bold, GraphicsUnit.Point);
            CBSubEspecie.FormattingEnabled = true;
            CBSubEspecie.ImeMode = ImeMode.NoControl;
            CBSubEspecie.Location = new Point(464, 245);
            CBSubEspecie.Name = "CBSubEspecie";
            CBSubEspecie.Size = new Size(232, 25);
            CBSubEspecie.TabIndex = 37;
            // 
            // FormIngresoTigre
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Fondo_ingreso_tigres;
            ClientSize = new Size(717, 506);
            Controls.Add(CBSubEspecie);
            Controls.Add(textBoxHabitat);
            Controls.Add(label12);
            Controls.Add(label5);
            Name = "FormIngresoTigre";
            Text = "INGRESO TIGRES";
            Controls.SetChildIndex(textBoxNombre, 0);
            Controls.SetChildIndex(textBoxPeso, 0);
            Controls.SetChildIndex(textBoxColorOjos, 0);
            Controls.SetChildIndex(buttonAceptar, 0);
            Controls.SetChildIndex(buttonCancelar, 0);
            Controls.SetChildIndex(textBoxEdad, 0);
            Controls.SetChildIndex(CBSexo, 0);
            Controls.SetChildIndex(label5, 0);
            Controls.SetChildIndex(label12, 0);
            Controls.SetChildIndex(textBoxHabitat, 0);
            Controls.SetChildIndex(CBSubEspecie, 0);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label12;
        private Label label5;
        protected TextBox textBoxHabitat;
        protected ComboBox CBSubEspecie;
    }
}