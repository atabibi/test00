using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TbPeopleList
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            DataGridChangeTheme();
        }

        private void DataGridChangeTheme()
        {
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(128,128,192);
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(211,211,233);
            dataGridView1.AlternatingRowsDefaultCellStyle.ForeColor = Color.Black;
            // dataGridView1.CellBorderStyle = DataGridViewCellBorderStyle.None;

            dataGridView1.DefaultCellStyle.SelectionBackColor = Color.LightYellow;
            dataGridView1.DefaultCellStyle.SelectionForeColor = Color.DarkBlue;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'tbDbDataSet.Person' table. You can move, or remove it, as needed.
           FillData();

        }

        private void FillData()
        {
            this.personTableAdapter.Fill(this.tbDbDataSet.Person);
        }

        private void btnSaveChanges_Click(object sender, EventArgs e)
        {
            SaveChanges();
        }

        private void SaveChanges()
        {
            try
            {
                _ = dataGridView1.EndEdit();
                personBindingSource.EndEdit();
                int n = personTableAdapter.Update(personBindingSource.DataSource as TbDbDataSet);
                if (n == 0)
                {
                    MessageBox.Show("هیچ تغییری برای ذخیره کردن یافت نشد.");
                }
                else
                {
                    MessageBox.Show($"{n} تغییر در بانک اطلاعاتی ایجاد شد");
                }
            }
            catch (Exception err)
            {
                MessageBox.Show("خطا در ذخیره سازی تغییرات: " + err.Message,
                                "خطا",
                                MessageBoxButtons.OK,
                                MessageBoxIcon.Error);
            }
          
        }

        private void btnCancelChanges_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("می خواهید همه تغییراتی که داه اید را لغو کنید؟", "اخطار", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.Cancel)
            {
                return;
            }

            dataGridView1.CancelEdit();
            personBindingSource.CancelEdit();
            FillData();
        }

        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            _ = dataGridView1.EndEdit();
            if (tbDbDataSet.HasChanges())
            {
                var dlgResult = MessageBox.Show("تغییراتی که داده اید را هنوز ذخیره نکرده اید. آیا میخواهید با اینحال خارج شوید؟",
                                                "اخطار!",
                                                MessageBoxButtons.YesNo,
                                                MessageBoxIcon.Warning);

                if (dlgResult == DialogResult.Yes)
                {
                    SaveChanges();
                }
                else if (dlgResult == DialogResult.No)
                {
                    e.Cancel = true;
                }
            }
        }

        private void dataGridView1_RowPostPaint(object sender, DataGridViewRowPostPaintEventArgs e)
        {
            DataGridView dg = (DataGridView)sender;
            // Current row record
            string rowNumber = (e.RowIndex + 1).ToString();

            // Format row based on number of records displayed by using leading zeros
            while (rowNumber.Length < dg.RowCount.ToString().Length) rowNumber = "0" + rowNumber;

            // Position text
            SizeF size = e.Graphics.MeasureString(rowNumber, this.Font);
            if (dg.RowHeadersWidth < (int)(size.Width + 20)) dg.RowHeadersWidth = (int)(size.Width + 20);

            // Use default system text brush
            Brush b = SystemBrushes.ControlText;

            // Draw row number
            e.Graphics.DrawString(rowNumber, dg.Font, b, e.RowBounds.Size.Width - 25, e.RowBounds.Location.Y + ((e.RowBounds.Height - size.Height) / 2));
        }

        private void dataGridView1_CellValidating(object sender, DataGridViewCellValidatingEventArgs e)
        {
            
        }

        private void dataGridView1_RowValidating(object sender, DataGridViewCellCancelEventArgs e)
        {
            
        }

        private void personBindingSource_DataError(object sender, BindingManagerDataErrorEventArgs e)
        {
            MessageBox.Show(e.Exception.Message);
        }

        private void dataGridView1_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
            if (e.Exception.GetType() == typeof(NoNullAllowedException))
            {
                MessageBox.Show($"مقدار وارد شده برای '{dataGridView1.Columns[e.ColumnIndex].HeaderText}' در سطر {e.RowIndex + 1}  نمی تواند تهی باشد.");
            }
            else
            {
                if (e.RowIndex == 0)
                    return;
                if (e.ColumnIndex !=  -1)
                    MessageBox.Show($"خطا در ستون {dataGridView1.Columns[e.ColumnIndex].HeaderText} : { e.Exception.Message}" );
            }
           
        }

        private void dataGridView1_DefaultValuesNeeded(object sender, DataGridViewRowEventArgs e)
        {
            e.Row.Cells["FName"].Value = "نامشخص";
            e.Row.Cells["LName"].Value = "نامشخص";
        }

        private void btnLoadFromCSV_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("با اینکار همه ی اطلاعات موجود در بانک اطلاعاتی حذف خواهد شد. آیا می خواهید ادامه دهید؟", "اخطار", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                return;
            }

            LoadFromCSVFile();

        }

        private void LoadFromCSVFile()
        {
            using (var dlg = new OpenFileDialog() {
                Filter = "*.csv|*.csv"
            })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    LoadFromCSVFile(dlg.FileName);
                }
            }
        }

        private void LoadFromCSVFile(string fileName)
        {
            MessageBox.Show($"Save as {fileName}");
        }
    }
}
