using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BIMT.Util.Zip;
using System.IO;

namespace BIMTClassLibrary.MyLiterature
{
    public class ZipService
    {
        /// <summary>
        /// 压缩文件夹
        /// </summary>
        /// <param name="dir">文件夹目录</param>
        /// <param name="zipFile">压缩后的文件</param>
        public static void Zip(string dir, string zipFile)
        {
            try
            {
                string[] FileProperties = new string[2];
                if (Directory.Exists(dir))
                {
                    FileProperties[0] = dir;// "D:\\unzipped\\";//待压缩文件目录
                    FileProperties[1] = zipFile;// "D:\\zip\\a.zip";  //压缩后的目标文件
                    ZipFloClass Zc = new ZipFloClass();
                    Zc.ZipFile(FileProperties[0], FileProperties[1]);
                }
            }
            catch (Exception)
            {
                throw;
            }
            
        }

        /// <summary>
        /// 解压缩文件
        /// </summary>
        /// <param name="zipFile">压缩文件</param>
        /// <param name="dir">解压目录</param>
        public static void UnZip(string zipFile, string dir)
        {
            try
            {
                if (Directory.Exists(dir)&&File.Exists(zipFile))
                {
                    string[] FileProperties = new string[2];
                    FileProperties[0] = zipFile;// "D:\\zip\\b.zip";//待解压的文件
                    FileProperties[1] = dir;// "D:\\unzipped\\";//解压后放置的目标目录
                    UnZipFloClass UnZc = new UnZipFloClass();
                    UnZc.unZipFile(FileProperties[0], FileProperties[1]);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
