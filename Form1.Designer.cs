namespace WindowsFormsApp1
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.DrawingField = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.DrawingField)).BeginInit();
            this.SuspendLayout();
            // 
            // DrawingField
            // 
            this.DrawingField.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DrawingField.Location = new System.Drawing.Point(0, 0);
            this.DrawingField.Margin = new System.Windows.Forms.Padding(0);
            this.DrawingField.Name = "DrawingField";
            this.DrawingField.Size = new System.Drawing.Size(1720, 961);
            this.DrawingField.TabIndex = 0;
            this.DrawingField.TabStop = false;
            this.DrawingField.Click += new System.EventHandler(this.DrawingField_Click);
            this.DrawingField.Paint += new System.Windows.Forms.PaintEventHandler(this.DrawingField_Paint);
            this.DrawingField.MouseDown += new System.Windows.Forms.MouseEventHandler(this.DrawingField_MouseDown);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1720, 961);
            this.Controls.Add(this.DrawingField);
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.DrawingField)).EndInit();
            this.ResumeLayout(false);
        }

        #endregion
        private System.Windows.Forms.PictureBox DrawingField;
    }
}

