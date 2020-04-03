using CsvHelper;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.IO;
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
            dataGridView1.RowsDefaultCellStyle.BackColor = Color.FromArgb(128, 128, 192);
            dataGridView1.RowsDefaultCellStyle.ForeColor = Color.White;

            dataGridView1.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(211, 211, 233);
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
                bindingNavigatorAddNewItem.Enabled = true;
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
                if (err.Message.Contains("FName") || err.Message.Contains("LName"))
                {
                    MessageBox.Show("نام و نام خانوادگی نباید خالی باشند" + ":  " + $"سطر {personBindingSource.Position+1}", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    return;
                }

                MessageBox.Show("خطا در ذخیره سازی تغییرات: سطر شماره " + (personBindingSource.Position+1) + " : "  + err.Message,
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
                //if (e.RowIndex == 0)
                //    return;
                //if (e.ColumnIndex !=  -1)
                //    MessageBox.Show($"خطا در ستون {dataGridView1.Columns[e.ColumnIndex].HeaderText} : { e.Exception.Message}" );
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
            string fileName = null;
            using (var dlg = new OpenFileDialog()
            {
                Filter = "*.csv|*.csv"
            })
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    fileName = dlg.FileName;
                }
            }

            if (fileName != null)
            {
                LoadFromCSVFile(fileName);
            }
        }

        private void LoadFromCSVFile(string fileName)
        {
            // MessageBox.Show($"Save as {fileName}");

            using (var reader = new StreamReader(fileName))
            using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
            {
                // Do any configuration to `CsvReader` before creating CsvDataReader.
                using (var dr = new CsvDataReader(csv))
                {
                    var dt = new DataTable();
                    dt.Load(dr);

                    DeletePrevData();
                    ImportToPersonTable(dt);
                }
            }
        }

        private void DeletePrevData()
        {
            progressBar1.Maximum = tbDbDataSet.Person.Rows.Count;
            progressBar1.Value = 0;
            foreach (DataRow r in tbDbDataSet.Person.Rows)
            {
                r.Delete();
                progressBar1.Value++;
            }

            personTableAdapter.Update(tbDbDataSet.Person);
            progressBar1.Value = 0;
        }

        private void ImportToPersonTable(DataTable dt)
        {

            for (int k = 0; k < dt.Rows.Count; k++)
            {
                var r = dt.Rows[k];

                /*
                 ستون 0: ردیف که نمی خوانیم
                 ستون 1: نام  نام خانوادگی
                 ستون 2: جنسیت: یک مذکر و صفر مونث
                 ستون 3: مبلغ که نمی خوانیم
                 ستون 4: کد ملی
                 ستون 5: پدر یا مادر
                 ستون 6: جد یا جده
                 ستون 7: شماره حساب
                 ستون 8: شماره کارت
                 ستون 9: توضیحات
                 */

                var fullName = r[1].ToString().Trim();
                string fname = "نامشخص";
                string lname = "نامشخص";
                if (fullName.Length > 0)
                {
                    var fl = fullName.Split(' ');
                    if (fl.Length == 1)
                        fname = fl[0];
                    else if (fl.Length == 2)
                    {
                        fname = fl[0];
                        lname = fl[1];
                    }
                    else if (fl.Length > 2)
                    {
                        fname = fl[0];
                        lname = string.Join(" ", fl.Skip(1));
                    }
                };

                var parentName = r[5].ToString().Trim();
                var jadName = r[6].ToString().Trim();
                var melliCode = r[4].ToString().Trim();
                var shomareHesab = r[7].ToString().Trim();
                var shomareCard = r[8].ToString().Trim();
                var desc = r[9].ToString().Trim();

                if (shomareHesab.Length > 50)
                {
                    // یعنی احتمالا توضیحات را امیر بجای شماره حساب نوشته
                    desc += shomareHesab;
                    shomareHesab = "";
                }

                if (shomareCard.Length > 50)
                {
                    desc += shomareCard;
                    shomareCard = "";
                }

                bool gender = r[2].ToString().Trim() == "1";
                personTableAdapter.Insert(
                        fname,
                        lname,
                        parentName, // پدر یا مادر
                        jadName, // جد یا جده
                        melliCode.Length > 10 ? melliCode.Substring(0, 10) : melliCode, // کد ملی
                        shomareHesab, // ش حساب
                        shomareCard, // ش کارت
                        desc, // توضیحات
                        gender
                    );

            }


            FillData();
        }


        private void ReportToJson(string fileName, decimal mablaghForMale)
        {
            List<PersonForExcel> people = new List<PersonForExcel>(500);
            try
            {
                int n = 0;
                foreach (TbDbDataSet.PersonRow p in tbDbDataSet.Person.Rows)
                {
                    n++;
                    people.Add(new PersonForExcel
                    {
                        CodeMelli = p.IsMelliCodeNull() ? "-" :  p.MelliCode.Trim(),
                        Desc = p.IsDescNull() ? "-" : p.Desc.Trim(),
                        FullName =  $"{p.FName} {p.LName}",
                        Gender =  p.Gender ? "مذکر" : "مونث",
                        Id = n,
                        Jad = p.IsJadNameNull() ? "-" : p.JadName,
                        Mablagh =  p.Gender ? mablaghForMale : mablaghForMale / 2,
                        Parent = p.IsParentNameNull() ? "-" : p.ParentName,
                        ShomareCard = p.IsShomareCardNull() ? "-" : p.ShomareCard,
                        ShomareHesab = p.IsShomareHesabNull() ? "-" : p.ShomareHesab
                    }); 
                }

                var json = JsonConvert.SerializeObject(people, Formatting.Indented);

                using (var stream = new StreamWriter(fileName, false))
                {
                    stream.Write(json);
                    stream.Close();
                }

                MessageBox.Show($"{fileName} با موفقیت ذخیره شد");
            }
            catch (Exception err)
            {
                MessageBox.Show($"خطا در ذخیره فایل : {err.Message}");
            }

        }


        private void BtnReport_Clicked(object sender, EventArgs e)
        {
            string fileName = "";
            using (SaveFileDialog dlg = new SaveFileDialog()
            {
                DefaultExt = "csv",
                Filter = "*.csv|*.csv",
                AddExtension = true,
                Title = "نام و محل ذخیره فایل را مشخص کنید"
            })
            {
                if (dlg.ShowDialog() != DialogResult.OK)
                {
                    return;
                }
                fileName = dlg.FileName;
            }

            string strMablaghForMale = "";
            if (TbDialogs.InputBox("میزان سهم", "مقدار سهم هر مرد را وارد کنید:", ref strMablaghForMale) != DialogResult.OK)
            {
                return;
            }

            decimal mablaghForMale = 0;
            if (decimal.TryParse(strMablaghForMale, out mablaghForMale) == false)
            {
                MessageBox.Show("مقدار وارد شده یک عدد معتبر نیست");
                return;
            }

            ReportToJson(fileName, mablaghForMale);
        }

        //private void btnExportToCSV_Click(object sender, EventArgs e)
        //{
        //    string fileName = "";
        //    using (SaveFileDialog dlg = new SaveFileDialog()
        //    {
        //        DefaultExt = "csv",
        //        Filter = "*.csv|*.csv",
        //        AddExtension = true,
        //        Title = "نام و محل ذخیره فایل را مشخص کنید"
        //    })
        //    {
        //        if (dlg.ShowDialog() != DialogResult.OK)
        //        {
        //            return;
        //        }
        //        fileName = dlg.FileName;
        //    }

        //    string strMablaghForMale = "";
        //    if (TbDialogs.InputBox("میزان سهم", "مقدار سهم هر مرد را وارد کنید:", ref strMablaghForMale) != DialogResult.OK)
        //    {
        //        return;
        //    }

        //    decimal mablaghForMale = 0;
        //    if (decimal.TryParse(strMablaghForMale, out mablaghForMale) == false)
        //    {
        //        MessageBox.Show("مقدار وارد شده یک عدد معتبر نیست");
        //        return;
        //    }

        //    List<PersonForExcel> people = new List<PersonForExcel>(500);
        //    try
        //    {
        //        int n = 0;
        //        foreach (TbDbDataSet.PersonRow p in tbDbDataSet.Person.Rows)
        //        {
        //            n++;
        //            people.Add(new PersonForExcel
        //            {
        //                CodeMelli = p.MelliCode.Trim(),
        //                Desc = p.Desc.Trim(),
        //                FullName = $"{p.FName} {p.LName}",
        //                Gender = p.Gender ? "مذکر" : "مونث",
        //                Id = n,
        //                Jad = p.JadName,
        //                Mablagh = p.Gender ? mablaghForMale : mablaghForMale / 2,
        //                Parent = p.ParentName,
        //                ShomareCard = p.ShomareCard,
        //                ShomareHesab = p.ShomareHesab
        //            });
        //        }

        //        SaveCSVFile(people, fileName);
        //    }
        //    catch (Exception err)
        //    {
        //        MessageBox.Show($"خطا در ذخیره فایل : {err.Message}");
        //    }

        //    MessageBox.Show($"{fileName} با موفقیت ذخیره شد");

        //}

        //private void SaveCSVFile(List<PersonForExcel> people, string fileName)
        //{


        //    using (var writer = new StreamWriter(fileName, false, Encoding.UTF8))
        //    using (var csv = new CsvWriter(writer, CultureInfo.InvariantCulture))
        //    {
        //        csv.WriteRecords(people);
        //    }

        //}

        //private void BackupDB()
        //{
        //    try
        //    {
        //        SaveFileDialog sd = new SaveFileDialog();
        //        sd.Filter = "SQL Server database backup files|*.bak";
        //        sd.Title = "Create Database Backup";

        //        if (sd.ShowDialog() == DialogResult.OK)
        //        {
        //            using (SqlConnection conn = new SqlConnection(ConfigurationManager.ConnectionStrings["TbPeopleList.Properties.Settings.TbDbConnectionString"].ConnectionString))
        //            {
        //                string sqlStmt = string.Format("backup database [" + System.Windows.Forms.Application.StartupPath + "\\TbDb.mdf] to disk='{0}'", sd.FileName);
        //                using (SqlCommand bu2 = new SqlCommand(sqlStmt, conn))
        //                {
        //                    conn.Open();
        //                    bu2.ExecuteNonQuery();
        //                    conn.Close();

        //                    MessageBox.Show("Backup Created Sucessfully");
        //                }
        //            }
        //        }
        //    }
        //    catch (Exception)
        //    {
        //        MessageBox.Show("Backup Not Created");
        //    }
        //}

        private void RestoreDbFromJsonFile(string fileName)
        {
            string jsonText = "";
            using (StreamReader streamReader = new StreamReader(fileName))
            {
                jsonText = streamReader.ReadToEnd();
            }

            var people = JsonConvert.DeserializeObject<List<PersonForJson>>(jsonText);

            DeletePrevData();

            progressBar1.Maximum = people.Count;
            progressBar1.Value = 0;
            foreach (var p in people)
            {
                personTableAdapter.Insert(
                        FName: p.FName,
                        LName: p.LName,
                        ParentName: p.ParentName,
                        JadName: p.JadName,
                        MelliCode: p.MelliCode,
                        ShomareHesab: p.ShomareHesab,
                        ShomareCard: p.ShomareCard,
                        Desc: p.Desc,
                        Gender: p.Gender
                    );
                progressBar1.Value++;
            }
            
            FillData();
            progressBar1.Value = 0;
        }

        private void BackUpDbAsJsonFile(string fileName)
        {
            List<PersonForJson> people = new List<PersonForJson>(500);

            progressBar1.Maximum = tbDbDataSet.Person.Rows.Count;
            progressBar1.Value = 0;
            foreach (TbDbDataSet.PersonRow p in tbDbDataSet.Person.Rows)
            {
                people.Add(
                    new PersonForJson
                    {
                        Desc = p.Desc.Trim(),
                        FName = p.FName.Trim(),
                        LName = p.LName.Trim(),
                        Gender = p.Gender,
                        JadName = p.JadName.Trim(),
                        MelliCode = p.MelliCode.Trim(),
                        ParentName = p.ParentName.Trim(),
                        ShomareCard = p.ShomareCard.Trim(),
                        ShomareHesab = p.ShomareHesab.Trim()
                    }
                   );
                progressBar1.Value++;
            }

            var json = JsonConvert.SerializeObject(people,Formatting.Indented);
            // Console.WriteLine(json);

            using (var stream = new StreamWriter(fileName, false))
            {
                stream.Write(json);
                stream.Close();
            }
        }


        private void BtnBackupDB_Click(object sender, EventArgs e)
        {
            try
            {
                using (var saveDlg = new SaveFileDialog())
                {
                    saveDlg.Filter = "*.json|*.json";
                    saveDlg.Title = "نام فایل پشتیبان را وارد کنید";
                    saveDlg.DefaultExt = "*.json";
                    saveDlg.AddExtension = true;

                    if (saveDlg.ShowDialog() == DialogResult.OK)
                    {
                        BackUpDbAsJsonFile(saveDlg.FileName);
                        MessageBox.Show("فایل پشتیبان با موفقیت ذخیره شد");
                    }
                }

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            progressBar1.Value = 0;
        }


        private void BtnResoreDB_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("با اینکار همه ی اطلاعات موجود در بانک اطلاعاتی حذف خواهد شد. آیا می خواهید ادامه دهید؟", "اخطار", MessageBoxButtons.OKCancel, MessageBoxIcon.Warning) == DialogResult.Cancel)
            {
                return;
            }

            try
            {
                using (var openDlg = new OpenFileDialog()
                    {
                        DefaultExt = "*.json",
                        Filter = "*.json|*.json",
                        Title = "فایل پشتیبان را انتخاب کنید"
                    }
                )
                {
                    if (openDlg.ShowDialog() == DialogResult.OK)
                    {
                        RestoreDbFromJsonFile(openDlg.FileName);
                        MessageBox.Show("اطلاعات با موفقیت بازیابی شد");
                    }
                }
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }

            // RestoreBackupDB();
            //FoundDbs();
        }

        private void bindingNavigatorAddNewItem_Click(object sender, EventArgs e)
        {
            
        }

        private void personBindingSource_AddingNew(object sender, AddingNewEventArgs e)
        {
           
        }

        private void personBindingSource_PositionChanged(object sender, EventArgs e)
        {
            
           // bindingNavigatorAddNewItem.Enabled = true;
        }
    }
}
