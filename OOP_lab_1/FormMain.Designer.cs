﻿namespace OOP_lab_1
{
    partial class FormMain
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
            this.pbDrawField = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawField)).BeginInit();
            this.SuspendLayout();
            // 
            // pbDrawField
            // 
            this.pbDrawField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbDrawField.Location = new System.Drawing.Point(0, 0);
            this.pbDrawField.Name = "pbDrawField";
            this.pbDrawField.Size = new System.Drawing.Size(1178, 744);
            this.pbDrawField.TabIndex = 0;
            this.pbDrawField.TabStop = false;
            this.pbDrawField.Click += new System.EventHandler(this.pbDrawField_Click);
            // 
            // FormMain
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.ClientSize = new System.Drawing.Size(1178, 744);
            this.Controls.Add(this.pbDrawField);
            this.MaximumSize = new System.Drawing.Size(1200, 800);
            this.MinimumSize = new System.Drawing.Size(1200, 800);
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.FormMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.pbDrawField)).EndInit();
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.PictureBox pbDrawField;

        #endregion
    }
}