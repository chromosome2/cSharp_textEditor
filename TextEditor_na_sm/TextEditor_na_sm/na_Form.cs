using System;
using System.Windows.Forms;

namespace TextEditor_na_sm
{
    public partial class na_Form : Form
    {
        string num = "";
        public na_Form()
        {
            InitializeComponent();
        }

        public na_Form(string num)
        {
            InitializeComponent();
            this.num = num;
        }

        private void na_WriteForm_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(num))
            {
                na_control1.CreateEditor();
            }
            else
            {
                na_control1.CreateEditor＿bind(num);
                button1.Visible = false;
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(textBox1.Text)) { MessageBox.Show("제목을 입력하세요."); return; }
            na_control1.Save_btn(textBox1.Text);
        }

    }
}