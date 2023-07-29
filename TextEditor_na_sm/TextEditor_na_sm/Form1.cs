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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            na_list FrmVal = new na_list();

            foreach (Form frm in Application.OpenForms) //열려있다면 다시 오픈하지말고 열려있는 창 load하는 문
            {
                if (frm.Name == FrmVal.Name)
                {
                    if (frm.WindowState == FormWindowState.Minimized) frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                    return;
                }
            }

            FrmVal.Text = "네이버게시글 리스트 보기";
            FrmVal.MdiParent = this.MdiParent;
            FrmVal.Show();
            FrmVal.Activate();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            sm_list FrmVal = new sm_list();

            foreach (Form frm in Application.OpenForms) //열려있다면 다시 오픈하지말고 열려있는 창 load하는 문
            {
                if (frm.Name == FrmVal.Name)
                {
                    if (frm.WindowState == FormWindowState.Minimized) frm.WindowState = FormWindowState.Normal;
                    frm.Activate();
                    return;
                }
            }

            FrmVal.Text = "서머노트 게시글 리스트 보기";
            FrmVal.MdiParent = this.MdiParent;
            FrmVal.Show();
            FrmVal.Activate();
        }
    }
}
