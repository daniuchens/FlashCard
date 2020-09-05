using System;
using System.Drawing;
using System.IO;
using System.Linq;

namespace FlashCard
{
    public static class ImageHelper
    {
        public static bool IsImageFile(string extension)
        {
            string[] imageExts = { "BMP", "GIF", "EXIF", "JPG", "PNG", "TIFF" };

            string imageExt = extension.Replace(".", "").ToUpper();

            return imageExts.Contains(imageExt);
        }

        /// <summary>
        /// 將文字轉換成 Bitmap
        /// </summary>
        /// <param name="text">欲轉換的文字</param>
        /// <param name="font">圖片文字屬性</param>
        /// <param name="rect">用於輸出的矩形，文字在矩形中顯示，若為 Rectangle.Empty 則自動計算</param>
        /// <param name="fontColor">字體顏色</param>
        /// <param name="backColor">背景顏色</param>
        /// <returns></returns>
        public static Bitmap TextToBitmap(string text, Font font, Rectangle rect, Color fontColor, Color backColor)
        {
            Graphics g;
            Bitmap bmp;
            StringFormat format = new StringFormat(StringFormatFlags.NoClip);
            if (rect == Rectangle.Empty)
            {
                bmp = new Bitmap(1, 1);
                g = Graphics.FromImage(bmp);
                // 計算繪製文字所需的區域大小（根據寬度計算長度），重新建立矩形區域以繪圖
                SizeF sizef = g.MeasureString(text, font, PointF.Empty, format);

                int width = (int)(sizef.Width + 1);
                int height = (int)(sizef.Height + 1);
                rect = new Rectangle(0, 0, width, height);
                bmp.Dispose();

                bmp = new Bitmap(width, height);
            }
            else
            {
                bmp = new Bitmap(rect.Width, rect.Height);
            }
            g = Graphics.FromImage(bmp);

            // 使用 ClearType 字體功能
            g.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            g.FillRectangle(new SolidBrush(backColor), rect);
            g.DrawString(text, font, new SolidBrush(fontColor), rect, format);
            return bmp;
        }

        public static Image GetExtImage(WordPath item)
        {
            if (item.PathMode == DisplayMode.ImageFolder)
            {
                return ImageResource.ImageFolder;
            }

            string fileExt = Path.GetExtension(item.Path).Replace(".", "").ToUpper();

            switch(fileExt)
            {
                case "TXT":
                    return ImageResource.TXT;

                case "CSV":
                    return ImageResource.CSV;
            }

            return null;
        }
    }
}