using System;
using System.Collections.Generic;
using System.Text;
using System.Xml.Serialization;
using System.IO;
using model;


namespace BIL
{
    public class Set
    {
        public static string path = "";
        public static UserData User = null;
        public static Set set = new Set();


        // Ȩ��
        public const int Admin = 0;
        public const int Super = 1;
        public const int Ordinarily = 2;

        //���ݿ�����
        public const int Access = 0;
        public const int SqlServer = 1;


        public string ChaoName = "";
        public int interval = 10;//ÿ���೤ʱ��ˢ�¿��Ԥ��
        public string SmtpServer = "";
        public string SmtpUser = "";
        public string SmtpPwd = "";
        /// <summary>
        /// ���ݿ����� 
        /// </summary>
        public int DBType = 1;
        public string SqlServerName = "";
        public string SqlUser = "";
        public string SqlPwd = "";

        /// <summary>
        /// ��ȡ����
        /// </summary>
        public static void XmlDeserialize()
        {

            if (!File.Exists(Set.path))
                return;
            using (FileStream fs = new FileStream(Set.path, FileMode.Open))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Set));
                //�����л�
                set = (Set)xs.Deserialize(fs);
            }
        }

        /// <summary>
        /// д������
        /// </summary>
        public static void XmlSerializer()
        {
            using (FileStream fs = new FileStream(Set.path, FileMode.Create))
            {
                XmlSerializer xs = new XmlSerializer(typeof(Set));
                //���л�
                xs.Serialize(fs, set);
            }
        }

    }
}
