using System;


namespace Model
{
    /// <summary>
    /// StockNo����ʵ��ṹ
    /// <summary>
    [Serializable]
    public class StockNoData
    {
        #region ����
        public const string FIELD_NUMBER = "number";
        #endregion

        #region ˽�б���

        private int _number;
        #endregion

        #region ��������

        /// <summary>
        /// �ֶ�numberʵ��
        /// <summary>
        public int Number
        {
            get { return this._number; }
            set { this._number = value; }
        }

        #endregion
    }
}
