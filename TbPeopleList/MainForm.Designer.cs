namespace TbPeopleList
{
    partial class MainForm
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
            this.BtnGoToProgram = new System.Windows.Forms.Button();
            this.BtnDbRestore = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BtnGoToProgram
            // 
            this.BtnGoToProgram.Dock = System.Windows.Forms.DockStyle.Top;
            this.BtnGoToProgram.Location = new System.Drawing.Point(0, 0);
            this.BtnGoToProgram.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BtnGoToProgram.Name = "BtnGoToProgram";
            this.BtnGoToProgram.Size = new System.Drawing.Size(494, 172);
            this.BtnGoToProgram.TabIndex = 0;
            this.BtnGoToProgram.Text = "ورود به برنامه";
            this.BtnGoToProgram.UseVisualStyleBackColor = true;
            this.BtnGoToProgram.Click += new System.EventHandler(this.BtnGoToProgram_Click);
            // 
            // BtnDbRestore
            // 
            this.BtnDbRestore.Dock = System.Windows.Forms.DockStyle.Fill;
            this.BtnDbRestore.Location = new System.Drawing.Point(0, 172);
            this.BtnDbRestore.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.BtnDbRestore.Name = "BtnDbRestore";
            this.BtnDbRestore.Size = new System.Drawing.Size(494, 53);
            this.BtnDbRestore.TabIndex = 1;
            this.BtnDbRestore.Text = "بازیابی بانک اطلاعاتی از فایل پشتیبان";
            this.BtnDbRestore.UseVisualStyleBackColor = true;
            this.BtnDbRestore.Click += new System.EventHandler(this.BtnDbRestore_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(494, 225);
            this.Controls.Add(this.BtnDbRestore);
            this.Controls.Add(this.BtnGoToProgram);
            this.Font = new System.Drawing.Font("Tahoma", 7.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(2, 3, 2, 3);
            this.Name = "MainForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "موقوفه طبابت خان";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button BtnGoToProgram;
        private System.Windows.Forms.Button BtnDbRestore;
    }
}