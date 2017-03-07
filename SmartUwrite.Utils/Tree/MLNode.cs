using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMT.Util.Tree
{
    public class MLNode<T>
    {
        private T data;                   //存储结点的数据
        private MLNode<T>[] childs;       //存储子结点的位置

        public MLNode(int max)
        {
            childs = new MLNode<T>[max];
            for (int i = 0; i < childs.Length; i++)
            {
                childs[i] = null;
            }
        }

        public T Data
        {
            get { return data; }
            set { data = value; }
        }

        public MLNode<T>[] Childs
        {
            get { return childs; }
            set { childs = value; }
        }
    }
}
