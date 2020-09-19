using System;
using System.Collections.Generic;
using System.Text;
using IDAL;
using SQLServerDAL;
using model;

namespace BIL
{
    public class SotckCortrol
    {
        private static IStock st = Factory.getStock();
        private static IStockInfo si = Factory.getSInfo();
        public static List<StockData> getStocks()
        {
            return st.selStock();
        }

        /// <summary>
        /// ��ȡ����ͷ
        /// </summary>
        /// <param name="dt">����</param>
        /// <param name="state">����״̬ 0 δ���� 1 ���� 2 ����</param>
        /// <returns></returns>
        public static List<StockData> getStocks(DateTime dt,int state)
        {
            string str=string.Empty;
            if (state == 0)
                str = "Down = 0 and StockDate = '" + dt.ToString("d") + "' and Blank = 0";
            else if (state == 1)
                str = "Down = 1 and DownDate = '" + dt.ToString("d") + "' and Blank = 0";
            else if (state == 2)
                str = "Blank = 1";
            return st.selStock(str);
        }
        /// <summary>
        /// ��ȡ����ͷ
        /// </summary>
        /// <param name="dt">��ʼ����</param>
        /// <param name="dt1">��������</param>
        /// <param name="state">����״̬ 0 δ���� 1 ���� 2 ����</param>
        /// <returns></returns>
        public static List<StockData> getStocks(DateTime dt, DateTime dt1, int state)
        {
            string str = string.Empty;
            if (state == 0)
                str = "Down = 0 and StockDate between '" + dt.ToString("d") + "' and '" + dt1.ToString("d") + "' and Blank = 0";
            else if (state == 1)
                str = "Down = 1 and DownDate between '" + dt.ToString("d") + "' and '" + dt1.ToString("d") + "' and Blank = 0";
            else if (state == 2)
                str = "Blank = 1";
            return st.selStock(str);
        }
        /// <summary>
        /// ��ȡ���ж���ͷ
        /// </summary>
        /// <param name="state">����״̬ 0 δ���� 1 ���� 2 ����</param>
        /// <returns></returns>
        public static List<StockData> getStocks( int state)
        {
            string str = string.Empty;
            if (state == 0)
                str = "Down = 0 and Blank = 0";
            else if (state == 1)
                str = "Down = 1 and Blank = 0";
            else if (state == 2)
                str = "Blank = 1";
            return st.selStock(str);
        }

        /// <summary>
        /// ���ݹ�Ӧ�̻�ȡ����ͷ
        /// </summary>
        /// <param name="state">����״̬ 0 δ���� 1 ���� 2 ����</param>
        /// <returns></returns>
        public static List<StockData> getStocks(PurveyInfoData pid)
        {
            string str = string.Empty;
            str="PInfoID = " + pid.ID.ToString();
            return st.selStock(str);
        }

        /// <summary>
        /// ���Ӷ���
        /// </summary>
        /// <param name="sd">����ͷ</param>
        /// <param name="sidLS">������Ϣ</param>
        public static void addStock(StockData sd, List<StockInfoData> sidLS)
        {
            st.insertStock(sd, sidLS);
        }
        /// <summary>
        /// �����ɹ���
        /// </summary>
        /// <param name="sd">����ͷ</param>
        public static void downStock(StockData sd)
        {
            st.downStock( sd);
        }

        /// <summary>
        /// ���ϲɹ���
        /// </summary>
        /// <param name="sd">����ͷ</param>
        public static void blankStock(StockData sd)
        {
            st.BlankStock(sd);
        }
        public static List<StockInfoData> getStockInfo(StockData sd)
        {
            return si.selStockInfo(sd);
        }
    }
}
