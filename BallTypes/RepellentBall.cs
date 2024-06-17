using BBG_BigBallGame.BallsType;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBG_BigBallGame.BallTypes
{
    public  class RepellentBall : Ball
    {
        static Random rnd = new Random();
        static int maxX = Form1.Instance.pictureBox1.Width - 40;
        static int maxY = Form1.Instance.pictureBox1.Height - 40;

        public RepellentBall() : base(Color.Red, 18,
                                            GenerateLocationPoint(), rnd.Next(3, 5), rnd.Next(2, 5))
        {

        }

        public static Point GenerateLocationPoint()
        {
            int x = rnd.Next(maxX);
            int y = rnd.Next(maxY); 
            bool locationIsChecked = false;
            while( ! locationIsChecked ) 
            {
                bool isNewLocation = true;
                for( int i = 0; i < Engine.balls.Count; i++ ) 
                {
                    if( new Point(x, y)  == Engine.balls[i].Location)
                    {
                        isNewLocation = false;
                        x = rnd.Next(maxX);
                        y = rnd.Next(maxY);
                    }
                }

                if(isNewLocation ) 
                    locationIsChecked = true;   
            }
            return new Point(x, y);
        }
        public static void Collision(int index)
        {
            Ball currentBall = Engine.balls[index];

            for (int i = 0; i < Engine.balls.Count; i++)
            {
                if (i == index) continue;

                Ball otherBall = Engine.balls[i];

                if (Distance(index, i) < currentBall.Radius + otherBall.Radius)
                {
                    if (otherBall is RegularBall regularBall)
                    {
                        
                        otherBall.SpeedX = -otherBall.SpeedX;
                        otherBall.SpeedY = -otherBall.SpeedY;

                        currentBall.Location = GenerateLocationPoint();


                    }
                    
                    if (otherBall is MonsterBall)
                    {
                        otherBall.Radius /= 2;
                        currentBall.SpeedX = -currentBall.SpeedX;
                        currentBall.SpeedY = -currentBall.SpeedY;
                        Engine.Draw();
                    }
                    

                }
            }
        }
    }
}
