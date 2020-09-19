using System;
using System.Collections.Generic;
using System.Text;
using model;
using SQLServerDAL;
using IDAL;

namespace BIL
{
    public class PInfoCortrol
    {

        private static IPurveyInfo pi = Factory.getPInfo();
        public static List<PurveyInfoData> ls = getPurveyInfoData();
        public static List<PurveyInfoData> getPurveyInfoData()
        {
           return pi.selPurvey();
        }
        /// <summary>
        /// ���ӹ�Ӧ��,�ҷ��������Ӽ�¼��ID
        /// </summary>
        /// <param name="pid"></param>
        /// <returns>�����ӵ�ID</returns>
        public static int addPurveyInfo(PurveyInfoData pid)
        {
            int i = pi.insertPurvey(pid);
            pid.ID=i;
            ls.Add(pid);
            return i;
        }
        
        /// <summary>
        /// �޸Ĺ�Ӧ����Ϣ
        /// </summary>
        /// <param name="mtd">���޸ĵ���</param>
        /// <returns>�����������ϵ�ID����ӦListView����Ŀλ��</returns>
        public static int updPurveyInfo(PurveyInfoData pid)
        {
            pi.updatePurvey(pid);
            int i;
            for (i = 0; i < ls.Count; i++)
            {
                if (pid.ID == ls[i].ID)
                {
                    ls[i] = pid;
                    break;
                }
            }
            return i;
        }

        /// <summary>
        /// ɾ����Ӧ����Ϣ
        /// </summary>
        /// <param name="ptd">��ɾ������</param>
        public static void delPurveyInfo(PurveyInfoData pid)
        {
            pi.delPurvey(pid);
            int i;
            for (i = 0; i < ls.Count; i++)
            {
                if (pid.ID == ls[i].ID)
                {
                    ls.RemoveAt(i);
                    break;
                }
            }
        }

        /// <summary>
        /// ��������IDȡ����
        /// </summary>
        /// <param name="id">����ID</param>
        /// <returns></returns>
        public static PurveyInfoData getPInfoOfID(int id)
        {
            foreach (PurveyInfoData pdd in ls)
                if (pdd.ID == id)
                    return pdd;
            throw new MessageException("��ȡ�ͻ���Ϣʧ�ܣ��ͻ�ID" + id);
        }
    }
}
