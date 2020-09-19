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
    public partial class frmAdd : Form
    {
        public frmAdd()
        {
            InitializeComponent();
        }

        

        private void frmAdd_Load(object sender, EventArgs e)
        {
            try
            {
                string year = DateTime.Now.Year.ToString();
                this.txtNo.Text = year.Substring(2, 2) + toLen(DateTime.Now.Month, 2) + toLen(DateTime.Now.Day, 2) + toLen(StockNoCortrol.No + 1, 4);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private string toLen(int i,int len)
        {
            string no = i.ToString();
            while(no.Length != len)
            {
                    no = "0"+no;
            }
            return no;
        }

        private void btnPInfoID_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lvSInfo.Items.Count > 0)
                    throw new MessageException("�Ѿ��������Ʒ�����������Ʒ������ð�ť��");
                frmSelectPInfo fspi = new frmSelectPInfo();
                PurveyInfoData pid = (PurveyInfoData)fspi.ShowSelect();
                this.txtPInfo.Text = pid.Name;
                this.txtPInfo.Tag = pid;
            }
            catch (MessageException ex)
            {
                if (ex.Message != "")
                    MessageBox.Show(ex.Message);
            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                ListViewItem lvi =this.lvSInfo.SelectedItems[0];
                if(lvi==null)
                    throw new MessageException("��ѡ��Ҫ�޸ĵ���Ŀ��");
                frmSelectSInfo fss = new frmSelectSInfo();

                StockInfoData sid = fss.showSelect((PurveyInfoData)this.txtPInfo.Tag, 
                    (MerchandiseInfoData)lvi.Tag,lvi.SubItems[1].Text,lvi.SubItems[2].Text);
                addStoctInfo( sid,2);
            }
            catch (MessageException ex)
            {
                if (ex.Message != "")
                    MessageBox.Show(ex.Message);
            }
        }

        
        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtPInfo.Tag == null)
                    throw new MessageException("����ѡ��Ӧ�̣�");
                frmSelectSInfo fss = new frmSelectSInfo();
                StockInfoData sid = fss.showSelect((PurveyInfoData)this.txtPInfo.Tag);
                addStoctInfo(sid,1);
            }
            catch (MessageException ex)
            {
                if(ex.Message!="")
                    MessageBox.Show(ex.Message);
            }
        }
        /// <summary>
        /// ���ӻ��޸�һ����Ʒ��Ϣ
        /// </summary>
        /// <param name="sid">��Ʒ</param>
        /// <param name="cortrol">1���ӣ�2�޸�</param>
        private void addStoctInfo(StockInfoData sid,int cortrol)
        {
            MerchandiseInfoData mid = ((MerchandiseInfoData)MInfoCortrol.getMInfoOfID(sid.MID));
            ListViewItem lvi = new ListViewItem(mid.Name);
            lvi.Tag = mid;
            lvi.SubItems.Add(sid.Quantity.ToString());
            lvi.SubItems.Add(sid.Price.ToString());
            lvi.SubItems.Add(Convert.ToString(sid.Quantity * (double)sid.Price));
            if(cortrol==1)
            this.lvSInfo.Items.Add(lvi);
            else if(cortrol == 2)

            this.lvSInfo.Items[this.lvSInfo.SelectedIndices[0]] = lvi;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (this.lvSInfo.SelectedItems.Count == 0)
                return;
            this.lvSInfo.Items.Remove(this.lvSInfo.SelectedItems[0]);
        }

        private void button4_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("��ȷ��Ҫ��ն�����Ʒ��Ϣ��","ѯ��",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if (dr == DialogResult.Yes)
                this.lvSInfo.Items.Clear();
        }

        private void btnNo_Click(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("��ȷ��Ҫ��յ�ǰ�ɹ�����","ѯ��",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
            if(dr==DialogResult.Yes)
                clear();
        }

        private void clear()
        {
            try
            {
                string year = DateTime.Now.Year.ToString();
                this.txtNo.Text = year.Substring(2, 2) + toLen(DateTime.Now.Month, 2) + toLen(DateTime.Now.Day, 2) + toLen(StockNoCortrol.No + 1, 4);
                this.txtPInfo.Text = "";
                this.txtPInfo.Tag = "";
                this.lvSInfo.Items.Clear();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnYes_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lvSInfo.Items.Count == 0)
                    throw new MessageException("�ö���û����Ʒ��Ϣ��");
                StockData sd = new StockData();
                sd.PInfoID = ((PurveyInfoData)this.txtPInfo.Tag).ID;
                sd.StockDate = Convert.ToDateTime(this.dtp.Value.ToString("d"));
                sd.StockNo = this.txtNo.Text;
                sd.UserID = Set.User.ID;
                List<StockInfoData> ls = new List<StockInfoData>();
                foreach(ListViewItem lvi in this.lvSInfo.Items)
                {
                    StockInfoData sid = new StockInfoData();
                    sid.MID=((MerchandiseInfoData)lvi.Tag).ID;
                    sid.Quantity=Convert.ToInt32(lvi.SubItems[1].Text);
                    sid.Price = Convert.ToDouble(lvi.SubItems[2].Text);
                    ls.Add(sid);
                }
                SotckCortrol.addStock(sd, ls);
                StockNoCortrol.No += 1;
                DialogResult dr = MessageBox.Show("���������ɣ����ڵȴ���ˣ�\n�Ƿ������Ӷ�����","ѯ��",MessageBoxButtons.YesNo,MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                    clear();
                else
                    this.Close();
            }
            catch (MessageException ex)
            {
                if (ex.Message != "")
                    MessageBox.Show(ex.Message);
            }
            catch (SqlException ex)
            {
                MessageBox.Show("�������ʧ�ܣ�\n������Ϣ\n" + ex.Message);
            }
        }
    }
}