using System;
using System.Data;
using System.IO;
using System.Windows.Forms;

namespace TextEditor_na_sm
{
    public partial class na_control : UserControl
    {
        string num = ""; //게시글 VIEW시 받아올 게시글 NUMBER

        public na_control()
        {
            InitializeComponent();
        }

        public void CreateEditor() //게시글 Write
        {
            webBrowser1.ScriptErrorsSuppressed = true; //오류메세지 띄우기 여부

            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"sj_smartEditor\index.html"))) //파일이 존재하는지
            {
                //파일을 띄워주기
                webBrowser1.Url = new Uri(@"file:///" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"sj_smartEditor\index.html").Replace('\\', '/'));
            }
            else
            {
                MessageBox.Show("smartEditor 생성 오류", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void CreateEditor＿bind(string num)// 게시글 view
        {
            webBrowser1.ScriptErrorsSuppressed = true;

            if (File.Exists(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"sj_smartEditor\view.html"))) //파일이 존재하는지 체크
            {
                webBrowser1.Url = new Uri(@"file:///" + Path.Combine(AppDomain.CurrentDomain.BaseDirectory, @"sj_smartEditor\view.html").Replace('\\', '/')); //경로 가져오기
            }
            else
            {
                MessageBox.Show("smartEditor 생성 오류", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
            this.num = num;
        }

        private void webBrowser1_DocumentCompleted(object sender, WebBrowserDocumentCompletedEventArgs e)
        {
            Bind();// 꼭 이렇게 해줘야함.
        }

        public void Bind()
        {
            C_na na = new C_na();

            using (DataSet result = na.VIEW(num))
            {
                HtmlElement textArea = webBrowser1.Document.GetElementById("content");
                if (textArea != null)
                {
                    textArea.InnerHtml = result.Tables[0].Rows[0]["cont"].ToString().Trim();
                }
            }
        }

        public void Save_btn(string title)
        {
            C_na na = new C_na();
            try
            {
                webBrowser1.Document.InvokeScript("fn_save");

                HtmlElement textArea = webBrowser1.Document.GetElementById("txtContent"); //htmlElemet가져오기. //id를 통해서 가져옴.
                string content = textArea.GetAttribute("value"); //value속성 값 가져오기.

                na.INSERT(title, content); //db에 insert
            }
            catch (Exception e)
            {
                MessageBox.Show("error");
            }
        }


    }
}
