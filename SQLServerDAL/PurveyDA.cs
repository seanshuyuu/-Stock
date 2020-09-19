using System;
using System.Collections.Generic;
using System.Text;
using model;
using IDAL;
using System.Data;
using System.Data.SqlClient;
namespace SQLServerDAL
{
    public class PurveyDA:IDAL.IPurvey
    {
        static string connStr = UserDA.connStr;
        /// <summary>
        /// ���빩Ӧ��Ʒ
        /// </summary>
        /// <param name="purvey">��Ӧ��Ʒ��</param>
        /// <returns></returns>
        public int insertPurvey(PurveyData purvey)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into Purvey values(@PInfoID,@MInfoID,@Price)", conn);
            cmd.Parameters.AddWithValue("@PInfoID",purvey.PInfoID);
            cmd.Parameters.AddWithValue("@MInfoID", purvey.MInfoID);
            cmd.Parameters.AddWithValue("@Price", purvey.Price);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select @@IDENTITY";
            int i = Convert.ToInt32(cmd.ExecuteScalar());
            conn.Close();
            return i;
        }
        /// <summary>
        /// ɾ����Ӧ��Ʒ
        /// </summary>
        /// <param name="purvey">��Ӧ��Ʒ��</param>
        /// <returns></returns>
        public int delPurvey(PurveyData purvey)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Purvey where ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", purvey.ID);
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        /// <summary>
        /// �޸Ĺ�Ӧ��Ʒ
        /// </summary>
        /// <param name="purvey">��Ӧ��Ʒ��</param>
        /// <returns></returns>
        public int updatePurvey(PurveyData purvey)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update purvey set PInfoID = @PinfoID,MInfoID = @MInfoID,Price = @Price where ID = @id", conn);
            cmd.Parameters.AddWithValue("@id", purvey.ID);
            cmd.Parameters.AddWithValue("@PInfoID", purvey.PInfoID);
            cmd.Parameters.AddWithValue("@MInfoID", purvey.MInfoID);
            cmd.Parameters.AddWithValue("@Price", purvey.Price);
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        /// <summary>
        /// ��ѯ��Ӧ��Ʒ
        /// </summary>
        /// <param name="purvey">��Ӧ��Ʒ��</param>
        /// <returns>���ع�Ӧ��Ʒ����</returns>
        public List<PurveyData> selPurvey()
        {
            List<PurveyData> list = new List<PurveyData>();
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter sda = new SqlDataAdapter("select * from purvey",conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                PurveyData pd = new PurveyData();
                pd.ID = (int)dr[0];
                pd.PInfoID = (int)dr[1];
                pd.MInfoID = (int)dr[2];
                pd.Price = Convert.ToDouble(dr[3]);
                list.Add(pd);
            }
            return list;
        }
    }
}
