using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;

namespace ColorModifyTest
{
    public class ImageBuffer
    {
        public static ImageBuffer CreateFrom(Image image)
        {
            Bitmap bmp = new Bitmap(image);
            int width = bmp.Width;
            int height = bmp.Height;
            BitmapData bmpData = bmp.LockBits(new System.Drawing.Rectangle(0, 0, width, height), ImageLockMode.WriteOnly, PixelFormat.Format32bppArgb);

            byte[] buffer = new byte[bmpData.Stride * height];
            System.Runtime.InteropServices.Marshal.Copy(bmpData.Scan0, buffer, 0, buffer.Length);


            ImageBuffer ret = new ImageBuffer(buffer, width, height, bmpData.Stride);
            bmp.UnlockBits(bmpData);
            bmp.Dispose();


            return ret;
        }

        /// <summary>
        /// 空のイメージバッファを作成する
        /// </summary>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <returns></returns>
        public static ImageBuffer Create(int width, int height)
        {
            int stride = width * 4; /* BGRA, PixelFormat.Format32bppArgb */
            byte[] buffer = new byte[stride * height];
            ImageBuffer ret = new ImageBuffer(buffer, width, height, stride);
            return ret;
        }


        private byte[] buffer;
        int width;
        int height;
        int lineBytes;

        /// <summary>
        /// コンストラクタ
        /// </summary>
        /// <param name="buffer"></param>
        /// <param name="width"></param>
        /// <param name="height"></param>
        /// <param name="lineBytes"></param>
        private ImageBuffer(byte[] buffer, int width, int height, int lineBytes)
        {
            this.buffer = buffer;
            this.width = width;
            this.height = height;
            this.lineBytes = lineBytes;
        }

        /// <summary>
        /// 幅
        /// </summary>
        public int Width
        {
            get { return this.width; }
        }
        /// <summary>
        /// 高さ
        /// </summary>
        public int Height
        {
            get { return height; }
        }
        /// <summary>
        /// 指定位置のピクセルを取得する。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <returns></returns>
        public Color GetPixel(int x, int y)
        {
            if ((x < 0) || (x >= width) || (y < 0) || (y >= height))
            {
                return Color.FromArgb(0, 0, 0, 0);
            }

            int pos = x * 4 + lineBytes * y;
            int b = buffer[pos + 0];
            int g = buffer[pos + 1];
            int r = buffer[pos + 2];
            int a = buffer[pos + 3];


            return Color.FromArgb(a, r, g, b);
        }

        /// <summary>
        /// 指定位置のピクセルを設定する。
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        /// <param name="c"></param>
        public void SetPixel(int x, int y, Color c)
        {
            if ((x < 0) || (x >= width) || (y < 0) || (y >= height))
            {
                return;
            }

            int pos = x * 4 + lineBytes * y;
            buffer[pos + 0] = c.B;
            buffer[pos + 1] = c.G;
            buffer[pos + 2] = c.R;
            buffer[pos + 3] = c.A;
        }

        public Image GetImage()
        {
            Bitmap bitmap = new Bitmap(width, height, PixelFormat.Format32bppArgb);

            BitmapData bmpData = bitmap.LockBits(new System.Drawing.Rectangle(0, 0, width, height), 
                ImageLockMode.ReadWrite, PixelFormat.Format32bppArgb);

            System.Runtime.InteropServices.Marshal.Copy(buffer, 0, bmpData.Scan0, buffer.Length);

            bitmap.UnlockBits(bmpData);

            return bitmap;
        }
         
    }
}
