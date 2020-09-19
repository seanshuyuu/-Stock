using System;


namespace model
{
    /// <summary>
    /// StockInfo����ʵ��ṹ
    /// <summary>
    [Serializable]
    public class StockInfoData
    {
        #region ����
        public const string FIELD_ID = "iD";
        public const string FIELD_SID = "sID";
        public const string FIELD_MID = "mID";
        public const string FIELD_PRICE = "price";
        public const string FIELD_QUANTITY = "quantity";
        #endregion

        #region ˽�б���

        private int _iD;
        private int _sID;
        private int _mID;
        private double _price;
        private int _quantity;
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
        /// �ֶ�sIDʵ��
        /// <summary>
        public int SID
        {
            get { return this._sID; }
            set { this._sID = value; }
        }

        /// <summary>
        /// �ֶ�mIDʵ��
        /// <summary>
        public int MID
        {
            get { return this._mID; }
            set { this._mID = value; }
        }

        /// <summary>
        /// �ֶ�priceʵ��
        /// <summary>
        public double Price
        {
            get { return this._price; }
            set { this._price = value; }
        }

        /// <summary>
        /// �ֶ�quantityʵ��
        /// <summary>
        public int Quantity
        {
            get { return this._quantity; }
            set { this._quantity = value; }
        }

        #endregion
    }
}
