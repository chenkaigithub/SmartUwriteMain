using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMT.Util.Tree
{
    interface ITree<T>
    {
        T Root();                                //求树的根结点
        T Parent(T t);                           //求结点t的双亲结点
        T Child(T t, int i);                     //求结点t的第i个子结点
        T RightSibling(T t);                     //求结点t第一个右边兄弟结点
        bool Insert(T s, T t, int i);            //将树s加入树中作为结点t的第i颗子树
        T Delete(T t, int i);                    //删除结点t的第i颗子树
        void Traverse(int TraverseType);         //按某种方式遍历树
        void Clear();                            //清空树
        bool IsEmpty();                          //判断是否为空
        int GetDepth(T t);                          //求树的深度
    }
}
