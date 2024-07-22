using System.ComponentModel;
using System.IO;
using System.Windows;
using System.Windows.Media.Imaging;
using Playnite.Native;

namespace System.Drawing
{
    public static class IconExtension
    {
        public static byte[] ToByteArray(this Icon icon, Imaging.ImageFormat format)
        {
            using (var stream = new MemoryStream())
            {
                using (var bitmap = icon.ToBitmap())
                {
                    bitmap.Save(stream, format);
                    return stream.ToArray();
                }
            }
        }

        public static BitmapSource ToImageSource(this Icon icon)
        {
            using (Bitmap bitmap = icon.ToBitmap())
            {
                IntPtr hBitmap = bitmap.GetHbitmap();
                BitmapSource wpfBitmap = Windows.Interop.Imaging.CreateBitmapSourceFromHBitmap(
                    hBitmap,
                    IntPtr.Zero,
                    Int32Rect.Empty,
                    BitmapSizeOptions.FromEmptyOptions());

                if (!Gdi32.DeleteObject(hBitmap))
                {
                    throw new Win32Exception();
                }

                return wpfBitmap;
            }
        }
    }
}
