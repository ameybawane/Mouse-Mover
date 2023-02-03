using System;
using System.Drawing;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;

namespace MouseMover
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Timer timer = new Timer();
            timer.Interval = 12000; // 120 seconds
            timer.Tick += new EventHandler(timer1_Tick);
            timer.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            //Cursor.Position = new Point(Cursor.Position.X + 10, Cursor.Position.Y + 10);
            int x = Cursor.Position.X;
            int y = Cursor.Position.Y;
            int moveX = 10;
            int moveY = 10;
            Rectangle screen = Screen.PrimaryScreen.Bounds;

            if (x + moveX >= screen.Right || x + moveX <= screen.Left)
            {
                moveX = -moveX;
            }

            if (y + moveY >= screen.Bottom || y + moveY <= screen.Top)
            {
                moveY = -moveY;
            }

            Cursor.Position = new Point(x + moveX, y + moveY);
        }
    }
}