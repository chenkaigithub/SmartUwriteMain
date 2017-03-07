using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace BIMTClassLibrary.pitcture
{
    class PictureHelper
    {
        private string filename;
        private Bitmap imgSource;

        public PictureHelper(string filename)
        {
            // TODO: Complete member initialization
            this.filename = filename;
        }

        public PictureHelper(Bitmap imgSource)
        {
            // TODO: Complete member initialization
            this.imgSource = imgSource;
        }
        /// <summary>
        /// 将图片的分辨率改为300dpi--已废弃
        /// wuhailong
        /// 2016-07-27
        /// </summary>
        /// <param name="filename"></param>
        /// <returns></returns>
        public Bitmap _ConvertDPI()
        {
            try
            {
                Bitmap bmp = new Bitmap(filename);
                if (bmp!=null)
                {
                    bmp.SetResolution(300,300);
                    return bmp;
                }
                return null;
            }
            catch (Exception)
            {
                
                throw;
            }
        }

        /// <summary>
        /// 将 图片转化为300 dpi
        /// wuhailong
        /// 2016-07-28
        /// </summary>
        /// <param name="bitmap"></param>
        /// <returns></returns>
        public Bitmap ConvertDPI()
        {
           return ConvertDPI( 300.0F);
        }

        /// <summary>
        /// 将图片转化为指定dpi
        /// wuhailong
        /// 2016-07-28
        /// </summary>
        /// <param name="bitmap"></param>
        /// <param name="dpi"></param>
        /// <returns></returns>
        public Bitmap ConvertDPI(float dpi)
        {
            try
            {
                Bitmap imgSource = this.imgSource;// new Bitmap(pictureBox1.Image);
                Bitmap imgTarget = new Bitmap(imgSource.Width, imgSource.Height, PixelFormat.Format24bppRgb);
                imgTarget.SetResolution(dpi, dpi);
                using (Graphics g = Graphics.FromImage(imgTarget))
                {
                    g.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.HighQualityBicubic;
                    g.DrawImage(imgSource, new Rectangle(0, 0, imgTarget.Width, imgTarget.Height), 0, 0, imgSource.Width, imgSource.Height, GraphicsUnit.Pixel);
                    g.Dispose();
                    return imgTarget;
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
