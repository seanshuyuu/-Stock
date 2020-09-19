using System;
using System.Collections.Generic;
using System.Text;
using model;
using SQLServerDAL;
using IDAL;

namespace BIL
{
    public class MInfoCortrol
    {
        private static IMerchandiseInfo mi = Factory.getMInfo();
        public static List<MerchandiseInfoData> ls = MInfoCortrol.getPType();

        public static List<MerchandiseInfoData> getPType()
        {
            return mi.selMerchandiseType();
        }

        /// <summary>
        /// ������Ʒ,�ҷ��������Ӽ�¼��ID
        /// </summary>
        /// <param name="mid"></param>
        /// <returns>�����ӵ�ID</returns>
        public static int addMnfo(MerchandiseInfoData mid)
        {
            int i = mi.insertMerchandiseType(mid);
            mid.ID = i;
            ls.Add(mid);
            return i;
        }

        /// <summary>
        /// �޸���Ʒ��Ϣ
        /// </summary>
        /// <param name="mtd">���޸ĵ���</param>
        /// <returns>�����������ϵ�ID����ӦListView����Ŀλ��</returns>
        public static int updMInfo(MerchandiseInfoData mid)
        {
            mi.updateMerchandiseType(mid);
            int i;
            for (i = 0; i < ls.Count; i++)
            {
                if (mid.ID == ls[i].ID)
                {
                    ls[i] = mid;
                    break;
                }
            }
            return i;
        }

        /// <summary>
        /// ɾ����Ʒ��Ϣ
        /// </summary>
        /// <param name="ptd">��ɾ������</param>
        public static void delMInfo(MerchandiseInfoData mid)
        {
            mi.delMerchandiseType(mid);
            int i;
            for (i = 0; i < ls.Count; i++)
            {
                if (mid.ID == ls[i].ID)
                {
                    ls.RemoveAt(i);
                    break;
                }
            }
        }

        /// <summary>
        /// ������ƷIDȡ������
        /// </summary>
        /// <param name="id">����ID</param>
        /// <returns></returns>
        public static MerchandiseInfoData getMInfoOfID(int id)
        {
            foreach (MerchandiseInfoData mid in ls)
                if (mid.ID == id)
                    return mid;
            throw new MessageException("��ȡ��Ʒ����ʧ�ܣ���ƷID" + id);
        }
    }
}
