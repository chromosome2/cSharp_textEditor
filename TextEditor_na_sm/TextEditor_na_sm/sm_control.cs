using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TextEditor_na_sm
{
    public partial class sm_control : UserControl
    {
        string num = "";
        string title = string.Empty;

        public sm_control()
        {
            InitializeComponent();
        }

        public void CreateEditor()
        {
            webBrowser1.ScriptErrorsSuppressed = true; //오류메세지 띄우기 여부

            //AppDomain.CurrentDomain.BaseDirectory = TextEditor_na_sm\TextEditor_na_sm\bin\Debug\ 
            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"sj_article\index.html"))) //파일이 존재하는지
            {
                //파일을 띄워주기
                webBrowser1.Url = new Uri(@"file:///" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"sj_article\index.html").Replace('\\', '/'));
            }
            else
            {
                MessageBox.Show("summernote 생성 오류", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateEditor＿bind(string num)
        {
            webBrowser1.ScriptErrorsSuppressed = true;

            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"sj_article\view.html"))) //파일이 존재하는지 체크
            {
                webBrowser1.Url = new Uri(@"file:///" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"sj_article\view.html").Replace('\\', '/')); //경로 가져오기
            }
            else
            {
                MessageBox.Show("summernote 생성 오류", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            this.num = num;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Bind();// 꼭 이렇게 해줘야함.
        }

        public void Bind()
        {
            C_sm c_sm = new C_sm();

            using (DataSet result = c_sm.VIEW(num))
            {
                HtmlElement textArea = webBrowser1.Document.GetElementById("content");
                if (textArea != null)
                {
                    textArea.InnerHtml = result.Tables[0].Rows[0]["cont"].ToString().Trim();
                    this.title = result.Tables[0].Rows[0]["title"].ToString().Trim();
                }
            }
        }

        public void Save_btn(string title)
        {
            C_sm c_sm = new C_sm();
            try
            {
                webBrowser1.Document.InvokeScript("fn_save");

                HtmlElement textArea = webBrowser1.Document.GetElementById("summernote");
                string content = textArea.GetAttribute("value");

                c_sm.INSERT(title, content); //db에 insert
            }
            catch (Exception e)
            {
                MessageBox.Show("error");
            }
        }
    }
}
