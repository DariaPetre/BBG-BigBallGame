using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace BBG_BigBallGame.BallsType
{
    public  class RegularBall : Ball
    {   
        static Random rnd = new Random();
        static int maxX = Form1.Instance.pictureBox1.Width - 40;
        static int maxY = Form1.Instance.pictureBox1.Height - 40;

        public RegularBall() : base(Color.FromArgb(255, rnd.Next(10, 240), rnd.Next(10, 240), rnd.Next(10, 240)), rnd.Next(10, 21), 
                                            new Point(rnd.Next(maxX - 1), rnd.Next(0,maxY - 1)), rnd.Next(1,5), rnd.Next(1, 5))
        {

        }

        public static void Collision(int index)
        {
            Ball currentBall = Engine.list[index];
           
            for (int i = 0; i < Engine.list.Count; i++)
            {
                if (i == index) continue;

                Ball otherBall = Engine.list[i];
      
                if (Distance(index, i) < currentBall.Radius + otherBall.Radius)
                {
                        if (otherBall is RegularBall)
                        {
                           if(currentBall.Radius > otherBall.Radius) 
                           {
                             currentBall.Radius += otherBall.Radius;
                             Color averageColor = AverageColor(currentBall.Color, otherBall.Color);
                             currentBall.Color = averageColor;
                             Engine.list.RemoveAt(i);
                            }
                        
                        }
                        
                        if (otherBall is MonsterBall)
                        {
                            otherBall.Radius += currentBall.Radius;
                            Engine.Draw();
                            Engine.list.RemoveAt(index);
                        }


                }
            }
        }

        public static Color AverageColor(Color color1, Color color2)
        {
            int R = (color1.R + color2.R) / 2;
            int G = (color1.G + color2.G) / 2;
            int B = (color1.B + color2.B) / 2;

            return Color.FromArgb(R, G, B);

        }
    }   
}
