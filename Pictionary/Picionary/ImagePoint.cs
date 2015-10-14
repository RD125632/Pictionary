using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Pictionary
{
    public class ImagePoint
    {
        public Point p1 { get; private set; }
        public Point p2 { get; private set; }
        public Color color;


        public ImagePoint(Point p1, Point p2, Color color)
        {
            this.p1 = p1;
            this.p2 = p2;
            this.color = color;
        }

    }
}
