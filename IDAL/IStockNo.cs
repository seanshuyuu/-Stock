using System;
using System.Collections.Generic;
using System.Text;

namespace IDAL
{
    public interface IStockNo
    {
        /// <summary>
        /// �޸ı��
        /// </summary>
        /// <param name="user">�µı��</param>
        void updateNo(int No);
        
        /// <summary>
        /// ��ѯ���
        /// </summary>
        /// <returns>���</returns>
        int selNo();

    }
}
