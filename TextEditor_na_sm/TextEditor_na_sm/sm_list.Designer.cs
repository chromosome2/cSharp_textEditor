namespace TextEditor_na_sm
{
    partial class sm_list
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.spread1 = new unvell.ReoGrid.ReoGridControl();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(527, 57);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 139);
            this.button1.TabIndex = 3;
            this.button1.Text = "작성";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // spread1
            // 
            this.spread1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spread1.ColumnHeaderContextMenuStrip = null;
            this.spread1.LeadHeaderContextMenuStrip = null;
            this.spread1.Location = new System.Drawing.Point(12, 24);
            this.spread1.Name = "spread1";
            this.spread1.RowHeaderContextMenuStrip = null;
            this.spread1.Script = null;
            this.spread1.SheetTabContextMenuStrip = null;
            this.spread1.SheetTabNewButtonVisible = true;
            this.spread1.SheetTabVisible = true;
            this.spread1.SheetTabWidth = 60;
            this.spread1.ShowScrollEndSpacing = true;
            this.spread1.Size = new System.Drawing.Size(492, 504);
            this.spread1.TabIndex = 2;
            this.spread1.Text = "reoGridControl1";
            this.spread1.DoubleClick += new System.EventHandler(this.reoGridControl1_DoubleClick);
            // 
            // sn_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 569);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.spread1);
            this.Name = "sn_list";
            this.Text = "sn_list";
            this.Load += new System.EventHandler(this.sn_list_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private unvell.ReoGrid.ReoGridControl spread1;
    }
}