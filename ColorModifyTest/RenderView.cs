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
            private float saturation; // 0.0-1.0
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
            public float Saturation
            {
                get { return this.saturation; }
                set
                {
                    if (value < 0.0f)
                    {
                        this.saturation = 0.0f;
                    }
                    else if (value > 1.0f)
                    {
                        this.saturation = 1.0f;
                    }
                    else
                    {
                        this.saturation = value;
                    }
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
            public static ColorHSV FromHSV(int hue, float saturation, int value)
            {
                ColorHSV ret = new ColorHSV();
                ret.Hue = hue;
                ret.Saturation = saturation;
                ret.Value = (byte)((value > 255) ? 255 : ((value < 0) ? 0 : value));
                return ret;
            }
        }

        private Image image;

        public RenderView()
        {
            InitializeComponent();
        }

        public Image Image
        {
            get { return this.image; }
            set { this.image = value; }
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

        protected override void OnPaint(PaintEventArgs evt)
        {
            Graphics g = evt.Graphics;

            if (image != null)
            {
                try
                {
                    Image drawImage = ConvertImage(image, Hue, Saturation, Value);
                    g.DrawImageUnscaled(drawImage, 0, 0);
                    drawImage.Dispose();
                }
                catch (Exception e)
                {
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

        private Image ConvertImage(Image srcImage, int hue, int saturation, int value)
        {
            Bitmap src = new Bitmap(srcImage);
            Bitmap dst = new Bitmap(src.Width, src.Height, PixelFormat.Format32bppArgb);

            float S = saturation / 255.0f;
            for (int y = 0; y < src.Height; y++)
            {
                for (int x = 0; x < src.Width; x++)
                {
                    Color c = src.GetPixel(x, y);

                    dst.SetPixel(x, y, ConvertPixel(c, hue, S, value));
                }
            }

            return dst;
        }
        private static Color ConvertPixel(Color c, int hue, float saturation, int value)
        {
            if (c.A == 0)
            {
                return c;
            }

            // Convert RGB to HSV
            ColorHSV srcHSV = ConvertRGBtoHSV(c);
            int h = (srcHSV.Hue + hue) % 360;
            float s = srcHSV.Saturation + saturation;
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

            float s;
            if (max > 0)
            {
                s = (max / 255.0f - min / 255.0f) / (float)(max / 255.0f);
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
            int P = (int)(c.Value * (1.0f - c.Saturation));
            int Q = (int)(c.Value * (1.0f - c.Saturation * (c.Hue / 60.0f - h)));
            int T = (int)(c.Value * (1.0f - c.Saturation * (1.0f - c.Hue / 60.0f + h)));
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
