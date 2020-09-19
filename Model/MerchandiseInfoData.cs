using System;


namespace model
{
    /// <summary>
    /// MerchandiseInfo����ʵ��ṹ
    /// <summary>
    [Serializable]
    public class MerchandiseInfoData
    {
        #region ����
        public const string FIELD_ID = "iD";
        public const string FIELD_NAME = "name";
        public const string FIELD_TYPEID = "typeID";
        public const string FIELD_QUANTITY = "quantity";
        public const string FIELD_STORAGE = "storage";
        #endregion

        #region ˽�б���

        private int _iD;
        private string _name;
        private int _typeID;
        private int _quantity;
        private int _storage;
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
        /// �ֶ�typeIDʵ��
        /// <summary>
        public int TypeID
        {
            get { return this._typeID; }
            set { this._typeID = value; }
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
        /// �ֶ�storageʵ��
        /// <summary>
        public int Storage
        {
            get { return this._storage; }
            set { this._storage = value; }
        }

        #endregion
    }
}
