using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

using System.Xml;

namespace NetClient
{
    public partial class frm_SendFileConfig : Form
    {
        public frm_SendFileConfig()
        {
            InitializeComponent();
        }

        private void Bt_FileBrowser_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                Text_FilePath.Text = openFileDialog1.FileName;
                //检查ListView中是否有重复值
                if (isExistsItem(Text_FilePath.Text) == true)
                {
                    MessageBox.Show("文件路径重复!");
                }
                else
                {
                    //想ListView中添加数据
                    ListViewItem p = new ListViewItem();
                    p = new ListViewItem(new string[] { System.IO.Path.GetFileName(Text_FilePath.Text), Text_FilePath.Text });
                    this.listView_FileList.Items.Add(p);
                    Text_FilePath.Text = "";
                }
            }
        }

        private void Bt_AddFile_Click(object sender, EventArgs e)
        {

        }


        /// <summary>
        /// 判断ListView中是否有重复路径
        /// </summary>
        /// <param name="str"></param>
        /// <returns></returns>
        private bool isExistsItem(string str)
        {
            foreach (ListViewItem item in listView_FileList.Items)
            {
                if (item.SubItems[1].Text == str)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 删除选中的文件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            if (this.listView_FileList.SelectedItems.Count != 0 )
            {
                
                    this.listView_FileList.Items[listView_FileList.SelectedIndices[0]].Remove();
                
            }
        }

        private void Bt_SaveFileList_Click(object sender, EventArgs e)
        {
            XmlDocument doc = new XmlDocument(); 
            XmlDeclaration dec = doc.CreateXmlDeclaration("1.0", "GB2312", null); doc.AppendChild(dec);  //创建一个根节点（一级）  
            XmlElement root = doc.CreateElement("FileLists");  
            doc.AppendChild(root);  //创建节点（二级）  
           // XmlNode node = doc.CreateElement("Seconde");  //创建节点（三级）  



            for (int i = 0; i < listView_FileList.Items.Count; i++)
            {
                XmlElement xmlelem = doc.CreateElement("FileInfo");
                xmlelem.SetAttribute("FileName", listView_FileList.Items[i].Text);
                xmlelem.SetAttribute("FilePath", listView_FileList.Items[i].SubItems[1].Text.ToString());
                root.AppendChild(xmlelem);
            }

            //root.AppendChild(node);  




            //保存创建好的XML文档
            doc.Save(Application.StartupPath + "\\FilePath.xml");
            doc = null;
            if(MessageBox.Show("配置文件保存成功,是否关闭配置窗口？"  , "提示" , MessageBoxButtons.YesNo , MessageBoxIcon.Question) == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void frm_SendFileConfig_Load(object sender, EventArgs e)
        {
            string XmlFilePath = Application.StartupPath + "\\FilePath.xml";

            if (System.IO.File.Exists(XmlFilePath))
            {

                //创建XML实例
                XmlDocument xmlDoc = new XmlDocument();
                //加载XML文件
                xmlDoc.Load(XmlFilePath);
                //选择一个匹配的节点
                XmlNode xn = xmlDoc.SelectSingleNode("FileLists");
                //获取这个节点的所有子节点
                XmlNodeList xnl = xn.ChildNodes;
                //循环读取所有子节点，并显示节点的信息
                foreach (XmlNode xnf in xnl)
                {
                    XmlElement xe = (XmlElement)xnf;
                    //想ListView中添加数据
                    ListViewItem p = new ListViewItem();
                    p = new ListViewItem(new string[] { xe.GetAttribute("FileName"), xe.GetAttribute("FilePath") });
                    this.listView_FileList.Items.Add(p);

                }
            }

                 
        }

        private void frm_SendFileConfig_FormClosing(object sender, FormClosingEventArgs e)
        {
            //if (MessageBox.Show("是否关闭？", "提示", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            //{
            //    e.Cancel = false;
            //    //return DialogResult.Yes;
            //}
            //else
            //{
            //    e.Cancel = true;
            //}
        }


    }
}
