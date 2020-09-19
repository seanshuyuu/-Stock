using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using BIL;
using System.Runtime.InteropServices;
using System.Data.SqlClient;
using model;



namespace WinUI
{
   
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                if (this.txtName.Text.Length == 0)
                    throw new MessageException("�û�������Ϊ�գ�");
                else if (this.txtPwd.Text == "")
                    throw new MessageException("���벻��Ϊ�գ�");
                UserData u = UserCortrol.login(this.txtName.Text, this.txtPwd.Text);
                Set.User = u;
                this.DialogResult = DialogResult.Yes;
            }
            catch (SqlException)
            {
                DialogResult dr = MessageBox.Show("���ӵ�SqlServer������ʧ�ܣ�\n�Ƿ���з��������ã�", "ѯ��", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.No)
                    return;
                frmSqlSet fss = new frmSqlSet();
                fss.ShowDialog();
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

        private void frmLogin_Load(object sender, EventArgs e)
        {

            UserCortrol.setConn(Set.set.SqlServerName, Set.set.SqlUser, Set.set.SqlPwd);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

    }
}