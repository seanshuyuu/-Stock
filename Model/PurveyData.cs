using System;


namespace model
{
    /// <summary>
    /// Purvey����ʵ��ṹ
    /// <summary>
    [Serializable]
    public class PurveyData
    {
        #region ����
        public const string FIELD_ID = "iD";
        public const string FIELD_PINFOID = "pInfoID";
        public const string FIELD_MTYPEID = "mInfoID";
        public const string FIELD_PRICE = "price";
        #endregion

        #region ˽�б���

        private int _iD;
        private int _pInfoID;
        private int _mInfoID;
        private double _price;
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
        /// �ֶ�pInfoIDʵ��
        /// <summary>
        public int PInfoID
        {
            get { return this._pInfoID; }
            set { this._pInfoID = value; }
        }

        /// <summary>
        /// �ֶ�mTypeIDʵ��
        /// <summary>
        public int MInfoID
        {
            get { return this._mInfoID; }
            set { this._mInfoID = value; }
        }

        /// <summary>
        /// �ֶ�priceʵ��
        /// <summary>
        public double Price
        {
            get { return this._price; }
            set { this._price = value; }
        }

        #endregion
    }
}
//��/1/��/��/��/��