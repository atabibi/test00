namespace TababatkhanList
{
    partial class FrmMain
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
            this.components = new System.ComponentModel.Container();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.tbListDataSet = new TababatkhanList.TbListDataSet();
            this.personBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.personTableAdapter = new TababatkhanList.TbListDataSetTableAdapters.PersonTableAdapter();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.fNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.lNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.mablaghDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.parentNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.jadNameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.melliCodeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shomarehHesabDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.shomarehKartBankiDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descriptionDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbListDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(882, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.dataGridView1);
            this.splitContainer1.Panel2.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.splitContainer1.Size = new System.Drawing.Size(882, 568);
            this.splitContainer1.SplitterDistance = 159;
            this.splitContainer1.TabIndex = 1;
            // 
            // dataGridView1
            // 
            this.dataGridView1.AutoGenerateColumns = false;
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.iDDataGridViewTextBoxColumn,
            this.fNameDataGridViewTextBoxColumn,
            this.lNameDataGridViewTextBoxColumn,
            this.mablaghDataGridViewTextBoxColumn,
            this.parentNameDataGridViewTextBoxColumn,
            this.jadNameDataGridViewTextBoxColumn,
            this.melliCodeDataGridViewTextBoxColumn,
            this.shomarehHesabDataGridViewTextBoxColumn,
            this.shomarehKartBankiDataGridViewTextBoxColumn,
            this.descriptionDataGridViewTextBoxColumn});
            this.dataGridView1.DataSource = this.personBindingSource;
            this.dataGridView1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.dataGridView1.Location = new System.Drawing.Point(0, 0);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 51;
            this.dataGridView1.RowTemplate.Height = 24;
            this.dataGridView1.Size = new System.Drawing.Size(719, 568);
            this.dataGridView1.TabIndex = 0;
            // 
            // tbListDataSet
            // 
            this.tbListDataSet.DataSetName = "TbListDataSet";
            this.tbListDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // personBindingSource
            // 
            this.personBindingSource.DataMember = "Person";
            this.personBindingSource.DataSource = this.tbListDataSet;
            // 
            // personTableAdapter
            // 
            this.personTableAdapter.ClearBeforeFill = true;
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            this.iDDataGridViewTextBoxColumn.Visible = false;
            this.iDDataGridViewTextBoxColumn.Width = 125;
            // 
            // fNameDataGridViewTextBoxColumn
            // 
            this.fNameDataGridViewTextBoxColumn.DataPropertyName = "نام";
            this.fNameDataGridViewTextBoxColumn.HeaderText = "FName";
            this.fNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.fNameDataGridViewTextBoxColumn.Name = "fNameDataGridViewTextBoxColumn";
            this.fNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // lNameDataGridViewTextBoxColumn
            // 
            this.lNameDataGridViewTextBoxColumn.DataPropertyName = "نام خانوادگی";
            this.lNameDataGridViewTextBoxColumn.HeaderText = "LName";
            this.lNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.lNameDataGridViewTextBoxColumn.Name = "lNameDataGridViewTextBoxColumn";
            this.lNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // mablaghDataGridViewTextBoxColumn
            // 
            this.mablaghDataGridViewTextBoxColumn.DataPropertyName = "مبلغ";
            this.mablaghDataGridViewTextBoxColumn.HeaderText = "Mablagh";
            this.mablaghDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.mablaghDataGridViewTextBoxColumn.Name = "mablaghDataGridViewTextBoxColumn";
            this.mablaghDataGridViewTextBoxColumn.Width = 125;
            // 
            // parentNameDataGridViewTextBoxColumn
            // 
            this.parentNameDataGridViewTextBoxColumn.DataPropertyName = "پدر یا مادر";
            this.parentNameDataGridViewTextBoxColumn.HeaderText = "ParentName";
            this.parentNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.parentNameDataGridViewTextBoxColumn.Name = "parentNameDataGridViewTextBoxColumn";
            this.parentNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // jadNameDataGridViewTextBoxColumn
            // 
            this.jadNameDataGridViewTextBoxColumn.DataPropertyName = "جد یا جده";
            this.jadNameDataGridViewTextBoxColumn.HeaderText = "JadName";
            this.jadNameDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.jadNameDataGridViewTextBoxColumn.Name = "jadNameDataGridViewTextBoxColumn";
            this.jadNameDataGridViewTextBoxColumn.Width = 125;
            // 
            // melliCodeDataGridViewTextBoxColumn
            // 
            this.melliCodeDataGridViewTextBoxColumn.DataPropertyName = "کد ملی";
            this.melliCodeDataGridViewTextBoxColumn.HeaderText = "MelliCode";
            this.melliCodeDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.melliCodeDataGridViewTextBoxColumn.Name = "melliCodeDataGridViewTextBoxColumn";
            this.melliCodeDataGridViewTextBoxColumn.Width = 125;
            // 
            // shomarehHesabDataGridViewTextBoxColumn
            // 
            this.shomarehHesabDataGridViewTextBoxColumn.DataPropertyName = "شماره حساب";
            this.shomarehHesabDataGridViewTextBoxColumn.HeaderText = "ShomarehHesab";
            this.shomarehHesabDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.shomarehHesabDataGridViewTextBoxColumn.Name = "shomarehHesabDataGridViewTextBoxColumn";
            this.shomarehHesabDataGridViewTextBoxColumn.Width = 125;
            // 
            // shomarehKartBankiDataGridViewTextBoxColumn
            // 
            this.shomarehKartBankiDataGridViewTextBoxColumn.DataPropertyName = "ش کارت بانکی";
            this.shomarehKartBankiDataGridViewTextBoxColumn.HeaderText = "ShomarehKartBanki";
            this.shomarehKartBankiDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.shomarehKartBankiDataGridViewTextBoxColumn.Name = "shomarehKartBankiDataGridViewTextBoxColumn";
            this.shomarehKartBankiDataGridViewTextBoxColumn.Width = 125;
            // 
            // descriptionDataGridViewTextBoxColumn
            // 
            this.descriptionDataGridViewTextBoxColumn.DataPropertyName = "توضیحات";
            this.descriptionDataGridViewTextBoxColumn.HeaderText = "Description";
            this.descriptionDataGridViewTextBoxColumn.MinimumWidth = 6;
            this.descriptionDataGridViewTextBoxColumn.Name = "descriptionDataGridViewTextBoxColumn";
            this.descriptionDataGridViewTextBoxColumn.Width = 125;
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(882, 592);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.RightToLeft = System.Windows.Forms.RightToLeft.Yes;
            this.RightToLeftLayout = true;
            this.Text = "لیست اعضای موقوفه";
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.tbListDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.personBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.DataGridView dataGridView1;
        private TbListDataSet tbListDataSet;
        private System.Windows.Forms.BindingSource personBindingSource;
        private TbListDataSetTableAdapters.PersonTableAdapter personTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn fNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn lNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn mablaghDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn parentNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn jadNameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn melliCodeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shomarehHesabDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn shomarehKartBankiDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn descriptionDataGridViewTextBoxColumn;
    }
}

