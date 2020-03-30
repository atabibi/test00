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
                var dlgResult = MessageBox.Show("تغییراتی که داده اید را هنوز ذخیره نکرده اید. آیا میخواهید آنها را ذخیره کنید؟",
                                                "اخطار!",
                                                MessageBoxButtons.YesNoCancel,
                                                MessageBoxIcon.Warning);

                if (dlgResult == DialogResult.Yes)
                {
                    SaveChanges();
                }
                else if (dlgResult == DialogResult.Cancel)
                {
                    e.Cancel = true;
                }
            }
        }
    }
}
