using System;


namespace model
{
    /// <summary>
    /// Depot����ʵ��ṹ
    /// <summary>
    [Serializable]
    public class DepotData
    {
        #region ����
        public const string FIELD_ID = "iD";
        public const string FIELD_MINFOID = "mInfoID";
        public const string FIELD_QUANTITY = "quantity";
        public const string FIELD_HINT = "hint";
        #endregion

        #region ˽�б���

        private int _iD;
        private int _mInfoID;
        private int _quantity;
        private int _hint;
        #endregion

        #region ��������

        /// <summary>
        /// �ֶ�iDʵ��
        /// <summary>
        public int ID
        {
            get { return this._iD; }
            set { this._iD = value; }
        }

        /// <summary>
        /// �ֶ�mInfoIDʵ��
        /// <summary>
        public int MInfoID
        {
            get { return this._mInfoID; }
            set { this._mInfoID = value; }
        }

        /// <summary>
        /// �ֶ�quantityʵ��
        /// <summary>
        public int Quantity
        {
            get { return this._quantity; }
            set { this._quantity = value; }
        }

        /// <summary>
        /// �ֶ�hintʵ��
        /// <summary>
        public int Hint
        {
            get { return this._hint; }
            set { this._hint = value; }
        }

        #endregion
    }
}
