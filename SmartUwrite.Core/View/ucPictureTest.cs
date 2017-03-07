using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using BIMTClassLibrary.pitcture;
using System.Drawing.Imaging;

namespace BIMTClassLibrary
{
    public partial class ucPictureTest : UserControl
    {
        //private string m_strPicPath;
        public ucPictureTest()
        {
            InitializeComponent();
        }

        public ucPictureTest(string p)
        {
            InitializeComponent();
            if (File.Exists(p))
            {
                fileName = p;
                InitData(p);
            }
            
        }

        public void InitData()
        { }

        public void InitData(string p_strPath)
        {
            try
            {
                richTextBox1.Text = string.Empty;
                richTextBox2.Text = string.Empty;
                this.fileName = p_strPath;
                bool _boolGS = false;
                bool _boolFBL = false;
                FileInfo fi = new FileInfo(fileName);
         
                long length = fi.Length;
                if (length < 1024)
                {
                    txtDD.Text = length + " 字节";
                }
                else if (length >= 1024 && length <= 1024 * 1024)
                {
                    txtDD.Text = length / 1024 + " KB";
                }
                else if (length >= 1024 * 1024 && length <= 1024 * 1024 * 1024)
                {
                    txtDD.Text = length / 1024 / 1024 + " MB";
                }
                else
                {
                    richTextBox1.Text += "图片大小不合格，图片大小不能超过10MB！\n\n";
                }



                if (fi.Extension != ".tiff" && fi.Extension != ".tif")
                {
                    richTextBox1.Text += "图片格式不是tiff格式！（点击“下载图片”保存文件，可将图片自动调整为tiff格式）\n\n";
                    _boolGS = true;
                }



                string _strExtrension = fi.Extension;
                
                if (_strExtrension == ".png" | _strExtrension == ".jpeg" | _strExtrension == ".jpg" | _strExtrension == ".gif" | _strExtrension == ".tif" | _strExtrension == ".tiff")
                {

                    Image pic = Image.FromFile(fileName);//strFilePath是该图片的绝对路径
                    //Bitmap pic = new Bitmap(image);
                    pictureBox1.Image = pic;// pic;
                   
                    int intWidth = pic.Width;//长度像素值
                    txtX.Text = intWidth.ToString() + " PX";

                    int intHeight = pic.Height;//高度像素值 
                    txtY.Text = intHeight.ToString() + " PX";

                    //string _strFile = Marshal.PtrToStringAnsi(OCRpart(p_strPath, -1, 0, 0, intWidth, intHeight));

                    if ((pic.HorizontalResolution >= 300 && pic.HorizontalResolution <= 600) && (pic.VerticalResolution <= 600 && pic.VerticalResolution >= 300))
                    {
                        //标准分辨率
                    }
                    else
                    {
                        _boolFBL = true;
                        if ( pic.VerticalResolution < 300)
                        {
                            richTextBox1.Text += "分辨率过低！(点击“下载图片”保存文件，可自动调整为300dpi)\n\n";
                        }
                        else if (pic.VerticalResolution > 600)
                        {
                            richTextBox1.Text += "分辨率过高！(点击“下载图片”保存文件，可自动调整为300dpi)\n\n";
                        }
                       
                    }
                    if (_boolGS)
                    {
                        richTextBox2.Text += "图片格式应为.tif\n";
                    }
                    if (_boolFBL)
                    {
                        richTextBox2.Text += "建议分辨率为300-600dpi\n";
                    }
                    richTextBox2.Text += "颜色模式：RGB（8 bit）或灰度图\n"
                            + "线条宽度：>0.5单位\n"
                            + "图片分层：无分层\n"
                            + "图中字体：Arial, Time，8-12字号\n";

                    txtFBLX.Text = pic.HorizontalResolution.ToString() + " DPI";
                    txtFBLY.Text = pic.VerticalResolution.ToString() + " DPI";
                    //pic.Dispose();
                }
                if (richTextBox1.Text == string.Empty)
                {
                    TestResult.Text = "合格！";
                }
                else
                {
                    TestResult.Text = "不合格！";
                }
                
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmImageInfo), ex);
            }

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
                sfd_pic.ShowDialog();
                Bitmap imgSource = new Bitmap(pictureBox1.Image);
                PictureHelper ph = new PictureHelper(imgSource);
                Bitmap imgTarget = ph.ConvertDPI();
                imgTarget.Save(sfd_pic.FileName, ImageFormat.Tiff);
                MessageBox.Show(null,"图片保存成功！","另存为");
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(frmImageInfo), "保存图片" + ex.Message);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            ofd_pic.ShowDialog();
            if (File.Exists(ofd_pic.FileName))
            {
                this.fileName = ofd_pic.FileName;
                InitData(ofd_pic.FileName);
            }
          
        }

        /// <summary>
        /// 设置当鼠标悬浮上边时的展示效果
        /// wuhailong
        /// 2016-07-07
        /// </summary>
        /// <param name="lable"></param>
        public void SetLableHoverStyle(Label lable)
        {
            try
            {
                if (lable == null)
                {
                    return;
                }
                else
                {
                    lable.BackColor = Color.Red;
                }
            }
            catch (Exception ex)
            {
                Log4Net.LogHelper.WriteLog(typeof(ucPictureTest), ex);
            }
        }

        private void label8_MouseHover(object sender, EventArgs e)
        {
            Label lable = sender as Label;
            SetLableHoverStyle(lable);
        }


        public string filename { get; set; }

        public string fileName { get; set; }
    }
}
