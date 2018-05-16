using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Drawing2D;

namespace SmartCurve
{

	public class ImageCurve
	{
		List<Point> keyPt = new List<Point>();
		byte[] level = new byte[256];

		public ImageCurve()
		{
		}
		public byte[] GetImageLevel(Point[] pts )
        {
//            Point[] pts = new Point[keyPt.Count];
//            for (int i = 0; i < pts.Length; i++)
//            {
//                pts[i].X = keyPt[i].X * 255 / this.Width;
//                pts[i].Y = 255 - keyPt[i].Y * 255 / this.Height;
//            }

            for (int i = 0; i < pts[0].X; i++)
                level[i] = (byte)pts[0].Y;
            for (int i = pts[pts.Length - 1].X; i < 256; i++)
                level[i] = (byte)pts[pts.Length - 1].Y;

            Spline sp = new Spline();
            sp.DataPoint = pts;
            sp.Precision = 1.0;
            Point[] spt=sp.SplinePoint;
            for (int i = 0; i < spt.Length; i++)
            {
                int n = spt[i].Y;
                if (n < 0) n = 0;
                if (n > 255) n = 255;
                level[pts[0].X + i] = (byte)n;
            }
            return level;
        }

		
	}
}
