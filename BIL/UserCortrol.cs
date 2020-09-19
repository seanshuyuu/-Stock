using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using model;
using SQLServerDAL;

namespace BIL
{

    public class UserCortrol
    {
        private static IUser user = Factory.getUser();

        public static UserData login(string name, string pwd)
        {
            UserData u = new UserData();
            u.Name = name;
            u.Pwd = pwd;
            UserData ru = new UserData();
            ru = user.logicUser(u);
            if (ru != null)
                return ru;
            else
                throw new MessageException("��½ʧ�ܣ��û������������");
        }

        public static void setConn(string server, string user, string pwd)
        {
            UserDA.connStr = @"server=" + server + ";database=stock;uid=" + user + ";pwd=" + pwd;
        }

        /// <summary>
        /// ����IDȡ����
        /// </summary>
        /// <param name="id">ID</param>
        /// <returns></returns>
        public static UserData getUser(int id)
        {
            foreach (UserData ud in user.selUser())
                if (ud.ID == id)
                    return ud;
            throw new MessageException("��ȡ�û���Ϣʧ�ܣ��û�ID" + id);
        }

        public static List<UserData> selUser()
        {
            return user.selUser();
        }

        public static void delUser(UserData us)
        {
            user.delUser(us);
        }


        public static int insertUser(UserData us)
        {
            int i = user.insertUser(us);
            return i;
        }

        public static int updateUser(UserData ud)
        {
            return user.updateUser(ud);
        }

        public static UserData getUserByName(string name)
        {
            foreach (UserData ud in user.selUser())
                if (ud.Name == name)
                    return ud;
            throw new MessageException("��ȡ�û���Ϣʧ�ܣ��û�ID" + name);
        }


    }
}
