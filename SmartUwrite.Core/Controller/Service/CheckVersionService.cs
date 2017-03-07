using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using Microsoft.Win32;
using Aliyun.OpenServices.OpenStorageService;
using BIMTClassLibrary.WordTemplate;
using System.IO;

namespace BIMTClassLibrary.Controller.Service
{
    public class CheckVersionService
    {

        public string GetPath()
        {
            string subKey = @"Software\Microsoft\Office\Word\Addins\比美特医护在线.SmartUwrite";
            RegistryKey hkml = RegistryKey.OpenBaseKey(RegistryHive.CurrentUser, RegistryView.Default);
            RegistryKey software = hkml.OpenSubKey(subKey);
            string path = (string)software.GetValue("Manifest");
            return path.Substring(0, path.LastIndexOf('\\')) + "\\{0}";
        }
        public string GetVersion(string path)
        {
            Assembly assembly = Assembly.LoadFile(path);
            AssemblyName assemblyName = assembly.GetName();
            Version version = assemblyName.Version;
            return version.ToString();
        }

        /// <summary>
        /// oss下载文件
        /// </summary>
        public void OssDownloadFile(string key, string path)
        {
            OssClient client = OssManager.GetInstance();
            OssObject obj = client.GetObject("bimt-smartuwrite", string.Format(SelectPlatform() + "{0}", key));
            if (obj != null)
            {
                // Object流处理   
                int numBytesRead = 0;
                int numBytesToRead = (int)obj.Metadata.ContentLength;
                byte[] bytes = new byte[numBytesToRead];
                FileStream fs = new FileStream(path, FileMode.Create);
                // 将流写入本地文件保存   
                while (numBytesToRead > 0)
                {
                    int n = obj.Content.Read(bytes, numBytesRead, Math.Min(numBytesToRead, int.MaxValue));
                    if (n <= 0)
                    { break; }
                    fs.Write(bytes, numBytesRead, n);
                    numBytesRead += n;
                    numBytesToRead -= n;
                }
                fs.Close();
            }
        }

        private string SelectPlatform()
        {
            ushort s = GetPEArchitecture(string.Format(GetPath(), "BIMT200.dll"));
            if (s == 0x10b)
            {
                return "SmartUwrite_for_x86_office/";
            }
            return "SmartUwrite_for_x64_office/";
        }

        public static ushort GetPEArchitecture(string pFilePath)
        {
            ushort architecture = 0;
            try
            {
                using (System.IO.FileStream fStream = new System.IO.FileStream(pFilePath, System.IO.FileMode.Open, System.IO.FileAccess.Read))
                {
                    using (System.IO.BinaryReader bReader = new System.IO.BinaryReader(fStream))
                    {
                        if (bReader.ReadUInt16() == 23117) //check the MZ signature
                        {
                            fStream.Seek(0x3A, System.IO.SeekOrigin.Current); //seek to e_lfanew.
                            fStream.Seek(bReader.ReadUInt32(), System.IO.SeekOrigin.Begin); //seek to the start of the NT header.
                            if (bReader.ReadUInt32() == 17744) //check the PE\0\0 signature.
                            {
                                fStream.Seek(20, System.IO.SeekOrigin.Current); //seek past the file header,
                                architecture = bReader.ReadUInt16(); //read the magic number of the optional header.
                            }
                        }
                    }
                }
            }
            catch (Exception) { /* TODO: Any exception handling you want to do, personally I just take 0 as a sign of failure */}
            //if architecture returns 0, there has been an error.
            return architecture;
        }
    }
}
