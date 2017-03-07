using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using System.Runtime.InteropServices;

namespace BIMTClassLibrary
{
    public partial class frmImageInfo : Form, IBaseControl
    {
        private string m_strPicPath;
        
        public frmImageInfo()
        {
            InitializeComponent();
        }

        public frmImageInfo(string p)
        {
            InitializeComponent();

            InitData(p);
        }

        /// <summary>
        /// 生成缩略图
        /// </summary>
        /// <param name="serverImagePath">图片地址</param>
        /// <param name="thumbnailImagePath">缩略图地址</param>
        /// <param name="width">图片宽度</param>
        /// <param name="height">图片高度</param>
        /// <param name="p"></param>
        public static void GetThumbnail(string serverImagePath, string thumbnailImagePath, int width, int height)
        {
            System.Drawing.Image serverImage = System.Drawing.Image.FromFile(serverImagePath);
            //画板大小
            int towidth = width;
            int toheight = height;
            //缩略图矩形框的像素点
            int x = 0;
            int y = 0;
            int ow = serverImage.Width;
            int oh = serverImage.Height;

            if (ow > oh)
            {
                toheight = serverImage.Height * width / serverImage.Width;
            }
            else
            {
                towidth = serverImage.Width * height / serverImage.Height;
            }
            //新建一个bmp图片
            System.Drawing.Image bm = new System.Drawing.Bitmap(width, height);
            //新建一个画板
            System.Drawing.Graphics g = System.Drawing.Graphics.FromImage(bm);
            //设置高质量插值法
            g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.High;
            //设置高质量,低速度呈现平滑程度
            g.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighQuality;
            //清空画布并以透明背景色填充
            g.Clear(System.Drawing.Color.White);
            //在指定位置并且按指定大小绘制原图片的指定部分
            g.DrawImage(serverImage, new System.Drawing.Rectangle((width - towidth) / 2, (height - toheight) / 2, towidth, toheight),
                0, 0, ow, oh,
                System.Drawing.GraphicsUnit.Pixel);
            try
            {
                //以jpg格式保存缩略图
                bm.Save(thumbnailImagePath, System.Drawing.Imaging.ImageFormat.Jpeg);
            }
            catch (System.Exception e)
            {
                throw e;
            }
            finally
            {
                serverImage.Dispose();
                bm.Dispose();
                g.Dispose();
            }
        }


        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                //pictureBox1.Image.
                sfd_pic.ShowDialog();
                GetThumbnail(m_strPicPath, sfd_pic.FileName, int.Parse(txtX.Text), int.Parse(txtY.Text));
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmImageInfo), "保存图片" + ex.Message);
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            ofd_pic.ShowDialog();
            InitData(ofd_pic.FileName);
        }

        public void InitData()
        { }

        public void InitData(string p_strPath)
        {
            try
            {
                richTextBox1.Text = string.Empty;
                this.m_strPicPath = p_strPath;
                richTextBox2.Text = "颜色模式：RGB（8 bit）或灰度图\n"
                             + "线条宽度：>0.5单位\n"
                             + "图片分层：无分层\n"
                             + "图中字体：Arial, Time，8-12字号\n";

                FileInfo fi = new FileInfo(m_strPicPath);
                long length = fi.Length;
                if (length < 1024)
                {
                    txtDD.Text = length + " 字节";
                }
                else if (length >= 1024 && length <= 1024 * 10)
                {
                    txtDD.Text = length / 1024 + " KB";
                }
                else if (length >= 1024 * 10 && length <= 1024 * 10 * 10)
                {
                    txtDD.Text = length / 1024 / 1024 + " MB";
                }
                else
                {
                    richTextBox1.Text += "图片大小不能超过10MB！\n";
                }


                
                if (fi.Extension != ".tiff" && fi.Extension != ".tif")
                {
                    richTextBox1.Text += "图片格式不是tiff格式！\n";
                }

               

                string _strExtrension = fi.Extension;
                if (_strExtrension == ".png" | _strExtrension == ".jpeg" | _strExtrension == ".jpg" | _strExtrension == ".gif" | _strExtrension == ".tif" | _strExtrension == ".tiff")
                {
                   
                    Image pic = Image.FromFile(m_strPicPath);//strFilePath是该图片的绝对路径
                    pictureBox1.Image = pic;

                    int intWidth = pic.Width;//长度像素值
                    txtX.Text = intWidth.ToString();

                    int intHeight = pic.Height;//高度像素值 
                    txtY.Text = intHeight.ToString();

                    //string _strFile = Marshal.PtrToStringAnsi(OCRpart(p_strPath, -1, 0, 0, intWidth, intHeight));

                    if ((pic.HorizontalResolution >= 300 && pic.HorizontalResolution <= 600) && (pic.VerticalResolution <= 600 && pic.VerticalResolution >= 300))
                    {
                        //标准分辨率
                    }
                    else
                    {
                        richTextBox1.Text += "建议分辨率：300-600dpi\n";
                    }

                    txtFBLX.Text = pic.HorizontalResolution.ToString();
                    txtFBLY.Text = pic.VerticalResolution.ToString();
                }
                if (richTextBox1.Text==string.Empty)
                {
                    TestResult.Text = "通过！";
                }
                else
                {
                    TestResult.Text = "不通过！";
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmImageInfo), ex);
            }
          
        }

        private void splitContainer1_Panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
