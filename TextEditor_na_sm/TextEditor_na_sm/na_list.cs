using System;
using System.Data;
using System.Windows.Forms;
using Oracle.ManagedDataAccess.Client;

namespace TextEditor_na_sm
{
    public partial class na_list : Form
    {
        OracleConnection conn;

        public na_list()
        {
            InitializeComponent();

            try
            {
                //ORACLE 연결
                string constr = "Data Source = (DESCRIPTION =(ADDRESS = (PROTOCOL = TCP)(HOST = 192.168.86.231)(PORT = 1521))(CONNECT_DATA =(SERVER = DEDICATED)(SERVICE_NAME = XE)));" +
                    "User Id = c##testArticle;" +
                    "Password = 1234 ;";

                conn = new OracleConnection(constr);
                conn.Open();
            }
            catch (Exception e)
            {
                MessageBox.Show("ORACLE 데이터베이스 연결 실패입니다.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void na_list_Load(object sender, EventArgs e)
        {
            spread1.CurrentWorksheet.SetRows(10);
            spread1.CurrentWorksheet.SetCols(2);
            spread1.CurrentWorksheet.ColumnHeaders[0].Text = "번호";
            spread1.CurrentWorksheet.ColumnHeaders[1].Text = "글 제목";

            ShowList();
        }

        public void ShowList()
        {
            try
            {
                C_na c_na = new C_na();
                DataSet ds = c_na.VIEW("");

                if (ds.Tables[0].Rows.Count > 0)
                {
                    for (int i = 0; i < ds.Tables[0].Rows.Count; i++)
                    {
                        spread1.CurrentWorksheet[i, 0] = ds.Tables[0].Rows[i]["ARTICLENUM"];
                        spread1.CurrentWorksheet[i, 1] = ds.Tables[0].Rows[i]["TITLE"];
                    }
                }

                spread1.CurrentWorksheet.AutoFitColumnWidth(1, false);
                spread1.CurrentWorksheet.AutoFitRowHeight(0, false);
                spread1.CurrentWorksheet.AutoFitRowHeight(1, false);
            }
            catch (Exception e)
            {

            }
        }

        private void reoGridControl1_DoubleClick(object sender, EventArgs e)
        {
            string num = spread1.CurrentWorksheet.GetCell(spread1.CurrentWorksheet.SelectionRange.Row, 0).Data.ToString();

            na_Form FrmVal = new na_Form(num);

            foreach (Form frm in Application.OpenForms) //열려있다면 다시 오픈하지말고 열려있는 창 load하는 문
            {
                if (frm.Name == FrmVal.Name)
                {
                    if (frm.WindowState == FormWindowState.Minimized) frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                    return;
                }
            }

            FrmVal.Text = "게시글 보기";
            FrmVal.MdiParent = this.MdiParent;
            FrmVal.Show();
            FrmVal.Activate();
        }

        private void na_list_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (conn != null)
            {
                conn.Dispose();
                conn.Close();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            na_Form FrmVal = new na_Form();

            foreach (Form frm in Application.OpenForms) //열려있다면 다시 오픈하지말고 열려있는 창 load하는 문
            {
                if (frm.Name == FrmVal.Name)
                {
                    if (frm.WindowState == FormWindowState.Minimized) frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                    return;
                }
            }

            FrmVal.Text = "게시글 작성";
            FrmVal.MdiParent = this.MdiParent;
            FrmVal.Show();
            FrmVal.Activate();
        }
    }
}
