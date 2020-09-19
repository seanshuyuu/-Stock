using System;
using System.Collections.Generic;
using System.Text;
using model;
using IDAL;
using System.Data;
using System.Data.SqlClient;
//5/��/��/��/��/��
namespace SQLServerDAL
{
    public class PurveyTypeDA:IDAL.IPurveyType
    {
        static string connStr = UserDA.connStr;
        /// <summary>
        /// ���빩Ӧ������
        /// </summary>
        /// <param name="purveyType">���ع�Ӧ��������</param>
        /// <returns></returns>
        public int insertPurveyType(PurveyTypeData purveyType)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("insert into purveyType values(@TypeName)",conn);
            cmd.Parameters.AddWithValue("@TypeName",purveyType.TypeName);
            cmd.ExecuteNonQuery();
            cmd.CommandText = "select @@IDENTITY";
            int i = Convert.ToInt32( cmd.ExecuteScalar());
            conn.Close();
            return i;
        }
        /// <summary>
        /// ɾ����Ӧ������
        /// </summary>
        /// <param name="purveyType">���ع�Ӧ��������</param>
        /// <returns></returns>
        public int delPurveyType(PurveyTypeData purveyType)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from purveyType where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", purveyType.ID);
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        /// <summary>
        /// ���¹�Ӧ������
        /// </summary>
        /// <param name="purveyType">���ع�Ӧ��������</param>
        /// <returns></returns>
        public int updatePurveyType(PurveyTypeData purveyType)
        {
            SqlConnection conn = new SqlConnection(connStr);
            conn.Open();
            SqlCommand cmd = new SqlCommand("update purveyType set TypeName = @TypeName where id = @id", conn);
            cmd.Parameters.AddWithValue("@id", purveyType.ID);
            cmd.Parameters.AddWithValue("TypeName",purveyType.TypeName);
            int i = cmd.ExecuteNonQuery();
            conn.Close();
            return i;
        }
        /// <summary>
        /// ��ѯ��Ӧ������
        /// </summary>
        /// <param name="purveyType">���ع�Ӧ��������</param>
        /// <returns>���ع�Ӧ�����͵ļ���</returns>
        public List<PurveyTypeData> selPurveyType()
        {
            List<PurveyTypeData> list = new List<PurveyTypeData>();
            SqlConnection conn = new SqlConnection(connStr);
            SqlDataAdapter sda = new SqlDataAdapter("select * from purveyType",conn);
            DataSet ds = new DataSet();
            sda.Fill(ds);
            foreach (DataRow dr in ds.Tables[0].Rows)
            {
                PurveyTypeData purType = new PurveyTypeData();
                purType.ID = (int)dr[0];
                purType.TypeName = dr[1].ToString();
                list.Add(purType);
            }
            return list;
        }
    }
}
