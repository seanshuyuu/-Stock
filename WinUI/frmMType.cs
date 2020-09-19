using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BIL;
using model;
using System.Data.SqlClient;

namespace WinUI
{
    public partial class frmMType : Form
    {
        public frmMType()
        {
            InitializeComponent();
        }

        private void btnAccession_Click(object sender, EventArgs e)
        {

            try
            {

                if (this.mTypeTreeView1.tvMType.SelectedNode == null)
                    throw new MessageException("��ѡ����Ŀ��");
                frmInput ipt = new frmInput("��������Ʒ���ͣ�");
                string str = ipt.ShowInput();
                MerchandiseTypeData mtd = new MerchandiseTypeData();
                mtd.Name = str;
                mtd.ParentID = Convert.ToInt32(this.mTypeTreeView1.tvMType.SelectedNode.Tag);
                int i = MTypeCortrol.addTypeName(mtd);
                TreeNode tn = new TreeNode(str);
                tn.Tag = i;
                this.mTypeTreeView1.tvMType.SelectedNode.Nodes.Add(tn);

            }

            catch (MessageException ex)
            {
                if (ex.Message != "")
                    MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmMType_Load(object sender, EventArgs e)
        {
           
        }

        private void tvMType_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
           // 
        }

        private void btnAmend_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode tn = this.mTypeTreeView1.tvMType.SelectedNode;
                if (tn == null)
                    throw new MessageException("��ѡ��Ҫ�޸ĵ���Ŀ��");
                else if (Convert.ToInt32(tn.Tag) == 1)
                    throw new MessageException("����Ŀ�����޸ģ�");
                frmInput ipt = new frmInput("����������������",tn.Text);
                string str = ipt.ShowInput();
                MerchandiseTypeData mtd = new MerchandiseTypeData();
                mtd.ID=Convert.ToInt32(tn.Tag);
                mtd.Name=str;
                mtd.ParentID=Convert.ToInt32(tn.Parent.Tag);
                MTypeCortrol.updTypeName(mtd);
                
                tn.Text = str;
            }
            catch (MessageException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                TreeNode tn = this.mTypeTreeView1.tvMType.SelectedNode;
                if (tn == null)
                    throw new MessageException("��ѡ��Ҫɾ������Ŀ��");
                else if (Convert.ToInt32(tn.Tag) == 1)
                    throw new MessageException("����Ŀ����ɾ����");
                else if (MTypeCortrol.checkChild(Convert.ToInt32(tn.Tag)))
                    throw new MessageException("����Ŀ��������Ŀ����ɾ����");
                MerchandiseTypeData mtd = new MerchandiseTypeData();
                mtd.ID = Convert.ToInt32(tn.Tag);
                mtd.Name = tn.Text;
                mtd.ParentID = Convert.ToInt32(tn.Parent.Tag);
                MTypeCortrol.delTypeName(mtd);
                this.mTypeTreeView1.tvMType.Nodes.Remove(tn);
            }
            catch (SqlException)
            {
                MessageBox.Show("���������ڱ�ʹ�ã�����ɾ����");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void tvMType_DragDrop(object sender, DragEventArgs e)
        {

        }
    }
}