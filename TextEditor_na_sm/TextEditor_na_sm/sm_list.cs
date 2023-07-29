using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor_na_sm
{
    public partial class sm_list : Form
    {
        public sm_list()
        {
            InitializeComponent();
        }

        public void ShowList()
        {
            try
            {
                C_sm c_sj = new C_sm();
                DataSet ds = c_sj.VIEW("");

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

            sm_Form FrmVal = new sm_Form(num);

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

        private void button1_Click(object sender, EventArgs e)
        {
            sm_Form FrmVal = new sm_Form();

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

        private void sn_list_Load(object sender, EventArgs e)
        {
            spread1.CurrentWorksheet.SetRows(10);
            spread1.CurrentWorksheet.SetCols(2);
            spread1.CurrentWorksheet.ColumnHeaders[0].Text = "번호";
            spread1.CurrentWorksheet.ColumnHeaders[1].Text = "글 제목";

            ShowList();
        }
    }
}
