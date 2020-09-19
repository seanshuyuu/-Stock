using System;


namespace model
{
    /// <summary>
    /// Stock����ʵ��ṹ
    /// <summary>
    [Serializable]
    public class StockData
    {
        #region ����
        public const string FIELD_ID = "iD";
        public const string FIELD_STOCKNO = "stockNo";
        public const string FIELD_PINFOID = "pInfoID";
        public const string FIELD_USERID = "userID";
        public const string FIELD_STOCKDATE = "stockDate";
        public const string FIELD_DOWN = "down";
        public const string FIELD_DOWNDATE = "downDate";
        public const string FIELD_DOWNUSERID = "downUserID";
        public const string FIELD_BLANK = "blank";
        public const string FIELD_BLANKDATE = "blankDate";
        public const string FIELD_BLANKUSERID = "blankUserID";
        #endregion

        #region ˽�б���

        private int _iD;
        private string _stockNo;
        private int _pInfoID;
        private int _userID;
        private DateTime _stockDate;
        private bool _down;
        private DateTime _downDate;
        private int _downUserID;
        private bool _blank;
        private DateTime _blankDate;
        private int _blankUserID;
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
        /// �ֶ�stockNoʵ��
        /// <summary>
        public string StockNo
        {
            get { return this._stockNo; }
            set { this._stockNo = value; }
        }

        /// <summary>
        /// �ֶ�pInfoIDʵ��
        /// <summary>
        public int PInfoID
        {
            get { return this._pInfoID; }
            set { this._pInfoID = value; }
        }

        /// <summary>
        /// �ֶ�userIDʵ��
        /// <summary>
        public int UserID
        {
            get { return this._userID; }
            set { this._userID = value; }
        }

        /// <summary>
        /// �ֶ�stockDateʵ��
        /// <summary>
        public DateTime StockDate
        {
            get { return this._stockDate; }
            set { this._stockDate = value; }
        }

        /// <summary>
        /// �ֶ�downʵ��
        /// <summary>
        public bool Down
        {
            get { return this._down; }
            set { this._down = value; }
        }

        /// <summary>
        /// �ֶ�downDateʵ��
        /// <summary>
        public DateTime DownDate
        {
            get { return this._downDate; }
            set { this._downDate = value; }
        }

        /// <summary>
        /// �ֶ�downUserIDʵ��
        /// <summary>
        public int DownUserID
        {
            get { return this._downUserID; }
            set { this._downUserID = value; }
        }

        /// <summary>
        /// �ֶ�blankʵ��
        /// <summary>
        public bool Blank
        {
            get { return this._blank; }
            set { this._blank = value; }
        }

        /// <summary>
        /// �ֶ�blankDateʵ��
        /// <summary>
        public DateTime BlankDate
        {
            get { return this._blankDate; }
            set { this._blankDate = value; }
        }

        /// <summary>
        /// �ֶ�blankUserIDʵ��
        /// <summary>
        public int BlankUserID
        {
            get { return this._blankUserID; }
            set { this._blankUserID = value; }
        }

        #endregion
    }
}
