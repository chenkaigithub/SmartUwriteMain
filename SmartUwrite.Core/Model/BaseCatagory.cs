using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.DocDatabase.Service;

namespace BIMTClassLibrary.DocDatabase
{
    public class BaseDocManager:BasePostEntity 
    {
        public string BaseUrl = @"http://192.168.0.122";//@"http://writeaid2.bimt.com/";

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
