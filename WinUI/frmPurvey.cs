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
    public partial class frmPurvey : Form
    {
        public frmPurvey()
        {
            InitializeComponent();
        }



        private void addPInfo_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lvMInfo.SelectedItems.Count == 0)
                    return;

                frmSelectPInfo fspi = new frmSelectPInfo();
                PurveyInfoData pid = (PurveyInfoData)fspi.ShowSelect();
                foreach (ListViewItem lvi in this.lvPurvey.Items)
                {
                    if ((PurveyInfoData)lvi.Tag == pid)
                    {
                        lvi.Selected = true;
                        return;
                    }
                }
                frmInput fi = new frmInput("�����빩Ӧ�۸�");
                string str = fi.ShowInput();
                double price = Convert.ToDouble(str);
                PurveyData pd = new PurveyData();
                pd.PInfoID = pid.ID;
                pd.MInfoID = ((MerchandiseInfoData)this.lvMInfo.SelectedItems[0].Tag).ID;
                pd.Price = price;
                int i = PurveyCortrol.addPurevey(pd);
                pd.ID = i;
                addPurevey(pid, pd);
            }
            catch (MessageException ex)
            {
                if (ex.Message != "")
                    MessageBox.Show(ex.Message);
            }
        }

        private void frmPurvey_Load(object sender, EventArgs e)
        {
            this.mTypeTreeView1.tvMType.AfterSelect += new TreeViewEventHandler(tvMType_AfterSelect);
        }

        void tvMType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int id = (int)e.Node.Tag;
            if (id == 1)
                return;
            this.lvMInfo.Items.Clear();
            this.lvPurvey.Items.Clear();
            foreach (MerchandiseInfoData mid in MInfoCortrol.ls)
                if (mid.TypeID == id)
                    addMInfo(mid);
        }

        /// <summary>
        /// ��PListView�����һ����¼
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="id">��Ӧ��¼ID�洢�ڵ�����Tag</param>
        private void addMInfo(MerchandiseInfoData mid)
        {
            try
            {
                ListViewItem lvi = new ListViewItem(mid.Name);
                lvi.Tag = mid;
                lvi.SubItems.Add(mid.Quantity.ToString());
                this.lvMInfo.Items.Add(lvi);
            }
            catch (MessageException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        

        private void delPInfo_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("��ȷ��Ҫɾ����Щѡ�е���Ŀ��", "ѯ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                foreach (ListViewItem lvi in this.lvPurvey.SelectedItems)
                {
                    PurveyData pd = (PurveyData)lvi.SubItems[1].Tag;
                    //pd.ID = ;
                    PurveyCortrol.delPurevey(pd);
                    lvi.Remove();
                }
        }

        private void lvMInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            this.lvPurvey.Items.Clear();
            if (this.lvMInfo.SelectedItems.Count == 0)
                return;
            MerchandiseInfoData mid = (MerchandiseInfoData)this.lvMInfo.SelectedItems[0].Tag;

            foreach (PurveyData pd in PurveyCortrol.ls)
            {
                if (pd.MInfoID == mid.ID)
                {
                    foreach (PurveyInfoData pid in PInfoCortrol.ls)
                    {
                        if (pid.ID == pd.PInfoID)
                        {
                            addPurevey(pid, pd);
                        }
                    }
                }
            }
        }

        /// <summary>
        /// ��PListView�����һ����¼
        /// </summary>
        /// <param name="pid"></param>
        /// <param name="id">��Ӧ��¼ID�洢�ڵ�����Tag</param>
        private void addPurevey(PurveyInfoData pid, PurveyData pd)
        {
            try
            {
                //��Ӧ����
                ListViewItem lvi = new ListViewItem(pid.Name);
                lvi.Tag = pid;
                //�����Ʒ����
                ListViewItem.ListViewSubItem lvs = new ListViewItem.ListViewSubItem();
                lvs.Text = pd.Price.ToString();
                lvs.Tag = pd;
                lvi.SubItems.Add(lvs);

                //����ͻ�����
                lvi.SubItems.Add(pid.Days.ToString());

                //��ӹ�Ӧ������
                lvs = new ListViewItem.ListViewSubItem();
                PurveyTypeData ptd = PTypeCortrol.getPTypeOfID(pid.PTypeID);
                lvs.Text = ptd.TypeName;
                lvs.Tag = ptd;
                lvi.SubItems.Add(lvs);
                
                lvi.SubItems.Add(pid.LinkMan);
                lvi.SubItems.Add(pid.Tel);
                lvi.SubItems.Add(pid.Fox);
                lvi.SubItems.Add(pid.Email);
                lvi.SubItems.Add(pid.Address);
                this.lvPurvey.Items.Add(lvi);
            }
            catch (MessageException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
    }
}