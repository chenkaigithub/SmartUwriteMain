using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMT.Util.Tree
{
    public class MLTree<T> : ITree<MLNode<T>>
    {
        private MLNode<T> head;

        public MLNode<T> Head
        {
            get { return head; }
            set { head = value; }
        }

        public MLTree()
        {
            head = null;
        }

        public MLTree(MLNode<T> node)
        {
            head = node;
        }

        //求树的根结点
        public MLNode<T> Root()
        {
            return head;
        }

        public void Clear()
        {
            head = null;
        }

        //待测试！！！
        public int GetDepth(MLNode<T> root)
        {
            int len;
            if (root == null)
            {
                return 0;
            }
            for (int i = 0; i < root.Childs.Length; i++)
            {
                if (root.Childs[i] != null)
                {
                    len = GetDepth(root.Childs[i]);
                    return len + 1;
                }
            }
            return 0;
        }

        public bool IsEmpty()
        {
            return head == null;
        }

        //求结点t的双亲结点，如果t的双亲结点存在，返回双亲结点，否则返回空
        //按层序遍历的算法进行查找
        public MLNode<T> Parent(MLNode<T> t)
        {
            MLNode<T> temp = head;
            if (IsEmpty() || t == null)
                return null;
            if (temp.Data.Equals(t.Data))
                return null;
            CSeqQueue<MLNode<T>> queue = new CSeqQueue<MLNode<T>>(50);
            queue.EnQueue(temp);
            while (!queue.IsEmpty())
            {
                temp = (MLNode<T>)queue.DeQueue();
                for (int i = 0; i < temp.Childs.Length; i++)
                {
                    if (temp.Childs[i] != null)
                    {
                        if (temp.Childs[i].Data.Equals(t.Data))
                        {
                            return temp;
                        }
                        else
                        {
                            queue.EnQueue(temp.Childs[i]);
                        }
                    }
                }
            }
            return null;
        }

        //求结点t的第i个子结点。如果存在，返回第i个子结点，否则返回空
        //i=0时，表示求第一个子节点
        public MLNode<T> Child(MLNode<T> t, int i)
        {
            if (t != null && i < t.Childs.Length)
            {
                return t.Childs[i];
            }
            else
            {
                return null;
            }
        }

        //求结点t第一个右边兄弟结点，如果存在，返回第一个右边兄弟结点，否则返回空
        public MLNode<T> RightSibling(MLNode<T> t)
        {
            MLNode<T> pt = Parent(t);
            if (pt != null)
            {
                int i = FindRank(t);
                return Child(pt, i + 1);
            }
            else
            {
                return null;
            }
        }

        //查找结点t在兄弟中的排行，成功时返回位置，否则返回-1
        private int FindRank(MLNode<T> t)
        {
            MLNode<T> pt = Parent(t);
            for (int i = 0; i < pt.Childs.Length; i++)
            {
                MLNode<T> temp = pt.Childs[i];
                if (temp != null && temp.Data.Equals(t.Data))
                {
                    return i;
                }
            }
            return -1;
        }

        //查找在树中的结点t，成功是返回t的位置，否则返回null
        private MLNode<T> FindNode(MLNode<T> t)
        {
            if (head.Data.Equals(t.Data))
                return head;
            MLNode<T> pt = Parent(t);
            foreach (MLNode<T> temp in pt.Childs)
            {
                if (temp != null && temp.Data.Equals(t.Data))
                {
                    return temp;
                }
            }
            return null;
        }

        //把以s为头结点的树插入到树中作为结点t的第i颗子树。成功返回true
        public bool Insert(MLNode<T> s, MLNode<T> t, int i)
        {
            if (IsEmpty())
                head = t;
            //t = FindNode(t);
            if (t != null && t.Childs.Length > i)
            {
                t.Childs[i] = s;
                return true;
            }
            else
            {
                return false;
            }
        }

        //删除结点t的第i个子树。返回第i颗子树的根结点。
        public MLNode<T> Delete(MLNode<T> t, int i)
        {
            t = FindNode(t);
            MLNode<T> node = null;
            if (t != null && t.Childs.Length > i)
            {
                node = t.Childs[i];
                t.Childs[i] = null;
            }
            return node;
        }


        //先序遍历
        //根结点->遍历根结点的左子树->遍历根结点的右子树 
        public void preorder(MLNode<T> root)
        {
            if (root == null)
                return;
            for (int i = 0; i < root.Childs.Length; i++)
            {
                preorder(root.Childs[i]);
            }
        }


        //后序遍历
        //遍历根结点的左子树->遍历根结点的右子树->根结点
        public void postorder(MLNode<T> root)
        {
            if (root == null)
            { return; }
            for (int i = 0; i < root.Childs.Length; i++)
            {
                postorder(root.Childs[i]);
            }
        }


        //层次遍历
        //引入队列 
        public void LevelOrder(MLNode<T> root)
        {
            Console.WriteLine("遍历开始：");
            if (root == null)
            {
                Console.WriteLine("没有结点！");
                return;
            }

            MLNode<T> temp = root;

            CSeqQueue<MLNode<T>> queue = new CSeqQueue<MLNode<T>>(50);
            queue.EnQueue(temp);
            while (!queue.IsEmpty())
            {
                temp = (MLNode<T>)queue.DeQueue();
                Console.WriteLine(temp.Data + " ");
                for (int i = 0; i < temp.Childs.Length; i++)
                {
                    if (temp.Childs[i] != null)
                    {
                        queue.EnQueue(temp.Childs[i]);
                    }
                }
            }
            Console.WriteLine("遍历结束！");
        }

        //按某种方式遍历树
        //0 先序
        //1 后序
        //2 层序
        public void Traverse(int TraverseType)
        {
            if (TraverseType == 0) preorder(head);
            else if (TraverseType == 1) postorder(head);
            else LevelOrder(head);
        }
    }
}
