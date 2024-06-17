using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBG_BigBallGame.BallsType
{
    public class MonsterBall : Ball
    {   
        static Random random = new Random();
        static int maxX = Form1.Instance.pictureBox1.Width - 80;
        static int maxY = Form1.Instance.pictureBox1.Height - 80;
        public MonsterBall() : base(Color.Black, 40, new Point(random.Next(0, maxX), random.Next(0, maxY)), 0, 0) 
        { }
    }
}
