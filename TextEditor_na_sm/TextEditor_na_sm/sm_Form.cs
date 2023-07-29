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
    public partial class sm_Form : Form
    {
        string num = "";
        public sm_Form()
        {
            InitializeComponent();
        }

        public sm_Form(string num)
        {
            InitializeComponent();
            this.num = num;
        }

        private void sm_Form_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(num))
            {
                sm_control1.CreateEditor();
            }
            else
            {
                sm_control1.CreateEditor＿bind(num);
                button1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) { MessageBox.Show("제목을 입력하세요."); return; }
            sm_control1.Save_btn(textBox1.Text);
        }
    }
}
