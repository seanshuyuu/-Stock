using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BIL;
using model;
using System.Drawing.Printing;

//��/��/��/��/��/��
namespace WinUI
{
    public partial class frmManage : Form
    {
        public frmManage()
        {
            InitializeComponent();
        }

        private void frmManage_Load(object sender, EventArgs e)
        {
            addPType();
            this.treeView1.ExpandAll();
        }

        private void addPType()
        {
            TreeNode tn = null;
            foreach(TreeNode t in this.treeView1.Nodes[0].Nodes)
            {
                if (t.Tag!=null && t.Tag.ToString() .Equals ("��˾����"))
                {
                    tn = t;
                    break;
                }
            }
            if (tn != null)
            {
                foreach (PurveyTypeData ptd in PTypeCortrol.ls)
                {
                    TreeNode tt = new TreeNode();
                    tt.Text = ptd.TypeName;
                    tt.Tag = ptd;
                    foreach (PurveyInfoData pid in PInfoCortrol.ls)
                    {
                        TreeNode ts = new TreeNode();
                        if (pid.PTypeID == ptd.ID)
                        {
                            ts.Text = pid.Name;
                            ts.Tag = pid;
                            tt.Nodes.Add(ts);
                        }
                    }
                    tn.Nodes.Add(tt);
                }
            }
        }
        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            TreeNode n = e.Node;
            if (n.Tag == null)
                return;

            DateTime dt = DateTime.Now;
            int week = Convert.ToInt32(dt.DayOfWeek);
            int day = dt.Day;
            DateTime one = dt;
            DateTime two = dt;

