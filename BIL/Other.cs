using System;
using System.Collections.Generic;
using System.Text;
using System.Net.Mail;
using System.Net;

namespace BIL
{
    public class Other
    {
        /// <summary>
        /// �����ʼ�
        /// </summary>
        /// <param name="From">�������ʼ���ַ</param>
        /// <param name="to">���͵����ʼ���ַ</param>
        /// <param name="title">�ʼ�����</param>
        /// <param name="MailTxt">�ʼ�����</param>
        /// <param name="smtp">Smtp������</param>
        /// <param name="port">Smtp�������˿�</param>
        /// <param name="user">Smtp�ʼ��������ʺ�</param>
        /// <param name="pass">Smtp�ʼ�����������</param>
        public static void SendMail(string From,string to,string title,string MailTxt,string smtp,int port,string user,string pass)
        {
            MailMessage mail = new MailMessage(From, to, title, MailTxt);
            SmtpClient client = new SmtpClient(smtp, port);
            client.Credentials = new NetworkCredential(user, pass);
            client.Send(mail);

        }
    }
}
