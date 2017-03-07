using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.rest;
using BIMTClassLibrary.Model;
using BIMT.Util.Serialiaze;

namespace BIMTClassLibrary.Controller.Service
{
    class BimtProxyService<T>
    {
        T entity;
        public BimtProxyService(string url)
        {
            try
            {
                RestHelper rh = new RestHelper(url, string.Empty, string.Empty);
                string json = rh.SendGet();
                ResponseEntity<T> tt = DeserialiazeClass.Deserialize<ResponseEntity<T>>(json);
                Entity = tt.GetResponse();
            }
            catch (Exception)
            {
                throw;
            }
        }

        public T Entity
        {
            get
            {
                return entity;
            }

            set
            {
                entity = value;
            }
        }
    }
}
