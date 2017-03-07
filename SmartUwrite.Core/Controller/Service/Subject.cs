using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.DocDatabase.Service
{
    /// <summary>
    /// 抽象主题类
    /// </summary>
    public abstract class Subject
    {
        private IList<Observer> observers = new List<Observer>();

        /// <summary>
        /// 增加观察者
        /// </summary>
        /// <param name="observer"></param>
        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        /// <summary>
        /// 移除观察者
        /// </summary>
        /// <param name="observer"></param>
        public void Detach(Observer observer)
        {
            observers.Remove(observer);
        }

        /// <summary>
        /// 向观察者（们）发出通知
        /// </summary>
        public void Notify()
        {
            foreach (Observer o in observers)
            {
                o.Update();
            }
        }
    }
}
