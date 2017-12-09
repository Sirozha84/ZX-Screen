namespace ZX_Screen
{
    partial class FormOptions
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
            this.tabPageAssotiation = new System.Windows.Forms.TabPage();
            this.buttonAssociacion = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.checkBoxSCR = new System.Windows.Forms.CheckBox();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.buttonOK = new System.Windows.Forms.Button();
            this.buttonCancel = new System.Windows.Forms.Button();
            this.tabPageAssotiation.SuspendLayout();
            this.tabControl1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabPageAssotiation
            // 
            this.tabPageAssotiation.Controls.Add(this.buttonAssociacion);
            this.tabPageAssotiation.Controls.Add(this.label1);
            this.tabPageAssotiation.Controls.Add(this.checkBoxSCR);
            this.tabPageAssotiation.Location = new System.Drawing.Point(4, 22);
            this.tabPageAssotiation.Name = "tabPageAssotiation";
            this.tabPageAssotiation.Padding = new System.Windows.Forms.Padding(3);
            this.tabPageAssotiation.Size = new System.Drawing.Size(361, 113);
            this.tabPageAssotiation.TabIndex = 0;
            this.tabPageAssotiation.Text = "Ассоциация файлов";
            this.tabPageAssotiation.UseVisualStyleBackColor = true;
            // 
            // buttonAssociacion
            // 
            this.buttonAssociacion.Location = new System.Drawing.Point(9, 42);
            this.buttonAssociacion.Name = "buttonAssociacion";
            this.buttonAssociacion.Size = new System.Drawing.Size(126, 23);
            this.buttonAssociacion.TabIndex = 2;
            this.buttonAssociacion.Text = "Ассоциировать";
            this.buttonAssociacion.UseVisualStyleBackColor = true;
            this.buttonAssociacion.Click += new System.EventHandler(this.buttonAssociacion_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(311, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Выберите файлы, которые будут открываться в программе";
            // 
            // checkBoxSCR
            // 
            this.checkBoxSCR.AutoSize = true;
            this.checkBoxSCR.Checked = true;
            this.checkBoxSCR.CheckState = System.Windows.Forms.CheckState.Checked;
            this.checkBoxSCR.Location = new System.Drawing.Point(9, 19);
            this.checkBoxSCR.Name = "checkBoxSCR";
            this.checkBoxSCR.Size = new System.Drawing.Size(48, 17);
            this.checkBoxSCR.TabIndex = 0;
            this.checkBoxSCR.Text = "SCR";
            this.checkBoxSCR.UseVisualStyleBackColor = true;
            // 
            // tabControl1
            // 
            this.tabControl1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.tabControl1.Controls.Add(this.tabPageAssotiation);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(369, 139);
            this.tabControl1.TabIndex = 0;
            // 
            // buttonOK
            // 
            this.buttonOK.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonOK.Location = new System.Drawing.Point(225, 157);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(75, 23);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // buttonCancel
            // 
            this.buttonCancel.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.buttonCancel.Location = new System.Drawing.Point(306, 157);
            this.buttonCancel.Name = "buttonCancel";
            this.buttonCancel.Size = new System.Drawing.Size(75, 23);
            this.buttonCancel.TabIndex = 2;
            this.buttonCancel.Text = "Отмена";
            this.buttonCancel.UseVisualStyleBackColor = true;
            this.buttonCancel.Click += new System.EventHandler(this.buttonCancel_Click);
            // 
            // FormOptions
            // 
            this.AcceptButton = this.buttonOK;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.buttonCancel;
            this.ClientSize = new System.Drawing.Size(393, 192);
            this.Controls.Add(this.buttonCancel);
            this.Controls.Add(this.buttonOK);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FormOptions";
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Параметры";
            this.Load += new System.EventHandler(this.FormOptions_Load);
            this.tabPageAssotiation.ResumeLayout(false);
            this.tabPageAssotiation.PerformLayout();
            this.tabControl1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabPage tabPageAssotiation;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.Button buttonCancel;
        private System.Windows.Forms.CheckBox checkBoxSCR;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button buttonAssociacion;
    }
}