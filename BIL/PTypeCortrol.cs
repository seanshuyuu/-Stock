using System;
using System.Collections.Generic;
using System.Text;
using model;
using SQLServerDAL;
using IDAL;

namespace BIL
{
    public class PTypeCortrol
    {
        private static IPurveyType pt = Factory.getPType();
        public static List<PurveyTypeData> ls = PTypeCortrol.getPType();

        public static List<PurveyTypeData> getPType()
        {
            return pt.selPurveyType();
        }
        /// <summary>
        /// ������������������ID
        /// </summary>
        /// <param name="ptd">���ӵ���</param>
        /// <returns>��ID</returns>
        public static int addTypeName(PurveyTypeData ptd)
        {
            int i = pt.insertPurveyType(ptd);
            ptd.ID = i;
            ls.Add(ptd);
            return i;
        }

        /// <summary>
        /// �޸��������������������ϵ��±�
        /// </summary>
        /// <param name="ptd"><���ӵ���/param>
        /// <returns>�������ϵ��±�</returns>
        public static int updTypeName(PurveyTypeData ptd)
        {
            pt.updatePurveyType(ptd);
            int i;
            for (i = 0; i < ls.Count; i++)
            {
                if (ptd.ID == ls[i].ID)
                {
                    ls[i] = ptd;
                    break;
                }
            }
            return i;
        }

        /// <summary>
        /// ɾ���������������������ϵ��±�
        /// </summary>
        /// <param name="ptd"><���ӵ���/param>
        /// <returns>�������ϵ��±�</returns>
        public static int delTypeName(PurveyTypeData ptd)
        {
            pt.delPurveyType(ptd);
            int i;
            for (i = 0; i < ls.Count; i++)
            {
                if (ptd.ID == ls[i].ID)
                {
                    ls.RemoveAt(i);
                    break;
                }
            }
            return i;
        }
        /// <summary>
        /// ��������IDȡ��������
        /// </summary>
        /// <param name="id">����ID</param>
        /// <returns></returns>
        public static PurveyTypeData getPTypeOfID(int id)
        {
            foreach (PurveyTypeData ptd in ls)
                if (ptd.ID == id)
                    return ptd;
            throw new MessageException("��ȡ�ͻ�����ʧ�ܣ�����ID"+id);
        }
    }
}
