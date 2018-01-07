using System;
using System.Drawing;
using System.Windows.Forms;

namespace WindowsFormsApplication27 {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        const int MAX_DOTS = 100;
        Dot[] dots = new Dot[MAX_DOTS];
        Graphics g;
        Random r = new Random();

        bool clicked = false;
        int clickX, clickY;

        void roundAngle(double y, double x, ref double aci) {
            if (x < 0 && y > 0) aci = aci + 180;
            if (x < 0 && y < 0) aci = aci + 180;
        }

        private void Form1_Load(object sender, EventArgs e) {
            //Box dots
            dots[0] = new Dot(30, 30, 30);
            dots[1] = new Dot(-30, 30, 30);
            dots[2] = new Dot(-30, -30, 30);
            dots[3] = new Dot(30, -30, 30);
            dots[4] = new Dot(30, 30, -30);
            dots[5] = new Dot(-30, 30, -30);
            dots[6] = new Dot(-30, -30, -30);
            dots[7] = new Dot(30, -30, -30);
            dots[8] = new Dot(30, 50, -50);
            dots[9] = new Dot(-30, 50, -50);
            dots[10] = new Dot(-30, -30, -50);
            dots[11] = new Dot(30, -30, -50);
            dots[12] = new Dot(30, 50, -30);
            dots[13] = new Dot(-30, 50, -30);

            //Box dot line connections 
            dots[0].next1 = dots[1];
            dots[1].next1 = dots[2];
            dots[2].next1= dots[3];
            dots[3].next1 = dots[0];

            dots[4].next1 = dots[5];
            dots[5].next1 = dots[6];
            dots[6].next1 = dots[7];
            dots[7].next1 = dots[4];

            dots[0].next2 = dots[4];
            dots[1].next2 = dots[5];
            dots[2].next2 = dots[6];
            dots[3].next2 = dots[7];
            

            for (int i = 14; i < MAX_DOTS; i++) {
                int newX = r.Next(0, 200) - 100;
                int newY = r.Next(0, 200) - 100;
                int newZ = r.Next(0, 200) - 100;
                dots[i] = new Dot(newX, newY, newZ);
                //if (i > 0) dots[i].next1 = dots[i - 1];//Draw line to next dot
            }

            g = CreateGraphics();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e) {
            clicked = true;
            clickX = e.X;
            clickY = e.Y;
        }

        private void Form1_MouseUp(object sender, MouseEventArgs e) {
            clicked = false;
        }
        private void Form1_MouseMove(object sender, MouseEventArgs e) {
            if (clicked) {
                for (int i = 0; i < MAX_DOTS; i++) {
                    dots[i].calcRX();
                    dots[i].calcRY();
                    dots[i].calcRZ();
                }
                for (int i = 0; i < MAX_DOTS; i++) {
                    dots[i].rotateHorizontal(-5*Math.Sign(e.X - clickX));
                    dots[i].calcRX();
                    dots[i].calcRY();
                    dots[i].calcRZ();
                    dots[i].rotateVertical(5*Math.Sign(e.Y - clickY));
                }

                for (int i = 0; i < MAX_DOTS; i++)
                    dots[i].erase(g, this);

                for (int i = 0; i < MAX_DOTS; i++) {
                    dots[i].oldX = dots[i].x;
                    dots[i].oldY = dots[i].y;
                    dots[i].oldZ = dots[i].z;
                    dots[i].draw(g, this);
                }
            }
        }

        private void Form1_Shown(object sender, EventArgs e) {
            for (int i = 0; i < MAX_DOTS; i++) {
                dots[i].oldX = dots[i].x;
                dots[i].oldY = dots[i].y;
                dots[i].oldZ = dots[i].z;
                dots[i].draw(g, this);
            }
        }
    }
}
