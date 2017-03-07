using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BIMTClassLibrary.RefreshView
{
    public class PayService
    {
        public string token { get;private set; }

        public PayService(string ptoken)
        {
            this.token = ptoken;
        }

        

        //private const string url = @"http://i.bimttest.com/order/smartuwrite/add?token={0}&link=word";
        private static readonly string url = @"http://i.bimt.com/order/smartuwrite/add?token={0}&link=word";
        public void Jump()
        {
            string s = string.Format(url, token);
            System.Diagnostics.Process.Start(s);
        }

        public bool IsPay()
        {
            try
            {
                return true;
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
