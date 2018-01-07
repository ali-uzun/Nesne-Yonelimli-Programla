using System;
using System.Drawing;
using System.Windows.Forms;
namespace WindowsFormsApplication27
{
    public class Dot
    {
        public double x, y, z;
        public double oldX, oldY, oldZ;
        public double angleX, angleY, angleZ;
        public double rX, rY, rZ;
        public Dot next1, next2;//To draw line
        public static int originX = 250;
        public static int originY = 250;

       public Dot(int x, int y, int z)
        {
            this.x = x;
            this.y = y;
            this.z = z;

            calcAngleX();
            calcAngleY();
            calcAngleZ();
        }

       public void calcAngleX()
       {
           angleX = Math.Atan(y / x) * 180 / Math.PI;
           if (x < 0 && y > 0) angleX = angleX + 180;
           if (x < 0 && y < 0) angleX = angleX + 180;
       }
       public void calcAngleY()
       {
           angleY = Math.Atan(z / x) * 180 / Math.PI;
           if (x < 0 && z > 0) angleY = angleY + 180;
           if (x < 0 && z < 0) angleY = angleY + 180;
       }
       public void calcAngleZ()
       {
           angleZ = Math.Atan(y / z) * 180 / Math.PI;
           if (z < 0 && y > 0) angleZ = angleZ + 180;
           if (z < 0 && y < 0) angleZ = angleZ + 180;
       }

       public void calcRX()
       {
           rX = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(y, 2));
       }
       public void calcRY()
       {
           rY = Math.Sqrt(Math.Pow(x, 2) + Math.Pow(z, 2));
       }
       public void calcRZ()
       {
           rZ = Math.Sqrt(Math.Pow(z, 2) + Math.Pow(y, 2));
       }

       public void rotateHorizontal(int angle)
       {
           angleY += angle;
           x = rY * Math.Cos(angleY * Math.PI / 180);
           z = rY * Math.Sin(angleY * Math.PI / 180);

           calcAngleX();
           calcAngleZ();
       }
       public void rotateVertical(int angle)
       {
           angleZ += angle;
           z = rZ * Math.Cos(angleZ * Math.PI / 180);
           y = rZ * Math.Sin(angleZ * Math.PI / 180);

           calcAngleX();
           calcAngleY();
       }

       public void erase(Graphics g,Form f)
       {
           g.DrawEllipse(new Pen(f.BackColor, 1), Convert.ToInt16(originX + oldX), Convert.ToInt16(originY + oldY), 1, 1);
           if (next1 != null)
               g.DrawLine(new Pen(f.BackColor, 1), Convert.ToInt16(originX + oldX), Convert.ToInt16(originY + oldY), Convert.ToInt16(originX + next1.oldX), Convert.ToInt16(originY + next1.oldY));
           if (next2 != null)
               g.DrawLine(new Pen(f.BackColor, 1), Convert.ToInt16(originX + oldX), Convert.ToInt16(originY + oldY), Convert.ToInt16(originX + next2.oldX), Convert.ToInt16(originY + next2.oldY));
       }
       public void draw(Graphics g, Form f)
       {
           g.DrawEllipse(new Pen(Color.Black, 1), Convert.ToInt16(originX + x), Convert.ToInt16(originY + y), 1, 1);
           if (next1 != null)
               g.DrawLine(new Pen(Color.Black, 1), Convert.ToInt16(originX + x), Convert.ToInt16(originY + y), Convert.ToInt16(originX + next1.x), Convert.ToInt16(originY + next1.y));
           if (next2 != null)
               g.DrawLine(new Pen(Color.Black, 1), Convert.ToInt16(originX + x), Convert.ToInt16(originY + y), Convert.ToInt16(originX + next2.x), Convert.ToInt16(originY + next2.y));
       }
    }
}
