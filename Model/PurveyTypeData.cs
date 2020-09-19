using System;


namespace model
{
    /// <summary>
    /// PurveyType����ʵ��ṹ
    /// <summary>
    [Serializable]
    public class PurveyTypeData
    {
        #region ����
        public const string FIELD_ID = "iD";
        public const string FIELD_TYPENAME = "typeName";
        #endregion

        #region ˽�б���

        private int _iD;
        private string _typeName;
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
        /// �ֶ�typeNameʵ��
        /// <summary>
        public string TypeName
        {
            get { return this._typeName; }
            set { this._typeName = value; }
        }

        #endregion
        public PurveyTypeData() { }

        public PurveyTypeData(int id, string typeName)
        {
            this._iD = id;
            this._typeName = typeName;
        }
        public override string ToString()
        {
            return this._typeName;
        }
    }
}
//��/��/a/��/��/��