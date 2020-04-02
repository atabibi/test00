using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TbPeopleList
{
    public partial class MainForm : Form
    {
        FrmMain _main;
        public MainForm()
        {
            InitializeComponent();
            _main = new FrmMain();
        }

        private void BtnGoToProgram_Click(object sender, EventArgs e)
        {
            _main.Show();
        }

        private void RestoreBackupDB()
        {
            try
            {

                OpenFileDialog openDlg = new OpenFileDialog();
                openDlg.Filter = "فایل پشتیبان|*.bak";
                openDlg.Title = "بازیابی فایل پشتبان";

                if (openDlg.ShowDialog() == DialogResult.OK)
                {


                    string connStr = ConfigurationManager.ConnectionStrings["TbPeopleList.Properties.Settings.TbDbConnectionString"].ConnectionString;
                    using (SqlConnection conn = new SqlConnection(connStr))
                    {
                        conn.Open();


                        //using (SqlCommand detachDB_Comm = new SqlCommand())
                        //{
                        //    detachDB_Comm.Connection = conn;

                        //    detachDB_Comm.CommandText = "sys.sp_detach_db [" + System.Windows.Forms.Application.StartupPath + "\\TbDb.mdf]";
                        //    detachDB_Comm.ExecuteNonQuery();
                        //}



                        using (SqlCommand restoredb_executioncomm = new SqlCommand())
                        {
                            restoredb_executioncomm.Connection = conn;
                            restoredb_executioncomm.CommandText = $"RESTORE DATABASE TbDb FROM DISK='{openDlg.FileName}' WITH REPLACE";

                            restoredb_executioncomm.ExecuteNonQuery();
                        }
                        conn.Close();
                    }
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void BtnDbRestore_Click(object sender, EventArgs e)
        {
            RestoreBackupDB();
        }
    }
}
