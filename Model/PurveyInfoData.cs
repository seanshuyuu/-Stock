using System;


namespace model
{
    /// <summary>
    /// PurveyInfo����ʵ��ṹ
    /// <summary>
    [Serializable]
    public class PurveyInfoData
    {
        #region ����
        public const string FIELD_ID = "iD";
        public const string FIELD_NAME = "name";
        public const string FIELD_PTYPEID = "pTypeID";
        public const string FIELD_LINKMAN = "linkMan";
        public const string FIELD_TEL = "tel";
        public const string FIELD_FOX = "fox";
        public const string FIELD_ADDRESS = "address";
        public const string FIELD_EMAIL = "emial";
        public const string FIELD_DAYS = "days";
        #endregion

        #region ˽�б���

        private int _iD;
        private string _name;
        private int _pTypeID;
        private string _linkMan;
        private string _tel;
        private string _fox;
        private string _address;
        private string _email;
        private int _days;
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
        /// �ֶ�nameʵ��
        /// <summary>
        public string Name
        {
            get { return this._name; }
            set { this._name = value; }
        }

        /// <summary>
        /// �ֶ�pTypeIDʵ��
        /// <summary>
        public int PTypeID
        {
            get { return this._pTypeID; }
            set { this._pTypeID = value; }
        }

        /// <summary>
        /// �ֶ�linkManʵ��
        /// <summary>
        public string LinkMan
        {
            get { return this._linkMan; }
            set { this._linkMan = value; }
        }

        /// <summary>
        /// �ֶ�telʵ��
        /// <summary>
        public string Tel
        {
            get { return this._tel; }
            set { this._tel = value; }
        }

        /// <summary>
        /// �ֶ�foxʵ��
        /// <summary>
        public string Fox
        {
            get { return this._fox; }
            set { this._fox = value; }
        }

        /// <summary>
        /// �ֶ�addressʵ��
        /// <summary>
        public string Address
        {
            get { return this._address; }
            set { this._address = value; }
        }

        public string Email
        {
            get { return this._email; }
            set { this._email = value; }
        }
        public int Days
        {
            get { return this._days; }
            set { this._days = value; }
        }
        #endregion
    }
}
