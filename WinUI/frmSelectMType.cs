using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using model;
using BIL;

namespace WinUI
{
    public partial class frmSelectMType : Form
    {
        public frmSelectMType()
        {
            InitializeComponent();
        }

        private void frmSelectMType_Load(object sender, EventArgs e)
        {

        }

        void tvMType_DoubleClick(object sender, EventArgs e)
        {

        }
        bool ok = false;
        /// <summary>
        /// ��ʾ����ѡ�񴰿ڣ����ѡ����׳�MessageException�쳣
        /// </summary>
        /// <returns>������Ʒ������</returns>
        public Object ShowSelect()
        {
            this.ShowDialog();
            if (ok == false)
                throw new MessageException("");
            MerchandiseTypeData mtd = new MerchandiseTypeData();
            mtd.ID = Convert.ToInt32(this.mTypeTreeView.tvMType.SelectedNode.Tag);
            mtd.Name = this.mTypeTreeView.tvMType.SelectedNode.Text;
            mtd.ParentID = Convert.ToInt32(this.mTypeTreeView.tvMType.SelectedNode.Parent.Tag);
            return mtd;

        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            if (Convert.ToInt32(this.mTypeTreeView.tvMType.SelectedNode.Tag) == 1)
                MessageBox.Show("����ѡ�������Ŀ��");
            else
            {
                ok = true;
                this.Close();
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ok = false;
            this.Close();
        }
    }
}