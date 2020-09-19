using System;
using System.Collections.Generic;
using System.Text;
using model;
using SQLServerDAL;
using IDAL;

namespace BIL
{
    public class MTypeCortrol
    {
        private static IMerchandiseType mt = Factory.getMType();
        public static List<MerchandiseTypeData> ls = MTypeCortrol.getPType();

        public static List<MerchandiseTypeData> getPType()
        {
            return mt.selMerchandiseType();
        }
        /// <summary>
        /// ��������
        /// </summary>
        /// <param name="mtd"></param>
        /// <returns>�����Ӽ�¼��id</returns>
        public static int addTypeName(MerchandiseTypeData mtd)
        {
            int i = mt.insertMerchandiseType(mtd);
            mtd.ID = i;
            ls.Add(mtd);
            return i;
        }

        /// <summary>
        /// �޸�������
        /// </summary>
        /// <param name="ptd"></param>
        public static void updTypeName(MerchandiseTypeData mtd)
        {
            mt.updateMerchandiseType(mtd);
            int i;
            for (i = 0; i < ls.Count; i++)
            {
                if (mtd.ID == ls[i].ID)
                {
                    ls[i] = mtd;
                    break;
                }
            }
        }

        /// <summary>
        /// ɾ��������
        /// </summary>
        /// <param name="ptd">��ɾ������</param>
        public static void delTypeName(MerchandiseTypeData mtd)
        {
            mt.delMerchandiseType(mtd);
            int i;
            for (i = 0; i < ls.Count; i++)
            {
                if (mtd.ID == ls[i].ID)
                {
                    ls.RemoveAt(i);
                    break;
                }
            }
        }
        /// <summary>
        /// ���������Ƿ�������
        /// </summary>
        /// <param name="id">���ID</param>
        /// <returns></returns>
        public static bool checkChild(int id)
        {
            bool ok = false;
            foreach (MerchandiseTypeData mtd in ls)
                if(mtd.ParentID == id)
                {
                    ok = true;
                    break;
                }
            return ok;
        }

        /// <summary>
        /// ��������IDȡ��������
        /// </summary>
        /// <param name="id">����ID</param>
        /// <returns></returns>
        public static MerchandiseTypeData getMTypeOfID(int id)
        {
            foreach (MerchandiseTypeData mtd in ls)
                if (mtd.ID == id)
                    return mtd;
            throw new MessageException("��ȡ��Ʒ����ʧ�ܣ�����ID" + id);
        }
    }
}
