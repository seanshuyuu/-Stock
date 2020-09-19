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
    public partial class frmRepertory : Form
    {
        public frmRepertory()
        {
            InitializeComponent();
        }

        private void frmRepertory_Load(object sender, EventArgs e)
        {
            this.mTypeTreeView.tvMType.AfterSelect += new TreeViewEventHandler(tvMType_AfterSelect);
            refurbish();
            this.timer1.Interval = Set.set.interval * 1000;
            this.timer1.Start();
        }
        void tvMType_AfterSelect(object sender, TreeViewEventArgs e)
        {
            int id = (int)e.Node.Tag;
            if (id == 1)
                return;
            this.lvMInfo.Items.Clear();
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
                lvi.SubItems.Add(mid.Storage.ToString());
                this.lvMInfo.Items.Add(lvi);
            }
            catch (MessageException ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ��ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (this.lvMInfo.SelectedItems.Count == 0)
                return;
            ListViewItem lvi = this.lvMInfo.SelectedItems[0];
            try
            {
                frmInput fi = new frmInput("��������������",lvi.SubItems[1].Text);
                string str = fi.ShowInput();
                int i = Convert.ToInt32(str);
                MerchandiseInfoData mid = (MerchandiseInfoData)lvi.Tag;
                mid.Storage = i;
                MInfoCortrol.updMInfo(mid);
                lvi.SubItems[1].Text = i.ToString();
            }
            catch (MessageException ex)
            {
                if (ex.Message != "")
                    MessageBox.Show(ex.Message);
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            refurbish();
        }

        public void refurbish()
        {
            this.lvHint.Items.Clear();
            foreach (PurveyData pd in PurveyCortrol.ls)
            {
                MerchandiseInfoData mid =MInfoCortrol.getMInfoOfID( pd.MInfoID);
                PurveyInfoData pid = PInfoCortrol.getPInfoOfID(pd.PInfoID);
                if (mid.Quantity * pid.Days > mid.Storage)
                {
                    ListViewItem lvi = new ListViewItem(mid.Name);
                    lvi.Tag = pd;
                    lvi.SubItems.Add(mid.Storage.ToString());
                    lvi.SubItems.Add(mid.Quantity.ToString());
                    lvi.SubItems.Add(pid.Name);
                    lvi.SubItems.Add(pid.Days.ToString());
                    int i =- ((mid.Storage - (mid.Quantity * pid.Days)) / mid.Quantity);
                    lvi.SubItems.Add(i.ToString());
                    this.lvHint.Items.Add(lvi);
                }
            }
        }

        private void lvHint_DoubleClick(object sender, EventArgs e)
        {
            if (this.lvHint.SelectedItems.Count == 0)
                return;
            ListViewItem lvi = this.lvHint.SelectedItems[0];
            PurveyData pd = (PurveyData)lvi.Tag;
            MerchandiseInfoData mid = MInfoCortrol.getMInfoOfID(pd.MInfoID);
            foreach(TreeNode tn in this.mTypeTreeView.tvMType.Nodes)
                selectNotes(tn,mid.TypeID);
            foreach (ListViewItem lv in this.lvMInfo.Items)
                if (lv.Tag == mid)
                    lv.Selected = true;
        }
        /// <summary>
        /// �ݹ�������ο�ѡ����Ʒ����
        /// </summary>
        /// <param name="tn">Ҫ�����Ľڵ�</param>
        /// <param name="MTypeId">��Ʒ����ID</param>
        private void selectNotes(TreeNode tn, int MTypeId)
        {
            foreach (TreeNode t in tn.Nodes)
            {
                int id = (int)t.Tag;
                if (id != MTypeId)
                    selectNotes(t, MTypeId);
                else
                {
                    this.mTypeTreeView.tvMType.SelectedNode = t;
                    return;
                }
            }
        }
    }
}