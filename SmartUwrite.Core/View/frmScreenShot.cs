using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

namespace BIMTClassLibrary.ScreenShot
{
    public partial class frmScreenShot : Form
    {
        private static frmScreenShot screenShot;
        private Graphics MainPainter;   //主画笔
        private Pen pen;                //就是笔咯
        private bool isDowned;          //判断鼠标是否按下
        private bool RectReady;          //矩形是否绘制完成
        private Image baseImage;        //基本图形(原来的画面)
        private Rectangle Rect;         //就是要保存的矩形
        private Point downPoint;         //鼠标按下的点
        int tmpx;
        int tmpy;

        public static frmScreenShot GetInstance()
        {
            if (screenShot == null)
            {
                screenShot = new frmScreenShot();
            }
            return screenShot;
        }
        private frmScreenShot()
        {
            InitializeComponent();
            this.TransparencyKey = Color.Red;
        }

        

        private void btn_start_Click(object sender, EventArgs e)
        {
            Rect = new Rectangle();
            
            if (((MouseEventArgs)e).Button == MouseButtons.Left && Rect.Contains(((MouseEventArgs)e).X, ((MouseEventArgs)e).Y))
            {
                //保存的时候有很多种方法的......我这里只用了这种
                Image memory = new Bitmap(Rect.Width, Rect.Height);
                Graphics g = Graphics.FromImage(memory);
                g.CopyFromScreen(Rect.X + 1, Rect.Y + 1, 0, 0, Rect.Size);
                Clipboard.SetImage(memory);
                this.Close();
            }
        }

        private void frmScreenShot_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                lb_shot.Location = new Point(e.X, e.Y);
                lb_shot.Visible = true;
                isDowned = true;

                if (RectReady == false)
                {
                    Rect.X = e.X;
                    Rect.Y = e.Y;
                    downPoint = new Point(e.X, e.Y);
                }
                if (RectReady == true)
                {
                    tmpx = e.X;
                    tmpy = e.Y;
                }
            }
            if (e.Button == MouseButtons.Right)
            {
                if (RectReady != true)
                {
                    this.Close();
                    return;
                }
                MainPainter.DrawImage(baseImage, 0, 0);
                RectReady = false;
            }

        }

        public void Reset()
        {
            lb_shot.Visible = false;
            this.FindForm().Close();
            
        }

        private void frmScreenShot_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                isDowned = false;
                RectReady = true;
                ucToolBar frm = ucToolBar.GetInstance();
                int x = Rect.X + Rect.Width - frm.Width;
                int y = Rect.Y + Rect.Height  + 3;
                if (lb_shot.Visible ==true)
                {
                    frm.Location = new Point(x, y);
                    frm.ShowDialog();
                }
                this.Opacity = 0d;
                cutImage();
                this.Opacity = 0.30d;
                //this.Controls.Add(frm);
            }
        }

        private void frmScreenShot_MouseMove(object sender, MouseEventArgs e)
        {
            if (RectReady == false)
            {
                if (isDowned == true)
                {
                    Rect.Width = Math.Abs(e.X - Rect.X);
                    Rect.Height = Math.Abs(e.Y - Rect.Y);
                    lb_shot.Width = Rect.Width;
                    lb_shot.Height = Rect.Height;
                    
                }
            }
            //if (RectReady == true)
            //{
            //    if (Rect.Contains(e.X, e.Y))
            //    {
            //        //this.Cursor = Cursors.Hand;
            //        if (isDowned == true)
            //        {
            //            //和上一次的位置比较获取偏移量
            //            Rect.X = Rect.X + e.X - tmpx;
            //            Rect.Y = Rect.Y + e.Y - tmpy;
            //            //记录现在的位置
            //            tmpx = e.X;
            //            tmpy = e.Y;
            //            MoveRect((Image)baseImage.Clone(), Rect);
            //        }
            //    }
            //}
        }
        Bitmap memoryImage;

        private void cutImage()
        {
            //Graphics myGraphics = this.CreateGraphics();
            //Bitmap bit = new Bitmap(Rect.Width, Rect.Height, myGraphics);//实例化一个和窗体一样大的bitmap
            //Graphics g = Graphics.FromImage(bit);
            //g.CompositingQuality = CompositingQuality.HighQuality;//质量设为最高
            //g.CopyFromScreen(Rect.X, Rect.Y, 0, 0, new Size(Rect.Width, Rect.Height));//保存整个窗体为图片


            Graphics myGraphics = this.CreateGraphics();
            Size s =Rect.Size;
            memoryImage = new Bitmap(s.Width, s.Height, myGraphics);
            Graphics memoryGraphics = Graphics.FromImage(memoryImage);
            memoryGraphics.CopyFromScreen(Rect.X, Rect.Y, 0, 0, s);

            SaveFileDialog sfd =new SaveFileDialog();
            sfd.Filter = "图片|*.png";
            sfd.ShowDialog();
            string fileName =sfd.FileName;
            memoryImage.Save(fileName);
        }

        private void frmScreenShot_Load(object sender, EventArgs e)
        {
            this.WindowState = FormWindowState.Maximized;
            MainPainter = this.CreateGraphics();
            pen = new Pen(Brushes.Blue);
            isDowned = false;
            baseImage = this.BackgroundImage;
            Rect = new Rectangle();
            RectReady = false;
        }

        private void DrawRect(Graphics Painter, int Mouse_x, int Mouse_y)
        {
            int width = 0;
            int heigth = 0;
            if (Mouse_y < Rect.Y)
            {
                Rect.Y = Mouse_y;
                heigth = downPoint.Y - Mouse_y;
            }
            else
            {
                heigth = Mouse_y - downPoint.Y;
            }
            if (Mouse_x < Rect.X)
            {
                Rect.X = Mouse_x;
                width = downPoint.X - Mouse_x;
            }
            else
            {
                width = Mouse_x - downPoint.X;
            }
            Rect.Size = new Size(width, heigth);
            Painter.DrawRectangle(pen, Rect);
        }

        private Image DrawScreen(Image back, int Mouse_x, int Mouse_y)
        {
            Graphics Painter = Graphics.FromImage(back);
            DrawRect(Painter, Mouse_x, Mouse_y);
            return back;
        }
        private void MoveRect(Image image, Rectangle Rect)
        {
            Graphics Painter = Graphics.FromImage(image);
            Painter.DrawRectangle(pen, Rect.X, Rect.Y, Rect.Width, Rect.Height);
            DrawRect(Painter, Rect.X + Rect.Width, Rect.Y + Rect.Height);
            MainPainter.DrawImage(image, 0, 0);
            image.Dispose();
        }

        private void frmScreenShot_DoubleClick(object sender, EventArgs e)
        {
            this.FindForm().Close();
        }

        private void lb_shot_MouseDown(object sender, MouseEventArgs e)
        {

        }
    }
}
