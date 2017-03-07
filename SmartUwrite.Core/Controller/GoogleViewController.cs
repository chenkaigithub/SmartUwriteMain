using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMTClassLibrary.Model;
using BIMT.Util.ExeProcess;
using System.Diagnostics;
using System.Windows.Forms;
using BIMTClassLibrary.RefreshView;
using BIMTClassLibrary.rest;
using BIMT.Util.Serialiaze;
using BIMTClassLibrary.Controller.Service;
using Newtonsoft.Json;
using BIMTClassLibrary.View;

namespace BIMTClassLibrary.Controller
{
    public class GoogleViewController : ChargeableController
    {
        public static string URL = string.Format("http://bigdata.api.bimt.com/v1/{0}", "/utils/google_scholar_sslist");
        public GoogleViewController(IRefreshViewable view):base(view)
        {
            this.view = view;
        }


        public override void Do()
        {
            string softName = "BimtShadowsocks";
            Process p = ProcessHelper.GetProcess(softName);
            if (p != null)
            {
                p.Kill();
            }

            string path = string.Format("{0}\\BIMT\\proxy\\{1}.exe", Environment.GetFolderPath(Environment.SpecialFolder.Personal),softName);
            string[] arg = new string[3];
            ProxyServer server = GetConfig();
            arg[0] = server.server;
            arg[1] = server.password;
            arg[2] = server.server_port.ToString();
            ProcessHelper.StartProcess(path, arg);
            //frmProxyNotify fr = new frmProxyNotify();
            //fr.Show();
            //fr.BringToFront();
        }



        public ProxyServer GetConfig()
        {
            try
            {
                BimtProxyService<ShadowSocksEntity> bps = new BimtProxyService<ShadowSocksEntity>(ShadowSocksEntity.URL);
                List<ProxyServer> list = bps.Entity.GetParams();
                Random r = new Random();
                r.Next(0, list.Count);
                return list[r.Next(0, list.Count)];
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
