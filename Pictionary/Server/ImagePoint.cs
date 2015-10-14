using System.Drawing;


namespace Server
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
