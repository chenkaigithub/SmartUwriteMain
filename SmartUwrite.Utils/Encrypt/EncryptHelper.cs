using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace BIMT.Util.Encrypt
{
    public class EncryptHelper
    {
        string encryptKey;    //定义密钥  
        public EncryptHelper(string key)
        {
            encryptKey = key;
        }

        public EncryptHelper()
        {
        }

        /// <summary> /// 加密字符串   
        /// </summary>  
        /// <param name="str">要加密的字符串</param>  
        /// <returns>加密后的字符串</returns>  
        public string Do(string str)
        {
            return Base64Encrypt(str);
            //DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象   
            //byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    
            //byte[] data = Encoding.Unicode.GetBytes(str);//定义字节数组，用来存储要加密的字符串  
            //MemoryStream MStream = new MemoryStream(); //实例化内存流对象      
            //CryptoStream CStream = new CryptoStream(MStream, descsp.CreateEncryptor(key, key), CryptoStreamMode.Write);
            //CStream.Write(data, 0, data.Length);  //向加密流中写入数据      
            //CStream.FlushFinalBlock();              //释放加密流      
            //return Convert.ToBase64String(MStream.ToArray());//返回加密后的字符串  
        }

        public static string encode(string str)
        {
            string htext = "";

            for (int i = 0; i < str.Length; i++)
            {
                htext = htext + (char)(str[i] + 10 - 1 * 2);
            }
            return htext;
        }

        public string De(string str)
        {
            return Base64Decrypt(str);
            //DESCryptoServiceProvider descsp = new DESCryptoServiceProvider();   //实例化加/解密类对象    
            //byte[] key = Encoding.Unicode.GetBytes(encryptKey); //定义字节数组，用来存储密钥    
            //byte[] data = Convert.FromBase64String(str);//定义字节数组，用来存储要解密的字符串  
            //MemoryStream MStream = new MemoryStream(); //实例化内存流对象      
            //CryptoStream CStream = new CryptoStream(MStream, descsp.CreateDecryptor(key, key), CryptoStreamMode.Write);
            //CStream.Write(data, 0, data.Length);      //向解密流中写入数据     
            //CStream.FlushFinalBlock();               //释放解密流      
            //return Encoding.Unicode.GetString(MStream.ToArray());       //返回解密后的字符串  
        }

        public static string decode(string str)
        {
            string dtext = "";

            for (int i = 0; i < str.Length; i++)
            {
                dtext = dtext + (char)(str[i] - 10 + 1 * 2);
            }
            return dtext;
        }

        #region Base64加密解密
        /// <summary>
        /// Base64加密 可逆
        /// </summary>
        /// <param name="value">待加密文本</param>
        /// <returns></returns>
        public static string Base64Encrypt(string value)
        {
            return Convert.ToBase64String(System.Text.Encoding.Default.GetBytes(value));
        }

        /// <summary>
        /// Base64解密
        /// </summary>
        /// <param name="ciphervalue">密文</param>
        /// <returns></returns>
        public static string Base64Decrypt(string ciphervalue)
        {
            return System.Text.Encoding.Default.GetString(System.Convert.FromBase64String(ciphervalue));
        }
        #endregion
    }
}
