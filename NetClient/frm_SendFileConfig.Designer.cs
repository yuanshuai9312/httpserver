namespace NetClient
{
    partial class frm_SendFileConfig
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_SendFileConfig));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.Bt_FileBrowser = new System.Windows.Forms.Button();
            this.Text_FilePath = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.adf = new System.Windows.Forms.GroupBox();
            this.listView_FileList = new System.Windows.Forms.ListView();
            this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.columnHeader2 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.contextMenuStrip1 = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.Bt_SaveFileList = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            this.adf.SuspendLayout();
            this.contextMenuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.Bt_FileBrowser);
            this.groupBox1.Controls.Add(this.Text_FilePath);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(612, 57);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "选择文件";
            // 
            // Bt_FileBrowser
            // 
            this.Bt_FileBrowser.Location = new System.Drawing.Point(527, 18);
            this.Bt_FileBrowser.Name = "Bt_FileBrowser";
            this.Bt_FileBrowser.Size = new System.Drawing.Size(75, 23);
            this.Bt_FileBrowser.TabIndex = 2;
            this.Bt_FileBrowser.Text = "浏览";
            this.Bt_FileBrowser.UseVisualStyleBackColor = true;
            this.Bt_FileBrowser.Click += new System.EventHandler(this.Bt_FileBrowser_Click);
            // 
            // Text_FilePath
            // 
            this.Text_FilePath.Location = new System.Drawing.Point(82, 20);
            this.Text_FilePath.Name = "Text_FilePath";
            this.Text_FilePath.Size = new System.Drawing.Size(439, 21);
            this.Text_FilePath.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(11, 23);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 0;
            this.label1.Text = "选择文件：";
            // 
            // adf
            // 
            this.adf.Controls.Add(this.listView_FileList);
            this.adf.Location = new System.Drawing.Point(13, 79);
            this.adf.Name = "adf";
            this.adf.Size = new System.Drawing.Size(611, 252);
            this.adf.TabIndex = 1;
            this.adf.TabStop = false;
            this.adf.Text = "文件列表";
            // 
            // listView_FileList
            // 
            this.listView_FileList.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1,
            this.columnHeader2});
            this.listView_FileList.ContextMenuStrip = this.contextMenuStrip1;
            this.listView_FileList.FullRowSelect = true;
            this.listView_FileList.GridLines = true;
            this.listView_FileList.Location = new System.Drawing.Point(10, 19);
            this.listView_FileList.MultiSelect = false;
            this.listView_FileList.Name = "listView_FileList";
            this.listView_FileList.Size = new System.Drawing.Size(591, 225);
            this.listView_FileList.TabIndex = 0;
            this.listView_FileList.UseCompatibleStateImageBehavior = false;
            this.listView_FileList.View = System.Windows.Forms.View.Details;
            // 
            // columnHeader1
            // 
            this.columnHeader1.Text = "文件名";
            this.columnHeader1.Width = 109;
            // 
            // columnHeader2
            // 
            this.columnHeader2.Text = "文件路径";
            this.columnHeader2.Width = 476;
            // 
            // contextMenuStrip1
            // 
            this.contextMenuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripMenuItem1});
            this.contextMenuStrip1.Name = "contextMenuStrip1";
            this.contextMenuStrip1.Size = new System.Drawing.Size(119, 26);
            this.contextMenuStrip1.Text = "删除文件";
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(152, 22);
            this.toolStripMenuItem1.Text = "删除文件";
            this.toolStripMenuItem1.Click += new System.EventHandler(this.toolStripMenuItem1_Click);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            // 
            // Bt_SaveFileList
            // 
            this.Bt_SaveFileList.Location = new System.Drawing.Point(490, 348);
            this.Bt_SaveFileList.Name = "Bt_SaveFileList";
            this.Bt_SaveFileList.Size = new System.Drawing.Size(124, 23);
            this.Bt_SaveFileList.TabIndex = 2;
            this.Bt_SaveFileList.Text = "保存文件列表";
            this.Bt_SaveFileList.UseVisualStyleBackColor = true;
            this.Bt_SaveFileList.Click += new System.EventHandler(this.Bt_SaveFileList_Click);
            // 
            // frm_SendFileConfig
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(636, 383);
            this.Controls.Add(this.Bt_SaveFileList);
            this.Controls.Add(this.adf);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "frm_SendFileConfig";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "定时文件设置";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frm_SendFileConfig_FormClosing);
            this.Load += new System.EventHandler(this.frm_SendFileConfig_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.adf.ResumeLayout(false);
            this.contextMenuStrip1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button Bt_FileBrowser;
        private System.Windows.Forms.TextBox Text_FilePath;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.GroupBox adf;
        private System.Windows.Forms.ListView listView_FileList;
        private System.Windows.Forms.ColumnHeader columnHeader1;
        private System.Windows.Forms.ColumnHeader columnHeader2;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button Bt_SaveFileList;
        private System.Windows.Forms.ContextMenuStrip contextMenuStrip1;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem1;
    }
}