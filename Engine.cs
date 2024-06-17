using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBG_BigBallGame.BallsType;
using BBG_BigBallGame.BallTypes;

namespace BBG_BigBallGame
{
    public static class Engine
    {   
        public static Bitmap bitmap;
        public static int time;
        public static List<Ball> list;

        public static void Initialize()
        {  
            list = new List<Ball>();

            for(int i = 0; i < 12; i++) 
               list.Add(new RegularBall());
            
            list.Add(new MonsterBall());
            
            list.Add(new RepellentBall());
            list.Add(new RepellentBall());
        }

        public static void Draw()
        {
            if (bitmap != null)
                bitmap.Dispose();

            bitmap = new Bitmap(Form1.Instance.Width, Form1.Instance.Height);

            using (Graphics graphics = Graphics.FromImage(bitmap))
            {   
                foreach (Ball ball in list)
                    graphics.FillEllipse(new SolidBrush(ball.Color), ball.Location.X, ball.Location.Y, 2 * ball.Radius, 2 * ball.Radius);
            }
            Form1.Instance.pictureBox1.Image = bitmap;
        }
    }
}
