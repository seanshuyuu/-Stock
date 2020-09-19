using System;


namespace model
{
    /// <summary>
    /// User����ʵ��ṹ
    /// <summary>
    [Serializable]
    public class UserData
    {
        #region ����
        public const string FIELD_ID = "iD";
        public const string FIELD_NAME = "name";
        public const string FIELD_PWD = "pwd";
        public const string FIELD_PURVIEW = "purview";
        #endregion

        #region ˽�б���

        private int _iD;
        private string _name;
        private string _pwd;
        private int _purview;
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
        /// �ֶ�pwdʵ��
        /// <summary>
        public string Pwd
        {
            get { return this._pwd; }
            set { this._pwd = value; }
        }

        /// <summary>
        /// �ֶ�purviewʵ��
        /// <summary>
        public int Purview
        {
            get { return this._purview; }
            set { this._purview = value; }
        }

        #endregion
    }
}
