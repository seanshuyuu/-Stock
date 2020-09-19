using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Text;
using System.Windows.Forms;
using BIL;
using model;

namespace UIL
{
    public partial class MTypeTreeView : UserControl
    {
        public MTypeTreeView()
        {
            InitializeComponent();
        }

        private void MTypeTreeView_Load(object sender, EventArgs e)
        {
            TreeNode rn = new TreeNode("�������");
            rn.Tag = 1;
            this.tvMType.Nodes.Add(rn);
            MTypeCortrol.ls = MTypeCortrol.getPType();
            fillTreeViewOfPrenntID(rn);
            this.tvMType.ExpandAll();
        }

        /// <summary>
        /// ���ݸ���Ŀ�µ���������Ŀ
        /// </summary>
        /// <param name="preentID">����Ŀ</param>
        public void fillTreeViewOfPrenntID(TreeNode ptn)
        {
            //�Ƴ�����Ŀ�µ���������Ŀ
            ptn.Nodes.Clear();
            //���Ӹ���Ŀ��ӵ�е�����Ŀ
            foreach (MerchandiseTypeData mtd in MTypeCortrol.ls)
            {
                if (mtd.ParentID == Convert.ToInt32(ptn.Tag))
                {
                    TreeNode rn = new TreeNode(mtd.Name);
                    rn.Tag = mtd.ID;
                    ptn.Nodes.Add(rn);
                    //��������Ŀ���Ƿ�ӵ������Ŀ����������һ����ʱ��������TreeView����Ŀ������һ���Ӻ�
                    foreach (MerchandiseTypeData ctn in MTypeCortrol.ls)
                    {
                        if (ctn.ParentID == Convert.ToInt32(rn.Tag))
                        {
                            rn.Nodes.Add("��ʱ");
                            break;
                        }
                    }
                }
            }
        }

        private void tvMType_BeforeExpand(object sender, TreeViewCancelEventArgs e)
        {
            fillTreeViewOfPrenntID(e.Node);
        }

    }
}
