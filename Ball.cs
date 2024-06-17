using System;
using System.Drawing;
using System.Reflection;
using BBG_BigBallGame.BallsType;

namespace BBG_BigBallGame
{
    public abstract class Ball
    {
        public int Radius { get; set; }
        public Point Location { get; set; }
        public Point StartLocation { get; set; }    
        public Color Color { get; set; }
        public int SpeedX { get; set; }
        public int SpeedY { get; set; }


        public Ball(Color color, int radius, Point location, int speedX, int speedY)
        {
            Color = color;
            Radius = radius;
            Location = location;
            StartLocation = location;
            SpeedX = speedX;
            SpeedY = speedY;
        }
       
        public void Move()
        {
            int maxY = Form1.Instance.pictureBox1.Height - 2 * Radius - 5 ;
            int maxX = Form1.Instance.pictureBox1.Width - 2 * Radius - 5 ;

            if (Location.X <= 0)
            {
                if(SpeedX < 0)
                   SpeedX = -SpeedX;
            }
            if (Location.X >= maxX)
            {
                if (SpeedX > 0)
                   SpeedX = -SpeedX;
            }
            if (Location.Y <= 0)
            {
                if(SpeedY < 0)
                   SpeedY = -SpeedY;
            }
            if(Location.Y >= maxY)
            {
                if(SpeedY > 0)
                    SpeedY = -SpeedY;
            }
            
            Location = new Point(Location.X + SpeedX, Location.Y + SpeedY);

        }

        public static double Distance(int index1, int index2)
        {
            Ball currentBall = Engine.list[index1];
            int currentBallCenterX = currentBall.Location.X + currentBall.Radius;
            int currentBallCenterY = currentBall.Location.Y + currentBall.Radius;

            Ball otherBall = Engine.list[index2];
            int otherBallCenterX = otherBall.Location.X + otherBall.Radius;
            int otherBallCenterY = otherBall.Location.Y + otherBall.Radius;

            double dx = currentBallCenterX - otherBallCenterX;
            double dy = currentBallCenterY - otherBallCenterY;
            return Math.Sqrt(dx * dx + dy * dy);
        }


       


    }
}