            if (n.Tag is string)
            {
                #region �ַ����ڵ�
                switch (n.Tag.ToString())
                {
                    case "����δ����":
                        addLVs(SotckCortrol.getStocks(0));
                        break;
                    case "����δ����":
                        addLVs(SotckCortrol.getStocks(dt, 0));
                        break;
                    case "����δ����":
                        addLVs(SotckCortrol.getStocks(dt.AddDays(-1), 0));
                        break;
                    case "����δ����":
                        if (week > 0)
                        {
                            one = one.AddDays(1 - week);
                            two = two.AddDays(7 - week);
                        }
                        else if (week == 0)
                        {
                            one = one.AddDays(-6);
                        }
                        addLVs(SotckCortrol.getStocks(one, two, 0));
                        break;
                    case "����δ����":
                        one = one.AddDays(1 - day);
                        two = two.AddDays(DateTime.DaysInMonth(two.Year, two.Month) - day);
                        addLVs(SotckCortrol.getStocks(one, two, 0));
                        break;
                    case "����������":
                        addLVs(SotckCortrol.getStocks(1));
                        break;
                    case "����������":
                        addLVs(SotckCortrol.getStocks(dt, 1));
                        break;
                    case "����������":
                        addLVs(SotckCortrol.getStocks(dt.AddDays(-1), 1));
                        break;
                    case "����������":
                        if (week > 0)
                        {
                            one = one.AddDays(1 - week);
                            two = two.AddDays(7 - week);
                        }
                        else if (week == 0)
                        {
                            one = one.AddDays(-6);
                        }
                        addLVs(SotckCortrol.getStocks(one, two, 1));
                        break;
                    case "����������":
                        one = one.AddDays(1 - day);
                        two = two.AddDays(DateTime.DaysInMonth(two.Year, two.Month) - day);
                        addLVs(SotckCortrol.getStocks(one, two, 1));
                        break;
                    case "���϶���":
                        addLVs(SotckCortrol.getStocks(2));
                        break;
                }
                #endregion
            }
            else if(n.Tag is PurveyInfoData)
            {
                #region ��˾�ڵ�
                addLVs(SotckCortrol.getStocks((PurveyInfoData)n.Tag));
                #endregion
            }
           
        }
        /// <summary>
        /// �ڶ�����Ϣ������һ��δ�����Ķ���
        /// </summary>
        /// <param name="ls"></param>
        private void addLVs(List<StockData> ls)
        {
            this.lvS.Items.Clear();
            this.lvSInfo.Items.Clear();
            foreach (StockData sd in ls)
            {
                ListViewItem lvi = new ListViewItem(sd.StockNo);
                lvi.Tag = sd;
                lvi.SubItems.Add(PInfoCortrol.getPInfoOfID(sd.PInfoID).Name);
                if (sd.Down == false && sd.Blank == false)
                {
                    lvi.SubItems.Add("δ����");
                    lvi.SubItems.Add(sd.StockDate.ToString("d"));
                    lvi.SubItems.Add(UserCortrol.getUser(sd.UserID).Name);
                    lvi.ImageIndex = 3;
                }
                else if (sd.Down == true)
                {
                    lvi.SubItems.Add("������");
                    lvi.SubItems.Add(sd.DownDate.ToString("d"));
                    lvi.SubItems.Add(UserCortrol.getUser(sd.UserID).Name);
                    lvi.SubItems.Add(UserCortrol.getUser(sd.DownUserID).Name);
                    lvi.ImageIndex = 0;
                }
                else if (sd.Blank == true)
                {
                    lvi.SubItems.Add("������");
                    lvi.SubItems.Add(sd.BlankDate.ToString("d"));
                    lvi.SubItems.Add(UserCortrol.getUser(sd.UserID).Name);
                    lvi.SubItems.Add(UserCortrol.getUser(sd.BlankUserID).Name);
                    lvi.ImageIndex = 1;
                }
                this.lvS.Items.Add(lvi);
            }
        }

        
        private void lvS_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (this.lvS.SelectedItems.Count == 0)
                return;
            ListViewItem lvi = this.lvS.SelectedItems[0];
            StockData sd = (StockData)lvi.Tag;
            List<StockInfoData> ls = SotckCortrol.getStockInfo(sd);
            this.lvSInfo.Items.Clear();
            double sum = 0;
            foreach(StockInfoData sid in ls)
            {
                addSInfo(sid);
                sum += sid.Quantity * sid.Price;
            }
            lvi = new ListViewItem("");
            lvi.SubItems.Add("");
            lvi.SubItems.Add("  �ܶ�");
            lvi.SubItems.Add(sum.ToString());
            this.lvSInfo.Items.Add(lvi);
        }
        /// <summary>
        /// ˢ�¶�����Ϣ
        /// </summary>
        /// <param name="sd">������Ϣ</param>
        private void addSInfo(StockInfoData sid)
        {

            ListViewItem lvi = new ListViewItem(MInfoCortrol.getMInfoOfID(sid.MID).Name);
            lvi.Tag = sid;
            lvi.SubItems.Add(sid.Quantity.ToString());
            lvi.SubItems.Add(sid.Price.ToString());
            lvi.SubItems.Add(Convert.ToString(sid.Quantity * sid.Price));
            this.lvSInfo.Items.Add(lvi);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem lvi in this.lvS.SelectedItems)
                {
                    StockData sd = (StockData)lvi.Tag;
                    if (sd.Blank == true || sd.Down == true)//�Ѿ����ϻ��������Ķ�������������
                        continue;
                    sd.Down = true;
                    sd.DownDate = Convert.ToDateTime(DateTime.Now.ToString("d"));
                    sd.DownUserID = Set.User.ID;
                    SotckCortrol.downStock(sd);
                    setLVs(sd, lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// �ڶ�����Ϣ������һ��δ�����Ķ���
        /// </summary>
        /// <param name="ls"></param>
        private void setLVs(StockData sd, ListViewItem lv)
        {
            ListViewItem lvi = new ListViewItem(sd.StockNo);
            lvi.Tag = sd;
            lvi.SubItems.Add(PInfoCortrol.getPInfoOfID(sd.PInfoID).Name);
            if (sd.Down == false && sd.Blank == false)
            {
                lvi.SubItems.Add("δ����");
                lvi.SubItems.Add(sd.StockDate.ToString("d"));
                lvi.SubItems.Add(UserCortrol.getUser(sd.UserID).Name);
                lvi.ImageIndex = 3;
            }
            else if (sd.Down == true)
            {
                lvi.SubItems.Add("������");
                lvi.SubItems.Add(sd.DownDate.ToString("d"));
                lvi.SubItems.Add(UserCortrol.getUser(sd.UserID).Name);
                lvi.SubItems.Add(UserCortrol.getUser(sd.DownUserID).Name);
                lvi.ImageIndex = 0;
            }
            else if (sd.Blank == true)
            {
                lvi.SubItems.Add("������");
                lvi.SubItems.Add(sd.BlankDate.ToString("d"));
                lvi.SubItems.Add(UserCortrol.getUser(sd.UserID).Name);
                lvi.SubItems.Add(UserCortrol.getUser(sd.BlankUserID).Name);
                lvi.ImageIndex = 1;
            }
            this.lvS.Items[this.lvS.Items.IndexOf(lv)] = lvi;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                foreach (ListViewItem lvi in this.lvS.SelectedItems)
                {
                    StockData sd = (StockData)lvi.Tag;
                    if (sd.Blank == true || sd.Down == true)//�Ѿ����ϻ��������Ķ�������������
                        continue;
                    sd.Blank = true;
                    sd.BlankDate = Convert.ToDateTime(DateTime.Now.ToString("d"));
                    sd.BlankUserID = Set.User.ID;
                    SotckCortrol.blankStock(sd);
                    setLVs(sd, lvi);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button5_Click(object sender, EventArgs e)
        {
            this.printDialog1.ShowDialog();
            this.printDocument1.PrinterSettings = this.printDialog1.PrinterSettings;
        }

        private void button4_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lvS.SelectedItems.Count == 0)
                    throw new MessageException("��ѡ��Ҫ��ӡ����Ŀ��");
                StockData sd = (StockData)this.lvS.SelectedItems[0].Tag;
                if (sd.Down == false || sd.Blank == true)
                    throw new MessageException("ֻ�ܴ�ӡ�������Ķ�����");
                //����A5ֽ���������ӡ
                foreach (PaperSize ps in this.printDocument1.PrinterSettings.PaperSizes)
                {
                    if (ps.PaperName.Equals("A5"))
                        this.printDocument1.DefaultPageSettings.PaperSize = ps;
                }
                this.printDocument1.DefaultPageSettings.Landscape = true;
                printPreviewDialog1.AutoSize = true;
                printPreviewDialog1.ShowDialog();
            }
            catch (MessageException ex)
            {
                MessageBox.Show(ex.Message);
            }
            catch (InvalidOperationException)
            {
                printPreviewDialog1.Close();
            }
            catch (InvalidPrinterException)
            {
                printPreviewDialog1.Close();
                MessageBox.Show("û�д�ӡ����");
            }
        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            List<StockInfoData> ls = new List<StockInfoData>();
            foreach(ListViewItem lvi in this.lvSInfo.Items)
            {
                if (lvi.Tag is StockInfoData)
                    ls.Add((StockInfoData)lvi.Tag);
            }
            ps(e.Graphics, Set.set.ChaoName, (StockData)this.lvS.SelectedItems[0].Tag, ls);
        }
        private static void ps(Graphics g,string name,StockData sd,List<StockInfoData> ls) 
        {

            Pen pen = new Pen(Brushes.Black);
            Font f = new Font("����", 11);
            Font fu = new Font("����", 11, FontStyle.Underline);
            g.DrawString(name+"�ɹ���", new Font("����", 25), Brushes.Black, new PointF(280, 60));

            g.DrawString("�����ţ�", f, Brushes.Black, new PointF(70, 110));
            g.DrawString(sd.StockNo, fu, Brushes.Black, new PointF(125, 110));

            g.DrawString("��Ӧ�̣�", f, Brushes.Black, new PointF(70, 140));
            g.DrawString(PInfoCortrol.getPInfoOfID(sd.PInfoID).Name, fu, Brushes.Black, new PointF(125, 140));

            g.DrawString("�µ����ڣ�", f, Brushes.Black, new PointF(590, 140));
            g.DrawString(sd.DownDate.ToString("d"), fu, Brushes.Black, new PointF(660, 140));

            g.DrawString("������ϸ��", f, Brushes.Black, new PointF(70, 190));

            int x = 150;
            int y = 190;
            int i = 1;
            for (i = 1; i < 14; i++)
            {
                g.DrawLine(pen, new Point(x, y + i * 25), new Point(x + 540, y + i * 25));
            }
            i--;
            g.DrawLine(pen, new Point(x, y + 25), new Point(x, y + i * 25));
            g.DrawLine(pen, new Point(x + 200, y + 25), new Point(x + 200, y + i * 25));
            i--;
            g.DrawLine(pen, new Point(x + 300, y + 25), new Point(x + 300, y + i * 25));
            g.DrawLine(pen, new Point(x + 400, y + 25), new Point(x + 400, y + i * 25));
            i++;
            g.DrawLine(pen, new Point(x + 540, y + 25), new Point(x + 540, y + i * 25));

            g.DrawString("��Ʒ����", f, Brushes.Black, new PointF(x + 70, y + 30));
            g.DrawString("����", f, Brushes.Black, new PointF(x + 232, y + 30));
            g.DrawString("����", f, Brushes.Black, new PointF(x + 335, y + 30));
            g.DrawString("�ܶ�", f, Brushes.Black, new PointF(x + 450, y + 30));
            g.DrawString("��    ��", f, Brushes.Black, new PointF(x + 70, y + 306));

            g.DrawString("�ɹ�Ա��", f, Brushes.Black, new PointF(350, 530));
            g.DrawString("��  �ˣ�", f, Brushes.Black, new PointF(510, 530));
              
            y = 245;
            i = 1;

            foreach (StockInfoData sid in ls)
            {
                g.DrawString(MInfoCortrol.getMInfoOfID(sid.MID).Name, f, Brushes.Black, new PointF(170, y));
                g.DrawString(sid.Quantity.ToString(), f, Brushes.Black, new PointF(375, y));
                g.DrawString(sid.Price.ToString(),f, Brushes.Black, new PointF(485, y));
                g.DrawString(Convert.ToString(sid.Quantity * sid.Price) + " Ԫ", f, Brushes.Black, new PointF(595, y));
                y += 25;
                i++;
                if (i > 10)
                    break;
            }

           
        }

        private static int strWidth(Font f,string str)
        {
            return ((int)f.GetHeight() * str.Length);
            
        }
        private void button6_Click(object sender, EventArgs e)
        {
            MessageBox.Show("δʵ�ֵĹ��ܣ�");
        }

        private void button3_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.lvS.SelectedItems.Count == 0)
                    throw new MessageException("��ѡ��Ҫ�����ʼ�����Ŀ��");
                StockData sd = (StockData)this.lvS.SelectedItems[0].Tag;
                if (sd.Down == false || sd.Blank == true)
                    throw new MessageException("ֻ�ܴ�ӡ�������Ķ�����");
                PurveyInfoData pid = PInfoCortrol.getPInfoOfID(sd.PInfoID);
                Other.SendMail(Set.set.SmtpUser, pid.Email, Set.set.ChaoName + "�ɹ���",
                    "�ʼ�����", Set.set.SmtpServer, 21, Set.set.SmtpUser, Set.set.SmtpPwd);
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


    }
}