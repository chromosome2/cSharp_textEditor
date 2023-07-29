namespace TextEditor_na_sm
{
    partial class na_list
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
            this.spread1 = new unvell.ReoGrid.ReoGridControl();
            this.button1 = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // spread1
            // 
            this.spread1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
            this.spread1.ColumnHeaderContextMenuStrip = null;
            this.spread1.LeadHeaderContextMenuStrip = null;
            this.spread1.Location = new System.Drawing.Point(0, 0);
            this.spread1.Name = "spread1";
            this.spread1.RowHeaderContextMenuStrip = null;
            this.spread1.Script = null;
            this.spread1.SheetTabContextMenuStrip = null;
            this.spread1.SheetTabNewButtonVisible = true;
            this.spread1.SheetTabVisible = true;
            this.spread1.SheetTabWidth = 60;
            this.spread1.ShowScrollEndSpacing = true;
            this.spread1.Size = new System.Drawing.Size(492, 504);
            this.spread1.TabIndex = 0;
            this.spread1.Text = "reoGridControl1";
            this.spread1.DoubleClick += new System.EventHandler(this.reoGridControl1_DoubleClick);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(515, 33);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(149, 139);
            this.button1.TabIndex = 1;
            this.button1.Text = "작성";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // na_list
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(698, 524);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.spread1);
            this.Name = "na_list";
            this.Text = "na_list";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.na_list_FormClosing);
            this.Load += new System.EventHandler(this.na_list_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private unvell.ReoGrid.ReoGridControl spread1;
        private System.Windows.Forms.Button button1;
    }
}