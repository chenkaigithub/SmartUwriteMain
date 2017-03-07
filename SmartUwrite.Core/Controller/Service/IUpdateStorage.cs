using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Collections;

namespace BIMTClassLibrary.Controller.Service
{
    interface IUpdateStorage
    {
        List<string> GetContainers(dynamic param);
        List<string> GetFileList(dynamic param);
        string AddContainer(dynamic param);
        string DelContainer(dynamic param);
        //string UploadFile(dynamic param);
        string DelFile(dynamic param);
        void UploadFile();
    }
}
