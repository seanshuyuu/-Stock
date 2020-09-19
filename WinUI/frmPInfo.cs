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
    public partial class frmPInfo : Form
    {
        public frmPInfo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                frmSelectPType frm = new frmSelectPType();
                PurveyTypeData pd = (PurveyTypeData)frm.ShowSelect();
                this.txtGenre.Text = pd.TypeName;
                this.txtGenre.Tag = pd;
            }
            catch (MessageException ex)
            {
                if (ex.Message != "")
                    MessageBox.Show(ex.Message);
            }
        }

        private void buttobtnAccessionn2_Click(object sender, EventArgs e)
        {
            try
            {
                checkText();
                PurveyInfoData pid = getPInfo();
                PInfoCortrol.addPurveyInfo(pid);
                addPurevey(pid);
                clear();
                
            }
            catch (MessageException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// �����û��������������
        /// </summary>
        /// <returns></returns>
        private PurveyInfoData getPInfo()
        {
            PurveyInfoData pid = new PurveyInfoData();
            pid.Name = this.txtName.Text;
            pid.PTypeID = ((PurveyTypeData)this.txtGenre.Tag).ID;
            pid.LinkMan = this.txtLinkMain.Text;
            pid.Tel = this.txtTel.Text;
            pid.Fox = this.txtFox.Text;
            pid.Address = this.txtAddress.Text;
            pid.Email = this.txtMail.Text;
            pid.Days = Convert.ToInt32(this.txtDays.Text);
            return pid;
        }
        /// <summary>
        /// ����û�����
        /// </summary>
        private void checkText()
        {
            if (this.txtName.Text.Length == 0)
                throw new MessageException("�����빫˾����");
            else if (this.txtGenre.Tag == null)
                throw new MessageException("��ѡ����ҵ���ͣ�");
            else if (this.txtLinkMain.Text.Length == 0)
                throw new MessageException("��������ϵ��������");
            else if (this.txtTel.Text.Length == 0)
                throw new MessageException("��������ϵ�绰��");
            else if (this.txtMail.Text.Length == 0)
                throw new MessageException("��������ϵ�ʼ���");
            else if (this.txtDays.Text.Length == 0)
                throw new MessageException("�������ͻ���������");
        }
        /// <summary>
        /// ����û�����
        /// </summary>
        private void clear()
        {
            this.txtName.Text = "";
            this.txtGenre.Tag = null;
            this.txtGenre.Text = "";
            this.txtLinkMain.Text = "";
            this.txtTel.Text = "";
            this.txtFox.Text = "";
            this.txtAddress.Text = "";
            this.txtMail.Text = "";
            this.txtDays.Text = "";
        }
        private void frmPInfo_Load(object sender, EventArgs e)
        {
            fillListView();
        }
        /// <summary>
        /// ������ݵ�ListView
        /// </summary>
        private void fillListView()
        {
            this.lvPureves.Items.Clear();
            foreach (PurveyInfoData pid in PInfoCortrol.ls)
                addPurevey(pid);
        }
        /// <summary>
        /// ��ListView�����һ����¼
        /// </summary>
        /// <param name="pid"></param>
        private void addPurevey(PurveyInfoData pid)
        {
            try
            {
                ListViewItem lvi = new ListViewItem(pid.Name);
                lvi.Tag = pid;
                ListViewItem.ListViewSubItem lvs = new ListViewItem.ListViewSubItem();
                PurveyTypeData ptd = PTypeCortrol.getPTypeOfID(pid.PTypeID);
                lvs.Text = ptd.TypeName;
                lvs.Tag = ptd;
                lvi.SubItems.Add(lvs);
                lvi.SubItems.Add(pid.LinkMan);
                lvi.SubItems.Add(pid.Tel);
                lvi.SubItems.Add(pid.Fox);
                lvi.SubItems.Add(pid.Email);
                lvi.SubItems.Add(pid.Days.ToString());
                lvi.SubItems.Add(pid.Address);
                this.lvPureves.Items.Add(lvi);
            }
            catch (MessageException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnAmend_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lvPureves.SelectedItems.Count == 0)
                    throw new MessageException("��ѡ��Ҫ�޸ĵ���Ŀ��");
                checkText();
                PurveyInfoData pid = getPInfo();
                pid.ID = ((PurveyInfoData)this.lvPureves.SelectedItems[0].Tag).ID;
                PInfoCortrol.updPurveyInfo(pid);

                ListViewItem lvi = new ListViewItem(pid.Name);
                lvi.Tag = pid;
                ListViewItem.ListViewSubItem lvs = new ListViewItem.ListViewSubItem();
                PurveyTypeData ptd = PTypeCortrol.getPTypeOfID(pid.PTypeID);
                lvs.Text = ptd.TypeName;
                lvs.Tag = ptd;
                lvi.SubItems.Add(lvs);
                lvi.SubItems.Add(pid.LinkMan);
                lvi.SubItems.Add(pid.Tel);
                lvi.SubItems.Add(pid.Fox);
                lvi.SubItems.Add(pid.Email);
                lvi.SubItems.Add(pid.Days.ToString());
                lvi.SubItems.Add(pid.Address);

                this.lvPureves.Items[this.lvPureves.SelectedIndices[0]] = lvi;
                clear();
            }
            catch (MessageException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void lvPureves_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvPureves.SelectedItems.Count > 0)
            {
                ListViewItem lvi = this.lvPureves.SelectedItems[0];
                PurveyInfoData pid = (PurveyInfoData)lvi.Tag;
                this.txtName.Text = pid.Name;
                this.txtGenre.Tag = lvi.SubItems[1].Tag;
                this.txtGenre.Text = lvi.SubItems[1].Text;
                this.txtLinkMain.Text = pid.LinkMan;
                this.txtTel.Text = pid.Tel;
                this.txtFox.Text = pid.Fox;
                this.txtAddress.Text = pid.Address;
                this.txtMail.Text = pid.Email;
                this.txtDays.Text = pid.Days.ToString();
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            PTypeCortrol.ls = PTypeCortrol.getPType();
            fillListView();
            clear();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lvPureves.SelectedItems.Count == 0)
                    throw new MessageException("��ѡ��Ҫɾ������Ŀ��");
                DialogResult dr = MessageBox.Show("��ȷ��Ҫɾ������Ŀ��", "ѯ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr != DialogResult.No)
                {
                    PInfoCortrol.delPurveyInfo((PurveyInfoData)this.lvPureves.SelectedItems[0].Tag);
                    this.lvPureves.Items.RemoveAt(this.lvPureves.SelectedIndices[0]);
                    clear();
                }
            }
            catch (MessageException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (SqlException)
            {
                MessageBox.Show("����Ŀ���ڱ�ʹ�ã��޷�ɾ����");
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                frmInput fipt = new frmInput("����������ؼ��ֽ�������");
                string str = fipt.ShowInput();
                foreach (ListViewItem lvi in this.lvPureves.Items)
                {
                    bool ok = false;
                    foreach (ListViewItem.ListViewSubItem lvs in lvi.SubItems)
                    {
                        if (lvs.Text.IndexOf(str) != -1)
                        {
                            ok = true;
                            break; ;
                        }
                    }
                    if (ok == false)
                        this.lvPureves.Items.Remove(lvi);
                }
                clear();
            }
            catch (MessageException ex)
            {
                if (ex.Message != "")
                    MessageBox.Show(ex.Message);
            }
        }
    }
}