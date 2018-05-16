
using System;

using System.Drawing;

namespace SmartCurve
{
	class Program
	{
		public static void Main(string[] args)
		{
		
			ApplyCurveFilter(@"C:\Users\Administrator\Desktop\新建文件夹\1.jpg");
		}
		
		static void ApplyCurveFilter(string fileName)
		{
			Bitmap bmp= (Bitmap)Bitmap.FromFile(fileName);
			var srcID = new ImageData();
			srcID.FromBitmap(bmp);
			var nch=srcID.Clone();
			
			var imageCurve=new ImageCurve();
			var levelValue=imageCurve.GetImageLevel(new Point[]
			                                        {
			                                        	new Point(0,0),new Point(128,128),new Point(192,132),new Point(256,256)});
			for (int w = 0; w < bmp.Width; w++) {
				for (int h = 0; h < bmp.Height; h++) {
//					if (red)
//						nch.R[w, h] = levelValue[srcID.R[w, h]];
//					if (green)
//						nch.G[w, h] = levelValue[srcID.G[w, h]];
//					if (blue)
						nch.B[w, h] = levelValue[srcID.B[w, h]];
				}
			}
			nch.ToBitmap().Save(@"C:\Users\Administrator\Desktop\新建文件夹\2.jpg",System.Drawing.Imaging.ImageFormat.Jpeg);
		}
	}
}