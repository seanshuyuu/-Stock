using System;


namespace model
{
    /// <summary>
    /// MerchandiseType����ʵ��ṹ
    /// <summary>
    [Serializable]
    public class MerchandiseTypeData
    {
        #region ����
        public const string FIELD_ID = "iD";
        public const string FIELD_NAME = "name";
        public const string FIELD_PARENTID = "parentID";
        #endregion

        #region ˽�б���

        private int _iD;
        private string _name;
        private int _parentID;
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
        /// �ֶ�parentIDʵ��
        /// <summary>
        public int ParentID
        {
            get { return this._parentID; }
            set { this._parentID = value; }
        }

        #endregion
    }
}
