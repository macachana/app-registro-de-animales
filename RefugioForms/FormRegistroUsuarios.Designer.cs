namespace RefugioForms
{
    partial class FormRegistroUsuarios
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormRegistroUsuarios));
            label1 = new Label();
            Registro_view = new ListBox();
            menuStrip1 = new MenuStrip();
            aBRIRARCHIVOLOGToolStripMenuItem = new ToolStripMenuItem();
            gUARDARARCHIVOLOGToolStripMenuItem = new ToolStripMenuItem();
            SFDArchivoLog = new SaveFileDialog();
            OFDArchivoLog = new OpenFileDialog();
            menuStrip1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = SystemColors.ButtonHighlight;
            label1.Font = new Font("Ebrima", 26.25F, FontStyle.Bold | FontStyle.Underline, GraphicsUnit.Point);
            label1.Location = new Point(306, 47);
            label1.Name = "label1";
            label1.Size = new Size(700, 47);
            label1.TabIndex = 0;
            label1.Text = "- REGISTRO DE USUARIOS LOGUEADOS -";
            // 
            // Registro_view
            // 
            Registro_view.FormattingEnabled = true;
            Registro_view.ItemHeight = 21;
            Registro_view.Location = new Point(23, 108);
            Registro_view.Name = "Registro_view";
            Registro_view.Size = new Size(1178, 529);
            Registro_view.TabIndex = 2;
            // 
            // menuStrip1
            // 
            menuStrip1.Font = new Font("Ebrima", 11.25F, FontStyle.Bold, GraphicsUnit.Point);
            menuStrip1.Items.AddRange(new ToolStripItem[] { aBRIRARCHIVOLOGToolStripMenuItem, gUARDARARCHIVOLOGToolStripMenuItem });
            menuStrip1.Location = new Point(0, 0);
            menuStrip1.Name = "menuStrip1";
            menuStrip1.Size = new Size(1224, 28);
            menuStrip1.TabIndex = 3;
            menuStrip1.Text = "menuStrip1";
            // 
            // aBRIRARCHIVOLOGToolStripMenuItem
            // 
            aBRIRARCHIVOLOGToolStripMenuItem.Name = "aBRIRARCHIVOLOGToolStripMenuItem";
            aBRIRARCHIVOLOGToolStripMenuItem.Size = new Size(172, 24);
            aBRIRARCHIVOLOGToolStripMenuItem.Text = "ABRIR ARCHIVO LOG";
            aBRIRARCHIVOLOGToolStripMenuItem.Click += aBRIRARCHIVOLOGToolStripMenuItem_Click;
            // 
            // gUARDARARCHIVOLOGToolStripMenuItem
            // 
            gUARDARARCHIVOLOGToolStripMenuItem.Name = "gUARDARARCHIVOLOGToolStripMenuItem";
            gUARDARARCHIVOLOGToolStripMenuItem.Size = new Size(201, 24);
            gUARDARARCHIVOLOGToolStripMenuItem.Text = "GUARDAR ARCHIVO LOG";
            gUARDARARCHIVOLOGToolStripMenuItem.Click += gUARDARARCHIVOLOGToolStripMenuItem_Click;
            // 
            // SFDArchivoLog
            // 
            SFDArchivoLog.Filter = "Log files (*.log)|*.log|All files (*.*)|*.*";
            // 
            // OFDArchivoLog
            // 
            OFDArchivoLog.FileName = "openFileDialog1";
            OFDArchivoLog.Filter = "Log files (*.log)|*.log|All files (*.*)|*.*";
            // 
            // FormRegistroUsuarios
            // 
            AutoScaleDimensions = new SizeF(10F, 21F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = SystemColors.ActiveCaptionText;
            ClientSize = new Size(1224, 667);
            Controls.Add(Registro_view);
            Controls.Add(label1);
            Controls.Add(menuStrip1);
            Font = new Font("Ebrima", 12F, FontStyle.Bold, GraphicsUnit.Point);
            FormBorderStyle = FormBorderStyle.FixedSingle;
            Icon = (Icon)resources.GetObject("$this.Icon");
            MainMenuStrip = menuStrip1;
            Margin = new Padding(4);
            MaximizeBox = false;
            MdiChildrenMinimizedAnchorBottom = false;
            MinimizeBox = false;
            Name = "FormRegistroUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "REGISTRO DE INGRESO DE USUARIOS";
            menuStrip1.ResumeLayout(false);
            menuStrip1.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private ListBox Registro_view;
        private MenuStrip menuStrip1;
        private ToolStripMenuItem aBRIRARCHIVOLOGToolStripMenuItem;
        private ToolStripMenuItem gUARDARARCHIVOLOGToolStripMenuItem;
        private SaveFileDialog SFDArchivoLog;
        private OpenFileDialog OFDArchivoLog;
    }
}