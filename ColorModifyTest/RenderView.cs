using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Drawing.Imaging;

namespace ColorModifyTest
{
    public partial class RenderView : UserControl
    {
        struct ColorHSV
        {
            private int hue; // 0-360
            private byte saturation; // 0-255
            private byte value; // 0-255
            public int Hue
            {
                get { return this.hue; }
                set
                {
                    int val = value % 360;
                    if (val < 0)
                    {
                        val += 360;
                    }
                    this.hue = val;
                }
            }
            public byte Saturation
            {
                get { return this.saturation; }
                set
                {
                    saturation = value;
                }
            }
            public byte Value
            {
                get { return this.value; }
                set
                {
                    this.value = value;
                }
            }
            public static ColorHSV FromHSV(int hue, int saturation, int value)
            {
                ColorHSV ret = new ColorHSV();
                ret.Hue = hue;
                ret.Saturation = (byte)((saturation > 255) ? 255 : ((saturation < 0) ? 0 : saturation));
                ret.Value = (byte)((value > 255) ? 255 : ((value < 0) ? 0 : value));
                return ret;
            }
        }

        private Image image;
        private ImageBuffer imageBuffer;
        private ImageBuffer renderBuffer;

        private System.Diagnostics.Stopwatch sw;
        private TimeSpan processTime;

        public RenderView()
        {
            sw = new System.Diagnostics.Stopwatch();
            InitializeComponent();

        }

        public Image Image
        {
            get { return this.image; }
            set {
                this.image = new Bitmap(value);
                if (image == null)
                {
                    imageBuffer = null;
                } else
                {
                    imageBuffer = ImageBuffer.CreateFrom(image);
                }
                Invalidate();
            }
        }

        public int Hue
        {
            get; set;
        }

        public int Saturation
        {
            get; set;
        }
        public int Value
        {
            get; set;
        }

        public TimeSpan ProcessTime
        {
            get { return processTime; }

        }

        protected override void OnPaint(PaintEventArgs evt)
        {
            Graphics g = evt.Graphics;

            g.FillRectangle(new SolidBrush(BackColor), 0, 0, Width, Height);

            
            if (imageBuffer != null)
            {
                try
                {
                    if ((renderBuffer == null) || (renderBuffer.Width != imageBuffer.Width) || (renderBuffer.Height != imageBuffer.Height))
                    {
                        renderBuffer = ImageBuffer.Create(imageBuffer.Width, imageBuffer.Height);
                    }
                    sw.Reset();
                    sw.Start();
                    Image drawImage = ConvertImage(imageBuffer, renderBuffer, Hue, Saturation, Value);
                    sw.Stop();
                    processTime = sw.Elapsed;
                    g.DrawImageUnscaled(drawImage, 0, 0);
                    drawImage.Dispose();
                }
                catch (Exception e)
                {
                    System.Console.WriteLine(e.StackTrace);
                }
            }



            Pen pen = new Pen(Color.FromArgb(255, 0, 0, 0));

            // ここ重要
            // graphics.ClipBounds は描画対象のサイズを返さないことに注意。
            //
            Rectangle border = new Rectangle(0, 0, ClientSize.Width - 1, ClientSize.Height - 1);
            g.DrawRectangle(pen, border);
            pen.Dispose();
        }

        /// <summary>
        /// 画像を変換して取得する。
        /// </summary>
        /// <param name="srcImage"></param>
        /// <param name="buffer">バッファ</param>
        /// <param name="hue"></param>
        /// <param name="saturation"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private Image ConvertImage(ImageBuffer srcImage, ImageBuffer buffer, int hue, int saturation, int value)
        {
            for (int y = 0; y < srcImage.Height; y++)
            {
                for (int x = 0; x < srcImage.Width; x++)
                {
                    Color c = srcImage.GetPixel(x, y);

                    ConvertPixel(c, hue, saturation, value);
                    //buffer.SetPixel(x, y, c);
                    buffer.SetPixel(x, y, ConvertPixel(c, hue, saturation, value));
                }
            }

            return buffer.GetImage();
        }

        /// <summary>
        /// 画像を変換して取得する。
        /// </summary>
        /// <param name="c"></param>
        /// <param name="hue"></param>
        /// <param name="saturation"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        private static Color ConvertPixel(Color c, int hue, int saturation, int value)
        {
            if (c.A == 0)
            {
                return c;
            }

            // Convert RGB to HSV
            ColorHSV srcHSV = ConvertRGBtoHSV(c);
            int h = (srcHSV.Hue + hue) % 360;
            int s = srcHSV.Saturation + saturation;
            int v = srcHSV.Value + value;

            // Convert HSV to RGB
            return ConvertHSVtoRGB(ColorHSV.FromHSV(h, s, v), c.A);
        }
        private static ColorHSV ConvertRGBtoHSV(Color c)
        {
            byte min = c.R;
            if (min > c.G)
            {
                min = c.G;
            }
            if (min > c.B)
            {
                min = c.B;
            }
            byte max = c.R;
            if (max < c.G)
            {
                max = c.G;
            }
            if (max < c.B)
            {
                max = c.B;
            }

            int h;
            if (max != min)
            {
                if (c.R == max)
                {
                    h = 60 * (c.G - c.B) / (max - min);
                }
                else if (c.G == max)
                {
                    h = 60 * (c.B - c.R) / (max - min) + 120;
                }
                else
                {
                    h = 60 * (c.R - c.G) / (max - min) + 240;
                }
            }
            else
            {
                h = 0;
            }

            int s;
            if (max > 0)
            {
                s = ((max - min) * 255) / max;
            }
            else
            {
                s = 0;
            }
            byte v = max;

            return ColorHSV.FromHSV(h, s, v);
        }
        private static Color ConvertHSVtoRGB(ColorHSV c, byte a)
        {
            int h = (c.Hue / 60);
            int P = (int)(c.Value * (255 - c.Saturation)) / 255;
            int Q = (int)(c.Value * (255 - c.Saturation * (c.Hue / 60.0f - h))) / 255;
            int T = (int)(c.Value * (255 - c.Saturation * (1.0f - c.Hue / 60.0f + h))) / 255;
            switch (h)
            {
                case 0:
                    return Color.FromArgb(a, c.Value, T, P);
                case 1:
                    return Color.FromArgb(a, Q, c.Value, P);
                case 2:
                    return Color.FromArgb(a, P, c.Value, T);
                case 3:
                    return Color.FromArgb(a, P, Q, c.Value);
                case 4:
                    return Color.FromArgb(a, T, P, c.Value);
                case 5:
                    return Color.FromArgb(a, c.Value, P, Q);
                default:
                    return Color.FromArgb(a, 0, 0, 0);
            }
        }
    }
}
